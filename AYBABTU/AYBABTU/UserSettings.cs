using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace AYBABTU
{

    /* This class handles the loading and writing of settings to the client's local system. */
    class UserSettings
    {
        public static void loadUserSettingsFromSystem()
        {
            // create an XmlWriter to write the data stored from the Properties.Settings.Default object

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            string filename = Application.UserAppDataPath + "\\serverinfo.xml";
            try
            {
                xmlDoc.Load(filename);
                
                Properties.Settings.Default.POPServer = xmlDoc.GetElementsByTagName("popserver")[0].InnerText;
                Properties.Settings.Default.SMTPServer = xmlDoc.GetElementsByTagName("smtpserver")[0].InnerText;
                Properties.Settings.Default.EmailAddress = xmlDoc.GetElementsByTagName("emailaddress")[0].InnerText;
                Properties.Settings.Default.Username = xmlDoc.GetElementsByTagName("username")[0].InnerText;
                Properties.Settings.Default.Password = xmlDoc.GetElementsByTagName("password")[0].InnerText;
                
                //MessageBox.Show(xmlDoc.GetElementsByTagName("popserver").Item(0).InnerText);
                xmlDoc.Save(filename);

            }
            catch (System.IO.FileNotFoundException e)
            {
                //if file is not found, create a new xml file
                XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("ServerInfo");
                xmlWriter.Close();

                xmlDoc.Load(filename);
                try
                {

                    Properties.Settings.Default.POPServer = xmlDoc.GetElementsByTagName("popserver")[0].Attributes[0].InnerText;
                    Properties.Settings.Default.SMTPServer = xmlDoc.GetElementsByTagName("smtpserver")[0].Attributes[0].InnerText;
                    Properties.Settings.Default.EmailAddress = xmlDoc.GetElementsByTagName("emailaddress")[0].Attributes[0].InnerText;
                    Properties.Settings.Default.Username = xmlDoc.GetElementsByTagName("username")[0].Attributes[0].InnerText;
                    Properties.Settings.Default.Password = xmlDoc.GetElementsByTagName("password")[0].Attributes[0].InnerText;
                }
                catch (NullReferenceException nulle)
                {
                    //MessageBox.Show(e.ToString());
                }
                xmlDoc.Save(filename);
            }

        }


        public static void writeUserSettingsToSystem()
        {
            //create a user file on the system with settings
            try
            {
                //pick whatever filename with .xml extension
                string filename = Application.UserAppDataPath + "\\serverinfo.xml";

                XmlDocument xmlDoc = new XmlDocument();

                try
                {
                    xmlDoc.Load(filename);

                    xmlDoc.GetElementsByTagName("popserver")[0].Attributes[0].InnerText = Properties.Settings.Default.POPServer;
                    xmlDoc.GetElementsByTagName("smtpserver")[0].Attributes[0].InnerText = Properties.Settings.Default.SMTPServer;
                    xmlDoc.GetElementsByTagName("emailaddress")[0].Attributes[0].InnerText = Properties.Settings.Default.EmailAddress;
                    xmlDoc.GetElementsByTagName("username")[0].Attributes[0].InnerText = Properties.Settings.Default.Username;
                    xmlDoc.GetElementsByTagName("password")[0].Attributes[0].InnerText = Properties.Settings.Default.Password;
                    
                    xmlDoc.Save(filename);
                }
                catch (Exception)
                {
                    //if file is not found, create a new xml file
                    XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                    xmlWriter.WriteStartElement("ServerInfo");
                    xmlWriter.Close();

                    xmlDoc.Load(filename);

                    XmlNode root = xmlDoc.DocumentElement;
                    XmlElement popserverNode = xmlDoc.CreateElement("popserver");
                    XmlText popserverTextNode = xmlDoc.CreateTextNode(Properties.Settings.Default.POPServer);

                    XmlElement smtpserverNode = xmlDoc.CreateElement("smtpserver");
                    XmlText smtpserverTextNode = xmlDoc.CreateTextNode(Properties.Settings.Default.SMTPServer);

                    XmlElement emailaddressNode = xmlDoc.CreateElement("emailaddress");
                    XmlText emailaddressTextNode = xmlDoc.CreateTextNode(Properties.Settings.Default.EmailAddress);

                    XmlElement usernameNode = xmlDoc.CreateElement("username");
                    XmlText usernameTextNode = xmlDoc.CreateTextNode(Properties.Settings.Default.Username);

                    XmlElement passwordNode = xmlDoc.CreateElement("password");
                    XmlText passwordTextNode = xmlDoc.CreateTextNode(Properties.Settings.Default.Password);

                    popserverNode.AppendChild(popserverTextNode);
                    smtpserverNode.AppendChild(smtpserverTextNode);
                    emailaddressNode.AppendChild(emailaddressTextNode);
                    usernameNode.AppendChild(usernameTextNode);
                    passwordNode.AppendChild(passwordTextNode);

                    root.AppendChild(popserverNode);
                    root.AppendChild(smtpserverNode);
                    root.AppendChild(emailaddressNode);
                    root.AppendChild(usernameNode);
                    root.AppendChild(passwordNode);

                    xmlDoc.Save(filename);
                }
                // need to write methods for CHANGING current values in the xml file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
