using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Net.Security;
using System.Collections;





/* 
 * METHODS and return values
 * if method does not return error code, getErrorCode MUST be called and 
 * the returned value must be a NON-1 value before the information is accessed
 * 
 * connect: error code
 * retrieveFolders: string[] of folders
 * retrieveAllMessages: string[] of messages
 * createFolder: error code
 * logout: error code
 * getErrorCode: error code
 * 
 * COMMUNICATIONERROR error communicating with server.  Unexpected response from server.
 *      Invalid arguments passed to method and consequently to server can cause this.
 * 
 * 
 * 
 * 
 * 
 * DO
 * 
 * 
 * getUID's
get all messages in a folder
get a specific message in a folder
get <b> new </b> mesages in a folder
move message
mark as deleted
purge


 * 
 * psudocode for aaron
 * 
 * 
 * 
 * 
 */
namespace AYBABTU
{
    class IMAPHandler
    {
        #region mainstuff

        #region vars
        public static int POSVAL = 0;
        public static int POSEXISTS= 1;


        public static int SUCCESS = 0;
        public static int USERPASSERROR = 1;
        public static int STREAMERROR = 2;
        public static int WRITEERROR = 3;
        public static int READERROR = 4;
        public static int COMMUNICATIONERROR = 5;
        public static int UNKNOWNERROR = 6;
        public static int NONE = 0;
        public static int OK = 1;
        public static int NO = 2;
        public static int BAD = 3;
        public static int OTHER = 4;
        static int PORT = 143;
        static string CRLF = "\r\n";
        static int tagLength = 4;
        static string firstTag = "0000";

        string username;
        string password;
        string serverName;


        Stream stream;
        SslStream sslStream;
        StreamReader reader;
        StreamWriter writer;

        int serverPort;

        bool ssl;

        string response;
        bool readerror;
        bool writeerror;
        bool streamerror;
        bool communicationerror;

        int error;
        long UIDValidity;

        static string previousTag;

        string commandResponse;

        string[] folders;
        string[] messages;

        #endregion 
        

        IMAPHandler(string serverHostName, string userName, string userPassword)
        {
            previousTag = firstTag;
            ssl = false;
            serverName = serverHostName;
            username = userName;
            password = userPassword;
        }

        IMAPHandler(string serverHostName, string userName, string userPassword, int serverport)
        {
            previousTag = firstTag;
            ssl = true;
            serverName = serverHostName;
            username = userName;
            password = userPassword;
            serverPort = serverport;

        }
        #endregion




        #region publicfinished








        //returns:
        //SUCCESS
        //USERPASSERROR
        //STREAMERROR
        //WRITEERROR
        //READERROR
        //COMMUNICATIONERROR
        //UNKNOWNERROR
        public int connect()
        {
            resetErrors();
            try
            {

                if (!ssl)
                    getStreamsNonSSL();
                else
                    getStreamsSSL(serverPort);

                //see if successfully connected to server and get welcome message.
                read();
                if (streamerror)
                    return STREAMERROR;
                if (response.Substring(0, 3).Equals(previousTag + "BYE"))
                {
                    return COMMUNICATIONERROR;
                }
                //If connected, check to see if the server send the CAPABILITY with welcome
                string capability = getCapabilities();
                if (capability == null)
                    return error;
                //try to get authorized
                if (username.Equals("") || password.Equals(""))
                    return USERPASSERROR;
                int logsuccess = login(capability);
                //OK
                //NO
                //BAD
                //OTHER
                if (logsuccess != OK)
                    return error;
                //login succeded so continue





                return SUCCESS;
            }
            catch (Exception e)
            {
                if (writeerror)
                    return WRITEERROR;
                if (readerror)
                    return READERROR;

                return UNKNOWNERROR;
            }
        }

        //returns:
        //SUCCESS
        //WRITEERROR
        //READERROR
        //COMMUNICATIONERROR
        //UNKNOWNERROR
        public string[] retrieveFolders()
        {
            resetErrors();
            string[] folders = null;
            try
            {

                int errorcode = reconnect("LIST \"\" \"*\"");
                //the sesion expired.  reconnect then try the list again.
                if (errorcode != SUCCESS)
                    return folders;
                
                string folderList = null;
                while (true)
                {

                    read();
                    int resp = getResponseCode();
                    //end of command
                    if (resp == OK)
                    {
                        break;
                    }
                    //this is unexpected
                    if (resp == NO || (resp == BAD))
                    {
                        error = COMMUNICATIONERROR;
                        return folders;
                    }
                    //it is part of the response.
                    //DO ACTION HERE
                    //find the end of the flags
                    int index1 = response.IndexOf(')');
                    //push index past the 'reference name' (first set of quotes with root or current directory)
                    index1 = response.IndexOf('\"', index1);
                    index1 = response.IndexOf('\"', index1 + 1);
                    //quote before folder
                    index1 = response.IndexOf('\"', index1 + 1);
                    //quote after folder
                    int index2 = response.IndexOf('\"', index1 + 1);
                    //get the folder
                    string file = response.Substring(index1 + 1, index2 - (index1 + 1));
                    //dont add it if it is unselectable (it is a folder with no messages)
                    if (!response.Contains("\\Noselect"))
                    {
                        folderList += file + "\n";
                    }

                }
                //remove the last NL
                int l = folderList.Length;
                folderList = folderList.Substring(0, l - 1);
                folders = folderList.Split('\n');
                error = SUCCESS;
                return folders;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return folders;
            }

        }

        //returns:
        //SUCCESS
        //WRITEERROR
        //READERROR
        //COMMUNICATIONERROR
        //UNKNOWNERROR
        public int logout()
        {
            resetErrors();
            try
            {
                string tag = generateTag();
                write(tag + " LOGOUT");
                read();
                //keep reading junk until 
                while (true)
                {
                    if (response.Substring(0, 5).Equals("* BYE"))
                    {
                        break;
                    }
                    read();
                }
                read();
                //read nonsense data until we get the OK
                while (true)
                {
                    int resp = getResponseCode();
                    if (resp == BAD || resp == NO)
                    {
                        return COMMUNICATIONERROR;
                    }
                    if (resp == OK)
                    {
                        break;
                    }
                }


                if (!ssl)
                {
                    stream.Close();
                    stream.Dispose();
                    return SUCCESS;
                }
                sslStream.Close();
                sslStream.Dispose();
                return SUCCESS;
            }
            catch (Exception e)
            {

                if (writeerror)
                    return WRITEERROR;
                if (readerror)
                    return READERROR;

                return UNKNOWNERROR;
            }

        }

        //returns:
        //SUCCESS
        //WRITEERROR
        //READERROR
        //COMMUNICATIONERROR
        //UNKNOWNERROR
        public int getErrorCode()
        {
            return error;
        }

        public long getUIDValidity()
        {
            return UIDValidity;
        }

        //returns:
        //SUCCESS
        //WRITEERROR
        //READERROR
        //COMMUNICATIONERROR
        //UNKNOWNERROR
        public string[] getAllMessages(string folder, long previousUIDVAL)
        {
            try
            {
                resetErrors();


                long[] uidVal = examine(folder, previousUIDVAL);
                if (error != SUCCESS)
                {
                    return null;
                }

                Console.WriteLine("         UIDVALIDITY: " + uidVal[POSVAL]);
                UIDValidity = uidVal[POSVAL];
                Console.WriteLine("         EXISTS: " + uidVal[POSEXISTS] + "b");
                //actually get the messages (one by one)
                long exists = uidVal[POSEXISTS];
                string[] messages = new string[exists];
                long i = 1;
                while (i <= exists)
                {
                    string message = getMessageBySeq(i);
                    if (error != SUCCESS)
                        return null;
                    messages[i - 1] = message;
                    i++;
                }

                return messages;
            }
            catch (Exception e)
            {
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return null;

            }
        }



        #endregion





        #region publicnotfinished


        public string[] getNewMessages(string folder, long previousUIDVAL)
        {
            try
            {
                resetErrors();


                long[] uidVal = examine(folder, previousUIDVAL);
                if (error != SUCCESS)
                {
                    return null;
                }

                Console.WriteLine("         UIDVALIDITY: " + uidVal[POSVAL]);
                UIDValidity = uidVal[POSVAL];
                Console.WriteLine("         EXISTS: " + uidVal[POSEXISTS] + "b");
                //actually get the messages (one by one)
                long exists = uidVal[POSEXISTS];
                string[] messages = new string[exists];
                long i = 1;
                //for each message
                while (i <= exists)
                {

                    //get the UID
                    string message = null;
                    string UIDString = null;
                    write(generateTag() + " " + "FETCH " + i + " (BODY[])");
                    read();
                    while (true)
                    {
                        if (getResponseCode() == OK)
                            break;
                        if (getResponseCode() == NO || getResponseCode() == BAD)
                        {
                            error = COMMUNICATIONERROR;
                            return null;
                        }
                        UIDString += response;
                        read();
                    }
                    //pullout the UID and attach it to the beginning of the message






                    //get the message contents
                    write(generateTag() + " " + "FETCH " + i + " (BODY[])");
                    read();
                    while (true)
                    {
                        if (getResponseCode() == OK)
                            break;
                        if (getResponseCode() == NO || getResponseCode() == BAD)
                        {
                            error = COMMUNICATIONERROR;
                            return null;
                        }
                        message += response;
                        read();
                    }
                    if (message == null)
                    {
                        error = COMMUNICATIONERROR;
                        return null;
                    }
                    messages[i - 1] = message;
                    i++;
                }

                return messages;
            }
            catch (Exception e)
            {
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return null;

            }
        }

        /*
        private string getMessageByUID(long UID)
        {
            //get the UID
            string message = null;
            string UIDString = null;
            write(generateTag() + " " + "FETCH " + i + " UID");
            read();
            while (true)
            {
                if (getResponseCode() == OK)
                    break;
                if (getResponseCode() == NO || getResponseCode() == BAD)
                {
                    error = COMMUNICATIONERROR;
                    return null;
                }
                UIDString += response;
                read();
            }
            //pullout the UID and attach it to the beginning of the message
            int uidplace = UIDString.IndexOf("(UID ");
            if (uidplace == -1)
            {
                return null;
                error = COMMUNICATIONERROR;
            }
            string UIDString2 = UIDString.Substring(uidplace + 5);
            string messageUID = UIDString2.Substring(0, UIDString2.IndexOf(")"));
            message = "UID " + messageUID + " ";

            Console.WriteLine("\t\t\tMESSAGE: " + message);




            //get the message contents
            write(generateTag() + " " + "FETCH " + i + " (BODY[])");
            read();
            if (getResponseCode() != NONE)
            {
                error = COMMUNICATIONERROR;
                return null;
            }
            read();
            while (true)
            {
                if (getResponseCode() == OK)
                    break;
                if (getResponseCode() == NO || getResponseCode() == BAD)
                {
                    error = COMMUNICATIONERROR;
                    return null;
                }
                message += "\n" + response;
                read();
            }
            if (message == null)
            {
                error = COMMUNICATIONERROR;
                return null;
            }
            return message;
        }
         */


        private string getMessageBySeq(long seq)
        {
            //get the UID
            string message = null;
            string UIDString = null;
            write(generateTag() + " " + "FETCH " + seq + " UID");
            read();
            while (true)
            {
                if (getResponseCode() == OK)
                    break;
                if (getResponseCode() == NO || getResponseCode() == BAD)
                {
                    error = COMMUNICATIONERROR;
                    return null;
                }
                UIDString += response;
                read();
            }
            //pullout the UID and attach it to the beginning of the message
            int uidplace = UIDString.IndexOf("(UID ");
            if (uidplace == -1)
            {
                return null;
                error = COMMUNICATIONERROR;
            }
            string UIDString2 = UIDString.Substring(uidplace + 5);
            string messageUID = UIDString2.Substring(0, UIDString2.IndexOf(")"));
            message = "UID " + messageUID + " ";

            Console.WriteLine("\t\t\tMESSAGE: " + message);




            //get the message contents
            write(generateTag() + " " + "FETCH " + seq + " (BODY[])");
            read();
            if (getResponseCode() != NONE)
            {
                error = COMMUNICATIONERROR;
                return null;
            }
            read();
            while (true)
            {
                if (getResponseCode() == OK)
                    break;
                if (getResponseCode() == NO || getResponseCode() == BAD)
                {
                    error = COMMUNICATIONERROR;
                    return null;
                }
                message += "\n" + response;
                read();
            }
            if (message == null)
            {
                error = COMMUNICATIONERROR;
                return null;
            }
            return message;

        }




        //@param: name of folder to create
        //returns:
        //SUCCESS
        //WRITEERROR
        //READERROR
        //COMMUNICATIONERROR
        //UNKNOWNERROR
        public int createFolder(string name)
        {
            resetErrors();
            return SUCCESS;
        }





        #endregion











        #region privateaccessory

        //PRIVATE ACCESSORY METHODS






        //0: none
        //OK
        //NO
        //BAD
        //no support for BYE.  It is either caught elsewhere and reconnected or it is an emeregency shutdown
        //and count it as an unknown error because it is so unexpected.
        private int getResponseCode()
        {
            if ((response.Length >= tagLength + 4) &&( response.Substring(0, tagLength + 4).Equals(previousTag + " BAD")))
            {
                return BAD;
            }
            if ((response.Length >= tagLength + 4) &&(response.Substring(0, tagLength + 3).Equals(previousTag + " NO")))
            {
                return NO;
            }
            if ((response.Length >= tagLength + 4) && (response.Substring(0, tagLength + 3).Equals(previousTag + " OK")))
            {
                return OK;
            }
            commandResponse = response;
            return NONE;
        }

        //INCOMPLETE (only LOGIN method)
        //SUCCESS
        //USERPASSERROR
        //COMMUNICATIONERROR
        //WRITEERROR
        //READERROR
        //UNKNOWNERROR
        private int login(string capabilities)
        {
            try
            {
                //see if we can use LOGIN
                if (!capabilities.Contains("LOGINDISABLED"))
                {
                    string tag = generateTag();
                    write(tag + " LOGIN " + username + " " + password);
                    read();
                    int resp = getResponseCode();
                    //keep reading until we get a response with respect to the login.
                    while (resp == NONE)
                    {
                        read();
                        resp = getResponseCode();
                    }
                    if (resp == OK)
                        return OK;
                    if (resp == NO)
                    {
                        error = USERPASSERROR;
                        return NO;
                    }
                    if (resp == BAD)
                    {
                        error = COMMUNICATIONERROR;
                        return BAD;
                    }
                }
                return COMMUNICATIONERROR;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return OTHER;
            }

        }

        //returns: next sequential alphanumeric string
        static private string generateTag()
        {
            int i = tagLength - 1;
            bool done = false;
            string newTag = null;
            while (i >= 0 && !done)
            {
                char chr = previousTag.Substring(i, 1).ToCharArray()[0];
                if (!chr.Equals('z'))
                {
                    if (chr.Equals('9'))
                    {
                        newTag = previousTag.Substring(0, i) + 'A' + previousTag.Substring(i + 1);
                    }
                    else if (chr.Equals('Z'))
                    {
                        newTag = previousTag.Substring(0, i) + 'a' + previousTag.Substring(i + 1);
                    }
                    else
                    {
                        string a = previousTag.Substring(0, i);
                        string b = ((char)((int)(previousTag.Substring(i, 1).ToCharArray()[0]) + 1)).ToString();
                        string c = previousTag.Substring(i + 1);
                        newTag = a + b + c;

                    }
                    break;
                }
                else
                {
                    previousTag = previousTag.Substring(0, i) + '0' + previousTag.Substring(i + 1);
                    i--;
                }
            }
            if (newTag.Equals(previousTag))
                throw new Exception();
            previousTag = newTag;
            return newTag;




        }

        //used for logging in
        //returns: string of capabilities as quoted by server
        private string getCapabilities()
        {
            try
            {

            string capability = null;
            if (!response.Contains("CAPABILITY"))
            {
                write(previousTag + " CAPABILITY");
                //read until we get an OK
                read();
                while (true)
                {
                    int resp = getResponseCode();
                    if (resp == OK)
                        break;
                    if (resp != NONE)
                    {
                        error = COMMUNICATIONERROR;
                        return null;
                    }
                    //This is a line with a capabliity on it (we know this beacause 
                    //there was no end of command response
                    capability += response;
                    read();
                }
                return capability;

            }
            return response;  
            }

            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return null;
            }

        }

        //returns
        private int reconnect(string argument)
        {
            try
            {
                //READ UNTIL CLEAN
                //NOT YET IMPLEMENTED



                write(generateTag() + " " + argument);
                //the sesion expired.  reconnect then try the list again.
                if(writeerror)                
                {
                    int errorcode = connect();
                    //see if we had an error connecting
                    if (errorcode != SUCCESS)
                    {
                        error = errorcode;
                        return errorcode;
                    }
                    write(generateTag() + " " + argument);
                }
                return SUCCESS;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return error;
            }
        }

        //0:error
        //1:UID Validity
        //2:
        //3:
        public long[] examine(string folder, long previousUIDVAL)
        {
            long[] vals = new long[3];
            int errorcode = reconnect("examine \"" + folder + "\"");
            if (errorcode != SUCCESS)
            {
                error = errorcode;
                return null;
            }
            read();
            ArrayList examine = new ArrayList();
            while (true)
            {
                if (getResponseCode() == OK)
                    break;
                if (getResponseCode() == BAD || getResponseCode() == NO)
                {
                    errorcode = COMMUNICATIONERROR;
                    return null;
                }
                //still getting response's
                examine.Add(response);
                read();
            }
            //get UID Validity and exists
            if ((examine == null))
            {
                error = COMMUNICATIONERROR;
                return null;
            }
            //UID Validity
            foreach (string line in examine)
            {
                if (line.Contains("UIDVALIDITY"))
                {
                    string UID = line.Substring(line.IndexOf("UIDVALIDITY") + "UIDVALIDITY".Length + 1);
                    long ID = long.Parse(UID.Substring(0, UID.IndexOf(']')));
                    vals[POSVAL] = ID;
                    break;
                }
            }   
            //conflict of UID's
            if (((vals[POSVAL] != previousUIDVAL) && (previousUIDVAL !=-1)))
            {
                error = COMMUNICATIONERROR;
                return null;
                
            }
            //EXISTS
            foreach (string line in examine)
            {
                if (line.Contains("EXISTS"))
                {
                    string exists = line.Substring(line.IndexOf(" ")+1);
                    long exist = long.Parse(exists.Substring(0, exists.IndexOf(' ')));
                    vals[POSEXISTS] = exist;
                    break;
                }
            }

            return vals;

        }

        public void resetErrors()
        {

            error = SUCCESS;
            readerror = false;
            writeerror = false;
            streamerror = false;
        }
        
        #endregion







        #region readwrite


        //STREAM/READ/WRITERS






        //finished
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
            Console.WriteLine(write + CRLF);
            try
            {
                writer.Write(write + CRLF);
                writer.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error sending to server");
                writeerror = true;
            }
        }

        private void con()
        {
            Console.WriteLine("SERVER: " + response);
        }


        private void flush()
        {
           if (ssl)
               sslStream.Flush();
           else
               stream.Flush();
        }



        #endregion





        //UNUSED







        #region unused



        //private Boolean connect(


        //returns:  1 = success
        //          2 = invalid username/password combo
        //          3 = maildrop already locked
        int authorization()
        {
            //try the USER and PASS mechanism
            write("USER " + username);
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

                write("PASS " + password);
                read();
                //invalid username/password combo.  
                //also possible if it is unable to lock maildrop 
                if (response.Contains("-ERR"))
                {
                    //                    disconnect();
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




        #endregion
    }

}



