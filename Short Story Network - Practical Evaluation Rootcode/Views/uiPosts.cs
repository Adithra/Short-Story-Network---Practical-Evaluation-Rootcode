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
        public int userID = 0;
        private LoggedUserDetails _loggedUserDetailsObj;


        public uiPosts(LoggedUserDetails loggedUserDetailsObj)
        {
            InitializeComponent();
            _loggedUserDetailsObj = loggedUserDetailsObj;
        }
        private void Load_Writers()
        {

        }

        private void showAllUsers_Click(object sender, EventArgs e)
        {

        }

        public ClientResponse Fill_Data()
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
                uiNewPost uiNewPostObj = new();
                uiNewPostObj.userID = userID;
                uiNewPostObj.ShowDialog();
                Fill_Data(userID);
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
                uiNewPost uiNewPostObj = new();
                var postID = (int)this.userList.Rows[e.RowIndex].Cells["PostId"].Value;
                uiNewPostObj.postID = postID;
                uiNewPostObj.Load_Post();
                uiNewPostObj.ShowDialog();
                Fill_Data(userID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}