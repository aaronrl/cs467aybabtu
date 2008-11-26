﻿using System;
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

    }
}