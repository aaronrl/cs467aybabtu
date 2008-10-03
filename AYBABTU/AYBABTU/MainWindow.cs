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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

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
                messageViewer.Text = ((Message)((ArrayList)inbox[index])[1]).MessageBody;
            }

        }

        private void messageList_MouseDoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            ReadWindow readSelectedMessage = new ReadWindow((Message)((ArrayList)inbox[indices[0]])[1]);
            readSelectedMessage.Show();
        }
        
        private void replyBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            Message replyMessage = (Message) ((ArrayList) inbox[indices[0]])[1];
            replyMessage.Subject = "RE: " + replyMessage.Subject;

            WriteWindow replyToMessageWindow = new WriteWindow(new Message(Properties.Settings.Default.EmailAddress,replyMessage.To,replyMessage.Subject,replyMessage.MessageBody));
            replyToMessageWindow.Show();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            Message forwardMessage = (Message) ((ArrayList) inbox[indices[0]])[1];
            forwardMessage.Subject = "FWD: " + forwardMessage.Subject;

            WriteWindow forwardMessageWindow = new WriteWindow(new Message(Properties.Settings.Default.EmailAddress, forwardMessage.To, forwardMessage.Subject, forwardMessage.MessageBody));
            forwardMessageWindow.Show();
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

            // open a stream to the mailbox file on the system
            FileStream fs = new FileStream(Application.UserAppDataPath + "\\inbox.mbx", FileMode.OpenOrCreate);
            
            try
            {
                // create the formatter to interpret the serialized object on the system
                BinaryFormatter formatter = new BinaryFormatter();
                inbox = (ArrayList) formatter.Deserialize(fs);
            }
            catch (SerializationException se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                fs.Close();
            }

            //Populate the message listing from the inbox array
            foreach(ArrayList msg in inbox){
                messageList.Items.Add((ListViewItem) msg[0]);
            }

            //Let's load the setttings from the system
            UserSettings.loadUserSettingsFromSystem();

            //Select the first message in the inbox to be displayed in the message viewer
            messageViewer.Text = ((Message)((ArrayList)inbox[0])[1]).MessageBody;

            Thread.Sleep(2000);
            splash.Close();
            splash.Dispose();
        }

        private void Main_FormClosing(object sender, EventArgs e)
        {
            saveMailboxToSystem();
        }

        private void Main_FormClosed(object sender, EventArgs e)
        {
            
        }
        /* this method takes the inbox array and serializes it to a file on the system */
        private void saveMailboxToSystem()
        {
            FileStream fs = new FileStream(Application.UserAppDataPath + "\\inbox.mbx", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, inbox);
            }
            catch (SerializationException se)
            {
                MessageBox.Show(se.ToString());
                //throw;
            }
            finally
            {
                fs.Close();
            }
        }

    }
}

/*
 * test data for populating the inbox array
 for (int i = 0; i < 40; i++)
 {
     Message aMsg = new Message("aaron@mail.com", "aaron@mail.com", "Hello " + i, "This is a test message, hopefully it works!  \nTest " + i);
     ListViewItem message = new ListViewItem(aMsg.From);
     message.SubItems.Add(aMsg.Subject);
     message.SubItems.Add("June 2, 1984");
                
     ArrayList listitem = new ArrayList();
     listitem.Add(message);
     listitem.Add(aMsg);
     inbox.Add(listitem);
                
 }
*/