using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    public partial class CreateNewAccountWindow : Form
    {
        private string textinput;
        private bool cancelled;

        public CreateNewAccountWindow()
        {
            InitializeComponent();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            textinput = accountNameTxtBox.Text;
            cancelled = false;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            cancelled = true;
            this.Close();
        }

        public string TextInput
        {
            get
            {
                return textinput;
            }
        }

        public bool Cancelled
        {
            get
            {
                return cancelled;
            }
        }
    }
}
