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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace AYBABTU
{
    public partial class Main : Form
    {
        Accounts accounts;

        public Main()
        {
            InitializeComponent();
        }

        #region Events

        #region Buttons
        private void getMessageBtn_Click(object sender, EventArgs e)
        {
            if (accounts != null)
            {
                AccountChecker checker = new AccountChecker(accounts.EmailAccounts);
                int step;
                try
                {
                    step = 100 / accounts.EmailAccounts.Length;
                }
                catch (DivideByZeroException error)
                {
                    step = 100;
                }
                MailChecker window = new MailChecker(checker, step);
                window.Show();
                checker.checkMessages();
                accounts.EmailAccounts = checker.accountsToCheck;
                window.Close();
                window.Dispose();
                try
                {
                    ListViewItem[] msglist = accounts.findAccountByName(folderList.SelectedNode.Parent.Text).getMailbox(folderList.SelectedNode.Text).getMessageList();
                    loadMessageList(msglist);
                }
                catch (NullReferenceException error)
                {
                }
            }
        }

        private void writeMessageBtn_Click(object sender, EventArgs e)
        {
            string selectedAccount = folderList.SelectedNode.Parent.Text;
            WriteWindow writedow = new WriteWindow(accounts.findAccountByName(selectedAccount).accountInfo.EmailAddress);
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

            accounts.findAccountByName(selectedAccount).deleteMessage(selectedMailbox, indices[0]);

            ListViewItem[] msglist = accounts.findAccountByName(selectedAccount).getMailbox(selectedMailbox).getMessageList();
            loadMessageList(msglist);
        }
        #endregion  

        #region Menu Items
        private void aboutAYBABTUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }

        private void emailAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsWindow accountsWindow = new AccountsWindow(accounts);
            accountsWindow.ShowDialog();
            // implementing the observer pattern here for asynchronous updates of the UI
            accounts = accountsWindow.currentAccounts;
            folderList.SuspendLayout();
            folderList.Nodes.Clear();
            folderList.Nodes.AddRange(accounts.getTreeViewOfAccounts());
            folderList.ExpandAll();
            if (accounts.EmailAccounts.Length > 0)
            {
                folderList.SelectedNode = folderList.Nodes[0].FirstNode;
                loadMessageList(accounts.findAccountByName(folderList.SelectedNode.Parent.Text).getMailbox(folderList.SelectedNode.Text).getMessageList());
            }
            else
            {
                loadMessageList(new ListViewItem[0]);
            }
            folderList.ResumeLayout();

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

        #region main form events
        private void Main_Load(object sender, EventArgs e)
        {
            //Splashscreen splash = new Splashscreen();
            //splash.Show();
            
            // load up accounts from system
            accounts = loadAccounts();

            // synchronize all imap accounts
            for (int i = 0; i < accounts.EmailAccounts.Length; i++)
            {
                if (accounts.accounts[i].accountInfo.IncomingServerType == AccountInfo.ServerType.IMAP)
                {
                    accounts.accounts[i].initializeIMAPHandler();
                }
            }


            // populate folder list
            folderList.Nodes.AddRange(accounts.getTreeViewOfAccounts());
            folderList.ExpandAll();
            folderList.SelectedNode = folderList.Nodes[0].FirstNode;                        
            
            // load the first message into the message viewer
            //messageViewer.Text = ((Message)((ArrayList)inbox[0])[1]).MessageBody;
            
            // add double click functionality to the message list
            messageList.MouseDoubleClick += new MouseEventHandler(messageList_MouseDoubleClick);

            
            //Thread.Sleep(2000);
            //splash.Close();
            //splash.Dispose();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            for (int i = 0; i < accounts.EmailAccounts.Length; i++)
            {
                if (accounts.accounts[i].accountInfo.IncomingServerType == AccountInfo.ServerType.IMAP)
                {
                    accounts.accounts[i].imap.logout();
                    accounts.accounts[i].resetUIDs();
                    accounts.accounts[i].imap = null;
                }
            }
            saveAccounts();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        #endregion

        private void saveAccounts()
        {
           // this method takes the inbox array and serializes it to a file on the system 
            FileStream fs = new FileStream(Application.UserAppDataPath + "\\accounts.accts", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, accounts);
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
        
        private Accounts loadAccounts()
        {
            // http://blog.paranoidferret.com/index.php/2008/05/13/c-snippet-tutorial-get-file-listings/
            // http://www.csharpfriends.com/Articles/getArticle.aspx?articleID=356
            // http://www.google.com/search?sourceid=chrome&ie=UTF-8&q=getting+a+directory+listing+in+c%23
            
            FileStream fst = new FileStream(Application.UserAppDataPath + "\\accounts.accts", FileMode.OpenOrCreate);
            Accounts loadedAccounts;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                object obj = formatter.Deserialize(fst);
                loadedAccounts = (Accounts) obj;
                int i;
                i = 0;
            }
            catch (SerializationException e)
            {
                //MessageBox.Show(e.ToString());
                loadedAccounts = new Accounts();
            }
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //    loadedAccounts = new Accounts();
            //}
            finally
            {
                fst.Close();
            }
            
            return loadedAccounts;
        }

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