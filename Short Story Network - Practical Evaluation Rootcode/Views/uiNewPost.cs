using Short_Story_Network___Practical_Evaluation_Rootcode.Controlers;
using Short_Story_Network___Practical_Evaluation_Rootcode.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    public partial class uiNewPost : Form
    {
        public int postID = 0;
        public int userID = 0;
        private LoggedUserDetails _loggedUserDetailsObj;
        private bool _overrideAccess = false;
        private int _userPostID = 0;

        public uiNewPost(LoggedUserDetails loggedUserDetailsObj, bool overrideAccess = false, int userPostID = 0)
        {
            InitializeComponent();
            _loggedUserDetailsObj = loggedUserDetailsObj;
            _overrideAccess = overrideAccess;
            _userPostID = userPostID;
            UI_Handler();
        }

        clsPost clsPostObj = new();

        private void Confirm_Click(object sender, EventArgs e)
        {
            FileStream fs;
            BinaryReader br;
            string FileName = button1.Tag;
            byte[] ImageData;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            Post postObj = new()
            {
                Post1 = postText.Text,
                UserId = _loggedUserDetailsObj.userID
            };
            if (postID > 0)
            {
                postObj.PostId = postID;
            }
            clsPostObj.Save_Date(postObj);
            this.Close();
        }

        public void Load_Post(int getPostID) {
            try
            {
                clsPost clsPostObj = new();
                var writerList = (List<Post>)clsPostObj.Get_Post(getPostID).ResultObject;
                if (writerList.Count >0)
                {
                    postText.Text = writerList[0].Post1.ToString();
                } 
            }
            catch (Exception ex)
            {
            }
        }

        private void addComment_Click(object sender, EventArgs e)
        {
            try
            {
                uiComments commentsObj = new(_loggedUserDetailsObj, false)
                {
                    userID = _loggedUserDetailsObj.userID,
                    postID = postID
                };
                commentsObj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void seeComments_Click(object sender, EventArgs e)
        {
            try
            {
                uiCommentsList commentsListObj = new(_loggedUserDetailsObj, _overrideAccess);
                commentsListObj.Fill_Data(postID);
                commentsListObj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UI_Handler()
        {
            try
            {
                clsUserAccessHandler clsUserAccessHandler = new clsUserAccessHandler();
                addComment.Enabled = _userPostID != _loggedUserDetailsObj.userID && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.AddComment);
                seeComments.Enabled = _overrideAccess != true && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.SeeComments);
                Confirm.Enabled = _overrideAccess != true && _userPostID == _loggedUserDetailsObj.userID && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.CreatePost)
                    && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.EditPost);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(open.FileName);
                    button1.Tag = open.FileName;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
