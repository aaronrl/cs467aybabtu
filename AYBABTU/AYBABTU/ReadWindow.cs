using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace AYBABTU
{
    public partial class ReadWindow : Form
    {
        private Message msg = new Message();
        Account acct;

        public ReadWindow()
        {
            InitializeComponent();
        }

        public ReadWindow(Message readThisMessage, Account account ){
            msg = readThisMessage;
            acct = account;
            InitializeComponent();
        }

        private void ReadWindow_Load(object sender, EventArgs e)
        {
            messageBody.Text = msg.MessageBody;
            fromTxtBox.Text = msg.From;
            toTxtBox.Text = msg.To;
            subjectTxtBox.Text = msg.Subject;
        }

        private void replyBtn_Click(object sender, EventArgs e)
        {
            
            Message replyMessage = (Message) msg.Clone();
            replyMessage.Subject = "RE: " + replyMessage.Subject;

            WriteWindow replyToMessageWindow = new WriteWindow(new Message(acct.accountInfo.EmailAddress, replyMessage.To, replyMessage.Subject, replyMessage.MessageBody), acct);
            replyToMessageWindow.Show();
            this.Close();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            
            Message forwardMessage = (Message) msg.Clone();
            forwardMessage.Subject = "FWD: " + forwardMessage.Subject;

            WriteWindow forwardMessageWindow = new WriteWindow(new Message(acct.accountInfo.EmailAddress, forwardMessage.To, forwardMessage.Subject, forwardMessage.MessageBody), acct);
            forwardMessageWindow.Show();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
