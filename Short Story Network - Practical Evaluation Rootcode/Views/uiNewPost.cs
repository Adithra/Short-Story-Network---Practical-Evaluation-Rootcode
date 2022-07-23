using Short_Story_Network___Practical_Evaluation_Rootcode.Controlers;
using Short_Story_Network___Practical_Evaluation_Rootcode.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public uiNewPost(LoggedUserDetails loggedUserDetailsObj, bool overrideAccess = false)
        {
            InitializeComponent();
            _loggedUserDetailsObj = loggedUserDetailsObj;
            _overrideAccess = overrideAccess;
            UI_Handler();
        }

        clsPost clsPostObj = new();

        private void Confirm_Click(object sender, EventArgs e)
        {
            Post postObj = new();
            postObj.Post1 = postText.Text;
            postObj.UserId = _loggedUserDetailsObj.userID;
            if (postID > 0)
            {
                postObj.PostId = postID;
            }
            clsPostObj.Save_Date(postObj);
        }

        public void Load_Post(int getPostID) {
            try
            {
                clsPost clsPostObj = new clsPost();
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
                uiComments commentsObj = new();
                commentsObj.userID = _loggedUserDetailsObj.userID;
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
                uiCommentsList commentsListObj = new();
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
                addComment.Enabled= _overrideAccess != true && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.AddComment);
                seeComments.Enabled= _overrideAccess != true && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.SeeComments);
                Confirm.Enabled = _overrideAccess != true && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.CreatePost)
                    && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.EditPost);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
