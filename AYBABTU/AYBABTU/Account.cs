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
        private Mailbox[] accountMailboxes;

        public Account(string name)
        {
            accountName = name;
            accountInfo = new AccountInfo();
            accountMailboxes[0] = new Mailbox("Inbox");
            accountMailboxes[1] = new Mailbox("Outbox");
            accountMailboxes[2] = new Mailbox("Sent");
            accountMailboxes[3] = new Mailbox("Drafts");
        }

        public Account(string name, AccountInfo info, Mailbox[] mailboxes)
        {
            accountName = name;
            accountInfo = info;
            accountMailboxes = mailboxes;
        }

        public ListViewItem returnTreeViewItems()
        {

        }

        public void checkForNewMessages()
        {
            // spawn a pop handler to get messages and pass them on to the MIME handler
            // all new messages will be put into mailboxes[0]
        }

        public void addNewMailbox(string name)
        {
            accountMailboxes[accountMailboxes.Length] = new Mailbox(name);
        }

        public void deleteMailbox(string name, int index)
        {
            //confirm deletion, possibly prompt to move messages to a different folder
            //delete mailbox
        }

    }
}
