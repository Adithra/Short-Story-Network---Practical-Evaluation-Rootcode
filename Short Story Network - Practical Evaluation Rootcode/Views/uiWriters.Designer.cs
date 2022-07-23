namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    partial class uiWriters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uiWriters));
            this.userList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.followWriter = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.revokeEditorState = new System.Windows.Forms.ToolStripMenuItem();
            this.bann = new System.Windows.Forms.ToolStripMenuItem();
            this.unBan = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.GOTOPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.showAllUsers = new System.Windows.Forms.Button();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.BackgroundColor = System.Drawing.Color.White;
            this.userList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userList.ContextMenuStrip = this.contextMenuStrip1;
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.Location = new System.Drawing.Point(0, 0);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(800, 450);
            this.userList.TabIndex = 0;
            this.userList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userList_CellClick);
            this.userList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userList_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.followWriter,
            this.setAsEditor,
            this.revokeEditorState,
            this.bann,
            this.unBan});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 114);
            // 
            // followWriter
            // 
            this.followWriter.Name = "followWriter";
            this.followWriter.Size = new System.Drawing.Size(174, 22);
            this.followWriter.Text = "Follow";
            this.followWriter.Click += new System.EventHandler(this.followWriter_Click);
            // 
            // setAsEditor
            // 
            this.setAsEditor.Name = "setAsEditor";
            this.setAsEditor.Size = new System.Drawing.Size(174, 22);
            this.setAsEditor.Text = "Set as Editor";
            this.setAsEditor.Click += new System.EventHandler(this.setAsEditor_Click);
            // 
            // revokeEditorState
            // 
            this.revokeEditorState.Name = "revokeEditorState";
            this.revokeEditorState.Size = new System.Drawing.Size(174, 22);
            this.revokeEditorState.Text = "Revoke Editor state";
            this.revokeEditorState.Click += new System.EventHandler(this.revokeEditorState_Click);
            // 
            // bann
            // 
            this.bann.Name = "bann";
            this.bann.Size = new System.Drawing.Size(174, 22);
            this.bann.Text = "Ban";
            this.bann.Click += new System.EventHandler(this.bann_Click_2);
            // 
            // unBan
            // 
            this.unBan.Name = "unBan";
            this.unBan.Size = new System.Drawing.Size(174, 22);
            this.unBan.Text = "UnBan";
            this.unBan.Click += new System.EventHandler(this.unBan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.GOTOPost);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.showAllUsers);
            this.panel1.Controls.Add(this.userNameText);
            this.panel1.Controls.Add(this.login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 397);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 53);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(383, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "See posts statistics";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GOTOPost
            // 
            this.GOTOPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GOTOPost.BackColor = System.Drawing.Color.DodgerBlue;
            this.GOTOPost.FlatAppearance.BorderSize = 0;
            this.GOTOPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GOTOPost.ForeColor = System.Drawing.Color.White;
            this.GOTOPost.Location = new System.Drawing.Point(520, 18);
            this.GOTOPost.Name = "GOTOPost";
            this.GOTOPost.Size = new System.Drawing.Size(131, 23);
            this.GOTOPost.TabIndex = 2;
            this.GOTOPost.Text = "See posts";
            this.GOTOPost.UseVisualStyleBackColor = false;
            this.GOTOPost.Click += new System.EventHandler(this.GOTOPost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Name";
            // 
            // showAllUsers
            // 
            this.showAllUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showAllUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.showAllUsers.FlatAppearance.BorderSize = 0;
            this.showAllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showAllUsers.ForeColor = System.Drawing.Color.White;
            this.showAllUsers.Location = new System.Drawing.Point(657, 17);
            this.showAllUsers.Name = "showAllUsers";
            this.showAllUsers.Size = new System.Drawing.Size(131, 23);
            this.showAllUsers.TabIndex = 2;
            this.showAllUsers.Text = "Show all users";
            this.showAllUsers.UseVisualStyleBackColor = false;
            this.showAllUsers.Click += new System.EventHandler(this.showAllUsers_Click);
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(12, 20);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(255, 20);
            this.userNameText.TabIndex = 3;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.DodgerBlue;
            this.login.FlatAppearance.BorderSize = 0;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.ForeColor = System.Drawing.Color.White;
            this.login.Location = new System.Drawing.Point(279, 17);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 4;
            this.login.Text = "Search";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // uiWriters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uiWriters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.uiWriters_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.userList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button showAllUsers;
        private System.Windows.Forms.Button GOTOPost;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem followWriter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.ToolStripMenuItem setAsEditor;
        private System.Windows.Forms.ToolStripMenuItem revokeEditorState;
        private System.Windows.Forms.ToolStripMenuItem bann;
        private System.Windows.Forms.ToolStripMenuItem unBan;
        private System.Windows.Forms.Button button1;
    }
}