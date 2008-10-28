using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    [Serializable]
    class Account
    {
        private string accountName;
        public AccountInfo accountInfo;
        SortedDictionary<string, Mailbox> accountMailboxes = new SortedDictionary<string, Mailbox>();

        public Account(string name)
        {
            accountName = name;
            accountInfo = new AccountInfo();
            accountMailboxes["Inbox"] = new Mailbox("Inbox");
            accountMailboxes["Outbox"] = new Mailbox("Outbox");
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
            get
            {
                return accountName;
            }
        }

        public ListViewItem returnTreeViewItems()
        {
            
            return null;
        }

        public void checkForNewMessages()
        {
            // spawn a pop handler to get messages and pass them on to the MIME handler
            // all new messages will be put into mailboxes[0]
        }

        public void addNewMailbox(string name)
        {
            accountMailboxes[name] = new Mailbox(name);
        }

        public void deleteMailbox(string name, int index)
        {
            //confirm deletion, possibly prompt to move messages to a different folder
            //delete mailbox
        }

    }
}
