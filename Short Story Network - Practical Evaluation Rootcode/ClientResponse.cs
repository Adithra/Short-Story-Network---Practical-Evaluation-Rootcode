using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    public enum UserRoles
    {
        DefaultUser,
        Writers,
        Editors,
        moderators
    }
    public enum UserAccessTypes
    {
        Default,
        CreatePost,
        EditPost,
        AddComment,
        EditComment,
        Follow,
        SetUserAccess
    }
    public class ClientResponse
    {
        private Exception clientException;

        private string message;
        public bool State { get; set; }

        public Exception ClientException
        {
            get => clientException;
            set
            {
                clientException = value;
                WriteToErrorLog(ClientException);
            }
        }

        public object ResultObject { get; set; }

        public string Message
        {
            get => string.IsNullOrEmpty(message) ? ClientException.Message : message;
            set => message = value;
        }

        public void WriteToErrorLog(Exception ex)

        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Errors\\"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Errors\\");

            var fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Errors\\Erro log.txt",
                FileMode.OpenOrCreate, FileAccess.ReadWrite);

            var s = new StreamWriter(fs);

            s.Close();

            fs.Close();

            var fs1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Errors\\Erro log.txt", FileMode.Append,
                FileAccess.Write);

            var s1 = new StreamWriter(fs1);

            s1.Write("Title: " + ex.TargetSite + Environment.NewLine);

            if (ex.InnerException == null)
            {
                s1.Write("Message: " + ex.Message + Environment.NewLine);

                s1.Write("StackTrace: " + ex.StackTrace + Environment.NewLine);
            }
            else
            {
                s1.Write("Message: " + ex.InnerException.Message + Environment.NewLine);

                s1.Write("StackTrace: " + ex.InnerException.StackTrace + Environment.NewLine);
            }

            s1.Write("Date/Time: " + DateTime.Now + Environment.NewLine);

            s1.Write("============================================" + Environment.NewLine);

            s1.Close();

            fs1.Close();
        }
    }
}
