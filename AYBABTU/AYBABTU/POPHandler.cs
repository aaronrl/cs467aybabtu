﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Net.Security;

namespace AYBABTU
{
    class POPHandler
    {
        private static int PORT = 110;
        private static int BUFFERSIZE = 512;
        private static string CRLF = "\r\n";

        private string username;
        private string password;
        private string serverName;


        private Stream stream;
        private SslStream sslStream;
        private StreamReader reader;
        private StreamWriter writer;
        private byte[] buffer;
        private int serverPort;

        private bool ssl;

        private string response;
        private bool readerror;
        private bool writeerror;
        private bool streamerror;

        private string[] messages;

        public POPHandler(string serverHostName, string userName, string userPassword)
        {
            ssl = false;
            buffer = new byte[BUFFERSIZE];
            serverName = serverHostName;
            username = userName;
            password = userPassword;
        }

        public POPHandler(string serverHostName, string userName, string userPassword, int serverport)
        {
            ssl = true;
            buffer = new byte[BUFFERSIZE];
            serverName = serverHostName;
            username = userName;
            password = userPassword;
            serverPort = serverport;

        }

        //returns: 0 = could not connect to server
        // 1 = success
        // 2 = invalid username/password combo
        // 3 = stream connection error
        // 4 = write error
        // 5 = read error
        // 6 = problem retrieving/deleting message from server
        // 7 = unknown error
        public int run()
        {
            response = null;
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

                //authentication failed.
                if (auth != 1)
                    return auth;

                return transaction();

                return 1;
            }
            catch (Exception e)
            {
                if (streamerror)
                    return 3;
                if (writeerror)
                    return 4;
                if (readerror)
                    return 5;

                return 7;
            }
        }



        //returns: 1 = success
        // 2 = invalid username/password combo
        private int authorization()
        {
            //try the USER and PASS mechanism
            write("USER " + username);
            read();
            //either username doesnt exist or the server doesnt use this authentication method
            //UNCONFIRMED. cannot find a server that uses apop
            if (response.Contains("-ERR"))
            {
                int start;
                int end;
                
                start = response.IndexOf('<');
                end = response.IndexOf('>');
                //if it doesnt support APOP, then the username was invalid
                if (start == -1 || (end < start))
                    return 2;



                string timestamp = response.Substring(start, end - start + 1);

                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(timestamp + password);
                data = x.ComputeHash(data);
                string hash = "";
                for (int i = 0; i < data.Length; i++)
                    hash += data[i].ToString("x2").ToLower();
                write("APOP " + username + " " + hash);
                read();
                //check to see if we were successful
                if (!response.Contains("+OK"))
                {
                    disconnect();
                    return 2;
                }

            }
            else
            //the server does use this authentication method
            {

                write("PASS " + password);
                read();
                //invalid username/password combo.
                //also possible if it is unable to lock maildrop
                if (response.Contains("-ERR"))
                {
                    disconnect();
                    return 2;
                }





            }
            //authentication successful.

            return 1;



        }

        private int transaction()
        {
            write("STAT ");
            read();
            string[] stats = response.Split(new char[] { ' ' });
            int num = Convert.ToInt32(stats[1]);
            int i = 1;
            messages = new string[num];
            string message;
            while (i <= num)
            {
                message = "";
                write("RETR " + i);
                read();
                //somthing unexpected has happened, just ignore this message
                if (response.Contains("-ERR"))
                {
                    return 6;

                }
                else
                {


                    //first line is just +OK or -ERR (and other junk, none of the message)
                    //start at the second line
                    read();

                    //there is still more to the message
                    while (!response.Equals("."))
                    {
                        message = message + "\n" + response;
                        read();
                    }
                    messages[i - 1] = message;
                  
                    //write("DELE " + i);
                    //somthing unexpected has happened, just ignore this message.
                    if (response.Contains("-ERR"))
                    {
                        return 6;

                    }
                }
                i++;
            }
            i = 0;
            write("BYE");
            disconnect();

            return 1;
        }




        private void getStreamsNonSSL()
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
                streamerror = true;
            }

        }
        private void getStreamsSSL(int port)
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
                streamerror = true;
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
                readerror = true;
            }

            if (response == null)
                readerror = true;
        }

        private void write(String write)
        {
            try
            {
                writer.Write(write + CRLF);
                writer.Flush();

            }
            catch (Exception e)
            {
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

        public string[] getMessages()
        {
            return messages;
        }


    }

}


