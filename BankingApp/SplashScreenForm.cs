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
    public partial class SplashScreenForm : Form
    {
        private MainForm MainForm;

        public SplashScreenForm()
        {
            InitializeComponent();

            MainForm = new MainForm();
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            timerLoading.Enabled = true;
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            if (panelLoading2.Width <= 700)
            {
                panelLoading2.Width += 10;
            }
            else
            {
                this.Hide();
                timerLoading.Enabled = false;
                MainForm.Show();
            }
        }
    }
}
