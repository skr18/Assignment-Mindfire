using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
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
            BindGrid();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridview.Rows[e.RowIndex];
            int Id = Convert.ToInt32(gridview.DataKeys[e.RowIndex].Value);

            Response.Redirect(string.Format("~/WebForm1.aspx?UserId={0}", Id));

            gridview.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gridview.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(gridview.DataKeys[e.RowIndex].Value);
            using (var dbcontext = new RegistrationPageEntities1())
            {
                //Users user = dbcontext.Users.Where(i => i.UserId == Id).FirstOrDefault();
                UserDetails user2 = dbcontext.UserDetails.Where(i => i.UserId == Id).FirstOrDefault();

                dbcontext.UserDetails.Remove(user2);
                dbcontext.SaveChanges();
            }
            this.BindGrid();
        }
    }
}