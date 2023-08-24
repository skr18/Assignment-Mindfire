using BusinessLogic;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using utils;

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
            if (Request.QueryString["errorOccurder"] !=null)
            {
                Response.ClearContent();
                Response.Write("<script>alert('You do not have admin access')</script>");

            }

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var name = nameInp.Text;
            var password = passwordInp.Text;
            string logPath = WebConfigurationManager.AppSettings["myLogRecordPath"] ;
            int userId=-1;
            try
            {
                userId = Auth.validUser(name, password);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
           


            

            if (userId > 0)
            {
                Session["userId"]=userId;
                try
                {
                    bool isAdmin = Auth.IsAdmin(userId);
                    if (isAdmin == true)
                    {
                        Response.Redirect("userslistpage");
                    }
                    else
                    {
                        Response.Redirect(string.Format("~/RegistrationPage.aspx?UserId={0}", userId));
                    }

                }
                catch(Exception ex)
                {
                    LogRecords.LogRecord(ex, logPath);
                }
                
               
            }
            else
            {
                
                //Response.Redirect(string.Format("loginpage.aspx?errorOccurder={0}",1));
                //Response.Write("<script>alert('Data inserted successfully')</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('UserName Or PassWord Invalid')", true);
                
            }

        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("registrationpage");
        }
    }
}