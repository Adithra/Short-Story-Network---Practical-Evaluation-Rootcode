﻿namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.userList = new System.Windows.Forms.DataGridView();
            this.newPost = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newPost);
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
            // newPost
            // 
            this.newPost.BackColor = System.Drawing.Color.DodgerBlue;
            this.newPost.FlatAppearance.BorderSize = 0;
            this.newPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newPost.ForeColor = System.Drawing.Color.White;
            this.newPost.Location = new System.Drawing.Point(657, 13);
            this.newPost.Name = "newPost";
            this.newPost.Size = new System.Drawing.Size(131, 23);
            this.newPost.TabIndex = 2;
            this.newPost.Text = "New Post";
            this.newPost.UseVisualStyleBackColor = false;
            this.newPost.Click += new System.EventHandler(this.showAllUsers_Click_1);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView userList;
        private System.Windows.Forms.Button newPost;
    }
}