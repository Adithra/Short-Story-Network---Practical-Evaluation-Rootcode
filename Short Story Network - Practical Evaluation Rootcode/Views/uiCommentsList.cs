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
    public partial class uiCommentsList : Form
    {
        public int postID = 0;
        public int userID = 0;
        public int commentID = 0;
        clsComments commentsObj = new();

        public uiCommentsList()
        {
            InitializeComponent();
        }

        public ClientResponse Fill_Data(int postID)
        {
            try
            {
                var writerList = (List<Post>)commentsObj.Get_Comments_List(postID).ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["CommentID"].Visible = false;
                this.userList.Columns["PostID"].Visible = false;        
                this.userList.Columns["UseCreatedByrId"].Visible = false;

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

        private void userList_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                uiComments commentsObj = new();
                commentsObj.commentID = commentID;

                commentsObj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
