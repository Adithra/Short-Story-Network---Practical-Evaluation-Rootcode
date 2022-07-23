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
            this.userList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showAllUsers = new System.Windows.Forms.Button();
            this.GOTOPost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.Location = new System.Drawing.Point(0, 0);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(800, 450);
            this.userList.TabIndex = 0;
            this.userList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userList_CellClick);
            this.userList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userList_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GOTOPost);
            this.panel1.Controls.Add(this.showAllUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 1;
            // 
            // showAllUsers
            // 
            this.showAllUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.showAllUsers.FlatAppearance.BorderSize = 0;
            this.showAllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showAllUsers.ForeColor = System.Drawing.Color.White;
            this.showAllUsers.Location = new System.Drawing.Point(657, 13);
            this.showAllUsers.Name = "showAllUsers";
            this.showAllUsers.Size = new System.Drawing.Size(131, 23);
            this.showAllUsers.TabIndex = 2;
            this.showAllUsers.Text = "Show all users";
            this.showAllUsers.UseVisualStyleBackColor = false;
            this.showAllUsers.Click += new System.EventHandler(this.showAllUsers_Click);
            // 
            // GOTOPost
            // 
            this.GOTOPost.BackColor = System.Drawing.Color.DodgerBlue;
            this.GOTOPost.FlatAppearance.BorderSize = 0;
            this.GOTOPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GOTOPost.ForeColor = System.Drawing.Color.White;
            this.GOTOPost.Location = new System.Drawing.Point(520, 14);
            this.GOTOPost.Name = "GOTOPost";
            this.GOTOPost.Size = new System.Drawing.Size(131, 23);
            this.GOTOPost.TabIndex = 2;
            this.GOTOPost.Text = "See posts";
            this.GOTOPost.UseVisualStyleBackColor = false;
            this.GOTOPost.Click += new System.EventHandler(this.GOTOPost_Click);
            // 
            // uiWriters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userList);
            this.Name = "uiWriters";
            this.Text = "uiWriters";
            ((System.ComponentModel.ISupportInitialize)(this.userList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button showAllUsers;
        private System.Windows.Forms.Button GOTOPost;
    }
}