﻿using System;
using System.Collections;
using System.Text;
using System.Net.Mail;

namespace AYBABTU
{
    /* Class to handle the contents of individual messages */
    // http://www.ondotnet.com/pub/a/dotnet/2002/08/26/serialization.html
    [Serializable]
    public class Message
    {
        private string to;
        private string toDisplay;
        private string from;
        private string fromDisplay;
        private string cc;
        private string ccDisplay;
        private string bcc;
        private string bccDisplay;
        private string subject;
        private string messageBody;
        private string date;
        private ArrayList attachments;
        private string rawMessage;
        private long uid;

        public Message()
        {
            to = "";
            from = "";
            fromDisplay = "";
            cc = "";
            bcc = "";
            subject = "";
            messageBody = "";
            attachments = new ArrayList();
            rawMessage = "";
            uid = -1;
        }

        public Message(string pTo, string pFrom, string pSubject, string pMessageBody)
        {
            to = pTo;
            from = pFrom;
            subject = pSubject;
            messageBody = pMessageBody;
            cc = "";
            bcc = "";
            uid = -1;
        }

        public Message(string pTo, string pFrom, string pCC, string pBCC, string pSubject, string pMessageBody, string pDate)
        {
            to = pTo;
            from = pFrom;
            cc = pCC;
            bcc = pBCC;
            subject = pSubject;
            messageBody = pMessageBody;
            date = pDate;
            uid = -1;
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

        public string ToDisplay
        {
            get
            {
                return toDisplay;
            }
            set
            {
                toDisplay = value;
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

        public string FromDisplay
        {
            get
            {
                return fromDisplay;
            }
            set
            {
                fromDisplay = value;
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

        public string CCDisplay
        {
            get
            {
                return ccDisplay;
            }
            set
            {
                ccDisplay = value;
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

        public string BCCDisplay
        {
            get
            {
                return bccDisplay;
            }
            set
            {
                bccDisplay = value;
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

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public string RawMessage
        {
            get
            {
                return rawMessage;
            }
            set
            {
                rawMessage = value;
            }
        }

        public long UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        public void addAttach(string path)
        {
            this.attachments.Add(path);
        }

        public void deleteAttach(string path)
        {
            if (this.attachments.Contains(path))
            {
                this.attachments.Remove(path);
            }
        }

        public Boolean hasAttachments(string path)
        {
            if (this.attachments.Count == 0)
                return false;
            else
            {
                return true;
            }
        }


        #endregion

        // return a mailmessage representation of the message for use in the SMTP client
        public MailMessage getMailMessage()
        {
            return (new MailMessage(from, to, subject, messageBody));
        }
    }
}
