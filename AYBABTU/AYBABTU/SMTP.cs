﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
//using System.Web.Mail;
namespace AYBABTU
{
    class SMTP
    {
        public static bool sendMessage(MailMessage msg)
        {
            SmtpClient client = new SmtpClient(Properties.Settings.Default.SMTPServer, Properties.Settings.Default.SMTPServerPort);
            client.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            client.Send(msg);
            return true;
        }
        
    }
}
