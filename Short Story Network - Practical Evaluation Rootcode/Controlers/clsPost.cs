using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsPost
    {
        #region "CRUD"  
        public ClientResponse Get_Post_List(int userID)
        {
            List<Post> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    if (userID == 0)
                    {
                        result = ctx.Posts
                       .ToList();
                    }
                    else
                    {
                        result = ctx.Posts
                       .Where(re => re.UserId == userID)
                       .ToList();
                    }
                    var rol = UserRoles.writers.ToString();
                }
                return new ClientResponse { Message = "", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        public ClientResponse Get_Post(int postID)
        {
            List<Post> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    result = ctx.Posts
                   .Where(re => re.PostId == postID)
                   .ToList();
                }
                return new ClientResponse { Message = "", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        public ClientResponse Save_Date(Post postObj)
        {
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    ctx.Posts.Add(postObj);
                    ctx.SaveChanges();
                }
                //var ctx = new ShortStoryNetworkContext();
                //var author = ctx.Posts.First(a => a.PostId == postObj.PostId);


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