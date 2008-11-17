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
        private Account[] accounts;
        
        public EmailAccountsWindow()
        {
            InitializeComponent();
        }

        /*public EmailAccountsWindow(Account[] pAccounts)
        {
            InitializeComponent();
            //accounts = pAccounts;
        }*/

        private void OKButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void EmailAccountsWindow_Load(object sender, EventArgs e)
        {
            // http://www.tek-tips.com/viewthread.cfm?qid=1442852&page=8
            try
            {
                accountsCmbBox.SuspendLayout();
                accountsCmbBox.Items.Clear();
      
                foreach (Account acc in accounts)
                {
                    accountsCmbBox.Items.Add(new AccountNameMap(acc));
                
                }
            } finally {   
                accountsCmbBox.ResumeLayout();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newAccountBtn_Click(object sender, EventArgs e)
        {
            CreateNewAccountWindow newAccountWindow = new CreateNewAccountWindow();
            newAccountWindow.ShowDialog();
            if (!newAccountWindow.Cancelled)
            {
                accountsCmbBox.Items.Add(newAccountWindow.TextInput);
                selectedAccount = new Account(newAccountWindow.TextInput);
                useSameSettingsChkBox.Checked = true;
                outgoingUsernameTxtBox.Enabled = false;
                outgoingPasswordTxtBox.Enabled = false;
                outgoingUsernameLbl.Enabled = false;
                outgoingPasswordLbl.Enabled = false;
                outgoingSSLChkBox.Enabled = false;
            }
            newAccountWindow.Dispose();
        }

        private void useSameSettingsChkBox_CheckedChanged(object sender, EventArgs e)
        {
            useSameSettingsAsIncomingServer(useSameSettingsChkBox.Checked);
        }

        private void accountsCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountNameMap map = accountsCmbBox.SelectedItem as AccountNameMap;
            selectedAccount = map.EmailAccount;

            if (selectedAccount.accountInfo.IncomingServerType == AccountInfo.ServerType.IMAP)
            {
                incomingServerType.SelectedText = "IMAP";
            }
            else
            {
                incomingServerType.SelectedText = "POP";
            }
            incomingServerTxtBox.Text = selectedAccount.accountInfo.IncomingServer;
            incomingPortTxtBox.Text = Convert.ToString(selectedAccount.accountInfo.IncomingPort);
            incomingUsernameTxtBox.Text = selectedAccount.accountInfo.IncomingUsername;
            incomingPasswordTxtBox.Text = selectedAccount.accountInfo.IncomingPassword;
            incomingSSLChkBox.Checked = selectedAccount.accountInfo.IncomingSSL;

            outgoingServerTxtBox.Text = selectedAccount.accountInfo.OutgoingServer;
            outgoingPortTxtBox.Text = Convert.ToString(selectedAccount.accountInfo.OutgoingPort);
            
            if (selectedAccount.accountInfo.OutgoingAuthentication == AccountInfo.AuthenticationType.None)
            {
                outgoingAuthenticationCmbBox.SelectedText = "None";
                authenticationType(false);
            }
            else
            {
                outgoingAuthenticationCmbBox.SelectedText = "Password";
                authenticationType(true);
                outgoingUsernameTxtBox.Text = selectedAccount.accountInfo.OutgoingUsername;
                outgoingPasswordTxtBox.Text = selectedAccount.accountInfo.OutgoingPassword;
                outgoingSSLChkBox.Checked = selectedAccount.accountInfo.OutgoingSSL;
            }
            
        }

        private void authenticationType(bool enable)
        {
            // this method enables or disables authentication information for the outgoing server
            useSameSettingsChkBox.Enabled = enable;
            useSameSettingsAsIncomingServer(enable);
        }

        private void useSameSettingsAsIncomingServer(bool enable)
        {
            if (enable)
            {
                outgoingUsernameTxtBox.Enabled = true;
                outgoingPasswordTxtBox.Enabled = true;
                outgoingUsernameLbl.Enabled = true;
                outgoingPasswordLbl.Enabled = true;
                outgoingSSLChkBox.Enabled = true;
            }
            else
            {
                outgoingUsernameTxtBox.Enabled = false;
                outgoingPasswordTxtBox.Enabled = false;
                outgoingUsernameLbl.Enabled = false;
                outgoingPasswordLbl.Enabled = false;
                outgoingSSLChkBox.Enabled = false;
            }

        }

        private void outgoingAuthenticationCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outgoingAuthenticationCmbBox.SelectedText == "None")
            {
                authenticationType(false);
            }
            else 
            {
                authenticationType(true);
            }
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    internal class AccountNameMap
    {
        // This is an internal class that helps in handling the combo box
        // for switching between editing accounts
        private Account _account;
        private string _name;

        public AccountNameMap(Account account)
        {
            _account = account;
            _name = account.AccountName;
        }

        public Account EmailAccount
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public override string ToString()
        {
            return _name;
        }

    }
}
