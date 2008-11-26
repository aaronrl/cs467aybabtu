using System;
using System.Collections.Generic;
using System.Text;

namespace AYBABTU
{
    [Serializable]
    public class AccountInfo
    {
        public enum ServerType { POP = 1, IMAP = 2 };
        public enum AuthenticationType { None = 1, Password = 2 };
        
        private string emailAddress;

        private string signature;

        #region server variables

        private ServerType incomingServerType;
        private string incomingServer;
        private int incomingPort;
        private string incomingUsername;
        private string incomingPassword;
        private bool incomingSSL;

        private string outgoingServer;
        private int outgoingPort;
        private AuthenticationType outgoingAuthentication;
        private bool outgoingUsesSameSettingsAsIncomingServer;
        private string outgoingUsername;
        private string outgoingPassword;
        private bool outgoingSSL;

        #endregion

        #region constructors
        public AccountInfo()
        {
        }

        public AccountInfo(
                            string pEmailAddress,
                            ServerType pIncomingServerType,
                            string pIncomingServer,
                            int pIncomingPort,
                            string pIncomingUsername,
                            string pIncomingPassword,
                            bool pIncomingSSL,
                            string pOutgoingServer,
                            int pOutgoingPort,
                            AuthenticationType pOutgoingAuthentication,
                            bool pOutgoingUsesSameSettingsAsIncomingServer,
                            string pOutgoingUsername,
                            string pOutgoingPassword,
                            bool pOutgoingSSL)
        {
            emailAddress = pEmailAddress;

            incomingServerType = pIncomingServerType;
            incomingServer = pIncomingServer;
            incomingPort = pIncomingPort;
            incomingUsername = pIncomingUsername;
            incomingPassword = pIncomingPassword;
            incomingSSL = pIncomingSSL;

            outgoingServer = pOutgoingServer;
            outgoingPort = pOutgoingPort;
            outgoingAuthentication = pOutgoingAuthentication;
            outgoingUsesSameSettingsAsIncomingServer = pOutgoingUsesSameSettingsAsIncomingServer;
            outgoingUsername = pOutgoingUsername;
            outgoingPassword = pOutgoingPassword;
            outgoingSSL = pOutgoingSSL;
        }
        #endregion 

        #region properties

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
            }
        }

        public string Signature
        {
            get
            {
                return signature;
            }
            set
            {
                signature = value;
            }
        }

        public ServerType IncomingServerType
        {
            get
            {
                return incomingServerType;
            }
            set
            {
                incomingServerType = value;
            }
        }

        public string IncomingServer
        {
            get
            {
                return incomingServer;
            }
            set
            {
                incomingServer = value;
            }
        }

        public int IncomingPort
        {
            get
            {
                return incomingPort;
            }
            set
            {
                incomingPort = value;
            }
        }

        public string IncomingUsername
        {
            get
            {
                return incomingUsername;
            }
            set
            {
                incomingUsername = value;
            }
        }

        public string IncomingPassword
        {
            get
            {
                return incomingPassword;
            }
            set
            {
                incomingPassword = value;
            }
        }

        public bool IncomingSSL
        {
            get
            {
                return incomingSSL;
            }
            set
            {
                incomingSSL = value;
            }
        }

        public string OutgoingServer
        {
            get
            {
                return outgoingServer;
            }
            set
            {
                outgoingServer = value;
            }
        }

        public int OutgoingPort
        {
            get
            {
                return outgoingPort;
            }
            set
            {
                outgoingPort = value;
            }
        }

        public AuthenticationType OutgoingAuthentication
        {
            get
            {
                return outgoingAuthentication;
            }
            set
            {
                outgoingAuthentication = value;
            }
        }

        public bool OutgoingUsesSameSettingsAsIncomingServer
        {
            get 
            {
                return outgoingUsesSameSettingsAsIncomingServer;
            }
            set 
            {
                outgoingUsesSameSettingsAsIncomingServer = value;
            }
        }

        public string OutgoingUsername
        {
            get
            {
                return outgoingUsername;
            }
            set
            {
                outgoingUsername = value;
            }
        }

        public string OutgoingPassword
        {
            get
            {
                return outgoingPassword;
            }
            set
            {
                outgoingPassword = value;
            }
        }

        public bool OutgoingSSL
        {
            get
            {
                return outgoingSSL;
            }
            set
            {
                outgoingSSL = value;
            }
        }

        #endregion
    }
}
