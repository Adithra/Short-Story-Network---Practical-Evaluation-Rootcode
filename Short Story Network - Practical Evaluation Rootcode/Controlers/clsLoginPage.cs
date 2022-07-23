using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Short_Story_Network___Practical_Evaluation_Rootcode.Models;
using Short_Story_Network___Practical_Evaluation_Rootcode.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Controlers
{
    public class clsLoginPage
    {
        private UserInfo _userInfoObj = new();

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
                    if (VerifyPassword(result[0].PasswordHash, _userInfoObj.PasswordHash))
                    {
                    LoggedUserDetails loggedUserDetailsObj = new()
                    {
                        //loggedUserDetailsObj.CreatedDate = DateTime.Now.Date);
                        userID = result[0].Id,
                        userName = result[0].UserId,
                        userFullName = string.Concat(result[0].FirstName, string.Empty, result[0].LastName),
                        IsEditor = result[0].IsEditor,
                        UserRole = result[0].UserRole
                    };
                    uiWriters writersObj = new(loggedUserDetailsObj)
                    {
                        userInfoObj = result[0]
                    };

                    writersObj.Load_Writers();
                    writersObj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Passord not found");
                    }

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

        private byte[] getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            int max_length = 32;
            byte[] salt = new byte[max_length];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        public string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false)
        {
            if (salt == null || salt.Length != 16)
            {
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            if (needsOnlyHash) return hashed;
            return $"{hashed}:{Convert.ToBase64String(salt)}";
        }

        private bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck)
        {
            var passwordAndHash = hashedPasswordWithSalt.Split(':');
            if (passwordAndHash == null || passwordAndHash.Length != 2)
                return false;
            var salt = Convert.FromBase64String(passwordAndHash[1]);
            if (salt == null)
                return false;
            var hashOfpasswordToCheck = HashPassword(passwordToCheck, salt, true);
            if (String.Compare(passwordAndHash[0], hashOfpasswordToCheck) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
