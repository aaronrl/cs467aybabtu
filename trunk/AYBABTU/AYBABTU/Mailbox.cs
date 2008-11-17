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
        }

        public Message getMessage(int index)
        {
            return messages[index];
        }

        public bool deleteMessage(int index)
        {
            return true;
        }

        public /*ListViewItem*/ void getMessageList()
        {
            for (int i = 0; i < messages.Length; i++)
            {
                Message aMsg = messages[i];
                ListViewItem message = new ListViewItem(aMsg.From);
                message.SubItems.Add(aMsg.Subject);
                message.SubItems.Add(aMsg.Date);

                ArrayList listitem = new ArrayList();
                listitem.Add(message);
                listitem.Add(aMsg);
                //inbox.Add(listitem);
            }
        }

        public void acceptMessage(Message incomingMessage)
        {
            messages.Add(incomingMessage);
        }

    }
}
