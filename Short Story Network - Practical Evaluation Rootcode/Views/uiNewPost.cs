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
    public partial class uiNewPost : Form
    {
        public int postID = 0;
        public int userID = 0;

        public uiNewPost()
        {
            InitializeComponent();
        }

        clsPost clsPostObj = new();

        private void Confirm_Click(object sender, EventArgs e)
        {
            Post postObj = new();
            postObj.Post1 = postText.Text;
            postObj.UserId = userID;
            if (postID > 0)
            {
                postObj.PostId = postID;
            }
            clsPostObj.Save_Date(postObj);
        }

        public void Load_Post() {
            try
            {
                clsPost clsPostObj = new clsPost();
                var writerList = (List<Post>)clsPostObj.Get_Post(postID).ResultObject;
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

        }
    }
}
