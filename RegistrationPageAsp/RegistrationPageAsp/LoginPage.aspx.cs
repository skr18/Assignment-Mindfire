using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] cookies = Request.Cookies.AllKeys;
                foreach (string cookie in cookies)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
            }

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var name = nameInp.Text;
            var password = passwordInp.Text;
            bool isAdmin = false;
            int userId=0;
            using (var dbcontext = new RegistrationPageEntities4())
            {
                var alluser = dbcontext.UserDetails.ToList();
                foreach(var user in alluser)
                {
                    if(user.FirstName == name && user.Password==password)
                    {
                        userId = user.UserId;
                        /*HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["UserId"] = userId.ToString();*/
                        
                        var roleIds = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == userId).Select(i => i.RoleId);
                        foreach(var role in roleIds)
                        {
                            var rolename = dbcontext.Roles.Where(i=> i.RoleId == role).Select(i=> i.RoleName).FirstOrDefault();
                            if(rolename == "Admin")
                            {
                                isAdmin= true;
                               // userInfo["IsAdmin"] = "true";
                               // Response.Cookies.Add(userInfo);
                            }
                        }
                        Session["UserId"] = userId;
                        if (isAdmin == true)
                        {
                            //Response.Redirect(string.Format("~/RegistrationPage.aspx?UserId={0}", userId));
                            Response.Redirect("userslistpage");
                            
                        }
                        else
                        {
                            //userInfo["IsAdmin"] = "false";
                           // Response.Cookies.Add(userInfo);
                            Response.Redirect(string.Format("~/RegistrationPage.aspx?UserId={0}" , userId));
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('UserName Or PassWord Invalid')", true);

                    }
                }
               
            }

        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrationpage");
        }
    }
}