using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagementsystem.DataAccess
{
    public class UserAuth
    {

        /// <summary>
        /// Takes name and password of current user and return true for valid user or false for invalid user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValid(string username , string password)
        {
            using(var dbContext = new AirportFuelManagementSystemEntities() )
            {
                var user = dbContext.Users.Where(i=> i.name==username && i.password==password).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
