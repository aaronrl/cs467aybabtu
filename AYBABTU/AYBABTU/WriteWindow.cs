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
        MailMessage msg = new MailMessage();

        public WriteWindow()
        {
            InitializeComponent();
        }

        public WriteWindow(MailMessage incomingMessage)
        {
            msg = incomingMessage;
            InitializeComponent();
        }

        private void WriteWindow_Load(object sender, EventArgs e)
        {
            fromTxtBox.Text = Properties.Settings.Default.EmailAddress;
            toTxtBox.Text = msg.To.ToString();
            subjectTxtBox.Text = msg.Subject;
            messageBodyTxtBox.Text = msg.Body;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            msg = new MailMessage(fromTxtBox.Text, toTxtBox.Text, subjectTxtBox.Text, messageBodyTxtBox.Text);
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
