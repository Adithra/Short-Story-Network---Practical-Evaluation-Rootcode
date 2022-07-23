namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    partial class uiPosts
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
            this.showAllUsers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userList)).BeginInit();
            this.SuspendLayout();
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showAllUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 3;
            // 
            // userList
            // 
            this.userList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.Location = new System.Drawing.Point(0, 0);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(800, 450);
            this.userList.TabIndex = 2;
            // 
            // uiPosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userList);
            this.Name = "uiPosts";
            this.Text = "uiPosts";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showAllUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView userList;
    }
}