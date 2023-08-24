using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserList
    {
        public static DataTable BindGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Roles");

            using (var dbcontext = new RegistrationPageEntities1())
            {

                var data = dbcontext.UserDetails.ToList();
                foreach (var item in data)
                {
                    var roleIds = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == item.UserId).Select(i => i.RoleId);
                    string roles = "";
                    foreach (var roleId in roleIds)
                    {
                        var roleName = dbcontext.Roles.Where(i => i.RoleId == roleId).Select(i => i.RoleName).Single();
                        roles += roleName + ",";
                    }
                    if (roles.Length > 0)
                    {
                        roles = roles.Substring(0, roles.Length - 1);
                    }
                    dataTable.Rows.Add(item.UserId, item.FirstName, item.Email, roles);
                }

            }
            return dataTable;
        }
        public static void OnRowDeleting(int Id)
        {  
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var UserRoles = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == Id);
                foreach (var role in UserRoles)
                {
                    dbcontext.IdsOfRolesAndUsers.Remove(role);
                }
                var UserNotes = dbcontext.UserNotes.Where(i => i.UserId == Id);
                foreach (var note in UserNotes)
                {
                    dbcontext.UserNotes.Remove(note);
                }

                UserDetails user2 = dbcontext.UserDetails.Where(i => i.UserId == Id).FirstOrDefault();
                dbcontext.UserDetails.Remove(user2);
                dbcontext.SaveChanges();


            }
        }
    }
}
