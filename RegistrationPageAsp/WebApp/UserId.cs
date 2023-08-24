using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace utils
{
    
    namespace utils
    {
        public partial class UserId : System.Web.UI.Page
        {
            public static int getUserId()
            {
                int id = 0;
                if (HttpContext.Current.Request.QueryString["UserId"] != null)
                {

                    id = int.Parse(HttpContext.Current.Request.QueryString["UserId"].ToString());
                }
                return id;
            } public static int getSessionId()
            {
                return int.Parse(HttpContext.Current.Session["UserId"].ToString());
            }
        }
    }
}
