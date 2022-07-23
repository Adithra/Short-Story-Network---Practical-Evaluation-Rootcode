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
    public partial class uiWriters : Form
    {
        public UserInfo userInfoObj = new UserInfo();
        private LoggedUserDetails _loggedUserDetailsObj;
        clsUser clsWritersObj = new clsUser();

        public uiWriters(LoggedUserDetails loggedUserDetailsObj)
        {
            InitializeComponent();
            _loggedUserDetailsObj = loggedUserDetailsObj;
        }

        public void Load_Writers()
        {
            Fill_Data(_loggedUserDetailsObj.UserRole);
        }

        private void showAllUsers_Click(object sender, EventArgs e)
        {
            if (showAllUsers.Text == "Show Follower only")
            {
                Fill_Data("F");
                showAllUsers.Text = "Show all users";
            }
            else
            {
                showAllUsers.Text = "Show Follower only";
                Fill_Data("U");
            }
        }
        private ClientResponse Fill_Data(string uRole)
        {
            try
            {
                var writerList = (List<UserInfo>)clsWritersObj.Get_Writer_List(uRole).ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["Id"].Visible = false;
                this.userList.Columns["UserId"].Visible = false;
                this.userList.Columns["PasswordHash"].Visible = false;
                this.userList.Columns["EmailAddress"].Visible = false;
                this.userList.Columns["UserRole"].Visible = false;
                this.userList.Columns["IsEditor"].Visible = false;
                this.userList.Columns["IsBanned"].Visible = false;
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
                var userID = (int)this.userList.Rows[e.RowIndex].Cells["Id"].Value;
                uiPosts uiPostsObj = new();
                uiPostsObj.userID = userID;
                uiPostsObj.Fill_Data(0);
                uiPostsObj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GOTOPost_Click(object sender, EventArgs e)
        {
            try
            {
                uiPosts uiNewPostObj = new();
                uiNewPostObj.userID = userInfoObj.Id;
                uiNewPostObj.Fill_Data(userInfoObj.Id);
                uiNewPostObj.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void followWriter_Click(object sender, EventArgs e)
        {
            try
            {
                List<Follower> followerList = new();
                if (this.userList.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in this.userList.SelectedRows)
                    {
                        followerList.Add(new Follower
                        {
                            Id = _loggedUserDetailsObj.userID,
                            FollwingID = (int)row.Cells["Id"].Value
                        });
                    }
                    clsWritersObj.Set_Followers(followerList);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
