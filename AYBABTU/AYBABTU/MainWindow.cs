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
        Account[] test = new Account[5];
        SortedDictionary<string,ArrayList> folders = new SortedDictionary<string,ArrayList>();
        Accounts accounts;

        public Main()
        {
            InitializeComponent();
        }

        #region Events

        #region Buttons
        private void getMessageBtn_Click(object sender, EventArgs e)
        {
            //MailChecker window = new MailChecker();
            //window.Show();
            accounts.findAccountByName("TEST0").checkForNewMessages();
            ListViewItem[] msglist = accounts.findAccountByName(folderList.SelectedNode.Parent.Text).getMailbox(folderList.SelectedNode.Text).getMessageList();
            loadMessageList(msglist);
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
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            string selectedAccount = folderList.SelectedNode.Parent.Text;
            string selectedMailbox = folderList.SelectedNode.Text;
            Message replyMessage = accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessage(indices[0]);
                //(Message)((ArrayList)inbox[indices[0]])[1];
            replyMessage.Subject = "RE: " + replyMessage.Subject;

            WriteWindow replyToMessageWindow = new WriteWindow(new Message(replyMessage.From, accounts.findAccountByName(selectedAccount).accountInfo.EmailAddress, replyMessage.Subject, replyMessage.MessageBody));
            replyToMessageWindow.Show();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            // access root for selected account
            string selectedAccount = folderList.SelectedNode.Parent.Text;
            string selectedMailbox = folderList.SelectedNode.Text;
            Message forwardMessage = accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessage(indices[0]);
            forwardMessage.Subject = "FWD: " + forwardMessage.Subject;

            WriteWindow forwardMessageWindow = new WriteWindow(new Message(forwardMessage.From, accounts.findAccountByName(selectedAccount).accountInfo.EmailAddress, forwardMessage.Subject, forwardMessage.MessageBody));
            forwardMessageWindow.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            string selectedAccount = folderList.SelectedNode.Parent.Text;
            string selectedMailbox = folderList.SelectedNode.Text;

            // delete message and move it to trash  *** INSERT CODE FOR IMAP DELETE ***
            try
            {
                Message deletedMessage = accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).deleteMessage(indices[0]);
                if (accounts.findAccountByName(selectedAccount).accountInfo.IncomingServerType == AccountInfo.ServerType.POP)
                {
                    accounts.findAccountByName(selectedAccount).getMailbox("Trash").addMessage(deletedMessage);
                }
                
                
            }
            catch (Exception exception)
            {
            }

            ListViewItem[] msglist = accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessageList();
            loadMessageList(msglist);
        }
        #endregion  

        #region Menu Items
        private void aboutAYBABTUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.Show();
        }

        private void emailAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EmailAccountsWindow accountsWindow = new EmailAccountsWindow();
            //accountsWindow.EmailAccounts = accounts.EmailAccounts;
            AccountsWindow accountsWindow = new AccountsWindow(accounts);
            accountsWindow.Show();
            //accounts.EmailAccounts = accountsWindow.EmailAccounts;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Interaction Events
        private void messageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            string selectedAccount = folderList.SelectedNode.Parent.Text;
            string selectedMailbox = folderList.SelectedNode.Text;

            //foreach (int index in indices)
            {
                // gets the selected message from the message list and sets its body to the viewer
                messageViewer.Text = ((Message) accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessage(indices[0])).MessageBody;
                subjectLbl.Text = ((Message)accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessage(indices[0])).Subject;
                fromLbl.Text = ((Message)accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessage(indices[0])).From;
            }

        }

        private void messageList_MouseDoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = messageList.SelectedIndices;
            string selectedAccount = folderList.SelectedNode.Parent.Text;
            string selectedMailbox = folderList.SelectedNode.Text;
            ReadWindow readSelectedMessage = new ReadWindow((Message) accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessage(indices[0]));
            readSelectedMessage.Show();
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
            if (folderList.SelectedNode.Level == 0)
            {
                folderList.SelectedNode = folderList.SelectedNode.FirstNode;
            }
            loadMessageList(accounts.findAccountByName(folderList.SelectedNode.Parent.Text).getMailbox(folderList.SelectedNode.Text).getMessageList());
        }

        #endregion

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            AccountInfo tmpinfo = new AccountInfo("cs467@i2k.com", AccountInfo.ServerType.POP, "mail.i2k.com", 110, "cs467", "cs467", false, "mail.i2k.com", 25, AccountInfo.AuthenticationType.Password, false, "cs467", "qu@RTZ", false);

            test[0] = new Account("TEST0");
            test[0].accountInfo = tmpinfo;

            test[1] = new Account("TEST1");
            test[2] = new Account("TEST2");
            test[3] = new Account("TEST3");
            test[4] = new Account("TEST4");

            accounts = new Accounts(test);
            
            // populate folder list
            folderList.Nodes.AddRange(accounts.getTreeViewOfAccounts());
            folderList.ExpandAll();
            folderList.SelectedNode = folderList.Nodes[0].FirstNode;                        
            
            /*
            Splashscreen splash = new Splashscreen();
            splash.Show();
            */

            //loadAccounts();

            
            /*loadMailboxesFromSystem();
            loadMessageList(inbox);
            */

            // need to load the tree listing
            // need to load UI elements for each folder

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
        private void loadMessageList(ListViewItem[] messages)
        {
            // use getMessageList() of the Mailbox class
            messageList.Items.Clear();
            //Populate the message listing from the inbox array
            messageList.Items.AddRange(messages);
        }
    
    }
}