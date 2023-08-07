using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Ajax.Utilities;
using System.Xml.Linq;
using System.Data.Entity.Migrations;
using System.Web.Services;
using static RegistrationPageAsp.WebUserControl1;

namespace RegistrationPageAsp
{

    public class Temp
    {
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public string userPermanentCountry { get; set; }
        public string userPermanentState { get; set; }
        public string userPresentCountry { get; set; }
        public string userPresentState { get; set; }

        public string userDob { get; set; }

        public string userPermanentAddress1 { get; set; }
        public string userPermanentAddress2 { get; set;}

        public string userPresentAddress1 { get; set; }
        public string userPresentAddress2 { get; set; }

        public string userGender { get; set; }

        public string userPermanentCity { get; set; }

        public string userPresentCity { get; set; }

        public string userPermanentPostal { get; set; }
        public string userPresentPostal { get; set; }

        public string Roles { get; set; }

        public string userSubcription { get; set; }

        public string UserPhoto { get; set; }

    }
   
    public partial class WebForm1 : AuthorizationClass
    {
        static int Id=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SetUserRoles();

            }
            if (Request.QueryString["UserId"]==null)
            {
                Id = 0;
            }
            else if(Id!=0)
            {
                usercontrol.objId = Id;
            }
            bool isAdmin = checkIsAdmin();
            int sessionUserId = int.Parse(Session["UserId"].ToString());
            int queryId = int.Parse(Request.QueryString["UserId"].ToString());
            if (isAdmin == false && sessionUserId != queryId )
            {
                Response.Redirect("loginpage");
            }
            displayImage();

        }

            [System.Web.Services.WebMethod]
        public static Object sendUserData(string UserId)
        {
                Temp obj = new Temp();
                
                int id = int.Parse(UserId);
                Id = id;
                using (var dbcontext = new RegistrationPageEntities4())
                {
                
                    string roles = "";
                    var allRolesId = dbcontext.IdsOfRolesAndUsers.Where(i=> i.UserId == id).Select(r=> r.RoleId);
                    foreach(var roleid in allRolesId)
                    {
                        var rolename =dbcontext.Roles.Where(i=> i.RoleId == roleid).
                            Select(r=> r.RoleName).FirstOrDefault();
                        roles += rolename + ",";
                    }
                    var data = dbcontext.UserDetails.Where(i=> i.UserId == id ).FirstOrDefault();

                    int stateId = data.PermanentStateId;
                    int countryId = data.PermanentCountryId;

                    var statename = dbcontext.States.Where(i=> i.StateId== stateId).
                        Select(r=>r.StateName).FirstOrDefault();
                    var Countryname = dbcontext.Country.Where(i=> i.CountryId == countryId).
                        Select(r=>r.CountryName).FirstOrDefault();

                    int presentStateId = data.PresentStateId;
                    int presentCountryId = data.PresentCountryId;

                    var presentSatename = dbcontext.States.Where(i => i.StateId == presentStateId).
                        Select(r => r.StateName).FirstOrDefault();
                    var presentCountryName = dbcontext.Country.Where(i => i.CountryId == presentCountryId).
                        Select(r => r.CountryName).FirstOrDefault();

                    obj.userFirstName = data.FirstName;
                    obj.userEmail = data.Email;
                    obj.userLastName =data.LastName;
                    obj.userPassword = data.Password;
                    obj.userDob = data.Dob;
                    obj.userGender = data.Gender;

                    obj.userPermanentAddress1 = data.PermanentAddressLine1;
                    obj.userPermanentAddress2 = data.PermanentAddressLine2;

                    obj.userPresentAddress1 = data.PresentAddressLine1;
                    obj.userPresentAddress2 = data.PresentAddressLine2;

                    obj.userPermanentState = statename;
                    obj.userPermanentCountry = Countryname;

                    obj.userPresentCountry = presentCountryName;
                    obj.userPresentState = presentSatename;

                    obj.userPermanentCity = data.PermanentCity;
                    obj.userPresentCity = data.PresentCity;

                    obj.userPermanentPostal = data.PermanentPostalCode;
                    obj.userPresentPostal = data.PresentPostalCode;

                    obj.Roles = roles;
                    obj.userSubcription = data.Subscribed;
                    obj.UserPhoto = data.ImageUrl;             
                
                }
           return obj;
        }

        public void displayImage()
        {
            int id = int.Parse(Request.QueryString["UserId"].ToString());
            using (var dbcontext = new RegistrationPageEntities4())
            {
                var data = dbcontext.UserDetails.Where(i => i.UserId == id).Select(r=> r.ImageUrl).FirstOrDefault();

                if (data != null)
                {
                    photo.ImageUrl = "ImageDisplay.ashx?ImageName=" + data;
                }
            }
        }
        
        [System.Web.Services.WebMethod]
        public static  void GetUserData(Temp data)
        {
            var name = data.userFirstName;
            var email = data.userEmail;
            var lastname = data.userLastName;
            var country = data.userPermanentCountry;
            var state = data.userPermanentState;
            var date = data.userDob;

            var Roles = data.Roles;

            
            using (var dbcontext = new RegistrationPageEntities4())
            {
                int countryId = dbcontext.Country.Where(i=> i.CountryName == country).
                    Select(r=>r.CountryId).FirstOrDefault();
                int stateId = dbcontext.States.Where(i=> i.StateName == state).
                    Select(r=>r.StateId).FirstOrDefault();
                UserDetails newuser;
                if (Id == 0)
                {
                    newuser = new UserDetails();
                }
                else
                {
                     newuser = dbcontext.UserDetails.Where(i=>i.UserId == Id).FirstOrDefault();
                }
                newuser.Email = email;
                newuser.FirstName = name;
                newuser.LastName = lastname;

                newuser.PermanentCountryId = countryId;
                newuser.PermanentStateId = stateId;
                newuser.PresentCountryId = countryId;
                newuser.PresentStateId = stateId;

                newuser.Dob = date;
                newuser.Gender = data.userGender;

                newuser.PermanentAddressLine1 = data.userPermanentAddress1;
                newuser.PermanentAddressLine2 = data.userPermanentAddress2;

                newuser.PresentAddressLine1 = data.userPresentAddress1;
                newuser.PresentAddressLine2 = data.userPresentAddress2;

                newuser.PresentCity = data.userPresentCity;
                newuser.PermanentCity = data.userPermanentCity;
                newuser.PresentPostalCode = data.userPresentPostal;
                newuser.PermanentPostalCode = data.userPermanentPostal;
                newuser.Subscribed = data.userSubcription;
                newuser.Password = data.userPassword;
                newuser.ImageUrl = data.UserPhoto;
                if(Id == 0)
                {
                    dbcontext.UserDetails.Add(newuser);
                }
               
                
                dbcontext.SaveChanges();
                int userId = newuser.UserId;
               // IdsOfRolesAndUsers newRoleUser;
                if (Id != 0)
                {
                   
                    var newRoleUser = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == Id);
                    foreach (var roleUser in newRoleUser)
                    {
                        dbcontext.IdsOfRolesAndUsers.Remove(roleUser);
                    }
                }
                foreach (var item in Roles.Split(','))
                {
                    if(item!="")
                    {
                        int roleID=dbcontext.Roles.Where(i=>i.RoleName==item).Select(i=>i.RoleId).Single();

                        IdsOfRolesAndUsers newRoleUser = new IdsOfRolesAndUsers();
                        newRoleUser.RoleId = roleID;
                        newRoleUser.UserId = userId;

                        dbcontext.IdsOfRolesAndUsers.Add(newRoleUser);
                        dbcontext.SaveChanges();
                    }
                   
                }          
            }
        }
            

        protected void SetUserRoles()
        {
            using (var dbcontext = new RegistrationPageEntities4())
            {
                var data = dbcontext.Roles;
                foreach (var role in data)
                {
                    ListItem item = new ListItem();
                    item.Text = role.RoleName.ToString();
                    RolesCheckBox.Items.Add(item);
                }
            }

        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, 
            ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        //[System.Web.Services.WebMethod]
        public static List<string> GetCountry() 
        {
            List<string> AllCountry = new List<string>();

            using(var dbcontext = new RegistrationPageEntities4())
            {
                var data = dbcontext.Country;
                foreach (var role in data)
                {
                    AllCountry.Add(role.CountryName.ToString());
                }
            }
            return AllCountry;
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
           ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static bool checkIsAdmin()
        {
            bool isAdmin = AuthorizationClass.CheckIsAdmin();
            if (isAdmin== true)
            {
                return true;
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

            using (var dbcontext = new RegistrationPageEntities4())
            {
                int countryID = ( dbcontext.Country.Where(i=> i.CountryName==name).
                    Select(r=> r.CountryId).FirstOrDefault());
                var data = dbcontext.States.Where(i=> i.CountryId == countryID).ToList();
                foreach (var role in data)
                {
                    AllState.Add(role.StateName.ToString());
                }
            }
            return AllState;
        }

       
    }
}