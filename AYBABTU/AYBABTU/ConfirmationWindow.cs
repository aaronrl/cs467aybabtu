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
    public partial class ConfirmationWindow : Form
    {
        public bool answer;

        public ConfirmationWindow()
        {
            InitializeComponent();
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            answer = true;
            this.Close();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Close();
        }
    }
}
