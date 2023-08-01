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

namespace RegistrationPageAsp
{

    public class Temp
    {
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userEmail { get; set; }
        
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
    }
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        Var name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              SetRoles();

            }
        }

        [System.Web.Services.WebMethod]
        public static Object sendData(string name )
        {
                Temp obj = new Temp();
                
               int id = int.Parse(name);
                using (var dbcontext = new RegistrationPageEntities1())
                {
                var data = dbcontext.UserDetails.Where(i=> i.UserId == id ).FirstOrDefault();

                int stateId = data.PermanentStateId;
                int countryId = data.PermanentCountryId;

                var statename = dbcontext.States.Where(i=> i.StateId== stateId).Select(r=>r.StateName).FirstOrDefault();
                var Countryname = dbcontext.Country.Where(i=> i.CountryId == countryId).Select(r=>r.CountryName).FirstOrDefault();

                int presentStateId = data.PresentStateId;
                int presentCountryId = data.PresentCountryId;

                var presentSatename = dbcontext.States.Where(i => i.StateId == presentStateId).Select(r => r.StateName).FirstOrDefault();
                var presentCountryName = dbcontext.Country.Where(i => i.CountryId == presentCountryId).Select(r => r.CountryName).FirstOrDefault();

                obj.userFirstName = data.FirstName;
                obj.userEmail = data.Email;
                obj.userLastName =data.LastName;
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


                }
           return obj;
        }
        
        [System.Web.Services.WebMethod]
        public static  void GetData(Temp data)
        {
            var name = data.userFirstName;
            var email = data.userEmail;
            var lastname = data.userLastName;
            var country = data.userPermanentCountry;
            var state = data.userPermanentState;
            var date = data.userDob;

            var Roles = data.Roles;

             using (var dbcontext = new RegistrationPageEntities1())
             {
                  Users newuser = new Users();
                  newuser.FirstName = name.ToString();
           
                  newuser.Email = email.ToString();

                  dbcontext.Users.Add(newuser);
                  dbcontext.SaveChanges();
             }
            using (var dbcontext = new RegistrationPageEntities1())
            {
                int countryId = dbcontext.Country.Where(i=> i.CountryName == country).Select(r=>r.CountryId).FirstOrDefault();
                int stateId = dbcontext.States.Where(i=> i.StateName == state).Select(r=>r.StateId).FirstOrDefault();
            
                UserDetails newuser = new UserDetails();
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

                dbcontext.UserDetails.Add(newuser);
                
                dbcontext.SaveChanges();
                int userId = newuser.UserId;
                foreach(var item in Roles.Split(','))
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
            

        protected void SetRoles()
        {
            using (var dbcontext = new RegistrationPageEntities1())
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
        [System.Web.Services.WebMethod]
        public static List<string> GetCountry() 
        {
            List<string> AllCountry = new List<string>();

            using(var dbcontext = new RegistrationPageEntities1())
            {
                var data = dbcontext.Country;
                foreach (var role in data)
                {
                    AllCountry.Add(role.CountryName.ToString());
                }
            }
            return AllCountry;
        }


        [System.Web.Services.WebMethod]
        public static List<string> GetState(string name)
        {
            List<string> AllState = new List<string>();

            using (var dbcontext = new RegistrationPageEntities1())
            {
                int countryID = ( dbcontext.Country.Where(i=> i.CountryName==name).Select(r=> r.CountryId).FirstOrDefault());
                var data = dbcontext.States.Where(i=> i.CountryId == countryID).ToList();
                foreach (var role in data)
                {
                    AllState.Add(role.StateName.ToString());
                }
            }
            return AllState;
        }

        [System.Web.Services.WebMethod]
        public List<string> GetRoles()
        {
            List<string> AllRoles = new List<string>();

            for(int i = 0;i< RolesCheckBox.Items.Count; i++)
            {
                if (RolesCheckBox.Items[i].Selected)
                {
                    AllRoles.Add(RolesCheckBox.Items[i].Text);
                }
            }
            return AllRoles;
        }


         protected void submitButton_Click(object sender, EventArgs e)
          {
           

          
          }
    }
}