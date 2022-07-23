using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Short_Story_Network___Practical_Evaluation_Rootcode.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    public partial class uiLoginPage : Form
    {

        public uiLoginPage()
        {
            InitializeComponent();
        }
        #region Componenet Events
        private void login_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new()
            {
                UserId = userNameText.Text,
                PasswordHash = PassowrdText.Text
            };
            clsLoginPage clsLoginPageObj = new(userInfo);
            clsLoginPageObj.Autoentication(this);

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            uiUserRegistration userRegistrationObj = new();
            userRegistrationObj.ShowDialog();
        }      
    }
}
