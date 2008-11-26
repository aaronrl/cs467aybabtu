using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    [Serializable]
    public class Account
    {
        private string accountName;
        public AccountInfo accountInfo = new AccountInfo();
        public SortedDictionary<string, Mailbox> accountMailboxes = new SortedDictionary<string, Mailbox>();

        public Account()
        {
            accountName = "Temp";
            accountInfo = new AccountInfo();
            accountMailboxes["Inbox"] = new Mailbox("Inbox");
            accountMailboxes["Outbox"] = new Mailbox("Outbox");
            accountMailboxes["Trash"] = new Mailbox("Trash");
            accountMailboxes["Sent"] = new Mailbox("Sent");
            accountMailboxes["Drafts"] = new Mailbox("Drafts");
        }

        public Account(string name)
        {
            accountName = name;
            accountInfo = new AccountInfo();
            accountMailboxes["Inbox"] = new Mailbox("Inbox");
            accountMailboxes["Outbox"] = new Mailbox("Outbox");
            accountMailboxes["Trash"] = new Mailbox("Trash");
            accountMailboxes["Sent"] = new Mailbox("Sent");
            accountMailboxes["Drafts"] = new Mailbox("Drafts");
        }

        public Account(string name, AccountInfo info, SortedDictionary<string, Mailbox> mailboxes)
        {
            accountName = name;
            accountInfo = info;
            accountMailboxes = mailboxes;
        }

        public string AccountName
        {
            // used for heading in tree view
            get
            {
                return accountName;
            }
        }

        public TreeNode returnTreeNode()
        {
            // return listing of mailboxes for this account
            TreeNode[] nodes = new TreeNode[5];
            
            nodes[0] = new TreeNode("Inbox");
            nodes[1] = new TreeNode("Outbox");
            nodes[2] = new TreeNode("Trash");
            nodes[3] = new TreeNode("Sent");
            nodes[4] = new TreeNode("Drafts");

            // adding context menu to trash folder
            //nodes[2].ContextMenu = ;

            TreeNode node = new TreeNode(accountName, nodes);
            
            return node;
        }

        public Mailbox getMailbox(string mailbox)
        {
            Mailbox retval = accountMailboxes[mailbox];
            return retval;
        }

        public bool emptyTrash()
        {
            accountMailboxes["Trash"] = new Mailbox("Trash");
            return true;
        }

        public void checkForNewMessages()
        {
            // spawn a pop handler to get messages and pass them on to the MIME handler
            // all new messages will be put into mailboxes[0]
            // take output from IMAP/POP Handler and pass to MIME handler then pass to receive
            Message[] incomingMessages;

            /* commenting out for testing purposes
            if (accountInfo.IncomingServer == AccountInfo.ServerType.POP)
            {
                POPHandler handler;
                if (accountInfo.IncomingSSL)
                {
                    handler = new POPHandler(accountInfo.IncomingServer, accountInfo.IncomingUsername, accountInfo.IncomingPassword, accountInfo.IncomingPort);
                }
                else
                {
                    handler = new POPHandler(accountInfo.IncomingServer,accountInfo.IncomingUsername, accountInfo.IncomingPassword);
                }
                // run() returns the array, not getMessage, fix
                string[] messages = handler.run();
              // check for errors
                int error = handler.getErrorCode();
               if( error == POPHandler.SUCCESS){
                    foreach (string message in messages)
                    {
                        incomingMessages = MIMEStub.returnMessages(message);
                    }
               }else{
                    //USERPASSERROR = 1;
                    //STREAMERROR = 2;
                    //WRITEERROR = 3;
                    //READERROR = 4;
                    //COMMUNICATIONERROR = 5;
                    //UNKNOWNERROR = 6;
                    switch(error){
                        case 1: MessageBox.Show("Username/Password Error"); break;
                        case 2: MessageBox.Show("Problem Connecting to server"); break;
                        case 3: MessageBox.Show("Problem writing to socket"); break;
                        case 4: MessageBox.Show("Problem reading from socket"); break;
                        case 5: MessageBox.Show("Unknown communication response from server"); break;
                        case 6: MessageBox.Show("Unknown error with POP server"); break;
              
                    }
             
               }
            }
            else if (accountInfo.IncomingServer == AccountInfo.ServerType.IMAP)
            {
                // there will be only one folder accessible to an IMAP acccount (INBOX).  deletions will occur immediately
            }
            */

            // ****BEGIN TEST CODE****
            string[] test = { "test", "test", "test" };
            incomingMessages = MIMEStub.returnMessages(test);
            // ****END TEST CODE****

            depositNewMessagesInInbox(incomingMessages);
        }

        private void depositNewMessagesInInbox(Message[] newMessages)
        {
            foreach (Message msg in newMessages)
            {
                accountMailboxes["Inbox"].addMessage(msg);
            }
        }

        /*
         * not doing this right now
        public void addNewMailbox(string name)
        {
            accountMailboxes[name] = new Mailbox(name);
        }

        public void deleteMailbox(string name, int index)
        {
            //confirm deletion, possibly prompt to move messages to a different folder
            //delete mailbox
        }
        */
    }
}
