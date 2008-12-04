using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace AYBABTU
{
    class MessageParser
    {
        # region returnMessages
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
                String bodyStr = "";
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
                        if (incomingMessages[i].Contains("multipart"))
                        {
                            //do boundary stuff...hell, I don't remember

                            int original = j;

                            while (MessageContents[original] != "")
                            {
                                original++;
                            }
                            while (original < MessageContents.Length && (!MessageContents[original].Contains(@"text/plain")))
                            {
                                original++;
                            }
                            while (original < MessageContents.Length && (!MessageContents[original].Contains("------=")))
                            {
                                if (original < MessageContents.Length && (!MessageContents[original].Contains("Content-")))
                                {
                                    bodyStr += MessageContents[original];

                                }
                                original++;
                            }

                            tempMessage.MessageBody = bodyStr.Trim();
                            if (MessageContents[j + 3].Contains("attachment"))
                            {
                                tempMessage.addAttach(grabAttachmentData(incomingMessages[i]));
                            }
                        }
                        //email doesn't contain any multipart
                        else if (MessageContents[j].Contains(@"text/plain"))
                        {

                            int original = j;

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
                }
                messages[i] = tempMessage;
            }//end of for loop

            return messages;

        }// end of main
        #endregion

        public static Attachment grabAttachmentData(String incomingMessages2)
        {

            String[] attachmentEmail = { };
            Attachment fileattach = null;
            String tempFileName = "";
            String fileName;
            String attachData = "";

     //       if (incomingMessages2.Length > 0)
    //        {

                    attachmentEmail = incomingMessages2.Split('\n');

                for (int b = 0; b < attachmentEmail.Length; b++)
                {
                    if (attachmentEmail[b].Contains("Content-Disposition: attachment;"))
                    {
                        int startHere = b;

                        //trying to avoid an error here
                        //basically, it starts where it says there's an attachment, and then looks for the name of the attachment
                        while (!attachmentEmail[startHere].Contains("filename") && startHere < attachmentEmail.Length)
                        {
                            startHere++;
                        }

                        
                        fileName = attachmentEmail[startHere].Trim();
                        //replace the word filename with nothing
                        fileName = fileName.Replace("filename=", "");
                        fileName = fileName.Replace("Content-Disposition: attachment;", "");
                        fileName = fileName.Trim();

                        char[] remove = fileName.ToCharArray();

                        for (int c = 0; c < remove.Length; c++)
                        {
                            if (!remove[c].Equals('\"'))
                            {
                                tempFileName += remove[c];
                            }

                        }
                        fileName = tempFileName;
                        //We now have the filename, now, we need the attachment details

                        
                        startHere++;
                        while (startHere < attachmentEmail.Length - 1)
                        {
                            if (!attachmentEmail[startHere].Contains("------="))
                            {
                                attachData += attachmentEmail[startHere];
                                startHere++;
                            }
                            else
                                startHere = attachmentEmail.Length + 12;
                        }

                        attachData = attachData.Trim();
                        fileattach = new Attachment(attachData, tempFileName);
                    }
             //   }
                    
            }
                return fileattach;
        }//end of get attachment data

    }
}