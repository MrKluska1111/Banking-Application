using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BankingApp
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public Address(string city, string street, int house)
        {
            City = city;
            Street = street;
            HouseNumber = house;
        }

        public bool createAdress()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = BankingDatabase.sqlite;"))
            {
                //create adress
                string query = string.Format("insert into Adress(city, street, houseNumber) values('{0}', '{1}', {2})", City, Street, HouseNumber);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
        }

    }
}
