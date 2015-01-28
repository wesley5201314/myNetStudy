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

public partial class Master : System.Web.UI.MasterPage
{
    DB my = new DB();
    string sql;
    DataSet ds = new DataSet();
    OleDbDataAdapter da;
    public list myli = new list();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Calendar1.SelectedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sitename.Text = Application["title"].ToString();
            sitename.NavigateUrl = Application["installdir"].ToString();
            sitedesc.Text = Application["description"].ToString();
            jianjie.Text = Application["jianjie"].ToString();
            Image1.ImageUrl = Application["head"].ToString();
            sql = "select * from sw_content";
            OleDbDataAdapter da = my.DataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            Label1.Text =dt.Rows.Count.ToString();
            Label2.Text = Application["online"].ToString();
            Label3.Text = Application["count"].ToString();
        }
    }
    protected void ListChennel_PreRender(object sender, EventArgs e)
    {
        string a="0";
        sql = "select * from sw_chennel where ch_child='" + a + "' order by ch_order desc";
        da = my.DataAdapter(sql);
        da.Fill(ds, "chennel");
        ListChennel.DataSource=ds.Tables["chennel"].DefaultView;
        ListChennel.DataBind();
    }
    protected void ListHot_PreRender(object sender, EventArgs e)
    {
        sql = "select top 10 * from sw_content order by ct_views desc";
        da = my.DataAdapter(sql);
        da.Fill(ds, "hotcontent");
        ListHot.DataSource = ds.Tables["hotcontent"].DefaultView;
        ListHot.DataBind();
    }
    protected void ListGuest_PreRender(object sender, EventArgs e)
    {
        sql = "select top 10 * from sw_guestbook";
        da = my.DataAdapter(sql);
        da.Fill(ds, "guest");
        ListGuest.DataSource = ds.Tables["guest"].DefaultView;
        ListGuest.DataBind();
    }
    protected void ListLink_PreRender(object sender, EventArgs e)
    {
        sql = "select * from sw_link where iflogo=" + (long)0;
        da = my.DataAdapter(sql);
        da.Fill(ds, "txtlink");
        sql = "select * from sw_link where iflogo=" + (long)1;
        da = my.DataAdapter(sql);
        da.Fill(ds, "logolink");
        ListLink.DataSource = ds.Tables["txtlink"].DefaultView;
        ListLink.DataBind();
        ListLogo.DataSource = ds.Tables["logolink"].DefaultView;
        ListLogo.DataBind();
    }
    protected void Searchbtn_Click(object sender, EventArgs e)
    {
        string tag = Search.Text.ToString().Trim();
        string type = SearchDrop.SelectedValue;
        sql = "select * from sw_tags where tag='" + tag + "'";
        OleDbDataReader dr = my.ExecuteReader(sql);
        if (dr.Read())
        {
            long cisu=Convert.ToInt64(dr["cisu"])+1;
            my.Clear();
            sql="update sw_tags set cisu='"+cisu+"' where tag='"+tag+"'";
            my.ExecuteNonQuery(sql);
        }
        else
        {
            my.Clear();
            sql = "insert into sw_tags(tag,cisu)Values('" + tag + "','" + (long)1 + "')";
            my.ExecuteNonQuery(sql);
        }
        string url = "Search.aspx?tag=" + Server.UrlEncode(tag) + "&type=" + type;
        Response.Redirect(url);
    }
}
