namespace AYBABTU
{
    partial class AccountsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountsList = new System.Windows.Forms.ListView();
            this.accountNameHeader = new System.Windows.Forms.ColumnHeader();
            this.emailAddressHeader = new System.Windows.Forms.ColumnHeader();
            this.serverNameHeader = new System.Windows.Forms.ColumnHeader();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountsList
            // 
            this.accountsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.accountNameHeader,
            this.emailAddressHeader,
            this.serverNameHeader});
            this.accountsList.FullRowSelect = true;
            this.accountsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.accountsList.HideSelection = false;
            this.accountsList.Location = new System.Drawing.Point(12, 30);
            this.accountsList.Name = "accountsList";
            this.accountsList.Size = new System.Drawing.Size(430, 256);
            this.accountsList.TabIndex = 0;
            this.accountsList.UseCompatibleStateImageBehavior = false;
            this.accountsList.View = System.Windows.Forms.View.Details;
            // 
            // accountNameHeader
            // 
            this.accountNameHeader.Text = "Name";
            this.accountNameHeader.Width = 118;
            // 
            // emailAddressHeader
            // 
            this.emailAddressHeader.Text = "Email Address";
            this.emailAddressHeader.Width = 142;
            // 
            // serverNameHeader
            // 
            this.serverNameHeader.Text = "Server";
            this.serverNameHeader.Width = 161;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(448, 30);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(448, 59);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(448, 88);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(448, 263);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select an account:";
            // 
            // AccountsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.accountsList);
            this.Name = "AccountsWindow";
            this.Text = "Accounts";
            this.Load += new System.EventHandler(this.AccountsWindow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountsWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView accountsList;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColumnHeader accountNameHeader;
        private System.Windows.Forms.ColumnHeader emailAddressHeader;
        private System.Windows.Forms.ColumnHeader serverNameHeader;
        private System.Windows.Forms.Label label1;
    }
}