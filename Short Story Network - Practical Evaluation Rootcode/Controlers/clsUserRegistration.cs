using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsUserRegistration
    {
        #region "CRUD"  
        public ClientResponse Check_User_ID_Availability(string ID)
        {
            List<UserInfo> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    //var rol = UserRoles.writers.ToString();
                    result = ctx.UserInfoes
                        .Where(re => re.UserId == ID)
                        .ToList();
                }
                return new ClientResponse { Message = "", State = result.Count > 0, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex };
            }
        }

        public ClientResponse Save_Date(UserInfo userInfoObj)
        {
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    ctx.UserInfoes.Add(userInfoObj);
                    ctx.SaveChanges();
                }
                return new ClientResponse { Message = "", State = true };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
        #endregion
    }
}