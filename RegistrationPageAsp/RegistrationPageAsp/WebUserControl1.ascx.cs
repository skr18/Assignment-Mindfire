using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public int objId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    objId = int.Parse(Request.QueryString["UserId"]);
                    BindGrid();
                }
            }
            
           
        }
        private void BindGrid()
        {
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var data = dbcontext.UserNotes.Where(i=> i.UserId == objId).ToList();
                gridview.DataSource = data;

                gridview.DataBind();
            }
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

            string newNote = (row.FindControl("EditNote") as TextBox).Text;

            using (var dbcontext = new RegistrationPageEntities1())
            {
                UserNotes user = dbcontext.UserNotes.Where(i => i.NoteId == Id).FirstOrDefault();
                Response.Write(user.Note);
                user.Note = newNote;

                dbcontext.SaveChanges();
                Response.Write(user.Note);
            }

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
                UserNotes user = dbcontext.UserNotes.Where(i => i.NoteId == Id).FirstOrDefault();

                dbcontext.UserNotes.Remove(user);
                dbcontext.SaveChanges();
            }
            this.BindGrid();
        }
        protected void Insert(object sender, EventArgs e)
        {
            using (var dbcontext = new RegistrationPageEntities1())
            {
                UserNotes newobj = new UserNotes();
                newobj.Note = txtNote.Text;
                newobj.UserId = objId;

                dbcontext.UserNotes.Add(newobj);
                dbcontext.SaveChanges();
            }
            txtNote.Text = "";

            BindGrid();
        }
    }
}