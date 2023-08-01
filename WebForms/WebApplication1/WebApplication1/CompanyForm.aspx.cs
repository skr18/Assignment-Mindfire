using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CompanyForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                usercontrol.objId = int.Parse(inp.Text);
            }
        }
        protected void FindData(object sender, EventArgs e)
        {
           
        }
    }
}