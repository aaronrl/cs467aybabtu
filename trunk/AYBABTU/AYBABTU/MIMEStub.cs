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
            Message[] messages = new Message[10];

            for (int i = 0; i < 10; i++)
            {
                messages[i] = new Message("Aaron@mail.com", "Test@mail.com", "This is a test message: " + i, "Hello!  I am a test message for this program!  I hope you like me!");
            }

            return messages;
        }
    }
}
