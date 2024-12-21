using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BankingApp
{
    public class OperationMethod : IWithdraw, IPayment, ITransfer
    {
        public Account Account { get; set; }

        public OperationMethod(string user, string password)
        {
            Account = new Account(user, password);
        }

        public OperationMethod()
        {

        }


        public bool withdraw(string user, decimal amount)
        {
            decimal balance;

            //retrieving current balance
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                string query = string.Format("select balance from Account a inner join Customer_Account ca on ca.idAccount = a.id " +
                                                                            "inner join Customer c on c.id = ca.idCustomer " +
                                                          "where c.nick = '{0}'", user);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                balance = Convert.ToDecimal(command.ExecuteScalar());
            
                //decriesing balance
                query = string.Format("update Account set balance = '{0}' where numberAccount = '{1}'", balance - amount, Account.NumberAccount);
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }

            if(addToTransaction("withdraw",  amount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool payment(string user, decimal amount)
        {
            decimal balance;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                //retrieve current balance
                string query = string.Format("select balance from Account a inner join Customer_Account ca on ca.idAccount = a.id " +
                                                              "inner join Customer c on c.id = ca.idCustomer " +
                                                  "where c.nick = '{0}'", user);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                balance = Convert.ToDecimal(command.ExecuteScalar());

                //incriesing balance
                query = string.Format("update Account set balance = '{0}' where numberAccount = '{1}'", balance + amount, Account.NumberAccount);
                command.CommandText = query;
                command.ExecuteNonQuery();
            }

            if(addToTransaction("payment", amount))
            {
                return true;
            } 
            else
            {
                return false;
            }          
            
        }

        public void transfer(string from, string into, decimal amount, string title)
        {
            decimal balanceFrom;
            decimal balanceInto;
            int idAccountFrom;
            int idAccountInto;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                connection.Open();
                SQLiteTransaction transaction = connection.BeginTransaction();

                try
                {
                    //retrieving idAccountFrom
                    string query = string.Format("select id from Account where numberAccount = '{0}'", from);
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    connection.Open();
                    idAccountFrom = Convert.ToInt32(command.ExecuteScalar());

                    //retrieving idAccountInto
                    query = string.Format("select id from Account where numberAccount = '{0}'", into);
                    command.CommandText = query;
                    idAccountInto = Convert.ToInt32(command.ExecuteScalar());

                    //retrieving AccountFrom balance
                    query = string.Format("select balance from Account where numberAccount = '{0}'", from);
                    command.CommandText = query;
                    balanceFrom = Convert.ToDecimal(command.ExecuteScalar());

                    //retrieving AccountInto balance
                    query = string.Format("select balance from Account where numberAccount = '{0}'", into);
                    command.CommandText = query;
                    balanceInto = Convert.ToDecimal(command.ExecuteScalar());

                    //add into Transactions
                    query = string.Format("insert into Transactions(dateTransaction, name, amount, title, idAccountFrom, " +
                                                   "idAccountInto) values('{0}', '{1}', '{2}', '{3}', {4}, {5})", DateTime.Now,
                                                            "transfer", amount, title, idAccountFrom, idAccountInto);
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    //updating accountFrom balance
                    query = string.Format("update Account set balance = '{0}' where numberAccount = '{1}'", balanceFrom - amount, from);
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    //updating accountigInto balance
                    query = string.Format("update Account set balance = '{0}' where numberAccount = '{1}'", balanceInto + amount, into);
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("Transfer failed");                  
                }

            }
        }

        private bool addToTransaction(string name, decimal amount)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                string query = string.Format("insert into Transactions(dateTransaction, name, amount, idAccountFrom) values('{0}', '{1}', '{2}', '{3}')", 
                                                      DateTime.Now.ToString(), name, amount, Account.Id);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
        }
    }
}
