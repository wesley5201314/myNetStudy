using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;

public partial class admin_hidecontent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                DB my = new DB();
                long id = Convert.ToInt64(Request.QueryString["id"]);
                string sql = "select * from sw_content where id=" + id;
                OleDbDataReader dr = my.ExecuteReader(sql);
                dr.Read();
                long ct_hide =Convert.ToInt64(dr["ct_hide"]);
                my.Clear();
                if (ct_hide == 0)
                {
                    ct_hide = 1;
                }
                else
                {
                    ct_hide = 0;
                }
                sql = "update sw_content set ct_hide='"+ct_hide+"' where id="+id;
                my.ExecuteNonQuery(sql);
                Response.Redirect("content.aspx");
            }
        }
    }
}
