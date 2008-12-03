using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AYBABTU
{
    class MessageParser
    {
        public static Message[] returnMessages(string[] incomingMessages)
        {
            Message[] messages = new Message[incomingMessages.Length];
            String[] MessageContents;
            Message tempMessage;
            String tmpStr;
            int UIDnumber = -1;
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
      + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
      + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
      + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
      + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);



            /*
             * Errors to handle: Not a MIME message
             * */

            // Going through each message
            for (int i = 0; i < incomingMessages.Length; i++)
            {
                tempMessage = new Message();
                MessageContents = incomingMessages[i].Split('\n');

                //get the UID.
                if (MessageContents[0].StartsWith("UID", true, null))
                {
                    UIDnumber = int.Parse(MessageContents[0].Substring(4).Trim());
                }

                //get to, from, subject, date, and cc fields
                // check line by line
                for (int j = 0; j < MessageContents.Length; j++)
                {
                    if (MessageContents[j].StartsWith("To:", true, null))
                    {
                        tmpStr = "";
                        char[] tmpChr = MessageContents[j].Substring(3).ToCharArray();
                        for (int k = 0; k < tmpChr.Length; k++)
                        {
                            if (!tmpChr[k].Equals('\"'))
                            {
                                tmpStr += tmpChr[k];
                            }
                        }
                        tempMessage.ToDisplay = tmpStr.Trim();
                        tempMessage.To = reStrict.Match(tmpStr).ToString();
                    }

                    if (MessageContents[j].StartsWith("CC:", true, null))
                    {
                        tmpStr = "";
                        char[] tmpChr = MessageContents[j].Substring(3).ToCharArray();
                        for (int k = 0; k < tmpChr.Length; k++)
                        {
                            if (!tmpChr[k].Equals('\"'))
                            {
                                tmpStr += tmpChr[k];
                            }
                        }
                        tempMessage.CCDisplay = tmpStr.Trim();
                        tempMessage.CC = reStrict.Match(tmpStr).ToString();
                    }
                    if (MessageContents[j].StartsWith("BCC:", true, null))
                    {
                        tmpStr = "";
                        char[] tmpChr = MessageContents[j].Substring(4).ToCharArray();
                        for (int k = 0; k < tmpChr.Length; k++)
                        {
                            if (!tmpChr[k].Equals('\"'))
                            {
                                tmpStr += tmpChr[k];
                            }
                        }
                        tempMessage.BCCDisplay = tmpStr.Trim();
                        tempMessage.BCC = reStrict.Match(tmpStr).ToString();
                    }
                    if (MessageContents[j].StartsWith("From:", true, null))
                    {
                        tmpStr = "";
                        char[] tmpChr = MessageContents[j].Substring(5).ToCharArray();
                        for (int k = 0; k < tmpChr.Length; k++)
                        {
                            if (!tmpChr[k].Equals('\"'))
                            {
                                tmpStr += tmpChr[k];
                            }
                        }
                        tempMessage.FromDisplay = tmpStr.Trim();
                        tempMessage.From = reStrict.Match(tmpStr).ToString();
                    }
                    if (MessageContents[j].StartsWith("Date:", true, null))
                    {
                        tmpStr = "";
                        char[] tmpChr = MessageContents[j].Substring(5).ToCharArray();
                        for (int k = 0; k < tmpChr.Length; k++)
                        {
                            if (!tmpChr[k].Equals('\"'))
                            {
                                tmpStr += tmpChr[k];
                            }
                        }
                        tempMessage.Date = tmpStr.Trim();
                    }
                    if (MessageContents[j].StartsWith("Subject:", true, null))
                    {
                        tmpStr = "";
                        char[] tmpChr = MessageContents[j].Substring(9).ToCharArray();
                        for (int k = 0; k < tmpChr.Length; k++)
                        {
                            if (!tmpChr[k].Equals('\"'))
                            {
                                tmpStr += tmpChr[k];
                            }
                        }
                        tempMessage.Subject = tmpStr.Trim();
                    }
 
                    //Body Time
                    if (MessageContents[j].Contains(@"text/plain"))
                    {
                        String bodyStr = "";
                        int original = j+3;
                        //the start of the body is at line j+3
                        do
                        {
                           bodyStr += MessageContents[original];
                            original++;
                        }
                        while
                        (!MessageContents[original].StartsWith("------=") || MessageContents[original].StartsWith("Content-"));

                        tempMessage.MessageBody = bodyStr.Trim();
                    }

                }
                messages[i] = tempMessage;
            }

            return messages;
        }
    }
}