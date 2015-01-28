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

public partial class admin_Default : System.Web.UI.Page
{
    public string pagetitle ;
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        pagetitle = "222";
        this.Title =pagetitle;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DB my = new DB();
            long x = 0;
            string sql = "select * from sw_guestbook where huifu=" + x;
            OleDbDataAdapter da = my.DataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds, "guest");
            sql = "select * from sw_comment where shen=" + x;
            da = my.DataAdapter(sql);
            da.Fill(ds, "com");
            DataTable g = ds.Tables["guest"];
            DataTable c = ds.Tables["com"];
            guestbook.Text = g.Rows.Count.ToString();
            comment.Text = c.Rows.Count.ToString();
        }
    }
}
