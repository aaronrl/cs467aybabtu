using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AYBABTU
{
    public partial class MailChecker : Form
    {
        public MailChecker()
        {
            InitializeComponent();
        }

        private void MailChecker_Load(object sender, EventArgs e)
        {
            checkMail();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkMail()
        {
            
        }
    }
}
