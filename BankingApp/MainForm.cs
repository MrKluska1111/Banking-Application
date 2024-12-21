using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApp
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAccountInfo1_Click(object sender, EventArgs e)
        {
            controlAccountInfo2.generateAccountInfoView();

            controlCreatingAccount2.Visible = false;
            controlWithdrawPayment3.Visible = false;
            controlTransfer1.Visible = false;
            controlAccountInfo2.Visible = true;
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            controlCreatingAccount2.generateCreatingAccountView();

            controlAccountInfo2.Visible = false;
            controlWithdrawPayment3.Visible = false;
            controlTransfer1.Visible = false;
            controlCreatingAccount2.Visible = true;
        }

        private void btnWithdrawPayment_Click(object sender, EventArgs e)
        {
            controlWithdrawPayment3.generateWithdrawPaymentView();

            controlAccountInfo2.Visible = false;
            controlCreatingAccount2.Visible = false;
            controlTransfer1.Visible = false;
            controlWithdrawPayment3.Visible = true;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            controlTransfer1.generateTransferView();

            controlAccountInfo2.Visible = false;
            controlCreatingAccount2.Visible = false;
            controlWithdrawPayment3.Visible = false;
            controlTransfer1.Visible = true;
        }
    }
}
