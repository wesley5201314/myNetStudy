using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.OleDb;

public partial class admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DB mydb = new DB();
        long a = 1;
        string sql = "select * from sw_config where id="+a;
        OleDbDataReader dr = mydb.ExecuteReader(sql);
        dr.Read();
        string x, y;
        x = dr["name"].ToString();
        if (Session["swadmin"] != null)
        {
            y = Session["swadmin"].ToString();
            if (x != y)
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}
