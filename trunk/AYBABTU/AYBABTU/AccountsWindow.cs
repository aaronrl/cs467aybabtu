using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AYBABTU
{
    public partial class AccountsWindow : Form
    {
        public Accounts currentAccounts;
        public bool closed;

        public AccountsWindow()
        {
            InitializeComponent();
            currentAccounts = new Accounts();
            closed = false;
        }

        public AccountsWindow(Accounts allAccounts)
        {
            InitializeComponent();
            currentAccounts = allAccounts;
            closed = false;
        }

        #region button actions
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AccountsEditor editor = new AccountsEditor();
            editor.ShowDialog();
            if (editor.accountSaved)
            {
                currentAccounts.createNewAccount(editor.acct);
            }
            editor.Dispose();
            
            generateAccountsList();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = accountsList.SelectedIndices;
            AccountsEditor editor = new AccountsEditor(currentAccounts.getAccountAt(indices[0]));
            editor.ShowDialog();
            if (editor.accountSaved)
            {
                currentAccounts.editAccountAt(editor.acct, indices[0]);
            }
            editor.Dispose();
            generateAccountsList();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = accountsList.SelectedIndices;
            ConfirmationWindow confirmWindow = new ConfirmationWindow();
            confirmWindow.ShowDialog();
            if (confirmWindow.answer)
            {
                currentAccounts.deleteAccount(indices[0]);
            }
            confirmWindow.Dispose();
            generateAccountsList();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void AccountsWindow_Load(object sender, EventArgs e)
        {
            generateAccountsList();
        }

        private void generateAccountsList()
        {
            accountsList.Items.Clear();
            accountsList.Items.AddRange(currentAccounts.getListViewOfAccounts());
            accountsList.Items[0].Selected = true;
        }

        private void AccountsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            closed = true;
        }
    }
}
