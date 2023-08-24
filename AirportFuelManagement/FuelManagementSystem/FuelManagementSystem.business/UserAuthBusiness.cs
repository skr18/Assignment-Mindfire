using FuelManagementsystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementSystem.business
{
    public class UserAuthBusiness
    {

        /// <summary>
        /// Takes name and password of current user and return true for valid user or false for invalid user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidUser(string username,string password)
        {
            return UserAuth.IsValid(username, password);   
        }
    }
}
