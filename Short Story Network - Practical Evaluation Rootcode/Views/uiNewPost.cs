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
        public uiNewPost()
        {
            InitializeComponent();
        }

        clsPost clsPostObj = new();

        private void Confirm_Click(object sender, EventArgs e)
        {
            Post postObj = new();
            postObj.Post1 = postText.Text;
            if (postID > 0)
            {
                postObj.PostId = postID;
            }
            clsPostObj.Save_Date(postObj);
        }
    }
}
