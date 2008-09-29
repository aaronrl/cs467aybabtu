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
    public partial class EmailAccountsWindow : Form
    {
        public EmailAccountsWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmailAccountsWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
