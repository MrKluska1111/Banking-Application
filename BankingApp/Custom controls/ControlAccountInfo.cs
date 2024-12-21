using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BankingApp.Custom_controls
{
    public partial class ControlAccountInfo : UserControl
    {
        ITransactions Transaction;

        public ControlAccountInfo()
        {
            InitializeComponent();

        }

        private void ControlAccountInfo_Load(object sender, EventArgs e)
        {

        }

        public void generateAccountInfoView()
        {
            Transaction = new OperationsData(LoggedUser.Nick, LoggedUser.Password);

            if(Transaction.Account == null)
            {
                Transaction.Account = new Account(LoggedUser.Nick, LoggedUser.Password);
            }            

            this.lblAccountType.Text = Transaction.Account.Type;
            this.lblAccountNumber.Text = Transaction.Account.NumberAccount;
            this.lblBalance.Text = Transaction.Account.Balance + " zł";
            this.gridTransactions.DataSource = Transaction.Transactions;
            this.lblIncome.Text = Transaction.Income.ToString() + " zł";
            this.lblExpenses.Text = Transaction.Expenses.ToString() + " zł";
        }
    }
}
