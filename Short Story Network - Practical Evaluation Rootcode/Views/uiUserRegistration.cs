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
    public partial class uiUserRegistration : Form
    {
        public uiUserRegistration()
        {
            InitializeComponent();
        }
        clsUserRegistration userRegistrationObj = new();
        private void login_Click(object sender, EventArgs e)
        {

        }

        private void userNameText_Leave(object sender, EventArgs e)
        {
            try
            {
                var tempValue = string.Empty;
                var result = userRegistrationObj.Check_User_ID_Availability(userNameText.Text).State == true ? "available" : "unavailable";
                availableState.Text = result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ClientResponse Password_Handler()
        {
            try
            {
                bool result = PassowrdText.Text == PassowrdConText.Text;

                return new ClientResponse { Message = "", State = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        private ClientResponse Save_Date()
        {
            try
            {
                UserInfo userInfoObj = new()
                {
                    UserId = userNameText.Text,
                    FirstName = firstNameText.Text,
                    LastName = lastNameText.Text,
                    PasswordHash = PassowrdConText.Text,
                    EmailAddress = emailAddressText.Text
                };
                var clinetResult = userRegistrationObj.Save_Date(userInfoObj);
                return new ClientResponse { Message = "", State = clinetResult.State };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
    }
}
