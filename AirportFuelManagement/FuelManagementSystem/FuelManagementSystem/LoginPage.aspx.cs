using FuelManagementSystem.business;
using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuelManagementSystem
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session.Abandon();
            }
            if (Request.QueryString["InvalidUrl"] == "true")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Login 1st')", true);
            }

        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var name = nameInp.Text;
            var password = passwordInp.Text;
            string logPath = WebConfigurationManager.AppSettings["myLogRecordPath"];
            bool isValidUser=false;

            try
            {
                isValidUser = UserAuthBusiness.IsValidUser(name, password);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occured While Fetching User Data Please Try Again')", true);
                LogRecords.LogRecord(ex, logPath);
               // Response.Redirect("loginpage");
            }

            if (isValidUser == true)
            {
                try
                {
                    Session["UserId"] = isValidUser;
                    Response.Redirect("dashboard");
                   
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occured While Loading The Page. Please Try Again')", true);
                    LogRecords.LogRecord(ex, logPath);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('UserName Or PassWord Invalid')", true);

            }

        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}