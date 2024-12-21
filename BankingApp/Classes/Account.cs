using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BankingApp
{
    public class Account 
    {
        public int Id { get; set; }
        public string NumberAccount { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public Account(string number, string password, string type)
        {
            NumberAccount = number;
            Password = password;
            Type = type;
            Balance = 0.00m;
        }

        public Account(string nick, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                string query = string.Format("select a.id, a.type, a.numberAccount, a.balance from Account a " +
                                                                          "inner join Customer_Account ca on ca.idAccount = a.id " +
                                                                           "inner join Customer c on c.id = ca.idCustomer " +
                                                      "where c.nick = '{0}' and a.password = '{1}'", nick, password);

                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    this.Id = Convert.ToInt32(reader["id"]);
                    this.Type = reader["type"].ToString();
                    this.NumberAccount = reader["numberAccount"].ToString();
                    this.Balance = Convert.ToDecimal(reader["balance"]);
                    this.Password = password;
                }
            }
        }

        public Account()
        {
            
        }

        //ta metoda nie jest związana bezpośrednio z żadnych konkretnym kontem więc jest statyczna
        public static string getPassword(string userNick)
        {
            object result;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=BankingDatabase.sqlite;"))
            {
                string query = string.Format("select password from Account a inner join Customer_Account ca on a.id = ca.idAccount " +
                                                                      "inner join Customer c on c.id = ca.idCustomer " +
                                                  "where c.nick = trim('{0}')", userNick);

                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                result = command.ExecuteScalar();
            }

            if(result != null)
            {
                return result.ToString();
            }
            else
            {
                return "";
            }
            
        }

        //ta właściwość nie jest związana bezpośrednio z żadnych konkretnym kontem więc jest statyczna
        public static List<string> AccountTypes
        {
            get
            {
                List<string> result = new List<string>();

                using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
                {
                    string query = "select type from Account_Types";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader["type"].ToString());
                    }
                }

                return result;
            }
        }

        public bool createAccount()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                string query = string.Format("insert into Account(numberAccount, balance, password, type) values('{0}', '{1}', '{2}', '{3}')",
                                                   NumberAccount, Balance, Password, Type);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool assignCustomer(string nick, string number)
        {
            object customerId;
            object adressId;

            //assign customerId, adressId in Customer_Account table
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                string query = string.Format("select id from Customer c where c.nick = '{0}'", nick);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                customerId = command.ExecuteScalar();

                query = string.Format("select id from Account a where a.numberAccount = '{0}'", number);
                command.CommandText = query;
                adressId = command.ExecuteScalar();

                query = string.Format("insert into Customer_Account values({0}, {1})", customerId, adressId);
                command.CommandText = query;
                command.ExecuteNonQuery();

                return true;
            }
        }

    }
}
