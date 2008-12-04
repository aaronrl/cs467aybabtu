using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace AYBABTU
{
    class SMTP
    {
        string server;
        int port;
        string username;
        string password;
        bool authentication;

        public SMTP(string pServer, int pPort)
        {
            server = pServer;
            port = pPort;
            authentication = false;
        }
        
        public SMTP(string pServer, int pPort, string pUsername, string pPassword)
        {
            server = pServer;
            port = pPort;
            username = pUsername;
            password = pPassword;
            authentication = true; ;
        }
        
        public void sendMessage(Message msg)
        {
            
            SmtpClient client = new SmtpClient(server, port);
            if (authentication)
            {
                client.Credentials = new System.Net.NetworkCredential(username, password);
            }
            client.Send(msg.getMailMessage());
        }
        
    }
}
