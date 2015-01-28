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

public partial class Show : System.Web.UI.Page
{
    public string pagekey, pagedesc,ct_title,ct_time,ct_views,content,tags;
    public string sql, ch_name,ch_id;
    public long id, ct_cid,ct_digg;
    DB my = new DB();
    list myli = new list();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt64(Request.QueryString["id"].ToString());
            sql = "select * from sw_content where id=" + id;
            OleDbDataReader dr = my.ExecuteReader(sql);
            if (dr.Read())
            {

                ct_title = dr["ct_title"].ToString();
                this.Title = dr["ct_title"].ToString() + " - " + Application["title"].ToString();
                ct_time = dr["ct_time"].ToString();
                ct_views = dr["ct_views"].ToString();
                ct_digg = Convert.ToInt64(dr["ct_digg"]);
                pagekey = dr["ct_keywords"].ToString();
                tags = GetTags(pagekey);
                pagedesc = myli.GetSubString(dr["ct_description"].ToString(), 100);
                ct_cid = Convert.ToInt64(dr["ct_cid"]);
                my.Clear();
                sql = "select * from sw_chennel where id=" + ct_cid;
                dr = my.ExecuteReader(sql);
                dr.Read();
                ch_name = dr["ch_name"].ToString();
                ch_id = dr["id"].ToString();
                my.Clear();
                sql = "select * from sw_content01 where aid=" + id;
                dr = my.ExecuteReader(sql);
                dr.Read();
                content = Server.HtmlDecode(dr["content"].ToString());
                my.Clear();
                long vi = Convert.ToInt64(ct_views) + 1;
                sql = "update sw_content set ct_views='"+vi+"' where id="+id;
                my.ExecuteNonQuery(sql);
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
        sitemap1.Text = "首页";
        sitemap1.NavigateUrl = Application["installdir"].ToString();
        sitemap2.Text = ch_name;
        sitemap2.NavigateUrl = Application["installdir"].ToString()+ "Chennel.aspx?id=" + ch_id.ToString();
        sitemap3.Text = "文章";
        diggsu.Text = ct_digg.ToString();
    }
    public string GetTags(string pagekey)
    {
        char[] douhao = { ',' };
        string[] tmptags = pagekey.Split(douhao);
        string tmptag="";
        foreach (string i in tmptags)
        {
            string tmp = Server.UrlEncode(i);
            tmptag += "<a href=Search.aspx?key="+tmp+"&type=0 target='_blank'>"+i+"</a>,";
        }
        return tmptag.Remove(tmptag.Length-1,1);
    }
    protected void up_PreRender(object sender, EventArgs e)
    {
        sql = "select top 1 * from sw_content where id<" + id + " and ct_cid="+ct_cid+" order by id desc";
        OleDbDataReader dr = my.ExecuteReader(sql);
        if (dr.Read())
        {
            up.Text = dr["ct_title"].ToString();
            up.NavigateUrl = "Show.aspx?id=" + dr["id"].ToString();
        }
        else {
            up.Text = ch_name;
            up.NavigateUrl = "Chennel.aspx?id=" + ct_cid.ToString();
        }
        my.Clear();
        sql = "select top 1 * from sw_content where id>" + id + " and ct_cid=" + ct_cid;
        dr = my.ExecuteReader(sql);
        if (dr.Read())
        {
            down.Text = dr["ct_title"].ToString();
            down.NavigateUrl = "Show.aspx?id=" + dr["id"].ToString();
        }
        else
        {
            down.Text = ch_name;
            down.NavigateUrl = "Chennel.aspx?id=" + ct_cid.ToString();
        }
    }
    protected void diggbuttom_Click(object sender, ImageClickEventArgs e)
    {
        ct_digg = ct_digg + 1;
        sql = "update sw_content set ct_digg=" + ct_digg + " where id=" + id;
        my.ExecuteNonQuery(sql);
        diggsu.Text = ct_digg.ToString();
        diggbuttom.Enabled = false;
    }
    protected void ListComment_PreRender(object sender, EventArgs e)
    {
        sql = "select * from sw_comment where aid=" + id + " and shen=" + (long)1+" order by id desc";
        OleDbDataAdapter da = my.DataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListComment.DataSource = ds;
        ListComment.DataBind();
    }
    protected void ListComment_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        string code = Server.HtmlEncode(((TextBox)ListComment.InsertItem.FindControl("ChkCode")).Text.ToString().ToUpper().Trim());
        string name = Server.HtmlEncode(((TextBox)ListComment.InsertItem.FindControl("Cname")).Text.ToString());
        string say = Server.HtmlEncode(((TextBox)ListComment.InsertItem.FindControl("Csay")).Text.ToString());
        string time = DateTime.Now.ToString();
        string ip = Request.ServerVariables.Get("Remote_Addr").ToString();
        if (code != Session["CheckCode"].ToString().Trim())
        {
            JS.Text = "验证码不正确";
            return;
        }
        else if(name=="")
        {
            JS.Text = "用户名不能为空";
            return;
        }
        else if (say == "")
        {
            JS.Text = "评论不能为空";
            return;
        }
        sql = "insert into sw_comment(name,cotime,ip,say,shen,aid,cid)Values('" + name + "','" + time + "','" + ip + "','" + say + "','" + (long)0 + "','" + id + "','" + ct_cid + "')";
        my.ExecuteNonQuery(sql);
        JS.Text="评论成功！等待管理员审核！";
    }
}
