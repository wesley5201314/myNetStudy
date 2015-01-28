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

public partial class _Default : System.Web.UI.Page
{
    public string pagekey, pagedesc;
    public list myli = new list();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = Application["title"].ToString();
            pagekey = Application["keywords"].ToString();
            pagedesc = Application["description"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
    }
    protected void ListContent_PreRender(object sender, EventArgs e)
    {
        sitemap1.Text = "首页";
        sitemap1.NavigateUrl = Application["installdir"].ToString();
        sitemap2.Visible = false;
        sitemap3.Visible = false;
        map1.Visible = false;
        map2.Visible = false;
    }
    void BindData()
    {
        DB my = new DB();
        long a = 1;
        string sql = "select * from sw_content where ct_hide<>" + a + " order by ct_order desc,id desc";
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
