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
        MailMessage msg = new MailMessage();
        
        public ReadWindow()
        {
            InitializeComponent();
        }

        public ReadWindow(MailMessage readThisMessage){
            msg = readThisMessage;
            InitializeComponent();
        }

        private void ReadWindow_Load(object sender, EventArgs e)
        {
            messageBody.Text = msg.Body;
            fromTxtBox.Text = msg.From.ToString();
            toTxtBox.Text = msg.To.ToString();
            subjectTxtBox.Text = msg.Subject;
        }

    }
}
