using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;

namespace AYBABTU
{
    class Accounts
    {
        private Account[] accounts;

        public Accounts()
        {
            loadAccounts();
        }

        private void loadAccounts()
        {
            DirectoryInfo fileListing = new DirectoryInfo(Application.UserAppDataPath);
            FileStream fs;

            foreach (FileInfo file in fileListing.GetFiles())
            {
                fs = new FileStream(Application.UserAppDataPath + "\\" + file.Name + "\\account.info", FileMode.Open);

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                }
                catch (SerializationException se)
                {
                    MessageBox.Show(se.ToString());
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        //public 

        public void createNewAccount(Account newAccount)
        {
            accounts[accounts.Length] = newAccount;
        }

        public void deleteAccount(int index)
        {
            //delete an account
        }

        public Account getAccountAt(int index)
        {
            return accounts[index];
        }

    }
}
