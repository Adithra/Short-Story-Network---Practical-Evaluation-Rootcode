using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Models
{
    public class LoggedUserDetails
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userFullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserRoles UserAccessType { get; set; }
        private string userRole;

        public string UserRole
        {
            get { return userRole; }
            set { 
                userRole = value;
                Get_Access_Type(value);
            }
        }

        public bool IsEditor { get; set; }
        private void Get_Access_Type(string charVal)
        {
            try
            {
                if (charVal == "U" && IsEditor)
                {
                    UserAccessType = UserRoles.Editors;
                }
                else if (charVal == "M")
                {
                    UserAccessType = UserRoles.Moderators;
                }
                else if (charVal == "U")
                {
                    UserAccessType = UserRoles.Writers;
                }
                else
                {
                    UserAccessType = UserRoles.UnknowUser;
                }
            }
            catch (Exception)
            {
                UserAccessType = UserRoles.UnknowUser;                
            }
        }
    }
}
