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
            Save_Date();
        }

        private void userNameText_Leave(object sender, EventArgs e)
        {
            try
            {
                var tempValue = string.Empty;
                var result = ((List<UserInfo>)userRegistrationObj.Check_User_ID_Availability(userNameText.Text).ResultObject).Count == 0 ? "available" : "unavailable";
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


        private bool Validate_Date()
        {
            var result = true;
            try
            {
                if (PassowrdText.Text != PassowrdConText.Text)
                {
                    result = false;
                    label7.Text = "Invalid password";
                }

                if (PassowrdText.Text == string.Empty)
                {
                    result = false;
                    label7.Text = "Enter password";
                }
                if (emailAddressText.Text == string.Empty)
                {
                    result = false;
                    label6.Text = "Invalid email address";
                }

                string value = emailAddressText.Text;
                if (value != string.Empty &&  value.Contains('@') && value.Contains('.'))
                {
                    var index1 = value.IndexOf('@');
                    var index2 = value.IndexOf('.');
                    bool a = false;
                    bool b = false;
                    if (index1 < value.Length - 1 && index1 > 0)
                    {
                        a = Char.IsLetterOrDigit(value, index1 + 1);
                    }

                    if (index2 < value.Length - 1 && index1 > 0)
                    {
                        b = Char.IsLetterOrDigit(value, index2 + 1);
                    }

                    if (a == true && b == true)
                    {
                    }
                    else
                    {
                        label6.Text = "Invalid email address";
                        result = false;
                    }
                }

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        private ClientResponse Save_Date()
        {
            try
            {
                if (!Validate_Date())
                {
                    return new ClientResponse { State = false };

                }

                clsLoginPage clsLoginPageObj = new(new UserInfo());                

                UserInfo userInfoObj = new()
                {
                    UserId = userNameText.Text,
                    FirstName = firstNameText.Text,
                    LastName = lastNameText.Text,
                    PasswordHash = clsLoginPageObj.HashPassword(PassowrdConText.Text),
                    EmailAddress = emailAddressText.Text,
                    UserRole = "U"
                };
                var clinetResult = userRegistrationObj.Save_Date(userInfoObj);
                this.Close();
                return new ClientResponse { Message = "", State = clinetResult.State };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
    }
}
