using System;
using System.Collections.Generic;
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
get all messages in a folder
 * 
 * 
 * 
 * DO
 * 
 * 
 * getUID's
get <b> new </b> mesages in a folder
move message
mark as deleted


 * 
 * psudocode for aaron
 * 
 * 
 * 
 * 
 */
namespace IMAP
{
    class IMAPHandler
    {
        #region mainstuff

        #region vars
        public static int POSVAL = 0;
        public static int POSEXISTS = 1;


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
        private int connect()
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
            //reconnect
            try
            {
                int errorcode = reconnect("NOOP");
                if (errorcode != SUCCESS)
                    return errorcode;

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

                UIDValidity = uidVal[POSVAL];
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


        public string[] getNewMessages(string folder, long previousUIDVAL, long MAXUID)
        {
            try
            {
                resetErrors();

                long[] uidVal = examine(folder, previousUIDVAL);
                if (error != SUCCESS)
                {
                    return null;
                }

                UIDValidity = uidVal[POSVAL];
                long exists = uidVal[POSEXISTS];
                //for each message, get the UID.  if the UID is larger then the previous UID, record that seq # and break 
                long UIDseq = -1;
                long UID;
                long i = 1;
                while (i <= exists)
                {
                    string message = getUIDBySeq(i);
                    if (error != SUCCESS)
                        return null;
                    UID = long.Parse(message);
                    if (UID > MAXUID)
                    {
                        UIDseq = i;
                        break;
                    }
                    i++;
                }
                if (UIDseq == -1)
                {
                    return null;
                }
                //actually get the messages (one by one)

                long numNew = exists - UIDseq + 1;
                string[] messages = new string[numNew];
                i = UIDseq;
                long messageNum = 0;
                while (i <= exists)
                {
                    string message = getMessageBySeq(i);
                    if (error != SUCCESS)
                        return null;
                    messages[messageNum] = message;
                    i++;
                    messageNum++;
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

        public int delete(string folder, long previousUIDVAL, long messageUID)
        {
            try
            {
                resetErrors();

                long[] uidVal = select(folder, previousUIDVAL);
                if (error != SUCCESS)
                {
                    return error;
                }

                UIDValidity = uidVal[POSVAL];
                //change the delete flag for the message
                write(generateTag() + " UID STORE " + messageUID + " +FLAGS.SILENT (\\Deleted)");
                read();
                int code = getResponseCode();
                while (code != OK)
                {
                    if ((code == BAD) || code == NO)
                        return COMMUNICATIONERROR;
                    //otherwise it is giving data that we dont care about
                    read();
                    code = getResponseCode();
                }


                //purge the message
                write(generateTag() + " CLOSE");
                read();
                code = getResponseCode();
                while (code != OK)
                {
                    if ((code == BAD) || code == NO)
                        return COMMUNICATIONERROR;
                    //otherwise it is giving data that we dont care about
                    read();
                    code = getResponseCode();
                }

                return SUCCESS;
            }
            catch (Exception e)
            {
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return error;

            }
        }


        private string getMessageBySeq(long seq)
        {
            try
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

        private string getUIDBySeq(long seq)
        {
            try
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
                return messageUID;
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
            if ((response.Length >= tagLength + 4) && (response.Substring(0, tagLength + 4).Equals(previousTag + " BAD")))
            {
                return BAD;
            }
            if ((response.Length >= tagLength + 4) && (response.Substring(0, tagLength + 3).Equals(previousTag + " NO")))
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

        //returns
        private int reconnect(string argument)
        {
            try
            {
                //READ UNTIL CLEAN
                //NOT YET IMPLEMENTED



                write(generateTag() + " " + argument);
                //the sesion expired.  reconnect then try the list again.
                if (writeerror)
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
                if (writeerror)
                    error = WRITEERROR;
                if (readerror)
                    error = READERROR;

                error = UNKNOWNERROR;
                return error;
            }
        }

        private int reconnectNoop()
        {
            return -1;
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
            //conflict of UIDVal's
            if (((vals[POSVAL] != previousUIDVAL) && (previousUIDVAL != -1)))
            {
                error = COMMUNICATIONERROR;
                return null;

            }
            //EXISTS
            foreach (string line in examine)
            {
                if (line.Contains("EXISTS"))
                {
                    string exists = line.Substring(line.IndexOf(" ") + 1);
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


        public long[] select(string folder, long previousUIDVAL)
        {
            long[] vals = new long[3];
            int errorcode = reconnect("select \"" + folder + "\"");
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
            //conflict of UIDVal's
            if (((vals[POSVAL] != previousUIDVAL) && (previousUIDVAL != -1)))
            {
                error = COMMUNICATIONERROR;
                return null;

            }
            //EXISTS
            foreach (string line in examine)
            {
                if (line.Contains("EXISTS"))
                {
                    string exists = line.Substring(line.IndexOf(" ") + 1);
                    long exist = long.Parse(exists.Substring(0, exists.IndexOf(' ')));
                    vals[POSEXISTS] = exist;
                    break;
                }
            }

            return vals;

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



        private void flush()
        {
            if (ssl)
                sslStream.Flush();
            else
                stream.Flush();
        }



        #endregion
    }

}



