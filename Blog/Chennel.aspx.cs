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

public partial class Chennel : System.Web.UI.Page
{
    public string pagekey, pagedesc;
    string sql,ch_name;
    long id;
    public list myli = new list();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        DB my = new DB();
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt64(Request.QueryString["id"].ToString());
            sql = "select * from sw_chennel where id=" + id;
            OleDbDataReader dr = my.ExecuteReader(sql);
            if (dr.Read())
            {

                ch_name = dr["ch_name"].ToString();
                this.Title = dr["ch_name"].ToString() + " - " + Application["title"].ToString();
                pagekey = dr["ch_keywords"].ToString();
                pagedesc = dr["ch_description"].ToString();
                my.Clear();
            }
            else
            {
                Response.End();
            }
        }
        else
        {
            Response.Redirect("~/");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void ListContent_PreRender(object sender, EventArgs e)
    {
        sitemap1.Text = "首页";
        sitemap1.NavigateUrl = "~/";
        sitemap2.Text = ch_name;
        sitemap2.NavigateUrl = "~/Chennle.aspx?id=" + id.ToString();
        sitemap3.Visible = false;
        map2.Visible = false;
    }
    void BindData()
    {
        DB my = new DB();
        string sql = "select * from sw_content where ct_cid=" + id + " and ct_hide<>" + (long)1 + " order by ct_order desc,id desc";
        OleDbDataAdapter da = my.DataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        AspNetPager1.RecordCount = dt.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = dt.DefaultView;
        ListContent.DataSource = pds;
        ListContent.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
