using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BankingApp
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public Address Address { get; set; }

        public Customer(string name, string surname, string nick, string birth, string phone)
        {
            Name = name;
            Surname = surname;
            Nick = nick;
            BirthDate = birth;
            Phone = phone;
        }

        public Customer()
        {

        }

        public bool createCustomer()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                //check whether given nick exists
                string query = string.Format("select * from Customer where nick = '{0}'", Nick);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    MessageBox.Show("Given nick is reserved. Try another.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                reader.Close();

                //insert Customer
                query = string.Format("insert into Customer(name, surname, nick, birthDate, phone, gender) values('{0}', '{1}', " +
                             "'{2}', '{3}', '{4}', '{5}')", Name, Surname, Nick, BirthDate, Phone, Gender);
                command.CommandText = query;
                command.ExecuteNonQuery();

                return true;
            }
        }

        public bool assignAdress(string nick, Address a)
        {
            object adressId;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                //retrieve adressId for given Customer
                string query = string.Format("select id from Adress a where a.city = '{0}' and a.street = '{1}' and a.houseNumber = {2}", 
                                                  a.City, a.Street, a.HouseNumber);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                adressId = command.ExecuteScalar();

                //assign Adress
                query = string.Format("update Customer set idAdress = {0} where nick = '{1}'", adressId, nick);
                command.CommandText = query;
                command.ExecuteNonQuery();

                return true;
            }
        }

        //ta metoda nie jest związana z żadnym konkretnym kontem więc jest statyczna
        public static List<string> getCustomerData(string accountNumber)
        {
            List<string> result = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                string query = string.Format("select c.name, c.surname, a.city  || ', ' || a.street || ' ' || a.houseNumber " +
                                                           "from Customer c inner join Adress a on c.idAdress = a.id "  +
                                                                        "inner join Customer_Account ca on ca.idCustomer = c.id " +
                                                                        "inner join Account ac on ac.id = ca.idAccount " + 
                                                           "where trim(ac.numberAccount) = '{0}'", accountNumber);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result.Add(reader[i].ToString());
                    }
                }

                return result;
            }
        }
    }
}
