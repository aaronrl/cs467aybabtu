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
        Accounts currentAccounts;

        public AccountsWindow()
        {
            InitializeComponent();
            currentAccounts = new Accounts();
        }

        public AccountsWindow(Accounts allAccounts)
        {
            InitializeComponent();
            currentAccounts = allAccounts;
        }

        #region button actions
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AccountsEditor editor = new AccountsEditor();
            editor.ShowDialog();
            if (editor.accountSaved)
            {
                
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = accountsList.SelectedIndices;
            AccountsEditor editor = new AccountsEditor(currentAccounts.getAccountAt(indices[0]));
            editor.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void AccountsWindow_Load(object sender, EventArgs e)
        {
            generateAccountsList(currentAccounts.getListViewOfAccounts());
        }

        private void generateAccountsList(ListViewItem[] accounts)
        {
            //accountsList.Clear();
            accountsList.Items.AddRange(accounts);
        }
    }
}
