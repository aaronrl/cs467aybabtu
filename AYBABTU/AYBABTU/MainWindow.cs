using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Threading;


namespace AYBABTU
{
    public partial class Main : Form
    {
        ArrayList inbox = new ArrayList();
        ArrayList outbox = new ArrayList();

        public Main()
        {
            InitializeComponent();
        }

        #region Events
        private void writeMessageBtn_Click(object sender, EventArgs e)
        {
            WriteWindow writedow = new WriteWindow();
            writedow.Show();
        }

        private void addressBookBtn_Click(object sender, EventArgs e)
        {
            AddressBookWindow abook = new AddressBookWindow();
            abook.Show();
        }

        private void notSpamBtn_Click(object sender, EventArgs e)
        {
            Splashscreen splash = new Splashscreen();
            splash.Show();
        }

        private void aboutAYBABTUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsWindow options = new OptionsWindow();
            options.Show();
        }

        private void emailAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailAccountsWindow accounts = new EmailAccountsWindow();
            accounts.Show();
        }

        private void messageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;

            foreach (int index in indices)
            {
                // gets the selected message from the message list and sets its body to the viewer
                messageViewer.Text = ((MailMessage)((ArrayList)inbox[index])[1]).Body;
            }

        }

        private void messageList_MouseDoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            ReadWindow readSelectedMessage = new ReadWindow((MailMessage)((ArrayList)inbox[indices[0]])[1]);
            readSelectedMessage.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            UserSettings.writeUserSettingsToSystem();
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            Splashscreen splash = new Splashscreen();
            splash.Show();
            for (int i = 0; i < 40; i++)
            {
                MailMessage msg =new MailMessage("aaron@mail.com", "aaron@mail.com", "Hello "+i, "This is a test message, hopefully it works!  \nTest "+i);
                ListViewItem message = new ListViewItem(msg.From.ToString());
                message.SubItems.Add(msg.Subject.ToString());
                message.SubItems.Add("June 2, 1984");
                //message.onDoubleClick += 
                ArrayList listitem = new ArrayList();
                listitem.Add(message);
                listitem.Add(msg);
                inbox.Add(listitem);
                
            }

            foreach(ArrayList msg in inbox){
                messageList.Items.Add((ListViewItem) msg[0]);
            }

            messageList.MouseDoubleClick += new MouseEventHandler(messageList_MouseDoubleClick);

            UserSettings.loadUserSettingsFromSystem();

            messageViewer.Text = ((MailMessage)((ArrayList)inbox[0])[1]).Body;

            Thread.Sleep(2000);
            splash.Close();
            splash.Dispose();
        }





    }
}