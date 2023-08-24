using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using utils;
using static utils.TempModels;

namespace Model
{
    public class UserData
    {
        public static List<Temp2> GetAllUserNoteData(int id,int sessionId)
        {
            List<Temp2> obj = new List<Temp2>();
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var notes = dbcontext.UserNotes.Where(i => i.UserId == id).Where(r=> r.IsPrivate== 0).ToList(); 
                if (UsersDataValidation.IsAdmin(sessionId) == true)
                {
                    notes = dbcontext.UserNotes.Where(i => i.UserId == id).ToList();
                }
                foreach (var note in notes)
                {
                    Temp2 obj2 = new Temp2();
                    obj2.NoteId = note.NoteId;
                    obj2.Note = note.Note;
                    obj2.AddedBy = note.AddedBy;
                    obj2.Date = note.Date;
                    obj.Add(obj2);
                }
            }
            return obj;
        }

        public static void deleteNoteData(int id)
        {
            
            using (var dbcontext = new RegistrationPageEntities1())
            {

                var UserNotes = dbcontext.UserNotes.Where(i => i.NoteId == id).FirstOrDefault();

                dbcontext.UserNotes.Remove(UserNotes);

                dbcontext.SaveChanges();
            }
        }

        public static void InsertNote(int sessionUserId, string txtNote, int id, string status)
        {
            using (var dbcontext = new RegistrationPageEntities1())
            {
                string name;
                bool isAdmin = UsersDataValidation.IsAdmin(sessionUserId);
                if (isAdmin == true)
                {
                    name = dbcontext.UserDetails.Where(i => i.UserId == sessionUserId).Select(r => r.FirstName).FirstOrDefault();
                }
                else
                {
                    name = dbcontext.UserDetails.Where(i => i.UserId == id).Select(r => r.FirstName).FirstOrDefault();
                }

                UserNotes newobj = new UserNotes();
                newobj.Note = txtNote;
                newobj.UserId = id;
                newobj.AddedBy = name;
                newobj.Date = DateTime.Now.ToString("dddd, dd MMMM yyyy");

                if (status == "true")
                {
                    newobj.IsPrivate = 1;
                }
                else
                {
                    newobj.IsPrivate = 0;
                }

                dbcontext.UserNotes.Add(newobj);
                dbcontext.SaveChanges();
            }
        }
        public static void updateNoteData(int sessionUserId, string txtNote, int id, string status,int noteId)
        {
            int isd = 0;
            using (var dbcontext = new RegistrationPageEntities1())
            {
                string name;
                bool isAdmin = UsersDataValidation.IsAdmin(sessionUserId);
                if (isAdmin == true)
                {
                    name = dbcontext.UserDetails.Where(i => i.UserId == sessionUserId).Select(r => r.FirstName).FirstOrDefault();
                }
                else
                {
                    name = dbcontext.UserDetails.Where(i => i.UserId == id).Select(r => r.FirstName).FirstOrDefault();
                }

                UserNotes noteToBeUpdated = dbcontext.UserNotes.Where(i => i.NoteId == noteId).FirstOrDefault();
                noteToBeUpdated.Note = txtNote;

                noteToBeUpdated.AddedBy = name;
                noteToBeUpdated.Date = DateTime.Now.ToString("dddd, dd MMMM yyyy");

                if (status == "true")
                {
                    noteToBeUpdated.IsPrivate = 1;
                }
                else
                {
                    noteToBeUpdated.IsPrivate = 0;
                }

                
                dbcontext.SaveChanges();
            }
        }


        public static string displayImage(int id)
        {
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var data = dbcontext.UserDetails.Where(i => i.UserId == id).Select(r => r.ImageUrl).FirstOrDefault();
                return data;
            }
        }


        public static Temp sendUserData(int id)
        {
            Temp obj = new Temp();
            using (var dbcontext = new RegistrationPageEntities1())
            {

                string roles = "";
                var allRolesId = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == id).Select(r => r.RoleId);
                foreach (var roleid in allRolesId)
                {
                    var rolename = dbcontext.Roles.Where(i => i.RoleId == roleid).
                        Select(r => r.RoleName).FirstOrDefault();
                    roles += rolename + ",";
                }
                var data = dbcontext.UserDetails.Where(i => i.UserId == id).FirstOrDefault();

                int stateId = data.PermanentStateId;
                int countryId = data.PermanentCountryId;

                var statename = dbcontext.States.Where(i => i.StateId == stateId).
                    Select(r => r.StateName).FirstOrDefault();
                var Countryname = dbcontext.Country.Where(i => i.CountryId == countryId).
                    Select(r => r.CountryName).FirstOrDefault();

                int presentStateId = data.PresentStateId;
                int presentCountryId = data.PresentCountryId;

                var presentSatename = dbcontext.States.Where(i => i.StateId == presentStateId).
                    Select(r => r.StateName).FirstOrDefault();
                var presentCountryName = dbcontext.Country.Where(i => i.CountryId == presentCountryId).
                    Select(r => r.CountryName).FirstOrDefault();

                obj.userFirstName = data.FirstName;
                obj.userEmail = data.Email;
                obj.userLastName = data.LastName;
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

        public static void GetUserData(Temp data, int ID)
        {
            var Roles = data.Roles;
            

            using (var dbcontext = new RegistrationPageEntities1())
            {
                int countryId = dbcontext.Country.Where(i => i.CountryName == data.userPermanentCountry).
                    Select(r => r.CountryId).FirstOrDefault();
                int stateId = dbcontext.States.Where(i => i.StateName == data.userPermanentState).
                    Select(r => r.StateId).FirstOrDefault();

                int presentcountryId = dbcontext.Country.Where(i => i.CountryName == data.userPresentCountry).
                   Select(r => r.CountryId).FirstOrDefault();
                int presentstateId = dbcontext.States.Where(i => i.StateName == data.userPresentState).
                    Select(r => r.StateId).FirstOrDefault();

                UserDetails newuser;
                if (ID == 0)
                {
                    newuser = new UserDetails();
                }
                else
                {
                    newuser = dbcontext.UserDetails.Where(i => i.UserId == ID).FirstOrDefault();
                }
                newuser.Email = data.userEmail;
                newuser.FirstName = data.userFirstName;
                newuser.LastName = data.userLastName;

                newuser.PermanentCountryId = countryId;
                newuser.PermanentStateId = stateId;
                newuser.PresentCountryId = presentcountryId;
                newuser.PresentStateId = presentstateId;

                newuser.Dob = data.userDob;
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
                if (ID == 0)
                {
                    dbcontext.UserDetails.Add(newuser);
                }

                
                dbcontext.SaveChanges();
                int userId = newuser.UserId;
                // IdsOfRolesAndUsers newRoleUser;
                if (ID != 0)
                {
                    var newRoleUser = dbcontext.IdsOfRolesAndUsers.Where(i => i.UserId == ID);
                    foreach (var roleUser in newRoleUser)
                    {
                        dbcontext.IdsOfRolesAndUsers.Remove(roleUser);
                    }
                }
                foreach (var item in Roles.Split(','))
                {
                    if (item != "")
                    {
                        int roleID = dbcontext.Roles.Where(i => i.RoleName == item).Select(i => i.RoleId).Single();

                        IdsOfRolesAndUsers newRoleUser = new IdsOfRolesAndUsers();
                        newRoleUser.RoleId = roleID;
                        newRoleUser.UserId = userId;

                        dbcontext.IdsOfRolesAndUsers.Add(newRoleUser);
                        dbcontext.SaveChanges();
                    }

                }
            }
        }


        public static List<RoleModel> SetUserRoles()
        {
            List< RoleModel> data = new List<RoleModel>();
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var alldata = dbcontext.Roles.ToList();
                foreach(var  role in alldata)
                {
                    RoleModel newRole = new RoleModel();
                    newRole.RoleName = role.RoleName;
                    data.Add(newRole);
                }
                
                
            }
            return data;

        }

        public static List<string> GetCountry()
        {
            List<string> AllCountry = new List<string>();

            using (var dbcontext = new RegistrationPageEntities1())
            {
                var data = dbcontext.Country;
                foreach (var role in data)
                {
                    AllCountry.Add(role.CountryName.ToString());
                }
            }
            return AllCountry;
        }

        public static List<string> GetState(string name)
        {
            List<string> AllState = new List<string>();

            using (var dbcontext = new RegistrationPageEntities1())
            {
                int countryID = (dbcontext.Country.Where(i => i.CountryName == name).
                    Select(r => r.CountryId).FirstOrDefault());
                var data = dbcontext.States.Where(i => i.CountryId == countryID).ToList();
                foreach (var role in data)
                {
                    AllState.Add(role.StateName.ToString());
                }
            }
            return AllState;
        }

       
    }
}
