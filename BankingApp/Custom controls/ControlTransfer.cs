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
    public partial class ControlTransfer : UserControl
    {
        private ITransfer Transfer;
        private List<TextBox> TextBoxes;
        private List<Label> RecipientLabels;
        private List<string> RecipientData;


        public ControlTransfer()
        {
            InitializeComponent();

            TextBoxes = new List<TextBox>() { txtFrom, txtInto, txtPassword, txtAmount, txtTitle };
            RecipientLabels = new List<Label>() { lblName, lblSurname, lblAdress };
        }

        private void UserTransfer_Load(object sender, EventArgs e)
        {

        }

        public void generateTransferView()
        {
            if(Transfer == null)
            {
                Transfer = new OperationMethod(LoggedUser.Nick, LoggedUser.Password);
            }           

            txtFrom.Text = Transfer.Account.NumberAccount;
        }


        private void txtInto_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtInto.Text.Length == 14)
            {
                RecipientData = Customer.getCustomerData(txtInto.Text);

                if(RecipientData != null || RecipientData.Count > 0)
                {
                    for(int i = 0; i < RecipientData.Count; i++)
                    {
                        RecipientLabels[i].Text = RecipientData[i];
                    }
                }
            }
            else
            {
                RecipientLabels.ForEach(a => a.Text = "not founded");
                RecipientData = null;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            decimal amount;

            if (TextBoxes.All(a => a.Text != ""))
            {
                if(RecipientData != null)
                {
                    if(txtPassword.Text == Account.getPassword(LoggedUser.Nick))
                    {
                        if(decimal.TryParse(txtAmount.Text, out amount))
                        {
                            try
                            {
                                Transfer.transfer(txtFrom.Text, txtInto.Text, Convert.ToDecimal(txtAmount.Text), txtTitle.Text);

                                MessageBox.Show("Transfer has been done successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                TextBoxes.ForEach(a => a.Text = "");
                                RecipientLabels.ForEach(a => a.Text = "not founded");
                                RecipientData = null;

                                this.generateTransferView();
                            }
                            catch(Exception error)
                            {
                                MessageBox.Show(error.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Given amount is not a number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct recipient's account.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter all required data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
