using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;

namespace BusinessLogic
{
    public class Auth
    {
        public static int validUser(string username,string password)
        {
                int userId = UsersDataValidation.UserValidation(username, password);
            
                return userId;
          
        }

        public static bool IsAdmin(int id)
        {
            if (UsersDataValidation.IsAdmin(id) == true)
            {
                return true;
            }
            return false;
         
        }
    }
}
