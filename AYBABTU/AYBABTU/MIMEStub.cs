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
            Message[] messages = new Message[incomingMessages.Length];

            for (int i = 0; i < incomingMessages.Length; i++)
            {
                //messages[i] = new Message("Aaron@mail.com", "Test@mail.com", "This is a test message: " + i, "Hello! \nI am a test message for this program! \nI hope you like me!");
                messages[i] = new Message();
                messages[i].RawMessage = incomingMessages[i];
                messages[i].MessageBody = incomingMessages[i];
                messages[i].Subject = "Test " + i;
                messages[i].From = "test" + i + "@test.com";
                messages[i].Date = "11/11/1111";
            }

            return messages;
        }
    }
}
