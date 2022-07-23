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
    public partial class uiStatistics : Form
    {
        public int _postID = 0;
        public int userID = 0;
        public int commentID = 0;
        clsStatistics statisticsObj = new();

        public uiStatistics()
        {
            InitializeComponent();
            Fill_Data();
        }

        public ClientResponse Fill_Data()
        {
            try
            {
                var writerList = (List<StatVowel>)statisticsObj.Get_Statistics().ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["PostId"].Visible = false;
                this.userList.Columns["Post"].Visible = false;
                this.userList.Columns["Id"].Visible = false;
                this.userList.Columns["SingleVowelCount"].HeaderText = "Single Vowel Count";
                this.userList.Columns["PairVowelCount"].HeaderText = "Pair Vowel Count";

                foreach (DataGridViewColumn column in this.userList.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
                return new ClientResponse { Message = "", State = true, ResultObject = true };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        private void newPost_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
