namespace AYBABTU
{
    partial class EmailAccountsWindow
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
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.incomingServerTxtBox = new System.Windows.Forms.TextBox();
            this.outgoingServerTxtBox = new System.Windows.Forms.TextBox();
            this.incomingUsernameTxtBox = new System.Windows.Forms.TextBox();
            this.incomingPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emailAddressTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.incomingSSLChkBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.incomingPortTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.incomingServerType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.outgoingSSLChkBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.outgoingPortTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.outgoingPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.outgoingUsernameTxtBox = new System.Windows.Forms.TextBox();
            this.useSameSettingsChkBox = new System.Windows.Forms.CheckBox();
            this.accountsCmbBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.newAccountBtn = new System.Windows.Forms.Button();
            this.editAccountBtn = new System.Windows.Forms.Button();
            this.deleteAccountBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(279, 401);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(360, 401);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // incomingServerTxtBox
            // 
            this.incomingServerTxtBox.Location = new System.Drawing.Point(99, 49);
            this.incomingServerTxtBox.Name = "incomingServerTxtBox";
            this.incomingServerTxtBox.Size = new System.Drawing.Size(225, 20);
            this.incomingServerTxtBox.TabIndex = 2;
            this.incomingServerTxtBox.WordWrap = false;
            // 
            // outgoingServerTxtBox
            // 
            this.outgoingServerTxtBox.Location = new System.Drawing.Point(99, 19);
            this.outgoingServerTxtBox.Name = "outgoingServerTxtBox";
            this.outgoingServerTxtBox.Size = new System.Drawing.Size(225, 20);
            this.outgoingServerTxtBox.TabIndex = 3;
            this.outgoingServerTxtBox.WordWrap = false;
            // 
            // incomingUsernameTxtBox
            // 
            this.incomingUsernameTxtBox.Location = new System.Drawing.Point(99, 101);
            this.incomingUsernameTxtBox.Name = "incomingUsernameTxtBox";
            this.incomingUsernameTxtBox.Size = new System.Drawing.Size(225, 20);
            this.incomingUsernameTxtBox.TabIndex = 5;
            this.incomingUsernameTxtBox.WordWrap = false;
            // 
            // incomingPasswordTxtBox
            // 
            this.incomingPasswordTxtBox.Location = new System.Drawing.Point(99, 127);
            this.incomingPasswordTxtBox.Name = "incomingPasswordTxtBox";
            this.incomingPasswordTxtBox.PasswordChar = '*';
            this.incomingPasswordTxtBox.Size = new System.Drawing.Size(225, 20);
            this.incomingPasswordTxtBox.TabIndex = 6;
            this.incomingPasswordTxtBox.UseSystemPasswordChar = true;
            this.incomingPasswordTxtBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Incoming Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Outgoing Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password:";
            // 
            // emailAddressTxtBox
            // 
            this.emailAddressTxtBox.Location = new System.Drawing.Point(99, 75);
            this.emailAddressTxtBox.Name = "emailAddressTxtBox";
            this.emailAddressTxtBox.Size = new System.Drawing.Size(225, 20);
            this.emailAddressTxtBox.TabIndex = 4;
            this.emailAddressTxtBox.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Email Address:";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(441, 401);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 13;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.incomingSSLChkBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.incomingPortTxtBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.incomingServerType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.incomingServerTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.emailAddressTxtBox);
            this.groupBox1.Controls.Add(this.incomingPasswordTxtBox);
            this.groupBox1.Controls.Add(this.incomingUsernameTxtBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 178);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incoming Server";
            // 
            // incomingSSLChkBox
            // 
            this.incomingSSLChkBox.AutoSize = true;
            this.incomingSSLChkBox.Location = new System.Drawing.Point(99, 155);
            this.incomingSSLChkBox.Name = "incomingSSLChkBox";
            this.incomingSSLChkBox.Size = new System.Drawing.Size(121, 17);
            this.incomingSSLChkBox.TabIndex = 17;
            this.incomingSSLChkBox.Text = "Use SSL Encryption";
            this.incomingSSLChkBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Port:";
            // 
            // incomingPortTxtBox
            // 
            this.incomingPortTxtBox.Location = new System.Drawing.Point(373, 49);
            this.incomingPortTxtBox.Name = "incomingPortTxtBox";
            this.incomingPortTxtBox.Size = new System.Drawing.Size(100, 20);
            this.incomingPortTxtBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Server Type:";
            // 
            // incomingServerType
            // 
            this.incomingServerType.FormattingEnabled = true;
            this.incomingServerType.Items.AddRange(new object[] {
            "POP",
            "IMAP"});
            this.incomingServerType.Location = new System.Drawing.Point(99, 22);
            this.incomingServerType.Name = "incomingServerType";
            this.incomingServerType.Size = new System.Drawing.Size(121, 21);
            this.incomingServerType.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outgoingSSLChkBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.outgoingPortTxtBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.outgoingPasswordTxtBox);
            this.groupBox2.Controls.Add(this.outgoingUsernameTxtBox);
            this.groupBox2.Controls.Add(this.useSameSettingsChkBox);
            this.groupBox2.Controls.Add(this.outgoingServerTxtBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 163);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outgoing Server";
            // 
            // outgoingSSLChkBox
            // 
            this.outgoingSSLChkBox.AutoSize = true;
            this.outgoingSSLChkBox.Location = new System.Drawing.Point(99, 120);
            this.outgoingSSLChkBox.Name = "outgoingSSLChkBox";
            this.outgoingSSLChkBox.Size = new System.Drawing.Size(121, 17);
            this.outgoingSSLChkBox.TabIndex = 19;
            this.outgoingSSLChkBox.Text = "Use SSL Encryption";
            this.outgoingSSLChkBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(338, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Port:";
            // 
            // outgoingPortTxtBox
            // 
            this.outgoingPortTxtBox.Location = new System.Drawing.Point(373, 19);
            this.outgoingPortTxtBox.Name = "outgoingPortTxtBox";
            this.outgoingPortTxtBox.Size = new System.Drawing.Size(100, 20);
            this.outgoingPortTxtBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Username:";
            // 
            // outgoingPasswordTxtBox
            // 
            this.outgoingPasswordTxtBox.Location = new System.Drawing.Point(99, 94);
            this.outgoingPasswordTxtBox.Name = "outgoingPasswordTxtBox";
            this.outgoingPasswordTxtBox.PasswordChar = '*';
            this.outgoingPasswordTxtBox.Size = new System.Drawing.Size(225, 20);
            this.outgoingPasswordTxtBox.TabIndex = 12;
            this.outgoingPasswordTxtBox.UseSystemPasswordChar = true;
            this.outgoingPasswordTxtBox.WordWrap = false;
            // 
            // outgoingUsernameTxtBox
            // 
            this.outgoingUsernameTxtBox.Location = new System.Drawing.Point(99, 68);
            this.outgoingUsernameTxtBox.Name = "outgoingUsernameTxtBox";
            this.outgoingUsernameTxtBox.Size = new System.Drawing.Size(225, 20);
            this.outgoingUsernameTxtBox.TabIndex = 11;
            this.outgoingUsernameTxtBox.WordWrap = false;
            // 
            // useSameSettingsChkBox
            // 
            this.useSameSettingsChkBox.AutoSize = true;
            this.useSameSettingsChkBox.Location = new System.Drawing.Point(99, 45);
            this.useSameSettingsChkBox.Name = "useSameSettingsChkBox";
            this.useSameSettingsChkBox.Size = new System.Drawing.Size(206, 17);
            this.useSameSettingsChkBox.TabIndex = 9;
            this.useSameSettingsChkBox.Text = "Use same settings as incoming server.";
            this.useSameSettingsChkBox.UseVisualStyleBackColor = true;
            // 
            // accountsCmbBox
            // 
            this.accountsCmbBox.FormattingEnabled = true;
            this.accountsCmbBox.Location = new System.Drawing.Point(68, 12);
            this.accountsCmbBox.Name = "accountsCmbBox";
            this.accountsCmbBox.Size = new System.Drawing.Size(121, 21);
            this.accountsCmbBox.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Account:";
            // 
            // newAccountBtn
            // 
            this.newAccountBtn.Location = new System.Drawing.Point(195, 12);
            this.newAccountBtn.Name = "newAccountBtn";
            this.newAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.newAccountBtn.TabIndex = 18;
            this.newAccountBtn.Text = "Create";
            this.newAccountBtn.UseVisualStyleBackColor = true;
            this.newAccountBtn.Click += new System.EventHandler(this.newAccountBtn_Click);
            // 
            // editAccountBtn
            // 
            this.editAccountBtn.Location = new System.Drawing.Point(276, 12);
            this.editAccountBtn.Name = "editAccountBtn";
            this.editAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.editAccountBtn.TabIndex = 19;
            this.editAccountBtn.Text = "Edit";
            this.editAccountBtn.UseVisualStyleBackColor = true;
            // 
            // deleteAccountBtn
            // 
            this.deleteAccountBtn.Location = new System.Drawing.Point(357, 12);
            this.deleteAccountBtn.Name = "deleteAccountBtn";
            this.deleteAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteAccountBtn.TabIndex = 20;
            this.deleteAccountBtn.Text = "Delete";
            this.deleteAccountBtn.UseVisualStyleBackColor = true;
            // 
            // EmailAccountsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 436);
            this.Controls.Add(this.deleteAccountBtn);
            this.Controls.Add(this.editAccountBtn);
            this.Controls.Add(this.newAccountBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.accountsCmbBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Name = "EmailAccountsWindow";
            this.Text = "Email Accounts";
            this.Load += new System.EventHandler(this.EmailAccountsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox incomingServerTxtBox;
        private System.Windows.Forms.TextBox outgoingServerTxtBox;
        private System.Windows.Forms.TextBox incomingUsernameTxtBox;
        private System.Windows.Forms.TextBox incomingPasswordTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailAddressTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox incomingSSLChkBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox incomingPortTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox incomingServerType;
        private System.Windows.Forms.CheckBox useSameSettingsChkBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox outgoingPasswordTxtBox;
        private System.Windows.Forms.TextBox outgoingUsernameTxtBox;
        private System.Windows.Forms.CheckBox outgoingSSLChkBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox outgoingPortTxtBox;
        private System.Windows.Forms.ComboBox accountsCmbBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button newAccountBtn;
        private System.Windows.Forms.Button editAccountBtn;
        private System.Windows.Forms.Button deleteAccountBtn;
    }
}