using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Ajax.Utilities;
using System.Xml.Linq;
using System.Web.Services;
using static RegistrationPageAsp.WebUserControl1;
using utils;
using BusinessLogic;
using Microsoft.SqlServer.Server;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Web.Configuration;
using System.Threading.Tasks;
using System.Threading;
using static utils.TempModels;
using utils.utils;

namespace RegistrationPageAsp
{
    public partial class WebForm1 : UserId
    {
        static int queryId = 0;
        static int sessionUserId=0;
        static string logPath = WebConfigurationManager.AppSettings["myLogRecordPath"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SetUserRoles();
                if(Request.QueryString["UserId"] != null)
                {
                    displayImage();
                }

            }
            if (Session["UserId"] != null)
            {
                sessionUserId = int.Parse(Session["UserId"].ToString());
            }
            if (Request.QueryString["UserId"] != null && Session["UserId"] != null)
            {
                try
                {
                   
                    queryId = int.Parse(Request.QueryString["UserId"].ToString());
                    bool isAdmin = Auth.IsAdmin(sessionUserId);

                    if (isAdmin == false && sessionUserId != queryId)
                    {
                        Response.Redirect("RegistrationPage?UserId="+sessionUserId);
                    }
                 
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                    LogRecords.LogRecord(ex, logPath);
                    Response.Redirect(string.Format("loginpage.aspx?errorOccurder={0}", 3));
                }
            }
            else if(Request.QueryString["UserId"] != null && Session["UserId"] == null)
            {
                Response.Redirect(string.Format("loginpage.aspx?errorOccurder={0}", 4));
            }
               
            
        }


        //user doc

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
        ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static Object GetAllUserDocuments()
        {
            List<TempModels.CoustomObjectUserDocuments> obj = new List<TempModels.CoustomObjectUserDocuments>();

            try
            {
                obj = UserDocumentBusiness.GetAllUserDocuments(UserId.getUserId() ,getSessionId());
                //obj = UserDocumentBusiness.GetAllUserDocuments(queryId, sessionUserId);
       
            }
            catch (Exception ex)
            {

                LogRecords.LogRecord(ex, logPath);
            }
            return obj;


        }


        protected void fileUploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = FileUpload.FileName.ToString();
                string path = System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();

                string uniqueFile = UserDocumentBusiness.fileUploadBtn_Click(path, filename, queryId, sessionUserId);
                FileUpload.PostedFile.SaveAs(uniqueFile);
            }
            catch(Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
          
        }

       
        
        //user Notes


            [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
        ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static Object GetAllUserNoteData()
        {
            List<TempModels.Temp2> obj = new List<TempModels.Temp2>();
            try
            {

                obj = RegistrationpageBusiness.GetAllUserNoteData(queryId, sessionUserId);
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return obj;
        }

        [System.Web.Services.WebMethod]
        public static void deleteNoteData(string Id)
        {
            try
            {
                int id = int.Parse(Id);
                RegistrationpageBusiness.deleteNoteData(id);
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }

        }

        [System.Web.Services.WebMethod]
        public static void InsertsNote(string text)
        {
            try
            {
                string status = myUserControl.Status;
                RegistrationpageBusiness.InsertNote(sessionUserId, text, queryId, status);
               //txtNote.Text = "";
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
          
        }

         [System.Web.Services.WebMethod]
        public static void updateNoteData(string Id ,string Text)
        {
            try
            {
                int noteId = int.Parse(Id);
                string status = myUserControl.Status;
                RegistrationpageBusiness.updateNoteData(sessionUserId, Text, queryId, status,noteId);
               //txtNote.Text = "";
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
          
        }




        //User Details


        [System.Web.Services.WebMethod]
        public static Object sendUserData(string UserId)
        {
            TempModels.Temp obj = new TempModels.Temp();

            int id = int.Parse(UserId);
            queryId = id;
            try
            {
                obj = RegistrationpageBusiness.sendUserData(id);
            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
              
           return obj;
        }

        public void displayImage()
        {
            int id = int.Parse(Request.QueryString["UserId"].ToString());
            string data = RegistrationpageBusiness.displayImage(id);
            if (data != null)
            {
                photo.ImageUrl = "ImageDisplay.ashx?ImageName=" + data;
            }

        }
        
        [System.Web.Services.WebMethod]
        public static  void GetUserData(TempModels.Temp data)
        {
            try
            {
                RegistrationpageBusiness.GetUserData(data, queryId);

            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
        }
            

       protected void SetUserRoles()
        {
            try
            {
                List<RoleModel> data = RegistrationpageBusiness.SetUserRoles();
                foreach (RoleModel role in data)
                {
                    ListItem item = new ListItem();
                    item.Text = role.RoleName;
                    RolesCheckBox.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
           

        }


        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, 
            ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        //[System.Web.Services.WebMethod]
        public static List<string> GetCountry() 
        {
            List<string> AllCountry = new List<string>();
            try
            {

                AllCountry = RegistrationpageBusiness.GetCountry();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }

            return AllCountry;
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
           ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static bool checkIsAdmin()
        {
            
            try
            {
                bool isAdmin = Auth.IsAdmin(sessionUserId);
                if (isAdmin == true)
                {
                    return true;
                }
               
            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return false;
        }

       
        [System.Web.Services.WebMethod]
        public static void sendDataToUserControl(string isChecked)
        {
            
            myUserControl.Status = isChecked;
            
        }

        [System.Web.Services.WebMethod]
        public static List<string> GetState(string name)
        {
            List<string> AllState = new List<string>();
            try
            {
                AllState = RegistrationpageBusiness.GetState(name);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return AllState;
        }


    }
}