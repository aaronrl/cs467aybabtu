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
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            Regex reStrict = new Regex(pattern);

            // Going through each message
            for (int i = 0; i < incomingMessages.Length; i++)
            {
                tempMessage = new Message();
                MessageContents = incomingMessages[i].Split('\n');

                //get the UID.
                if (MessageContents[0].StartsWith("UID", true, null))
                {
                    UIDnumber = int.Parse(MessageContents[0].Substring(4).Trim());
                    tempMessage.UID = UIDnumber;
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

                    if (MessageContents[j].Contains(@"Content-Type:"))
                    {
                        if (MessageContents[j].Contains("multipart"))
                        {
                            //do boundary stuff...hell, I don't remember
                            return messages;
                        }
                        //email doesn't contain any nice stuff
                        else if (MessageContents[j].Contains(@"text/plain"))
                        {
                            String bodyStr = "";
                            int original = j;
                            //the start of the body is at line j+3

                            while (MessageContents[original] != "")
                            {
                                original++;
                            }

                            original++;

                            while (original < MessageContents.Length)
                            {
                                if (MessageContents[original] == "")
                                {
                                    bodyStr += "\n\n";
                                }
                                else
                                {
                                    bodyStr += MessageContents[original];
                                }
                                original++;
                            }

                            tempMessage.MessageBody = bodyStr.Trim();
                        }
                    }

                    messages[i] = tempMessage;
                }
            }//end of for loop

            return messages;

        }// end of main
       /* public static string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }*/
    }
}