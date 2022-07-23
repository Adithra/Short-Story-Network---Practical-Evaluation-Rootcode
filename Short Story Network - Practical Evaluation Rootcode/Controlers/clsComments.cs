using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsComments
    {
        #region "CRUD"  
        public ClientResponse Get_Comments_List(int postID, int userID = 0)
        {
            List<Comment> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    if (postID == 0 && userID > 0)
                    {
                        result = ctx.Comments
                        .Where(re => re.CreatedBy == userID)
                        .ToList();
                    }
                    else
                    {
                        result = ctx.Comments
                       .Where(re => re.PostID == postID)
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

        public ClientResponse Get_Comments(int commentID)
        {
            List<Comment> result;
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    result = ctx.Comments
                   .Where(re => re.CommentID == commentID)
                   .ToList();
                }
                return new ClientResponse { Message = "", State = true, ResultObject = result };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        public ClientResponse Save_Date(Comment commentObj)
        {
            try
            {
                using (var ctx = new ShortStoryNetworkContext())
                {
                    if (commentObj.CommentID != null && commentObj.CommentID == 0)
                    {
                        ctx.Comments.Add(commentObj);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        var selectedPost = ctx.Comments.First(a => a.CommentID == commentObj.CommentID);
                        selectedPost.Comment1 = commentObj.Comment1;
                        ctx.SaveChanges();
                    }

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
