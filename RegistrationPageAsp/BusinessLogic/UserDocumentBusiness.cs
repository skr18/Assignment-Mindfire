using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static utils.TempModels;

namespace BusinessLogic
{
    public class UserDocumentBusiness
    {
        public static List<CoustomObjectUserDocuments> GetAllUserDocuments(int queryid,int sessionId)
        {
            return UserDocuments.GetAllUserDocuments(queryid,sessionId);
        }

        public static string fileUploadBtn_Click( string path, string filename, int userId, int sessionUserId)
        {

            return UserDocuments.fileUploadBtn_Click(path, filename, userId, sessionUserId);
        }
        public static string downloadFile(int id)
        {
            return UserDocuments.downloadFile(id);
        }
    }
}
