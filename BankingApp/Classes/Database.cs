using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BankingApp
{
    public static class Database
    {
        public static void CreateDatabase()
        {
            if (!File.Exists(Application.StartupPath + "BankingDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("BankingDatabase.sqlite");

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=BankingDatabase.sqlite;"))
                {
                    //create table Customer
                    SQLiteCommand command = new SQLiteCommand("create table Customer(id integer primary key autoincrement not null, name varchar(20)," +
                                  "surname varchar(20), nick varchar(20), birthDate Date, phone varchar(20), idAdress integer, gender char)", connection);
                    connection.Open();
                    command.ExecuteNonQuery();

                    command.CommandText = "insert into Customer(name, surname, nick, birthDate, phone, idAdress, gender) values('Kamil', 'Kluska', 'kamil100'," +
                                              "'1992-10-15', '664316177', 2, 'm')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Customer(name, surname, nick, birthDate, phone, idAdress, gender) values('Darek', 'Kwiatkowski', " +
                                              "'Darek50', '1990-01-20', '740350189', 3, 'm')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Customer(name, surname, nick, birthDate, phone, idAdress, gender) values('Piotr', 'Michalowski', " +
                                              "'Budzik','1991-05-05', '666777888', 1, 'm')";
                    command.ExecuteNonQuery();

                    //create table Adress
                    command.CommandText = "create table Adress(id integer primary key autoincrement not null, city varchar(20), street varchar(20), " +
                                            "houseNumber integer)";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Adress(city, street, houseNumber) values('Brzeg', 'Truskawkowa', 4)";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Adress(city, street, houseNumber) values('Wroclaw', 'Pilsudskiego', 12)";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Adress(city, street, houseNumber) values('Olesnica', 'Lesna', 7)";
                    command.ExecuteNonQuery();

                    //create table Account
                    command.CommandText = "create table Account(id integer primary key autoincrement not null, numberAccount varchar(20), " +
                                             "balance decimal(10, 2), password varchar(20), type varchar(20))";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account(numberAccount, balance, password, type) values('1111-1111-1111', 5150, '1234', 'normal')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account(numberAccount, balance, password, type) values('2222-2222-2222', 999.99, 'jebac', 'savings')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account(numberAccount, balance, password, type) values('3333-3333-3333', 8500, '666', 'student')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account(numberAccount, balance, password, type) values('4444-4444-4444', 1212.25, 'kopulowac', 'currency')";
                    command.ExecuteNonQuery();

                    //create table Customer_Account
                    command.CommandText = "create table Customer_Account(idCustomer integer not null, idAccount integer not null)";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Customer_Account values(1, 1)";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Customer_Account values(1, 2)";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Customer_Account values(2, 4)";         
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Customer_Account values(3, 3)";
                    command.ExecuteNonQuery();

                    //create table Account_Types
                    command.CommandText = "create table Account_Types(id integer primary key autoincrement not null, type varchar(20))";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Types(type) values('normal')";     
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Types(type) values('savings')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Types(type) values('company')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Types(type) values('student')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Types(type) values('currency')";
                    command.ExecuteNonQuery();

                    //create table Account_Operations
                    command.CommandText = "create table Account_Operations(id integer primary key autoincrement not null, name varchar(20))";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Operations(name) values('withdraw')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Operations(name) values('payment')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Operations(name) values('transfer')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Account_Operations(name) values('check balance')";
                    command.ExecuteNonQuery();

                    //create table Wihdraw_Amount
                    command.CommandText = "create table Withdraw_Amount(id integer primary key autoincrement not null, amount decimal(3, 0))";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Withdraw_Amount(amount) values('10')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Withdraw_Amount(amount) values('20')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Withdraw_Amount(amount) values('50')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Withdraw_Amount(amount) values('100')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Withdraw_Amount(amount) values('200')";
                    command.ExecuteNonQuery();
                    command.CommandText = "insert into Withdraw_Amount(amount) values('500')";
                    command.ExecuteNonQuery();

                    //create table Transaction
                    command.CommandText = "create table Transactions(id integer primary key autoincrement not null, dateTransaction Date, " +
                                               "name varchar(20), amount decimal(10, 2), title varchar(200), idAccountFrom integer, " +
                                                "idAccountInto integer)";
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
