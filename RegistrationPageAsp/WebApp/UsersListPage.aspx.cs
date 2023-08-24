using BusinessLogic;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using utils;

namespace RegistrationPageAsp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["UserId"] != null)
                {
                    string logPath = WebConfigurationManager.AppSettings["myLogRecordPath"];
                    try
                    {
                        int sessionUserId = int.Parse(Session["UserId"].ToString());
                        bool isAdmin = Auth.IsAdmin(sessionUserId);
                        if (isAdmin == true)
                        {
                            BindGrid();
                        }
                        else
                        {
                            int id = int.Parse(Session["UserId"].ToString());
                            Response.Redirect(string.Format("~/RegistrationPage.aspx?UserId={0}", id));
                        }

                    }
                    catch(Exception ex)
                    {
                        LogRecords.LogRecord(ex, logPath);
                    }
                    
                }
                else
                {
                    Response.Redirect("loginpage");
                }
            }
        }
        private void BindGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable = UserListBusiness.BindGrid();
            gridview.DataSource = dataTable;
            gridview.DataBind();
        }

       protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview.EditIndex = e.NewEditIndex;
            int Id = Convert.ToInt32(gridview.DataKeys[e.NewEditIndex].Value);
            Response.Redirect(string.Format("~/RegistrationPage.aspx?UserId={0}", Id));
            BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(gridview.DataKeys[e.RowIndex].Value);
            UserListBusiness.OnRowDeleting(Id);
            this.BindGrid();
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrationPage.aspx");
        }
    }
}