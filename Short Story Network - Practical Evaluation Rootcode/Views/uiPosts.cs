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
    public partial class uiPosts : Form
    {
        private LoggedUserDetails _loggedUserDetailsObj;
        clsUserAccessHandler clsUserAccessHandler = new clsUserAccessHandler();
        private bool _overrideAccess = false;


        public uiPosts(LoggedUserDetails loggedUserDetailsObj, bool overrideAccess = false)
        {
            InitializeComponent();
            _loggedUserDetailsObj = loggedUserDetailsObj;
            _overrideAccess = overrideAccess;
            UI_Handler();
        }
        private void Load_Writers()
        {

        }

        private void showAllUsers_Click(object sender, EventArgs e)
        {

        }

        public ClientResponse Fill_Data(int userID = 0)
        {
            try
            {
                clsPost clsPostObj = new clsPost();
                var writerList = (List<Post>)clsPostObj.Get_Post_List(userID).ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["PostId"].Visible = false;
                this.userList.Columns["UserId"].Visible = false;

                return new ClientResponse { Message = "", State = true, ResultObject = true };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        private void userList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.userList.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                this.userList.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void userList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var userID = this.userList.Rows[e.RowIndex].Cells["Id"].Value;
            }
            catch (Exception)
            {

                throw;

            }
        }

        private void showAllUsers_Click_1(object sender, EventArgs e)
        {
            try
            {
                uiNewPost uiNewPostObj = new(_loggedUserDetailsObj);
                uiNewPostObj.ShowDialog();
                Fill_Data(_loggedUserDetailsObj.userID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void uiPosts_Load(object sender, EventArgs e)
        {
            Fill_Data(0);
        }

        private void userList_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                uiNewPost uiNewPostObj = new(_loggedUserDetailsObj, true);
                var postID = (int)this.userList.Rows[e.RowIndex].Cells["PostId"].Value;
                uiNewPostObj.Load_Post(postID);
                uiNewPostObj.ShowDialog();
                Fill_Data(postID);
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
                newPost.Enabled = _overrideAccess != true && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.AddComment);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}