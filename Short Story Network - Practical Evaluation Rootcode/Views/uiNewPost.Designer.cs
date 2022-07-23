namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    partial class uiNewPost
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
            this.postText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.seeComments = new System.Windows.Forms.Button();
            this.addComment = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // postText
            // 
            this.postText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postText.Location = new System.Drawing.Point(0, 0);
            this.postText.Multiline = true;
            this.postText.Name = "postText";
            this.postText.Size = new System.Drawing.Size(800, 450);
            this.postText.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.seeComments);
            this.panel1.Controls.Add(this.addComment);
            this.panel1.Controls.Add(this.Confirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 2;
            // 
            // seeComments
            // 
            this.seeComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.seeComments.BackColor = System.Drawing.Color.DodgerBlue;
            this.seeComments.FlatAppearance.BorderSize = 0;
            this.seeComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeComments.ForeColor = System.Drawing.Color.White;
            this.seeComments.Location = new System.Drawing.Point(383, 14);
            this.seeComments.Name = "seeComments";
            this.seeComments.Size = new System.Drawing.Size(131, 23);
            this.seeComments.TabIndex = 2;
            this.seeComments.Text = "See Comment";
            this.seeComments.UseVisualStyleBackColor = false;
            this.seeComments.Click += new System.EventHandler(this.seeComments_Click);
            // 
            // addComment
            // 
            this.addComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addComment.BackColor = System.Drawing.Color.DodgerBlue;
            this.addComment.FlatAppearance.BorderSize = 0;
            this.addComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addComment.ForeColor = System.Drawing.Color.White;
            this.addComment.Location = new System.Drawing.Point(520, 14);
            this.addComment.Name = "addComment";
            this.addComment.Size = new System.Drawing.Size(131, 23);
            this.addComment.TabIndex = 2;
            this.addComment.Text = "Add Comment";
            this.addComment.UseVisualStyleBackColor = false;
            this.addComment.Click += new System.EventHandler(this.addComment_Click);
            // 
            // Confirm
            // 
            this.Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Confirm.BackColor = System.Drawing.Color.DodgerBlue;
            this.Confirm.FlatAppearance.BorderSize = 0;
            this.Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm.ForeColor = System.Drawing.Color.White;
            this.Confirm.Location = new System.Drawing.Point(657, 13);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(131, 23);
            this.Confirm.TabIndex = 2;
            this.Confirm.Text = "Save";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // uiNewPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.postText);
            this.Name = "uiNewPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "uiNewPost";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox postText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button addComment;
        private System.Windows.Forms.Button seeComments;
    }
}