using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie newcokie = new HttpCookie("User");
            newcokie.Value = "Sujeet";
            Response.Cookies.Add(newcokie);
            var co_val = Response.Cookies["User"].Value;
            Label3.Text = "Data From Cookie: User - " +co_val;
            if (!IsPostBack)
            {
                showdata();
                BindGrid();
                if (Session["Datalist"] != null)
                {
                    string name = Session["Datalist"].ToString();
                    DropDownList1.Items.Add(name);
                }
                else
                {
                    Response.Write("No previous data");
                }
            }
        }

        protected void Edit1(object sender, DataListCommandEventArgs e )
        {
            DataList2.EditItemIndex = e.Item.ItemIndex;
            showdata();
        }
        protected void Cancel1(object sender, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = -1;
            showdata();
        }
        protected void update1(object sender, DataListCommandEventArgs e)
        {
            DataListItem row = DataList2.Items[e.Item.ItemIndex];
            int Id = Convert.ToInt32(DataList2.DataKeys[e.Item.ItemIndex]);
            //Response.Write(Id);
            string name = (row.FindControl("FirstNameText") as TextBox).Text;
            int age = int.Parse((row.FindControl("AgeText") as TextBox).Text);
            using (var dbcontext = new TestDBEntities1())
            {
                UserDetails user = dbcontext.UserDetails.Where(i => i.UserId == Id).FirstOrDefault();
                user.Age = age;
                user.FirstName = name;
                dbcontext.SaveChanges();
            }

            DataList2.EditItemIndex = -1;
            showdata() ;
        }
        private void BindGrid()
        {
            using (var dbcontext = new TestDBEntities1())
            {
                gridview.DataSource = dbcontext.UserDetails.ToList();
                gridview.DataBind();
                showdata();
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
            //Response.Write(Id);
            string name = (row.FindControl("EditName") as TextBox).Text;
            int age =int.Parse( (row.FindControl("EditAge") as TextBox).Text );
            using (var dbcontext = new TestDBEntities1())
            {
                UserDetails user = dbcontext.UserDetails.Where(i => i.UserId==Id).FirstOrDefault();
                user.Age = age;
                user.FirstName = name;
                dbcontext.SaveChanges();
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
            using (var dbcontext = new TestDBEntities1())
            {
                UserDetails user = dbcontext.UserDetails.Where(i => i.UserId == Id).FirstOrDefault();
                dbcontext.UserDetails.Remove(user);
                dbcontext.SaveChanges();
            }
            this.BindGrid();
        }
        protected void Insert(object sender, EventArgs e)
        {
            var name = txtName.Text;
            int age = int.Parse(txtAge.Text);

            using (var dbcontext = new TestDBEntities1())
            {
                UserDetails newobj = new UserDetails();
                newobj.FirstName = name;
                newobj.Age = age;
                dbcontext.UserDetails.Add(newobj);
                dbcontext.SaveChanges();
            }
            txtName.Text = "";
            txtAge.Text = "";
            BindGrid();
        }

        private void showdata()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId23");
            dt.Columns.Add("FirstName1");
            dt.Columns.Add("Age1");
            using (var dbcontext = new TestDBEntities1())
            {
                var user = dbcontext.UserDetails.Select(i => i);
                foreach (var data in user)
                {
                    dt.Rows.Add(data.UserId, data.FirstName, data.Age);
                }
            }
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }

        protected void Button1_Click3(object sender, EventArgs e)
        {
            var name = textbox3.Text;
            int age = int.Parse(textbox4.Text);

            using (var dbcontext = new TestDBEntities1())
            {
                UserDetails newobj = new UserDetails();
                newobj.FirstName = name;
                newobj.Age = age;
                dbcontext.UserDetails.Add(newobj);
                dbcontext.SaveChanges();
            }
            textbox3.Text = "";
            textbox4.Text = "";
            showdata();
            BindGrid();
        }
        protected void Button1_Click2(object sender, EventArgs e)
        {
                 var name = textbox2.Text;
                 Label5.Text = "Your Choice is: " +name+" is updated";
                 textbox2.Text = "";
                 DropDownList1.Items.Add(name);
                Session["Datalist"] = name;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
            {
                Label4.Text = "Please Select a City";
            }
            else
                Label4.Text = "Your Choice is: " + DropDownList1.SelectedValue;
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = "E:\\demo.txt";
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {  
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else Label1.Text = "Requested file is not available to download";
        }
        protected void uploadFile(object sender, EventArgs e)
        {

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))  
            {
                foreach(HttpPostedFile obj in FileUpload1.PostedFiles)
                {

                    string fn = System.IO.Path.GetFileName(obj.FileName);  
                    string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(SaveLocation);
                        FileUploadStatus.Text = "All The file's are uploaded.";
                    }
                    catch (Exception ex)
                    {
                        FileUploadStatus.Text = "Error: " + ex.Message;
                    }
                }
               
            }  
            else  
            {  
                FileUploadStatus.Text = "Please select a file to upload.";  
            }  
           
        }
    }
}