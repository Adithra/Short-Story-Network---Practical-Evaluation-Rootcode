using Short_Story_Network___Practical_Evaluation_Rootcode.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    internal class StartUp
    {
        public  void Start()
        {
            uiUsers uiUsersObj = new();
            uiUsersObj.ShowDialog();
        }
    }
}
