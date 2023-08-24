using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
    public class TempModels
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
            public string userPermanentAddress2 { get; set; }

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
        public class RoleModel
        {
            public int RoleId { get; set; }

            public string RoleName { get; set; }

        }
        public class Temp2
        {
            public int NoteId { get; set; }
            public int Isprivate { get; set; }

            public string Note { get; set; }
            public string AddedBy { get; set; }

            public string Date { get; set; }

        }

        public class CoustomObjectUserDocuments
        {
            public int DocumentID { get; set; }
            public int UserId { get; set; }
            public string DocumentUrl { get; set; }

            public string AddedBy { get; set; }

            public string Date { get; set; }

        }
    }

    
}
