using Short_Story_Network___Practical_Evaluation_Rootcode.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsLoginPage
    {
        private string _userName;
        private string _password;

        public clsLoginPage(UserInfo userInfoObj)
        {
            _userName = userInfoObj.UserId;
            _password = userInfoObj.PasswordHash;
        }

        #region "CRUD"  
        private ClientResponse Autoentication_User()
        {
            List<UserInfo> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    result = ctx.UserInfoes
                        .Where(re => re.UserId == _userName)
                        .Where(re => re.PasswordHash== _password)
                        .ToList();
                }
                return new ClientResponse { Message = "Success", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
        #endregion



        private Boolean Autoentication()
        {
            try
            {

                if (((List<UserInfo>)Autoentication_User().ResultObject).Count > 0)
                {
                    uiWriters writersObj = new();
                    writersObj.Show();
                }
                else
                {
                    MessageBox.Show("User Account not found");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
