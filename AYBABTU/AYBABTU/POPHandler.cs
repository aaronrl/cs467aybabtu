﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Net.Security;

//METHODS
//run: string[] of messages
//getErrorCode: error code
//setDeleteFlag: void
//



namespace AYBABTU
{
    class POPHandler
    {
        #region class variables
        public static int SUCCESS = 0;
        public static int USERPASSERROR = 1;
        public static int STREAMERROR = 2;
        public static int WRITEERROR = 3;
        public static int READERROR = 4;
        public static int COMMUNICATIONERROR = 5;
        public static int UNKNOWNERROR = 6;
        private static int PORT = 110;
        private static string CRLF = "\r\n";

        private string username;
        private string password;
        private string serverName;


        private Stream stream;
        private SslStream sslStream;
        private StreamReader reader;
        private StreamWriter writer;
        private int serverPort;
        private bool deleteflag;

        private bool ssl;

        private string response;
        private bool readerror;
        private bool writeerror;
        private bool streamerror;

        private int error;
        #endregion

        #region constructors
        public POPHandler(string serverHostName, string userName, string userPassword)
        {
            deleteflag = false;
            ssl = false;
            serverName = serverHostName;
            username = userName;
            password = userPassword;
        }

        public POPHandler(string serverHostName, string userName, string userPassword, int serverport)
        {
            deleteflag = false;
            ssl = true;
            serverName = serverHostName;
            username = userName;
            password = userPassword;
            serverPort = serverport;

        }
        #endregion constructors

        #region public interface
        public string[] run()
        {
            error = SUCCESS;
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
                if (streamerror)
                {
                    disconnect();
                    error = STREAMERROR;
                    return null;
                }

                read();

                if (response.Contains("-ERR"))
                {
                    write("QUIT");
                    disconnect();
                    error = COMMUNICATIONERROR;
                    return null;
                }


                if (username.Length > 100 || password.Length > 100)
                {
                    write("QUIT");
                    disconnect();
                    error = USERPASSERROR;
                    return null;

                }
                int auth = authorization();

                //authentication failed.
                if (auth != 0)
                {
                    write("QUIT");
                    disconnect();
                    error = auth;
                    return null;
                }
                error = 0;
                string[] messages = transaction();
                write("QUIT");
                disconnect();
                return messages;

            }
            catch (Exception e)
            {
                if (streamerror)
                    error = STREAMERROR;
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;
                if (error == 0)
                    error = UNKNOWNERROR;
                return null;
            }
        }

        public void setDeleteFlag(bool value)
        {
            deleteflag = value;
        }

        //returns: 0 = success
        // 1 = invalid username/password combo
        // 2 = stream connection error
        // 3 = write error
        // 4 = read error
        // 5 = server communication error
        // 6 = unknown error
        public int getErrorCode()
        {
            return error;
        }
        #endregion


        #region internal methods
        //returns: 0 = success
        //         1 = invalid username/password combo
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
                {
                    return USERPASSERROR;
                }


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
                    return USERPASSERROR;
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
                    return USERPASSERROR;
                }

            }
            //authentication successful.

            return SUCCESS;



        }

        private string[] transaction()
        {
            string[] messages = null;
            write("STAT ");
            read();
            string[] stats = response.Split(new char[] { ' ' });
            int num = int.Parse(stats[1]);
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
                    error = COMMUNICATIONERROR;
                    return messages;

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
                    //strip the first newline
                    message = message.Substring(1);
                    messages[i - 1] = message;

                    if (deleteflag)
                    {
                        write("DELE " + i);
                        //somthing unexpected has happened, just ignore this message.
                        if (response.Contains("-ERR"))
                        {
                            error = COMMUNICATIONERROR;
                            return messages;

                        }
                    }
                }
                i++;
            }
            i = 0;

            return messages;
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
        #endregion
    }

}