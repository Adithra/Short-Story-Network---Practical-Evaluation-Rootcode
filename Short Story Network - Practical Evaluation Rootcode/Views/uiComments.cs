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
    public partial class uiComments : Form
    {

        public int postID = 0;
        public int userID = 0;
        public int commentID = 0;
        clsComments clsCommentsObj = new();

        public uiComments()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                Comment commentObj = new()
                {
                    Comment1 = commentText.Text,
                    CreatedBy = userID
                };
                if (commentID > 0)
                {
                    commentObj.CommentID = commentID;
                }
                clsCommentsObj.Save_Date(commentObj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Load_Post()
        {
            try
            {
                var writerList = (List<Post>)clsCommentsObj.Get_Comments(commentID).ResultObject;
                if (writerList.Count > 0)
                {
                    commentText.Text = writerList[0].Post1.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
