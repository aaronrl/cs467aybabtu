using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    [Serializable]
    class Mailbox
    {
        private string name;
        private ArrayList messages;

        public Mailbox(string pName)
        {
            name = pName;
            messages = new ArrayList();
        }

        

        public Message getMessage(int index)
        {
            return (Message) messages[index];
        }

        public Message deleteMessage(int index)
        {
            Message deletedMessage = (Message)messages[index];
            messages.RemoveAt(index);
            return deletedMessage;
        }

        public ListViewItem[] getMessageList()
        {
            ListViewItem[] listing = new ListViewItem[messages.Count];
            for (int i = 0; i < messages.Count; i++)
            {
                Message msg = (Message)messages[i];
                ListViewItem message = new ListViewItem(msg.From);
                message.SubItems.Add(msg.Subject);
                message.SubItems.Add(msg.Date);
                listing[i] = message;
            }
            return listing;
        }

        public void addMessage(Message incomingMessage)
        {
            messages.Add(incomingMessage);
        }

    }
}
