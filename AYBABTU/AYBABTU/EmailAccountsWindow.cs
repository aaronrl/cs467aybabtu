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
            Properties.Settings.Default.POPServer = incomingServerTxtBox.Text;
            Properties.Settings.Default.SMTPServer = outgoingServerTxtBox.Text;
            Properties.Settings.Default.EmailAddress = emailAddressTxtBox.Text;
            Properties.Settings.Default.Username = incomingUsernameTxtBox.Text;
            Properties.Settings.Default.Password = incomingPasswordTxtBox.Text;
            UserSettings.writeUserSettingsToSystem();
            this.Close();
        }

        private void EmailAccountsWindow_Load(object sender, EventArgs e)
        {
            incomingServerTxtBox.Text = Properties.Settings.Default.POPServer;
            outgoingServerTxtBox.Text = Properties.Settings.Default.SMTPServer;
            emailAddressTxtBox.Text = Properties.Settings.Default.EmailAddress;
            incomingUsernameTxtBox.Text = Properties.Settings.Default.Username;
            incomingPasswordTxtBox.Text = Properties.Settings.Default.Password;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
