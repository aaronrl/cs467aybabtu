using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace AYBABTU
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WriteWindow writedow = new WriteWindow();
            writedow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddressBookWindow abook = new AddressBookWindow();
            abook.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadWindow readdow = new ReadWindow();
            readdow.Show();
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void Main_Load(object sender, EventArgs e)
        {
            ArrayList inbox = new ArrayList();
            ArrayList outbox = new ArrayList();

            for (int i = 0; i < 40; i++)
            {
                MailMessage msg =new MailMessage("aaron@mail.com", "aaron@mail.com", "Hello "+i, "This is a test message, hopefully it works!");
                ListViewItem message = new ListViewItem(msg.From.ToString());
                message.SubItems.Add(msg.Subject.ToString());
                message.SubItems.Add("June 2, 1984");
                ArrayList listitem = new ArrayList();
                listitem.Add(message);
                listitem.Add(msg);
                inbox.Add(listitem);
                
            }

            foreach(ArrayList msg in inbox){
                messageList.Items.Add((ListViewItem) msg[0]);
            }

        }

    }
}
