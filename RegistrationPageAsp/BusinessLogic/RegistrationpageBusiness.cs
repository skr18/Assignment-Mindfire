using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;
using static utils.TempModels;

namespace BusinessLogic
{
    public class RegistrationpageBusiness
    {
        //Notes
        public static List<Temp2> GetAllUserNoteData(int id, int sessionId)
        {
           
            return UserData.GetAllUserNoteData(id, sessionId);
        }

        public static void deleteNoteData(int id)
        {
            UserData.deleteNoteData(id);
        }

        public static void InsertNote(int sessionUserId, string txtNote, int id, string status)
        {
            UserData.InsertNote(sessionUserId, txtNote, id, status);
        }  public static void updateNoteData(int sessionUserId, string txtNote, int id, string status,int noteId)
        {
            UserData.updateNoteData(sessionUserId, txtNote, id, status,noteId);
        }


        //user


        public static Temp sendUserData(int id)
        {
            return UserData.sendUserData(id);
        }

        public static string displayImage(int id)
        {
            return UserData.displayImage(id);
        }

        public static void GetUserData(Temp data,int ID)
        {
            UserData.GetUserData(data,ID);
        }

        public static List<RoleModel> SetUserRoles()
        {
            return UserData.SetUserRoles();

        }
        public static List<string> GetCountry()
        {
            return UserData.GetCountry();
        }
        public static List<string> GetState(string name)
        {
            return UserData.GetState(name);
        }

    }
}
