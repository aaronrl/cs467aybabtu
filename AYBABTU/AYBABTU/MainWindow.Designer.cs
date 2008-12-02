using System.Windows.Forms;
namespace AYBABTU
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMessageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.replyToSenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replyToAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAYBABTUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderList = new System.Windows.Forms.TreeView();
            this.userButtonPanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.replyAllBtn = new System.Windows.Forms.Button();
            this.replyBtn = new System.Windows.Forms.Button();
            this.writeMessageBtn = new System.Windows.Forms.Button();
            this.addressBookBtn = new System.Windows.Forms.Button();
            this.getMessageBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getAndSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageList = new System.Windows.Forms.ListView();
            this.fromHeader = new System.Windows.Forms.ColumnHeader();
            this.subjectHeader = new System.Windows.Forms.ColumnHeader();
            this.dateHeader = new System.Windows.Forms.ColumnHeader();
            this.messages = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.subjectLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.attachmentsBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.messageViewer = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.userButtonPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.messagesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMessageToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveAttachmentToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMessageToolStripMenuItem
            // 
            this.newMessageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem,
            this.contactToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.newMessageToolStripMenuItem.Name = "newMessageToolStripMenuItem";
            this.newMessageToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newMessageToolStripMenuItem.Text = "New";
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.messageToolStripMenuItem.Text = "Message";
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.contactToolStripMenuItem.Text = "Contact";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // saveAttachmentToolStripMenuItem
            // 
            this.saveAttachmentToolStripMenuItem.Name = "saveAttachmentToolStripMenuItem";
            this.saveAttachmentToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveAttachmentToolStripMenuItem.Text = "Save Attachment";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForMessagesToolStripMenuItem,
            this.newMessageToolStripMenuItem1,
            this.replyToSenderToolStripMenuItem,
            this.replyToAllToolStripMenuItem,
            this.forwardToolStripMenuItem});
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.messagesToolStripMenuItem.Text = "Messages";
            // 
            // checkForMessagesToolStripMenuItem
            // 
            this.checkForMessagesToolStripMenuItem.Name = "checkForMessagesToolStripMenuItem";
            this.checkForMessagesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.checkForMessagesToolStripMenuItem.Text = "Check for Messages";
            // 
            // newMessageToolStripMenuItem1
            // 
            this.newMessageToolStripMenuItem1.Name = "newMessageToolStripMenuItem1";
            this.newMessageToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.newMessageToolStripMenuItem1.Text = "New Message";
            // 
            // replyToSenderToolStripMenuItem
            // 
            this.replyToSenderToolStripMenuItem.Name = "replyToSenderToolStripMenuItem";
            this.replyToSenderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.replyToSenderToolStripMenuItem.Text = "Reply to Sender";
            // 
            // replyToAllToolStripMenuItem
            // 
            this.replyToAllToolStripMenuItem.Name = "replyToAllToolStripMenuItem";
            this.replyToAllToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.replyToAllToolStripMenuItem.Text = "Reply to All";
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailAccountsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // emailAccountsToolStripMenuItem
            // 
            this.emailAccountsToolStripMenuItem.Name = "emailAccountsToolStripMenuItem";
            this.emailAccountsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.emailAccountsToolStripMenuItem.Text = "Email Accounts";
            this.emailAccountsToolStripMenuItem.Click += new System.EventHandler(this.emailAccountsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutAYBABTUToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            // 
            // aboutAYBABTUToolStripMenuItem
            // 
            this.aboutAYBABTUToolStripMenuItem.Name = "aboutAYBABTUToolStripMenuItem";
            this.aboutAYBABTUToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.aboutAYBABTUToolStripMenuItem.Text = "About A.Y.B.A.B.T.U.";
            this.aboutAYBABTUToolStripMenuItem.Click += new System.EventHandler(this.aboutAYBABTUToolStripMenuItem_Click);
            // 
            // folderList
            // 
            this.folderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderList.Location = new System.Drawing.Point(0, 0);
            this.folderList.Name = "folderList";
            this.folderList.Size = new System.Drawing.Size(170, 507);
            this.folderList.TabIndex = 2;
            this.folderList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderList_AfterSelect);
            // 
            // userButtonPanel
            // 
            this.userButtonPanel.Controls.Add(this.deleteBtn);
            this.userButtonPanel.Controls.Add(this.forwardBtn);
            this.userButtonPanel.Controls.Add(this.replyAllBtn);
            this.userButtonPanel.Controls.Add(this.replyBtn);
            this.userButtonPanel.Controls.Add(this.writeMessageBtn);
            this.userButtonPanel.Controls.Add(this.addressBookBtn);
            this.userButtonPanel.Controls.Add(this.getMessageBtn);
            this.userButtonPanel.Location = new System.Drawing.Point(12, 27);
            this.userButtonPanel.Name = "userButtonPanel";
            this.userButtonPanel.Size = new System.Drawing.Size(1004, 61);
            this.userButtonPanel.TabIndex = 5;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteBtn.BackgroundImage")));
            this.deleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Location = new System.Drawing.Point(399, 5);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(60, 55);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("forwardBtn.BackgroundImage")));
            this.forwardBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.forwardBtn.FlatAppearance.BorderSize = 0;
            this.forwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardBtn.Location = new System.Drawing.Point(333, 5);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(60, 55);
            this.forwardBtn.TabIndex = 5;
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // replyAllBtn
            // 
            this.replyAllBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("replyAllBtn.BackgroundImage")));
            this.replyAllBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.replyAllBtn.FlatAppearance.BorderSize = 0;
            this.replyAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replyAllBtn.Location = new System.Drawing.Point(267, 5);
            this.replyAllBtn.Name = "replyAllBtn";
            this.replyAllBtn.Size = new System.Drawing.Size(60, 55);
            this.replyAllBtn.TabIndex = 4;
            this.replyAllBtn.UseVisualStyleBackColor = true;
            // 
            // replyBtn
            // 
            this.replyBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("replyBtn.BackgroundImage")));
            this.replyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.replyBtn.FlatAppearance.BorderSize = 0;
            this.replyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replyBtn.Location = new System.Drawing.Point(201, 5);
            this.replyBtn.Name = "replyBtn";
            this.replyBtn.Size = new System.Drawing.Size(60, 55);
            this.replyBtn.TabIndex = 3;
            this.replyBtn.UseVisualStyleBackColor = true;
            this.replyBtn.Click += new System.EventHandler(this.replyBtn_Click);
            // 
            // writeMessageBtn
            // 
            this.writeMessageBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("writeMessageBtn.BackgroundImage")));
            this.writeMessageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.writeMessageBtn.FlatAppearance.BorderSize = 0;
            this.writeMessageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeMessageBtn.Location = new System.Drawing.Point(69, 5);
            this.writeMessageBtn.Name = "writeMessageBtn";
            this.writeMessageBtn.Size = new System.Drawing.Size(60, 55);
            this.writeMessageBtn.TabIndex = 2;
            this.writeMessageBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.writeMessageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.writeMessageBtn.UseVisualStyleBackColor = true;
            this.writeMessageBtn.Click += new System.EventHandler(this.writeMessageBtn_Click);
            // 
            // addressBookBtn
            // 
            this.addressBookBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addressBookBtn.BackgroundImage")));
            this.addressBookBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addressBookBtn.FlatAppearance.BorderSize = 0;
            this.addressBookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addressBookBtn.Location = new System.Drawing.Point(135, 3);
            this.addressBookBtn.Name = "addressBookBtn";
            this.addressBookBtn.Size = new System.Drawing.Size(60, 55);
            this.addressBookBtn.TabIndex = 1;
            this.addressBookBtn.UseVisualStyleBackColor = true;
            this.addressBookBtn.Click += new System.EventHandler(this.addressBookBtn_Click);
            // 
            // getMessageBtn
            // 
            this.getMessageBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("getMessageBtn.BackgroundImage")));
            this.getMessageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.getMessageBtn.ContextMenuStrip = this.contextMenuStrip1;
            this.getMessageBtn.FlatAppearance.BorderSize = 0;
            this.getMessageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getMessageBtn.Location = new System.Drawing.Point(3, 3);
            this.getMessageBtn.Name = "getMessageBtn";
            this.getMessageBtn.Size = new System.Drawing.Size(60, 55);
            this.getMessageBtn.TabIndex = 0;
            this.getMessageBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.getMessageBtn.UseVisualStyleBackColor = true;
            this.getMessageBtn.Click += new System.EventHandler(this.getMessageBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AllowDrop = true;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getAndSendToolStripMenuItem,
            this.getMessagesToolStripMenuItem,
            this.sendMessagesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 70);
            // 
            // getAndSendToolStripMenuItem
            // 
            this.getAndSendToolStripMenuItem.Name = "getAndSendToolStripMenuItem";
            this.getAndSendToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.getAndSendToolStripMenuItem.Text = "Get and Send";
            // 
            // getMessagesToolStripMenuItem
            // 
            this.getMessagesToolStripMenuItem.Name = "getMessagesToolStripMenuItem";
            this.getMessagesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.getMessagesToolStripMenuItem.Text = "Get Messages";
            // 
            // sendMessagesToolStripMenuItem
            // 
            this.sendMessagesToolStripMenuItem.Name = "sendMessagesToolStripMenuItem";
            this.sendMessagesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendMessagesToolStripMenuItem.Text = "Send Messages";
            // 
            // messageList
            // 
            this.messageList.AllowColumnReorder = true;
            this.messageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fromHeader,
            this.subjectHeader,
            this.dateHeader});
            this.messageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageList.FullRowSelect = true;
            this.messageList.GridLines = true;
            this.messageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.messageList.Location = new System.Drawing.Point(0, 0);
            this.messageList.Name = "messageList";
            this.messageList.Size = new System.Drawing.Size(824, 191);
            this.messageList.TabIndex = 6;
            this.messageList.UseCompatibleStateImageBehavior = false;
            this.messageList.View = System.Windows.Forms.View.Details;
            this.messageList.SelectedIndexChanged += new System.EventHandler(this.messageList_SelectedIndexChanged);
            // 
            // fromHeader
            // 
            this.fromHeader.Text = "From";
            this.fromHeader.Width = 182;
            // 
            // subjectHeader
            // 
            this.subjectHeader.Text = "Subject";
            this.subjectHeader.Width = 489;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 120;
            // 
            // messages
            // 
            this.messages.DataSetName = "messages";
            this.messages.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 96);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 507);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.messageList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(824, 501);
            this.splitContainer2.SplitterDistance = 191;
            this.splitContainer2.TabIndex = 7;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.subjectLbl);
            this.splitContainer3.Panel1.Controls.Add(this.fromLbl);
            this.splitContainer3.Panel1.Controls.Add(this.attachmentsBtn);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.messageViewer);
            this.splitContainer3.Size = new System.Drawing.Size(824, 306);
            this.splitContainer3.SplitterDistance = 57;
            this.splitContainer3.TabIndex = 0;
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLbl.Location = new System.Drawing.Point(76, 30);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(0, 16);
            this.subjectLbl.TabIndex = 4;
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLbl.Location = new System.Drawing.Point(76, 11);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(0, 16);
            this.fromLbl.TabIndex = 3;
            // 
            // attachmentsBtn
            // 
            this.attachmentsBtn.FlatAppearance.BorderSize = 0;
            this.attachmentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("attachmentsBtn.Image")));
            this.attachmentsBtn.Location = new System.Drawing.Point(769, 3);
            this.attachmentsBtn.Name = "attachmentsBtn";
            this.attachmentsBtn.Size = new System.Drawing.Size(52, 51);
            this.attachmentsBtn.TabIndex = 2;
            this.attachmentsBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // messageViewer
            // 
            this.messageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageViewer.Location = new System.Drawing.Point(0, 0);
            this.messageViewer.Name = "messageViewer";
            this.messageViewer.Size = new System.Drawing.Size(824, 245);
            this.messageViewer.TabIndex = 0;
            this.messageViewer.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 628);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.userButtonPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "AYBABTU";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.userButtonPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.TreeView folderList;
        private System.Windows.Forms.Panel userButtonPanel;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button getMessageBtn;
        private System.Windows.Forms.Button addressBookBtn;
        private System.Windows.Forms.Button writeMessageBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button replyAllBtn;
        private System.Windows.Forms.Button replyBtn;
        private System.Windows.Forms.ToolStripMenuItem newMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAttachmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMessageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem replyToSenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replyToAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAYBABTUToolStripMenuItem;
        private System.Windows.Forms.ListView messageList;
        private System.Windows.Forms.ColumnHeader fromHeader;
        private System.Windows.Forms.ColumnHeader subjectHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Data.DataSet messages;
        private System.Data.DataTable dataTable1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Label label2;
        private Label label1;
        private RichTextBox messageViewer;
        private Button attachmentsBtn;
        private Label subjectLbl;
        private Label fromLbl;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem getAndSendToolStripMenuItem;
        private ToolStripMenuItem getMessagesToolStripMenuItem;
        private ToolStripMenuItem sendMessagesToolStripMenuItem;
    }
}

