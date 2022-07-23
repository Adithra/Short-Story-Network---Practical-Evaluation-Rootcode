using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ClientResponse Get_Writer_List(string uRole, int userID = 0, string userName = "")
        {
            List<UserInfo> result = new();
            List<Follower> followerObj;

            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {

                    
                    if (userID != 0)
                    {
                        followerObj = ctx.Followers
                            .Where(re => re.ActiveUserID == userID)
                            .Include(re => re.UserInfos)
                            .ToList();

                        foreach (var item in followerObj)
                        {
                            result.Add(item.UserInfos);
                        }
                    }
                    else if (userName != string.Empty)
                    {
                        result = ctx.UserInfoes
                            .Where(re => re.UserId == userName)
                            .ToList();
                    }
                    else if (uRole == "U")
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

        public ClientResponse Set_Followers(List<Follower> followerList)
        {
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    foreach (var follower in followerList)
                    {
                        ctx.Followers.Add(follower);
                        ctx.SaveChanges();
                    }                      
                }
                return new ClientResponse { Message = "Success", State = true, ResultObject = true };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }
        #endregion
    }
}
