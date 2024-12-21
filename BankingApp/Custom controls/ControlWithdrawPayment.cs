using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApp.Custom_controls
{
    public partial class ControlWithdrawPayment : UserControl
    {
        private IWithdraw Withdraw;
        private IPayment Payment;


        public ControlWithdrawPayment()
        {
            InitializeComponent();

        }

        private void ControlWithdrawPayment_Load(object sender, EventArgs e)
        {

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Withdraw = new OperationMethod(LoggedUser.Nick, LoggedUser.Password);
            Payment = new OperationMethod(LoggedUser.Nick, LoggedUser.Password);

            if (comboOperations.SelectedIndex != -1)
            {
                    if (comboAmount.SelectedIndex != -1)
                    {
                        if (Account.getPassword(LoggedUser.Nick) == txtPassword.Text)
                        {
                           if(comboOperations.SelectedValue.ToString() == "withdraw")
                            {
                                if (Withdraw.withdraw(LoggedUser.Nick, Convert.ToDecimal(comboAmount.SelectedValue.ToString())))
                                {
                                    MessageBox.Show("Withdraw has been done succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    comboOperations.SelectedIndex = -1;
                                    comboAmount.SelectedIndex = -1;
                                    txtPassword.Text = "";
                                }
                             }
                            else if(comboOperations.SelectedValue.ToString() == "payment")
                            {

                                if(Payment.payment(LoggedUser.Nick, Convert.ToDecimal(comboAmount.SelectedValue)))
                                 {
                                        MessageBox.Show("Payment has been done succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        comboOperations.SelectedIndex = -1;
                                        comboAmount.SelectedIndex = -1;
                                        txtPassword.Text = "";
                                  }   
                            }

                         }
                        else
                        {
                            MessageBox.Show("Please enter correct password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must choose amount of cash you want to pay or withdraw into account.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        public void generateWithdrawPaymentView()
        {
            comboAmount.DataSource = OperationsData.WithdrawAmount;
            comboAmount.SelectedIndex = -1;

            comboOperations.DataSource = OperationsData.AccountOperations;
            comboOperations.SelectedIndex = -1;
        }

    }

}
