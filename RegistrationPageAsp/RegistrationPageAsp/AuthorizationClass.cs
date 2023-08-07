using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

using System.Data.Entity;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class AuthorizationClass:System.Web.UI.Page
    {
       static int USERID;
        protected void Page_PreInit (object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                USERID = int.Parse(Session["UserId"].ToString());
            }
        }
        public static bool CheckIsAdmin()
        {
            bool isAdmin = false;
            using (var dbcontext = new RegistrationPageEntities4())
            {
                var roleIds = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == USERID).Select(i => i.RoleId);
                foreach (var role in roleIds)
                {
                    var rolename = dbcontext.Roles.Where(i => i.RoleId == role).Select(i => i.RoleName).FirstOrDefault();
                    if (rolename == "Admin")
                    {
                        isAdmin = true;

                    }
                }
            }
            return isAdmin;
        }

    }
}