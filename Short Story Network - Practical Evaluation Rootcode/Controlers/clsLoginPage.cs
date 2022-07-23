using Short_Story_Network___Practical_Evaluation_Rootcode.Models;
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
        private UserInfo _userInfoObj = new();
        private LoggedUserDetails loggedUserDetailsObj = new();

        public clsLoginPage(UserInfo userInfoObj)
        {
            _userInfoObj.UserId = userInfoObj.UserId;
            _userInfoObj.PasswordHash = userInfoObj.PasswordHash;
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
                        .Where(re => re.UserId == _userInfoObj.UserId)
                        .Where(re => re.PasswordHash== _userInfoObj.PasswordHash)
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



        public void Autoentication()
        {
            try
            {

                var result = (List<UserInfo>)Autoentication_User().ResultObject;

                if ((result.Count > 0))
                {
                    uiWriters writersObj = new()
                    {
                        userInfoObj = result[0]
                    };
                    //loggedUserDetailsObj.CreatedDate = DateTime.Now.Date);
                    loggedUserDetailsObj.userID = result[0].Id;
                    loggedUserDetailsObj.userName = result[0].UserId;
                    loggedUserDetailsObj.userFullName = string.Concat(result[0].FirstName,string.Empty,result[0].LastName);
                    loggedUserDetailsObj.UserAccessType = 

                    writersObj.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User Account not found");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
