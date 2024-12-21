using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class OperationsData : ITransactions
    {
        public Account Account { get; set; }

        //ta właściwość jest statyczna ponieważ nie jest związana bezpośrednio z żadnym kontem czy operacją
        public static List<string> WithdrawAmount
        {
            get
            {
                List<string> result = new List<string>();

                using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
                {
                    string query = "select amount from Withdraw_Amount";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }

                    return result;
                }
            }
        }

        //ta właściwość jest statyczna ponieważ nie jest związana bezpośrednio z żadnym kontem czy operacją
        public static List<string> AccountOperations
        {
            get
            {
                List<string> result = new List<string>();

                using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
                {
                    string query = "select name from Account_Operations where id < 3";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }

                    return result;
                }
            }
        }

        //ta właściwość jest związana z konkretnym kontem więc nie jest statyczna
        public decimal Income
        {
            get
            {
                object result;

                using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
                {
                    string query = string.Format("select sum(amount) from Transactions where name = 'payment' and idAccountFrom = {0}", Account.Id);

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    result = command.ExecuteScalar();                   

                    if(result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public decimal Expenses
        {
            get
            {
                object result;

                using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
                {
                    string query = string.Format("select sum(amount) from Transactions where (name = 'withdraw' or name = 'transfer') " +
                                                                " and idAccountFrom = {0}", Account.Id);

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        //constructors
        public OperationsData(string user, string password)
        {
            Account = new Account(user, password);
        }

        public OperationsData()
        {

        }

        public object Transactions
        {
            get
            {
                DataTable table = new DataTable();
                table.Columns.Add("Name");
                table.Columns.Add("Amount");
                table.Columns.Add("Title");
                table.Columns.Add("Date");
                table.Columns.Add("Into");

                using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
                {
                    string query = string.Format("select t.name, t.amount, t.title, t.dateTransaction, a.numberAccount from Transactions t " +
                                                                                    "left join Account a on a.id = t.idAccountInto " +
                                                             "where t.idAccountFrom = {0} order by t.dateTransaction desc limit 5", Account.Id);
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    //musisz odczytać reader żeby ci zapisało dane
                    while (reader.Read())
                    {
                        DataRow row = table.NewRow();
                        row["Name"] = reader["name"];
                        row["Amount"] = reader["amount"];
                        row["Title"] = reader["title"];
                        row["Date"] = reader["dateTransaction"];
                        row["Into"] = reader["numberAccount"];

                        table.Rows.Add(row);
                    }

                    return table;
                }
        
        

            }
        }
    }
}
