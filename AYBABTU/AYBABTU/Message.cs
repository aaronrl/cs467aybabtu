using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AYBABTU
{
    /* Class to handle the contents of individual messages */
    class Message
    {
        private string to;
        private string from;
        private string cc;
        private string bcc;
        private string subject;
        private string messageBody;

        public Message()
        {
            to = "";
            from = "";
            cc = "";
            bcc = "";
            subject = "";
            messageBody = "";
        }

        public Message(string pTo, string pFrom, string pCC, string pBCC, string pSubject, string pMessageBody)
        {
            to = pTo;
            from = pFrom;
            cc = pCC;
            bcc = pBCC;
            subject = pSubject;
            messageBody = pMessageBody;
        }
        #region Accessor and Mutator Methods

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public string From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public string CC
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }

        public string BCC
        {
            get
            {
                return bcc;
            }
            set
            {
                bcc = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public string MessageBody
        {
            get
            {
                return messageBody;
            }
            set
            {
                messageBody = value;
            }
        }
        #endregion
    }
}
