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
    public partial class uiComments : Form
    {

        public int postID = 0;
        public int userID = 0;
        private int _commentID = 0;
        clsComments clsCommentsObj = new();
        private bool _overrideAccess = false;
        private LoggedUserDetails _loggedUserDetailsObj;
        private int _userPostID = 0;

        public uiComments(LoggedUserDetails loggedUserDetailsObj, bool overrideAccess = false, int commentID = 0, int userPostID = 0)
        {
            InitializeComponent();
            _commentID = commentID;
            _overrideAccess = overrideAccess;
            _loggedUserDetailsObj = loggedUserDetailsObj;
            Load_Comment();
            UI_Handler();
            _userPostID = userPostID;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                Comment commentObj = new()
                {
                    Comment1 = commentText.Text,
                    CreatedBy = userID,
                    PostID=postID 
                };
                if (_commentID > 0)
                {
                    commentObj.CommentID = _commentID;
                }
                clsCommentsObj.Save_Date(commentObj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Load_Comment()
        {
            try
            {
                var writerList = (List<Comment>)clsCommentsObj.Get_Comments(_commentID).ResultObject;
                if (writerList.Count > 0)
                {
                    commentText.Text = writerList[0].Comment1.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void UI_Handler()
        {
            try
            {
                clsUserAccessHandler clsUserAccessHandler = new clsUserAccessHandler();
                Confirm.Enabled = _userPostID != _loggedUserDetailsObj.userID && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.CreatePost)
                    && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.EditPost);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
