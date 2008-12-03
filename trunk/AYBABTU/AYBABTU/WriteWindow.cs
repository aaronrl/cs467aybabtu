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
        Message msg = new Message();
        string from;

        public WriteWindow()
        {
            InitializeComponent();
        }

        public WriteWindow(Message incomingMessage)
        {
            msg = incomingMessage;
            from = msg.From;
            InitializeComponent();
        }

        public WriteWindow(string pFrom)
        {
            from = pFrom;
            InitializeComponent();
        }

        private void WriteWindow_Load(object sender, EventArgs e)
        {
            fromTxtBox.Text = from;
            toTxtBox.Text = msg.To;
            subjectTxtBox.Text = msg.Subject;
            messageBodyTxtBox.Text = msg.MessageBody;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            msg = new Message(toTxtBox.Text, fromTxtBox.Text, subjectTxtBox.Text, messageBodyTxtBox.Text);
            if (SMTP.sendMessage(msg))
            {
                this.Close();
            }
            else
            {

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
