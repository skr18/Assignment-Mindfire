using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public  class  UsersDataValidation
    {
        public static int  UserValidation(string name,string password)
        {
            int userId = -1;
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var alluser = dbcontext.UserDetails.ToList();
                foreach (var user in alluser)
                {
                    if (user.FirstName == name && user.Password == password)
                    {
                        return user.UserId;
                    }
                }
            }
            return userId;
        }

        public static bool IsAdmin(int id)
        {
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var roleIds = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == id).Select(i => i.RoleId);
                foreach (var role in roleIds)
                {
                    var rolename = dbcontext.Roles.Where(i => i.RoleId == role).Select(i => i.RoleName).FirstOrDefault();
                    if (rolename == "Admin")
                    {
                        return true;

                    }
                }
            }
            return false;
        }
    }
}
