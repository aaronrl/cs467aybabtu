using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AYBABTU
{
    public partial class MailChecker : Form
    {
        int step;

        public MailChecker()
        {
            InitializeComponent();
            step = 100;
        }

        public MailChecker(AccountChecker acctchecker, int barStep)
        {
            InitializeComponent();
            step = barStep;
            acctchecker.AccountCheckedEvent += new EventHandler<AccountCheckedEventArgs>(HandleAccountBeingChecked);
        }

        private void MailChecker_Load(object sender, EventArgs e)
        {
            progressBar.Step = step;
        }

        private void HandleAccountBeingChecked(object sender, AccountCheckedEventArgs e)
        {
            progressBar.PerformStep();
        }

    }

    public class AccountCheckedEventArgs : EventArgs
    {
        public string info = "data";
    }

    public class AccountChecker
    {
        // http://msdn.microsoft.com/en-us/library/ms182178(VS.80).aspx

        public event EventHandler<AccountCheckedEventArgs> AccountCheckedEvent;

        public Account[] accountsToCheck;
        public AccountChecker(Account[] incomingAccounts)
        {
            accountsToCheck = incomingAccounts;
        }
        public void checkMessages()
        {
            try
            {
                for (int i = 0; i < accountsToCheck.Length; i++)
                {
                    //currentAccountLbl.Text = "Processing account:  " + accountsToCheck[i].AccountName;
                    accountsToCheck[i].checkForNewMessages();
                    OnCompletionOfAccountReciept(new AccountCheckedEventArgs());
                }
            }
            catch (DivideByZeroException error)
            {

            }
        }
        protected virtual void OnCompletionOfAccountReciept(AccountCheckedEventArgs e)
        {
            if (AccountCheckedEvent != null)
            {
                AccountCheckedEvent(this, e);
            }
        }
    }
}
