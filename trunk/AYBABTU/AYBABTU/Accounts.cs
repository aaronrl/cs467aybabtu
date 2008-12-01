using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;

namespace AYBABTU
{
    public class Accounts
    {
        private Account[] accounts;

        public Accounts()
        {
            accounts = new Account[0];
        }

        public Accounts(Account[] pAccounts)
        {
            accounts = pAccounts;
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

        public void createNewAccount(Account newAccount)
        {
            Account[] newAccounts = new Account[accounts.Length + 1];
            for (int i = 0; i < accounts.Length; i++)
            {
                newAccounts[i] = accounts[i];
            }
            newAccounts[accounts.Length] = newAccount;
            accounts = newAccounts;
        }

        public void deleteAccount(int index)
        {
            //delete an account
            Account[] newAccounts = new Account[accounts.Length - 1];
            for (int i = 0; i < accounts.Length; i++)
            {
                if (i < index)
                {
                    newAccounts[i] = accounts[i];
                }
                else if (i > index)
                {
                    newAccounts[i - 1] = accounts[i];
                }
            }
            accounts = newAccounts;
        }

        public void editAccountAt(Account accountToEdit, int index)
        {
            accounts[index] = accountToEdit;
        }

        public Account getAccountAt(int index)
        {
            return accounts[index];
        }

        public Account findAccountByName(string searchName)
        {
            // this method will return the first occurance of the searchName term in the accounts array
            foreach (Account acct in accounts)
            {
                if (acct.AccountName == searchName)
                {
                    return acct;
                }
            }
            return null;
        }

        public Account[] EmailAccounts
        {
            get
            {
                return accounts;
            }
            set
            {
                accounts = value;
            }
        }

        public TreeNode[] getTreeViewOfAccounts()
        {
            TreeNode[] accountsTree = new TreeNode[accounts.Length];
            for(int i=0; i<accounts.Length;i++)
            {
                accountsTree[i] = accounts[i].returnTreeNode();
            }
            return accountsTree;
        }

        public ListViewItem[] getListViewOfAccounts()
        {
            ListViewItem[] listing = new ListViewItem[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                ListViewItem account = new ListViewItem(accounts[i].AccountName);
                account.SubItems.Add(accounts[i].accountInfo.EmailAddress);
                account.SubItems.Add(accounts[i].accountInfo.IncomingServer);
                listing[i] = account;
            }
            return listing;
        }

    }
}
