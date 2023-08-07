using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class WebForm2 : AuthorizationClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["UserId"] != null)
                {

                    bool isAdmin = CheckIsAdmin();
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
                else
                {
                    Response.Redirect("loginpage");
                }
            

            }
        }
        private void BindGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Roles");
            using (var dbcontext = new RegistrationPageEntities4())
            {
                
                var data = dbcontext.UserDetails.ToList();
                foreach (var item in data)
                {
                    var roleIds = dbcontext.IdsOfRolesAndUsers.Where(i=>i.UserId==item.UserId).Select(i=>i.RoleId);
                    string roles = "";
                    foreach (var roleId in roleIds)
                    {
                        var roleName = dbcontext.Roles.Where(i => i.RoleId == roleId).Select(i => i.RoleName).Single();
                        roles+= roleName+",";
                    }
                    if (roles.Length > 0)
                    {
                        roles = roles.Substring(0, roles.Length - 1);
                    }
                    dataTable.Rows.Add(item.UserId,item.FirstName,item.Email,roles);
                }
                
            }
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
            using (var dbcontext = new RegistrationPageEntities4())
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
            this.BindGrid();
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrationPage.aspx");
        }
    }
}