﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        tempMessage.To = tmpStr.Trim();
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
                        tempMessage.CC = tmpStr.Trim();
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
                        tempMessage.BCC = tmpStr.Trim();
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
                        tempMessage.From = tmpStr.Trim();
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
                        char[] tmpChr = MessageContents[j].Substring(10).ToCharArray();
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


                }
                messages[i] = tempMessage;
            }

            return messages;
        }
    }
}