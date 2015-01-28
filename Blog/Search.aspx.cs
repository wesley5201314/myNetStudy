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

public partial class Search : System.Web.UI.Page
{
    public string pagekey, pagedesc,stitle;
    string tag,sql;
    long type;
    DB my = new DB();
    public  list myli = new list();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Request.QueryString["tag"] != null)
        {
            tag = Server.UrlDecode(Request.QueryString["tag"].ToString());
            type = Convert.ToInt64(Request.QueryString["type"]);
            this.Title = "搜索'" + tag + "' - " + Application["title"].ToString();
            pagekey = tag;
            pagedesc = "搜索" + tag;
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
            sitemap1.Text = "首页";
            sitemap1.NavigateUrl = Application["installdir"].ToString();
            sitemap2.Text = "搜索："+tag;
            sitemap2.NavigateUrl = Application["installdir"].ToString()+"Search.aspx?tag=" + Server.UrlEncode(tag) + "&type=" + type.ToString();
            map2.Visible = false;
            sitemap3.Visible = false;
            BindData();
        }
    }

    public void BindData()
    {
        OleDbDataAdapter da;
        DataSet ds = new DataSet();
        DataTable table = new DataTable();
        DataTable dt = new DataTable();
        table.Columns.Add(new DataColumn("id", typeof(long)));
        table.Columns.Add(new DataColumn("ct_title", typeof(string)));
        table.Columns.Add(new DataColumn("ct_description", typeof(string)));
        table.Columns.Add(new DataColumn("ct_time", typeof(string)));
        table.Columns.Add(new DataColumn("ct_views", typeof(long)));
        table.Columns.Add(new DataColumn("ct_digg", typeof(long)));
        sql = "select * from sw_content where ct_hide=" + (long)0+" order by id desc";
        da = my.DataAdapter(sql);
        da.Fill(ds);
        dt = ds.Tables[0];
        if (type == 0)
        {
            table = ContentSearch(dt, table, "ct_title");
        }
        else
        {
            table = ContentSearch(dt, table, "ct_description");
        }
        AspNetPager1.RecordCount = table.Rows.Count;
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = table.DefaultView;
        ListSearch.DataSource = pds;
        ListSearch.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    public DataTable ContentSearch(DataTable dt,DataTable table,string datakey)
    {
        foreach (DataRow r in dt.Rows)
        {
            if (r[datakey].ToString().IndexOf(tag) >= 0)
            {
                DataRow row = table.NewRow();
                row["id"] = Convert.ToInt64(r["id"]);
                row["ct_title"] = r["ct_title"].ToString().Replace(tag, "<font color='red'>" + tag + "</font>");
                string des = myli.GetSubString(r["ct_description"].ToString(), 300);
                row["ct_description"] = des.Replace(tag, "<font color='red'>" + tag + "</font>");
                row["ct_time"] = r["ct_time"].ToString();
                row["ct_views"] = Convert.ToInt64(r["ct_views"]);
                row["ct_digg"] = Convert.ToInt64(r["ct_digg"]);
                table.Rows.Add(row);
            }
            int x = r["ct_keywords"].ToString().IndexOf(tag);
            bool y = GetDistnct(table, Convert.ToInt64(r["id"]));
            if ((x >= 0) && (y = false))
            {
                DataRow row = table.NewRow();
                row["id"] = Convert.ToInt64(r["id"]);
                row["ct_title"] = r["ct_title"].ToString().Replace(tag, "<font color='red'>" + tag + "</font>");
                string des = myli.GetSubString(r["ct_description"].ToString(), 300);
                row["ct_description"] = row["ct_description"] = des.Replace(tag, "<font color='red'>" + tag + "</font>");
                row["ct_time"] = r["ct_time"].ToString();
                row["ct_views"] = Convert.ToInt64(r["ct_views"]);
                row["ct_digg"] = Convert.ToInt64(r["ct_digg"]);
                table.Rows.Add(row);
            }
        }
        return table;
    }
    //判断是否存在记录
    public bool GetDistnct(DataTable dt, long id)
    {
        try
        {
            DataRow[] row = dt.Select("id="+id);
            if (row.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch 
        {
            return false;
        }
    }
    //去重复记录
    public DataTable GetDistinctPrimaryKeyColumnTable(DataTable dt, string[] PrimaryKeyColumns)
    {
        DataView dv = dt.DefaultView;
        DataTable dtDistinct = dv.ToTable(true,PrimaryKeyColumns);
        return dtDistinct;
    }
}
