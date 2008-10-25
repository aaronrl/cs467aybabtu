using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    public partial class EmailAccountsWindow : Form
    {
        private Account selectedAccount;
        
        public EmailAccountsWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void EmailAccountsWindow_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newAccountBtn_Click(object sender, EventArgs e)
        {
            CreateNewAccountWindow newAccountWindow = new CreateNewAccountWindow();
            newAccountWindow.Show();
            if (!newAccountWindow.Cancelled)
            {
                accountsCmbBox.Items.Add(newAccountWindow.TextInput);
                selectedAccount = new Account(newAccountWindow.TextInput);
            }
            newAccountWindow.Dispose();
        }
    }
}
