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
        public uiWriters()
        {
            InitializeComponent();
            Load_Writers();
        }

        private void Load_Writers()
        {
            try
            {
                clsUser clsWritersObj = new clsUser();

                var writerList = (List<UserInfo>)clsWritersObj.Get_Writer_List().ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["UserId"].Visible = false;
                this.userList.Columns["PasswordHash"].Visible = false;
                this.userList.Columns["EmailAddress"].Visible = false;
                this.userList.Columns["UserRole"].Visible = false;
                this.userList.Columns["IsEditor"].Visible = false;
                this.userList.Columns["IsBanned"].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }        
    }
}
