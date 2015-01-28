using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBlog.ascx
{
    public partial class count : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Text = Request.UserHostAddress;
            if (Application["online"] != null)
            {
                Label1.Text = Application["online"].ToString();
            }else {
                Label1.Text = "0";
            }
            if (Application["countall"] != null)
            {
                Label2.Text = Application["countall"].ToString();
            }else {
                Label2.Text = "0"; 
            }
        }
    }
}