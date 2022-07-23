using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsUser
    {
        string _userId;
        public clsUser()
        {

        }

        #region "CRUD"  
        public ClientResponse Get_Writer_List(string uRole)
        {
            List<UserInfo> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    if (uRole == "A")
                    {
                       result = ctx.UserInfoes
                      .ToList();
                    }
                    else
                    {
                        result = ctx.UserInfoes
                       .Where(re => re.UserRole == uRole)
                       .ToList();
                    }
                    //var rol = UserRoles.writers.ToString();
                }
                return new ClientResponse { Message = "", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
        #endregion
    }
}
