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
    public partial class ControlCreatingAccount : UserControl
    {
        private List<TextBox> textBoxes;
        private List<RadioButton> radioButtons;
        private Account CreatedAccount;
        private Customer CreatedCustomer;

        public ControlCreatingAccount()
        {
            InitializeComponent();

            textBoxes = new List<TextBox>() { txtAccontNo, txtCity, txtHouse, txtName, txtNick, txtPassword, txtPhone, txtStreet, txtSurname };
            radioButtons = new List<RadioButton>() { radioBtnMale, radioBtnFemale };

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            int house;
            int phone;

            if (textBoxes.All(x => x.Text != "") && comboAccountType.SelectedIndex != -1 && (radioBtnFemale.Checked || radioBtnMale.Checked))
            {
                if (int.TryParse(txtPhone.Text, out phone) && int.TryParse(txtHouse.Text, out house))
                {
                    CreatedCustomer = new Customer(txtName.Text, txtSurname.Text, txtNick.Text, dateBirth.Value.ToShortDateString(), txtPhone.Text);
                    CreatedAccount = new Account(txtAccontNo.Text, txtPassword.Text, comboAccountType.SelectedValue.ToString());
                    CreatedCustomer.Address = new Address(txtCity.Text, txtStreet.Text, Convert.ToInt32(txtHouse.Text));

                    if (radioBtnMale.Checked)
                    {
                        CreatedCustomer.Gender = 'm';
                    }
                    else
                    {
                        CreatedCustomer.Gender = 'f';
                    }

                    if (CreatedCustomer.createCustomer())
                    {
                        if (CreatedCustomer.Address.createAdress())
                        {
                            if (CreatedAccount.createAccount())
                            {
                                if (CreatedCustomer.assignAdress(CreatedCustomer.Nick, CreatedCustomer.Address) && CreatedAccount.assignCustomer(
                                    CreatedCustomer.Nick, CreatedAccount.NumberAccount))
                                {
                                    MessageBox.Show("Account has been created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    textBoxes.ForEach(a => a.Text = "");
                                    comboAccountType.SelectedIndex = -1;
                                    dateBirth.ResetText();
                                    radioButtons.ForEach(a => a.Checked = false);

                                    CreatedCustomer = null;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Given phone or house number is not a number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter all required data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ControlCreatingAccount_Load(object sender, EventArgs e)
        {

        }

        public void generateCreatingAccountView()
        {
            comboAccountType.DataSource = Account.AccountTypes;
            comboAccountType.SelectedIndex = -1;
        }
    }
}
