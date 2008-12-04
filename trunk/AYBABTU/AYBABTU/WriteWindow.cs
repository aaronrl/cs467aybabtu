using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace AYBABTU
{
    public partial class WriteWindow : Form
    {
        Account acct;
        Message inMsg;
        string from;
        string signature;

        public WriteWindow(Account sendingAccount)
        {
            acct = sendingAccount;
            InitializeComponent();
        }

        public WriteWindow(Message incomingMessage, Account sendingAccount)
        {
            inMsg = incomingMessage;
            acct = sendingAccount;
            InitializeComponent();
        }

        private void WriteWindow_Load(object sender, EventArgs e)
        {
            fromTxtBox.Text = acct.accountInfo.EmailAddress;
            fromTxtBox.Enabled = false;
            if (inMsg != null)
            {
                toTxtBox.Text = inMsg.To;
                subjectTxtBox.Text = inMsg.Subject;
                messageBodyTxtBox.Text = "\n\n\n" + acct.accountInfo.Signature + "\n\n\n" + inMsg.MessageBody;
                messageBodyTxtBox.Focus();
                messageBodyTxtBox.Select(0, 0);
            }
            else
            {
                toTxtBox.Focus();
                messageBodyTxtBox.Text = "\n\n\n" + acct.accountInfo.Signature + "\n";
                messageBodyTxtBox.Select(0, 0);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            Message outMsg = new Message(toTxtBox.Text, fromTxtBox.Text, subjectTxtBox.Text, messageBodyTxtBox.Text);
            SMTP client;
            if (acct.accountInfo.OutgoingAuthentication == AccountInfo.AuthenticationType.Password)
            {
                client = new SMTP(acct.accountInfo.OutgoingServer, acct.accountInfo.OutgoingPort, acct.accountInfo.OutgoingUsername, acct.accountInfo.OutgoingPassword);
            }
            else
            {
                client = new SMTP(acct.accountInfo.OutgoingServer, acct.accountInfo.OutgoingPort);
            }

            client.sendMessage(outMsg);

            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
