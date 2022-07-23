using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsWriters
    {
        string _userId;
        public clsWriters()
        {

        }

        #region "CRUD"  
        public ClientResponse Get_Writer_List()
        {
            List<UserInfo> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    var rol = UserRoles.writers.ToString();
                    result = ctx.UserInfoes
                        .Where(re => re.UserRole == "M")
                        .ToList();
                }
                return new ClientResponse { Message = "", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex };
            }
        }
        #endregion
    }
}
