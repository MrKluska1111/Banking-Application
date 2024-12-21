namespace BankingApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelToolBar1 = new System.Windows.Forms.Panel();
            this.lblNick = new System.Windows.Forms.Label();
            this.panelMenu1 = new System.Windows.Forms.Panel();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnWithdrawPayment = new System.Windows.Forms.Button();
            this.btnAccountInfo1 = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.controlTransfer1 = new BankingApp.Custom_controls.ControlTransfer();
            this.controlWithdrawPayment3 = new BankingApp.Custom_controls.ControlWithdrawPayment();
            this.controlCreatingAccount2 = new BankingApp.Custom_controls.ControlCreatingAccount();
            this.controlAccountInfo2 = new BankingApp.Custom_controls.ControlAccountInfo();
            this.panelToolBar1.SuspendLayout();
            this.panelMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolBar1
            // 
            this.panelToolBar1.BackColor = System.Drawing.Color.SteelBlue;
            this.panelToolBar1.Controls.Add(this.lblNick);
            this.panelToolBar1.Location = new System.Drawing.Point(197, 0);
            this.panelToolBar1.Name = "panelToolBar1";
            this.panelToolBar1.Size = new System.Drawing.Size(527, 36);
            this.panelToolBar1.TabIndex = 0;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNick.ForeColor = System.Drawing.Color.White;
            this.lblNick.Location = new System.Drawing.Point(397, 9);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(44, 19);
            this.lblNick.TabIndex = 0;
            this.lblNick.Text = "Nick";
            // 
            // panelMenu1
            // 
            this.panelMenu1.BackColor = System.Drawing.Color.SteelBlue;
            this.panelMenu1.Controls.Add(this.btnServices);
            this.panelMenu1.Controls.Add(this.btnTransfer);
            this.panelMenu1.Controls.Add(this.btnWithdrawPayment);
            this.panelMenu1.Controls.Add(this.btnAccountInfo1);
            this.panelMenu1.Controls.Add(this.btnCreateAccount);
            this.panelMenu1.Controls.Add(this.pictureBox2);
            this.panelMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu1.Location = new System.Drawing.Point(0, 0);
            this.panelMenu1.Name = "panelMenu1";
            this.panelMenu1.Size = new System.Drawing.Size(198, 472);
            this.panelMenu1.TabIndex = 1;
            // 
            // btnServices
            // 
            this.btnServices.BackColor = System.Drawing.Color.Azure;
            this.btnServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnServices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnServices.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnServices.Location = new System.Drawing.Point(29, 356);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(138, 38);
            this.btnServices.TabIndex = 6;
            this.btnServices.Text = "Services";
            this.btnServices.UseVisualStyleBackColor = false;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.Azure;
            this.btnTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransfer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnTransfer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTransfer.Location = new System.Drawing.Point(29, 312);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(138, 38);
            this.btnTransfer.TabIndex = 5;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnWithdrawPayment
            // 
            this.btnWithdrawPayment.BackColor = System.Drawing.Color.Azure;
            this.btnWithdrawPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWithdrawPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnWithdrawPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnWithdrawPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdrawPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWithdrawPayment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnWithdrawPayment.Location = new System.Drawing.Point(29, 268);
            this.btnWithdrawPayment.Name = "btnWithdrawPayment";
            this.btnWithdrawPayment.Size = new System.Drawing.Size(138, 38);
            this.btnWithdrawPayment.TabIndex = 4;
            this.btnWithdrawPayment.Text = "Withdraw/Payment";
            this.btnWithdrawPayment.UseVisualStyleBackColor = false;
            this.btnWithdrawPayment.Click += new System.EventHandler(this.btnWithdrawPayment_Click);
            // 
            // btnAccountInfo1
            // 
            this.btnAccountInfo1.BackColor = System.Drawing.Color.Azure;
            this.btnAccountInfo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountInfo1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnAccountInfo1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnAccountInfo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAccountInfo1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAccountInfo1.Location = new System.Drawing.Point(29, 224);
            this.btnAccountInfo1.Name = "btnAccountInfo1";
            this.btnAccountInfo1.Size = new System.Drawing.Size(138, 38);
            this.btnAccountInfo1.TabIndex = 3;
            this.btnAccountInfo1.Text = "Account Info";
            this.btnAccountInfo1.UseVisualStyleBackColor = false;
            this.btnAccountInfo1.Click += new System.EventHandler(this.btnAccountInfo1_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.Color.Azure;
            this.btnCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnCreateAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateAccount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCreateAccount.Location = new System.Drawing.Point(29, 180);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(138, 38);
            this.btnCreateAccount.TabIndex = 2;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(198, 137);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // controlTransfer1
            // 
            this.controlTransfer1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.controlTransfer1.Location = new System.Drawing.Point(197, 39);
            this.controlTransfer1.Name = "controlTransfer1";
            this.controlTransfer1.Size = new System.Drawing.Size(520, 430);
            this.controlTransfer1.TabIndex = 6;
            this.controlTransfer1.Visible = false;
            // 
            // controlWithdrawPayment3
            // 
            this.controlWithdrawPayment3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.controlWithdrawPayment3.Location = new System.Drawing.Point(197, 39);
            this.controlWithdrawPayment3.Name = "controlWithdrawPayment3";
            this.controlWithdrawPayment3.Size = new System.Drawing.Size(520, 430);
            this.controlWithdrawPayment3.TabIndex = 5;
            this.controlWithdrawPayment3.Visible = false;
            // 
            // controlCreatingAccount2
            // 
            this.controlCreatingAccount2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.controlCreatingAccount2.Location = new System.Drawing.Point(197, 39);
            this.controlCreatingAccount2.Name = "controlCreatingAccount2";
            this.controlCreatingAccount2.Size = new System.Drawing.Size(520, 430);
            this.controlCreatingAccount2.TabIndex = 4;
            this.controlCreatingAccount2.Visible = false;
            // 
            // controlAccountInfo2
            // 
            this.controlAccountInfo2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.controlAccountInfo2.Location = new System.Drawing.Point(197, 39);
            this.controlAccountInfo2.Name = "controlAccountInfo2";
            this.controlAccountInfo2.Size = new System.Drawing.Size(520, 430);
            this.controlAccountInfo2.TabIndex = 3;
            this.controlAccountInfo2.Visible = false;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(721, 472);
            this.Controls.Add(this.controlTransfer1);
            this.Controls.Add(this.controlWithdrawPayment3);
            this.Controls.Add(this.controlCreatingAccount2);
            this.Controls.Add(this.controlAccountInfo2);
            this.Controls.Add(this.panelToolBar1);
            this.Controls.Add(this.panelMenu1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelToolBar1.ResumeLayout(false);
            this.panelToolBar1.PerformLayout();
            this.panelMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCreatingAccount;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelToolBar;
        private Custom_controls.ControlCreatingAccount controlCreatingAccount1;
        private System.Windows.Forms.Button btnAccountInfo;
        private Custom_controls.ControlAccountInfo controlAccountInfo1;
        private System.Windows.Forms.Panel panelToolBar1;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.Panel panelMenu1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnAccountInfo1;
        private System.Windows.Forms.Button btnWithdrawPayment;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnTransfer;
        private Custom_controls.ControlWithdrawPayment controlWithdrawPayment1;
        private Custom_controls.ControlAccountInfo controlAccountInfo2;
        private Custom_controls.ControlCreatingAccount controlCreatingAccount2;
        private Custom_controls.ControlWithdrawPayment controlWithdrawPayment2;
        private Custom_controls.ControlWithdrawPayment controlWithdrawPayment3;
        private Custom_controls.ControlTransfer controlTransfer1;
    }
}