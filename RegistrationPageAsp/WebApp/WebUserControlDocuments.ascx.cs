using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationPageAsp
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["UserId"] != null)
            {
                userId = int.Parse(Request.QueryString["UserId"]);
                BindGrid();
            }
            //BindGrid();


        }
        private void BindGrid()
        {
            /*var data = UserDocumentBusiness.BindGrid(userId);
            gridview.DataSource = data;

            gridview.DataBind();*/
        }
        protected void fileUploadBtn_Click(object sender, EventArgs e)
        {
            string filename = FileUpload.FileName.ToString();
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();
            int sessionUserId = int.Parse(Session["UserId"].ToString());
            string uniqueFile = UserDocumentBusiness.fileUploadBtn_Click(path,filename, userId, sessionUserId);
            FileUpload.PostedFile.SaveAs(uniqueFile);
           
            
            
            
            
            // path = path + filename;
            /* using (var dbcontext = new RegistrationPageEntities4())
             {
                 int UserId = int.Parse(Request.QueryString["UserId"]);
                 path = path + $"UserId{userId}\\";
                 if (!Directory.Exists(path))
                 {
                     Directory.CreateDirectory(path);
                 }
                 FileUpload.PostedFile.SaveAs(path);
                 UsersDocuments newdoc = new UsersDocuments();
                 newdoc.UserId = UserId;
                 newdoc.DocumentUrl = filename;
                 dbcontext.UsersDocuments.Add(newdoc);
                 dbcontext.SaveChanges();
             }*/


            BindGrid();
        }
        /*  protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
          {
              int Id = Convert.ToInt32(gridview.DataKeys[e.RowIndex].Value);
              using (var dbcontext = new RegistrationPageEntities4())
              {
                  UsersDocuments user = dbcontext.UsersDocuments.Where(i => i.DocumentID == Id).FirstOrDefault();

                  dbcontext.UsersDocuments.Remove(user);
                  dbcontext.SaveChanges();
              }
              this.BindGrid();
          }*/

        public static void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            // string comandname = e.CommandArgument.ToString();
           
                string doc = UserDocumentBusiness.gridview_RowCommand(id);
                string ext = Path.GetExtension(doc).ToLower();
                Response.ContentType = $"application/{ext}";
                Response.AppendHeader("Content-Disposition",$"attachment; filename={doc}");
                string path = System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();
                path = path + doc;
                Response.TransmitFile(path);
                Response.End();
                

         }

          /*  switch (comandname)
            {
                case "deleteDoc":
                    using (var dbcontext = new RegistrationPageEntities4())
                    {
                        UsersDocuments user = dbcontext.UsersDocuments.Where(i => i.DocumentID == id).FirstOrDefault();

                        dbcontext.UsersDocuments.Remove(user);
                        dbcontext.SaveChanges();
                    }
                    break;

                case "download":
                     using (var dbcontext = new RegistrationPageEntities4())
                    {
                        var doc = dbcontext.UsersDocuments.Where(i => i.DocumentID == id).Select(r => r.DocumentUrl).FirstOrDefault();

                        Response.ContentType = "application/jpeg";
                        Response.AppendHeader($"Content-Disposition", "attachment; filename={doc}");
                        string path = System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();
                        path = path + doc;
                        Response.TransmitFile((path));
                        Response.End();
                        

                    }
                    break;


            }*/
          /*  if (comandname == "delete")
            {
                using (var dbcontext = new RegistrationPageEntities4())
                {
                    UsersDocuments user = dbcontext.UsersDocuments.Where(i => i.DocumentID == id).FirstOrDefault();

                    dbcontext.UsersDocuments.Remove(user);
                    dbcontext.SaveChanges();
                }
            }
          
            else {
                using (var dbcontext = new RegistrationPageEntities4())
                {
                    var doc = dbcontext.UsersDocuments.Where(i => i.DocumentID == id).Select(r => r.DocumentUrl).FirstOrDefault();

                    Response.ContentType = "application/jpeg";
                    Response.AppendHeader($"Content-Disposition", "attachment; filename={doc}");
                    string path = System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();
                    path = path + doc;
                    Response.TransmitFile((path));
                    Response.End();


                }
            }*/

        
    }
}