using Short_Story_Network___Practical_Evaluation_Rootcode.Controlers;
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

        public uiWriters()
        {
            InitializeComponent();
            Load_Writers();
        }

        private void Load_Writers()
        {
            Fill_Data("W");
        }

        private void showAllUsers_Click(object sender, EventArgs e)
        {
            if (showAllUsers.Text == "Show writers only")
            {
                Fill_Data("W");
                showAllUsers.Text = "Show all users";
            }
            else
            {
                showAllUsers.Text = "Show writers only";
                Fill_Data("A");
            }
        }
        private ClientResponse Fill_Data(string uRole)
        {
            try
            {
                clsUser clsWritersObj = new clsUser();

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
    }
}
