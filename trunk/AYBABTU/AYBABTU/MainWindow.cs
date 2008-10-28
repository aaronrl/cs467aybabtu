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
        SortedDictionary<string,ArrayList> folders = new SortedDictionary<string,ArrayList>();

        public Main()
        {
            InitializeComponent();
        }

        #region Events

        #region Buttons
        private void getMessageBtn_Click(object sender, EventArgs e)
        {
            MailChecker window = new MailChecker();
            window.Show();

        }
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

        private void replyBtn_Click(object sender, EventArgs e)
        {
            /*ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            Message replyMessage = (Message)((ArrayList)inbox[indices[0]])[1];
            replyMessage.Subject = "RE: " + replyMessage.Subject;

            WriteWindow replyToMessageWindow = new WriteWindow(new Message(Properties.Settings.Default.EmailAddress, replyMessage.To, replyMessage.Subject, replyMessage.MessageBody));
            replyToMessageWindow.Show();*/
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            /*ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            Message forwardMessage = (Message)((ArrayList)inbox[indices[0]])[1];
            forwardMessage.Subject = "FWD: " + forwardMessage.Subject;

            WriteWindow forwardMessageWindow = new WriteWindow(new Message(Properties.Settings.Default.EmailAddress, forwardMessage.To, forwardMessage.Subject, forwardMessage.MessageBody));
            forwardMessageWindow.Show();*/
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            UserSettings.writeUserSettingsToSystem();
        }
        #endregion  

        #region Menu Items
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Interaction Actions
        private void messageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;

            foreach (int index in indices)
            {
                // gets the selected message from the message list and sets its body to the viewer
                //messageViewer.Text = ((Message)((ArrayList)inbox[index])[1]).MessageBody;
            }

        }

        private void messageList_MouseDoubleClick(object sender, EventArgs e)
        {
            /*ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            ReadWindow readSelectedMessage = new ReadWindow((Message)((ArrayList)inbox[indices[0]])[1]);
            readSelectedMessage.Show();*/
        }

        private void Main_FormClosing(object sender, EventArgs e)
        {
            //saveMailboxToSystem();
        }

        private void Main_FormClosed(object sender, EventArgs e)
        {

        }

        private void folderList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*if (folderList.SelectedNode.Text == "Inbox")
            {
                loadMessageList(inbox);
            }
            else if (folderList.SelectedNode.Text == "Outbox")
            {
                loadMessageList(outbox);
            }*/
        }
        #endregion

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            /*
            Splashscreen splash = new Splashscreen();
            splash.Show();
            */

            //loadAccounts();

            
            /*loadMailboxesFromSystem();
            loadMessageList(inbox);
            */

            // load the first message into the message viewer
            //messageViewer.Text = ((Message)((ArrayList)inbox[0])[1]).MessageBody;
            
            // add double click functionality to the message list
            messageList.MouseDoubleClick += new MouseEventHandler(messageList_MouseDoubleClick);

            //Let's load the setttings from the system
            UserSettings.loadUserSettingsFromSystem();

            /*
            Thread.Sleep(2000);
            splash.Close();
            splash.Dispose();
            */
        }

        /*

        // this method takes the inbox array and serializes it to a file on the system 
        private void saveMailboxToSystem()
        {
            FileStream fs = new FileStream(Application.UserAppDataPath + "\\Inbox.mbx", FileMode.OpenOrCreate);

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

        private void loadMailboxesFromSystem()
        {
            // http://blog.paranoidferret.com/index.php/2008/05/13/c-snippet-tutorial-get-file-listings/
            // http://www.csharpfriends.com/Articles/getArticle.aspx?articleID=356
            // http://www.google.com/search?sourceid=chrome&ie=UTF-8&q=getting+a+directory+listing+in+c%23
            
            DirectoryInfo fileListing = new DirectoryInfo(Application.UserAppDataPath);
            FileStream fs;

            foreach (FileInfo file in fileListing.GetFiles("*.mbx"))
            {
                fs = new FileStream(Application.UserAppDataPath + "\\" + file.Name, FileMode.Open);
                

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    string filename = (file.Name).Substring(0, (file.Name).Length - 4);
                    folders[filename] = (ArrayList) formatter.Deserialize(fs);
                    //create an associative array with the filename being the key
                    //and the item being the array.  let the key be the name of
                    //the folder in the UI (use substring to strip the .mbx off)
                    //Look at System.Collections.Generic.Dictionary
                }
                catch (SerializationException se)
                {
                    MessageBox.Show(se.ToString());
                }
                finally
                {
                    fs.Close();
                }

            }
            /*

            // open a stream to the mailbox file on the system
            FileStream fst = new FileStream(Application.UserAppDataPath + "\\Inbox.mbx", FileMode.OpenOrCreate);

            try
            {
                // create the formatter to interpret the serialized object on the system
                BinaryFormatter formattter = new BinaryFormatter();
                inbox = (ArrayList)formattter.Deserialize(fst);
            }
            catch (SerializationException se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                fst.Close();
            }
            */
        //}

        /* this method loads up the message list with the supplied mailbox array */
        /*private void loadMessageList(ArrayList mailbox)
        {
            messageList.Items.Clear();
            //Populate the message listing from the inbox array
            foreach (ArrayList msg in mailbox)
            {
                messageList.Items.Add((ListViewItem)msg[0]);
            }
        }
    */
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