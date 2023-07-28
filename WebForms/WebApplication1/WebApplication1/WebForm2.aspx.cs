using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user2"] != null)
                {
                    data.Text = Session["user2"].ToString();
                }
                else
                {
                    data.Text = "No session Data";
                }
            }
            else
            {
                data.Text = "No Data";
            }
        }
        protected void check(object sender, EventArgs e)
        {
           
            Session["user2"] = "Sujeet2";
        }

    }
}