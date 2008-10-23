using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Net.Security;

namespace IMAP
{
    class IMAPHandler
    {
        static int PORT = 110;
        static int BUFFERSIZE = 512;
        static string CRLF = "\r\n";

        string username;
        string password;
        string serverName;


        Stream stream;
        SslStream sslStream;
        StreamReader reader;
        StreamWriter writer;
        byte[] buffer;
        int serverPort;

        bool ssl;

        string response;
        bool readerror;
        bool writeerror;
        bool streamerror;

        static void Main(string[] args)
        {

            IMAPHandler IMAP = new IMAPHandler("IMAP.student.gvsu.edu", "blah", "");
            IMAP.run();
            IMAPHandler IMAP2 = new IMAPHandler("IMAP.student.gvsu.edu", "paslasks", "");
            IMAP2.run();
            IMAPHandler IMAP3 = new IMAPHandler("IMAP.student.gvsu.edu", "paslasks", "");
            IMAP3.run();
            IMAPHandler IMAP0 = new IMAPHandler("mail.i2k.com", "", "");
            IMAP0.run();
            IMAPHandler IMAPssl = new IMAPHandler("IMAP.gmail.com", "aaaaaabbahasdiasllkasdjdnsainklas", "", 995);
            IMAPssl.run();
            IMAPHandler IMAPssl2 = new IMAPHandler("IMAP.gmail.com", "paslasks@gmail.com", "", 995);
            IMAPssl2.run();
            Console.WriteLine("END");
            Console.ReadLine();
        }

        IMAPHandler(string serverHostName, string userName, string userPassword)
        {
            ssl = false;
            buffer = new byte[BUFFERSIZE];
            serverName = serverHostName;
            username = userName;
            password = userPassword;
        }

        IMAPHandler(string serverHostName, string userName, string userPassword, int serverport)
        {
            ssl = true;
            buffer = new byte[BUFFERSIZE];
            serverName = serverHostName;
            username = userName;
            password = userPassword;
            serverPort = serverport;

        }

        //returns:  0 = could not connect to server
        //          1 = success
        //          2 = invalid username/password combo
        //          3 = maildrop already locked
        //          4 = read error
        //          5 = write error
        //          6 = unknown error
        //          7 = stream connection error
        private int run()
        {
            readerror = false;
            writeerror = false;
            streamerror = false;
            try
            {

                if (!ssl)
                    getStreamsNonSSL();
                else
                    getStreamsSSL(serverPort);

                //see if successfully connected to server.
                read();
                if (response.Contains("-ERR"))
                {
                    return 0;
                }


                if (username.Length > 100 || password.Length > 100)
                    return 1;
                int auth = authorization();
                Console.WriteLine("auth = " + auth);

                if (auth != 0)
                    return auth;

                return 1;
            }
            catch (Exception e)
            {
                if (readerror)
                    return 4;
                if (readerror)
                    return 4;
                if (streamerror)
                    return 5;

                return 5;
                e.ToString();
            }
        }



        //private Boolean connect(


        //returns:  1 = success
        //          2 = invalid username/password combo
        //          3 = maildrop already locked
        int authorization()
        {
            //try the USER and PASS mechanism
            write("USER " + username + CRLF);
            read();
            //either username doesnt exist or the server doesnt use this authentication method
            //UNCONFIRMED.  cannot find a server that uses aIMAP
            if (response.Contains("-ERR"))
            {
                int start;
                int end;
                /*
                bool done = false;
                string partialts = response;
                while(!done){
                    string partialts2;

                    start = partialts.IndexOf('<');
                    //if it doesnt support AIMAP, then the username was invalid
                    if(start == -1)
                        return 2;

                    partialts = response.Substring(start+1);
                    //check to see that there are no more <'s before the end of the timestamp
                    int start2 = partialts.IndexOf('<');
                    int mid1 = partialts.IndexOf('@');
                    partialts2 = partialts.Substring(mid1);
                    int mid2 = partialts2.Substring('.');
                    end = partialts.IndexOf('>');
                    if(!(end > start2))
                    {
                        if(
                }
                            */
                start = response.IndexOf('<');
                end = response.IndexOf('>');
                //if it doesnt support AIMAP, then the username was invalid
                if (start == -1 || (end < start))
                    return 2;



                string timestamp = response.Substring(start, end - start + 1);

                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(timestamp + password);
                data = x.ComputeHash(data);
                string hash = "";
                for (int i = 0; i < data.Length; i++)
                    hash += data[i].ToString("x2").ToLower();
                write("AIMAP " + username + " " + hash);
                read();
                //check to see if we were successful
                if (!response.Contains("+OK"))
                {
                    return 2;
                }

            }
            else
            //the server does use this authentication method
            {

                write("PASS " + password + CRLF);
                read();
                //invalid username/password combo.  
                //also possible if it is unable to lock maildrop 
                if (response.Contains("-ERR"))
                {
                    disconnect();
                    Console.WriteLine("closed");
                    //if it is because maildrop is locked (it probably has one of these words)
                    if (response.ToLower().Contains("maildrop") || response.ToLower().Contains("lock"))
                        return 3;
                    return 2;
                }





            }
            //authentication successful.

            return 1;



        }




        public void getStreamsNonSSL()
        {
            try
            {

                TcpClient client = new TcpClient(serverName, PORT);
                stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error connecting to server");
            }

        }
        public void getStreamsSSL(int port)
        {
            try
            {
                TcpClient client = new TcpClient(serverName, port);
                sslStream = new SslStream(client.GetStream());
                sslStream.AuthenticateAsClient(serverName);
                reader = new StreamReader(sslStream);
                writer = new StreamWriter(sslStream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error connecting to server using ssl");
            }

        }

        private void read()
        {
            try
            {

                response = reader.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error reading from server");
                readerror = true;
            }
            con();

            if (response == null)
                readerror = true;
        }

        private void write(String write)
        {
            Console.WriteLine(write);
            try
            {
                writer.Write(write);
                writer.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error sending to server");
                writeerror = true;
            }
        }

        private void disconnect()
        {
            if (!ssl)
            {
                stream.Close();
                stream.Dispose();
                return;
            }
            sslStream.Close();
            sslStream.Dispose();

        }
        private void con()
        {
            Console.WriteLine(response);
        }


    }

}



