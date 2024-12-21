using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace BankingApp
{
    public partial class Login : Form
    {  
        private SplashScreenForm splashScreenForm;  //to pole jest również prywatne ponieważ SplashScreen jest uruchamiany tylko po udanym logowaniu

        public Login()
        {
            InitializeComponent();
             

            splashScreenForm = new SplashScreenForm();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Database.CreateDatabase(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(Account.getPassword(txtUserName.Text) == txtPassword.Text && Account.getPassword(txtUserName.Text) != "")
            {
                LoggedUser.Nick = txtUserName.Text;
                LoggedUser.Password = txtPassword.Text;

                this.Hide();
                splashScreenForm.Show();  
            }
            else
            {
                MessageBox.Show("Please enter correct username or password.");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}
