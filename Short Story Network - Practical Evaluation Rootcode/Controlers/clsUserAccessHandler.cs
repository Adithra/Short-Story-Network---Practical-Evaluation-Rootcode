using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsUserAccessHandler
    {
        private string _userRole = string.Empty;
        private string _cannAccess = string.Empty;
        private UserAccessTypes _accessType = UserAccessTypes.Default;

        private bool Access_Handler(UserRoles userRole, UserAccessTypes accessType)
        {
            try
            {
                if (accessType == UserAccessTypes.CreatePost && userRole == UserRoles.Writers)
                {
                    return true;

                }
                else if (accessType == UserAccessTypes.EditPost && userRole == UserRoles.Writers)
                {
                    return true;
                }
                else if (accessType == UserAccessTypes.AddComment && userRole == UserRoles.Editors)
                {
                    return true;
                }
                else if (accessType == UserAccessTypes.EditComment && userRole == UserRoles.Editors)
                {
                    return true;
                }
                else if (accessType == UserAccessTypes.SetUserAccess && userRole == UserRoles.moderators)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false ;
            }
        }
    }
}
