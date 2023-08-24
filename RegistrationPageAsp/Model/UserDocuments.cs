using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static utils.TempModels;

namespace Model
{
    public class UserDocuments
    {
        public static List<CoustomObjectUserDocuments> GetAllUserDocuments(int QueryId,int sessionId)
        {
            List<CoustomObjectUserDocuments> data = new List<CoustomObjectUserDocuments>();
            using (var dbcontext = new RegistrationPageEntities1())
            {
                var newdoc = dbcontext.UsersDocuments.Where(i => i.UserId == QueryId).ToList();
                foreach (var item in newdoc)
                {
                    CoustomObjectUserDocuments temp = new CoustomObjectUserDocuments();
                    temp.UserId = item.UserId;
                    temp.DocumentID = item.DocumentID;
                    temp.DocumentUrl = item.DocumentUrl;
                    temp.AddedBy = item.AddedBy;
                    temp.Date   = item.Date;
                    data.Add(temp);
                }
            }
            return data;
        }
        public static string fileUploadBtn_Click(string path, string filename, int userId,int sessionUserId)
        {

            string extention = Path.GetExtension(filename).ToLower();
            string unique = Guid.NewGuid() + extention;
            string uniquePath = path + unique;
           
            using (var dbcontext = new RegistrationPageEntities1())
            {
                string name;
                bool isAdmin = UsersDataValidation.IsAdmin(sessionUserId);
                if (isAdmin == true)
                {
                    name = dbcontext.UserDetails.Where(i=> i.UserId == sessionUserId).Select(r=> r.FirstName).FirstOrDefault();
                }
                else
                {
                    name = dbcontext.UserDetails.Where(i => i.UserId == userId).Select(r => r.FirstName).FirstOrDefault();
                }
                UsersDocuments newdoc = new UsersDocuments
                {
                    UserId = userId,
                    DocumentUrl = filename,
                    UniqueGuid = unique,
                };
               
                newdoc.AddedBy = name;
                newdoc.Date = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                dbcontext.UsersDocuments.Add(newdoc);

                dbcontext.SaveChanges();
            }
            return uniquePath;
        }

        public static string downloadFile(int id)
        {
            string doc;
            using (var dbcontext = new RegistrationPageEntities1())
            {
                doc = dbcontext.UsersDocuments.Where(i => i.DocumentID == id).Select(r => r.UniqueGuid).FirstOrDefault();

            }
            return doc;
        }
    }
}
