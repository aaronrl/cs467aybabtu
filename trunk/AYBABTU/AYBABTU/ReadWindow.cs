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
        
        public ReadWindow()
        {
            InitializeComponent();
        }

        public ReadWindow(Message readThisMessage){
            msg = readThisMessage;
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
            
            Message replyMessage = msg;
            replyMessage.Subject = "RE: " + replyMessage.Subject;

            WriteWindow replyToMessageWindow = new WriteWindow(new Message(Properties.Settings.Default.EmailAddress, replyMessage.To, replyMessage.Subject, replyMessage.MessageBody));
            replyToMessageWindow.Show();
            this.Close();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            
            Message forwardMessage = msg;
            forwardMessage.Subject = "FWD: " + forwardMessage.Subject;

            WriteWindow forwardMessageWindow = new WriteWindow(new Message(Properties.Settings.Default.EmailAddress, forwardMessage.To, forwardMessage.Subject, forwardMessage.MessageBody));
            forwardMessageWindow.Show();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
