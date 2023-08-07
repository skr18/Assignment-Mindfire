using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class UserListPageWithoutGridView : System.Web.UI.Page
    {
        public class Temp
        {
            public string userFirstName { get; set; }    
            public string userEmail { get; set; }
            public string Roles { get; set; }
            public int UserId { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
           ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static Object GetAllUserData()
        {
            List<Temp> obj = new List<Temp>();

            using (var dbcontext = new RegistrationPageEntities4())
            {
                
                var data = dbcontext.UserDetails.ToList();
                foreach (var item in data)
                {
                    Temp temp = new Temp();
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
                    temp.UserId = item.UserId;
                    temp.userFirstName = item.FirstName;
                    temp.userEmail = item.Email;
                    temp.Roles = roles;
                    obj.Add(temp);
                }

            }
            return obj;
            
        }


        [System.Web.Services.WebMethod]
        public static void deleteData(string Id)
        {
            int id = int.Parse(Id);
            using (var dbcontext = new RegistrationPageEntities4())
            {
                var UserRoles = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == id);
                foreach (var role in UserRoles)
                {
                    dbcontext.IdsOfRolesAndUsers.Remove(role);
                }
                var UserNotes = dbcontext.UserNotes.Where(i => i.UserId == id);
                foreach (var note in UserNotes)
                {
                    dbcontext.UserNotes.Remove(note);
                }

                UserDetails user2 = dbcontext.UserDetails.Where(i => i.UserId == id).FirstOrDefault();
                dbcontext.UserDetails.Remove(user2);
                dbcontext.SaveChanges();
            }

        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrationPage.aspx");
        }

    }
}