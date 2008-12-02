using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AYBABTU
{
    class MIMEStub
    {
        public MIMEStub()
        {
        }

        public static Message[] returnMessages(string[] incomingMessages)
        {
<<<<<<< .mine
            Message[] messages = new Message[incomingMessages.Length()];
            String[] MessageContents;
            Message tempMessage;
            int count;
=======
            Message[] messages = new Message[incomingMessages.Length];
>>>>>>> .r88

<<<<<<< .mine
            // Going through each message
            for (int i = 0; i < incomingMessages.Length(); i++)
=======
            for (int i = 0; i < incomingMessages.Length; i++)
>>>>>>> .r88
            {
<<<<<<< .mine
                MessageContents = incomingMessages[i].Split('\n');

                //get to, from, subject, date, and cc fields
                for (int j = 0; j < MessageContents.Length(); j++)
                {
                    if(MessageContents[j].Substring(0,3).Equals("To:"))
                    {
                        
                    }
                    if (MessageContents[j].Substring(0, 3).Equals("CC:"))
                    {

                    }
                    if (MessageContents[j].Substring(0, 5).Equals("From:"))
                    {

                    }
                    if (MessageContents[j].Substring(0, 5).Equals("Date:"))
                    {

                    }
                    if (MessageContents[j].Substring(0, 8).Equals("Subject:"))
                    {

                    }
                }
=======
                //messages[i] = new Message("Aaron@mail.com", "Test@mail.com", "This is a test message: " + i, "Hello! \nI am a test message for this program! \nI hope you like me!");
                messages[i] = new Message();
                messages[i].RawMessage = incomingMessages[i];
                messages[i].MessageBody = incomingMessages[i];
                messages[i].Subject = "Test " + i;
                messages[i].From = "test" + i + "@test.com";
                messages[i].Date = "11/11/1111";
>>>>>>> .r88
            }

            return messages;
        }
    }
}
