using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserListBusiness
    {
        public static DataTable BindGrid()
        {
            return UserList.BindGrid();
        }

        public static void OnRowDeleting(int id)
        {
            UserList.OnRowDeleting(id);
        }
    }
}
