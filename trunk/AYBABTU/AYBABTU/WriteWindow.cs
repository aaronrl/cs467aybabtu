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

        public WriteWindow()
        {
            InitializeComponent();
        }

        public WriteWindow(Message incomingMessage)
        {
            msg = incomingMessage;
            InitializeComponent();
        }

        private void WriteWindow_Load(object sender, EventArgs e)
        {
            fromTxtBox.Text = Properties.Settings.Default.EmailAddress;
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

    }
}
