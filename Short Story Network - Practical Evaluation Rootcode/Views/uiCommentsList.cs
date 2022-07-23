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
    public partial class uiCommentsList : Form
    {
        public int _postID = 0;
        public int userID = 0;
        public int commentID = 0;
        clsComments commentsObj = new();
        clsUserAccessHandler clsUserAccessHandler = new clsUserAccessHandler();
        private bool _overrideAccess = false;
        private LoggedUserDetails _loggedUserDetailsObj;

        public uiCommentsList(LoggedUserDetails loggedUserDetailsObj, bool overrideAccess = false)
        {
            InitializeComponent();
            _overrideAccess = overrideAccess;
            _loggedUserDetailsObj = loggedUserDetailsObj;
        }

        public ClientResponse Fill_Data(int postID)
        {
            try
            {
                _postID = postID;
                var writerList = (List<Comment>)commentsObj.Get_Comments_List(postID).ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["CommentID"].Visible = false;
                this.userList.Columns["PostID"].Visible = false;        
                this.userList.Columns["CreatedBy"].Visible = false;
                foreach (DataGridViewColumn column in this.userList.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
                this.userList.ColumnHeadersVisible = false;

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
                var selectedID = (int)this.userList.Rows[e.RowIndex].Cells["CommentID"].Value;
                var createdBy = (int)this.userList.Rows[e.RowIndex].Cells["CreatedBy"].Value;

                uiComments commentsObj = new(_loggedUserDetailsObj, true, selectedID, createdBy);
                commentsObj.ShowDialog();
                Fill_Data(_postID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
