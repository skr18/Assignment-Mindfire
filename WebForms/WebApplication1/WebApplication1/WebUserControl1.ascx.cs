using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public string objType { get; set; }
        public int objId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BindGrid();
                btnAdd.Enabled= true;
            }
        }
        private void BindGrid()
        {
            using (var dbcontext = new userControlEntities1() )
            {
                var data = dbcontext.Notes.Where(i => i.UserId == objId && i.ObjType==objType).ToList();
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
          
            using (var dbcontext = new userControlEntities1() )
            {
                Notes user = dbcontext.Notes.Where(i => i.NoteId == Id).FirstOrDefault();
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
            using (var dbcontext = new userControlEntities1())
            {
                Notes user = dbcontext.Notes.Where(i => i.NoteId == Id).FirstOrDefault();
                
                dbcontext.Notes.Remove(user);
                dbcontext.SaveChanges();
            }
            this.BindGrid();
        }
        protected void Insert(object sender, EventArgs e)
        {
            using (var dbcontext = new userControlEntities1() )
            {
                Notes newobj = new Notes();
                newobj.Note = txtNote.Text;
                newobj.ObjType = objType;
                newobj.UserId = objId;
               
                dbcontext.Notes.Add(newobj);
                dbcontext.SaveChanges();
            }
            txtNote.Text = "";

            BindGrid();
        }

    }
}