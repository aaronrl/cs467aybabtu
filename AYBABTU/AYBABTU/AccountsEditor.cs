using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    public partial class AccountsEditor : Form
    {
        public Account acct;
        public bool newAccount;
        public bool accountSaved;

        #region constructors
        public AccountsEditor()
        {
            InitializeComponent();
            acct = new Account();
            newAccount = true;
        }

        public AccountsEditor(Account editThisAccount)
        {
            InitializeComponent();
            acct = editThisAccount;
            newAccount = false;
        }
        #endregion

        #region form events
        private void AccountsEditor_Load(object sender, EventArgs e)
        {
            if (!newAccount)
            {
                accountNameTxtBox.Text = acct.AccountName;
                nameTxtBox.Text = acct.accountInfo.Name;
                emailAddressTxtBox.Text = acct.accountInfo.EmailAddress;
                signatureTxtBox.Text = acct.accountInfo.Signature;
                if (acct.accountInfo.IncomingServerType == AccountInfo.ServerType.IMAP)
                {
                    incomingServerType.SelectedIndex = 1;
                }
                else
                {
                    incomingServerType.SelectedIndex = 0;
                }
                incomingServerTxtBox.Text = acct.accountInfo.IncomingServer;
                incomingPortTxtBox.Text = Convert.ToString(acct.accountInfo.IncomingPort);
                incomingUsernameTxtBox.Text = acct.accountInfo.IncomingUsername;
                incomingPasswordTxtBox.Text = acct.accountInfo.IncomingPassword;
                incomingSSLChkBox.Checked = acct.accountInfo.IncomingSSL;

                outgoingServerTxtBox.Text = acct.accountInfo.OutgoingServer;
                outgoingPortTxtBox.Text = Convert.ToString(acct.accountInfo.OutgoingPort);

                if (acct.accountInfo.OutgoingAuthentication == AccountInfo.AuthenticationType.None)
                {
                    outgoingAuthenticationCmbBox.SelectedIndex = 0;
                    authenticationType(false);
                }
                else
                {
                    outgoingAuthenticationCmbBox.SelectedIndex = 1;
                    authenticationType(true);
                    outgoingUsernameTxtBox.Text = acct.accountInfo.OutgoingUsername;
                    outgoingPasswordTxtBox.Text = acct.accountInfo.OutgoingPassword;
                    outgoingSSLChkBox.Checked = acct.accountInfo.OutgoingSSL;
                }
            }
        }

        private void AccountsEditor_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AccountsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
#endregion

        #region buttons
        private void okBtn_Click(object sender, EventArgs e)
        {
            acct.AccountName = accountNameTxtBox.Text;
            acct.accountInfo.Name = nameTxtBox.Text;
            acct.accountInfo.EmailAddress = emailAddressTxtBox.Text;

            if (incomingServerType.SelectedIndex == 0)
            {
                acct.accountInfo.IncomingServerType = AccountInfo.ServerType.POP;
            }
            else
            {
                acct.accountInfo.IncomingServerType = AccountInfo.ServerType.IMAP;
            }
            acct.accountInfo.IncomingServer = incomingServerTxtBox.Text;
            acct.accountInfo.IncomingUsername = incomingUsernameTxtBox.Text;
            acct.accountInfo.IncomingPassword = incomingPasswordTxtBox.Text;
            acct.accountInfo.IncomingSSL = incomingSSLChkBox.Checked;

            try
            {
                acct.accountInfo.IncomingPort = Convert.ToInt32(incomingPortTxtBox.Text);
                acct.accountInfo.OutgoingPort = Convert.ToInt32(outgoingPortTxtBox.Text);
            }
            catch (Exception conversionException)
            {
                acct.accountInfo.IncomingPort = 110;
                acct.accountInfo.OutgoingPort = 25;
            }
            
            acct.accountInfo.OutgoingServer = outgoingServerTxtBox.Text;
            
                if (outgoingAuthenticationCmbBox.SelectedIndex == 0)
            {
                acct.accountInfo.OutgoingAuthentication = AccountInfo.AuthenticationType.None;
                acct.accountInfo.OutgoingUsername = "";
                acct.accountInfo.OutgoingPassword = "";
            }
            else
            {
                acct.accountInfo.OutgoingAuthentication = AccountInfo.AuthenticationType.Password;
                acct.accountInfo.OutgoingUsername = outgoingUsernameTxtBox.Text;
                acct.accountInfo.OutgoingPassword = outgoingPasswordTxtBox.Text;
            }

           
            acct.accountInfo.Signature = signatureTxtBox.Text;

            accountSaved = true;
            this.Close();
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            accountSaved = false;
            this.Close();
        }
        #endregion

        public void authenticationType(bool enable)
        {
            if (enable)
            {
                outgoingUsernameTxtBox.Enabled = true;
                outgoingPasswordTxtBox.Enabled = true;
                //outgoingUsernameLbl.Enabled = true;
                //outgoingPasswordLbl.Enabled = true;
                outgoingSSLChkBox.Enabled = true;
            }
            else
            {
                outgoingUsernameTxtBox.Enabled = false;
                outgoingPasswordTxtBox.Enabled = false;
                //outgoingUsernameLbl.Enabled = false;
                //outgoingPasswordLbl.Enabled = false;
                outgoingSSLChkBox.Enabled = false;
            }
        }

    }
}
