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

public partial class GuestBook : System.Web.UI.Page
{
    public string pagekey, pagedesc,sql;
    DB my = new DB();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        this.Title ="留言本"+ Application["title"].ToString();
        pagekey = Application["keywords"].ToString();
        pagedesc = Application["description"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sitemap1.Text = "首页";
            sitemap1.NavigateUrl = Application["installdir"].ToString();
            sitemap2.Text = "留言本";
            sitemap2.NavigateUrl = Application["installdir"].ToString()+"GuestBook.aspx";
            sitemap3.Visible = false;
            map2.Visible = false;
        }
    }
    protected void ListGuest_PreRender(object sender, EventArgs e)
    {
        sql = "select * from sw_guestbook where huifu=1 order by id desc";
        OleDbDataAdapter da = my.DataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListGuest.DataSource = ds;
        ListGuest.DataBind();
    }
    protected void ListGuest_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        string code = Server.HtmlEncode(((TextBox)ListGuest.InsertItem.FindControl("ChkCode")).Text.ToString().ToUpper().Trim());
        string name = Server.HtmlEncode(((TextBox)ListGuest.InsertItem.FindControl("Cname")).Text.ToString());
        string content = Server.HtmlEncode(((TextBox)ListGuest.InsertItem.FindControl("Ccontent")).Text.ToString());
        string time = DateTime.Now.ToString();
        string ip = Request.ServerVariables.Get("Remote_Addr").ToString();
        if (code != Session["CheckCode"].ToString().Trim())
        {
            JS.Text = "验证码不正确";
            return;
        }
        else if (name == "")
        {
            JS.Text = "用户名不能为空";
            return;
        }
        else if (content == "")
        {
            JS.Text = "留言不能为空";
            return;
        }
        sql = "insert into sw_guestbook(name,modtime,ip,content,huifu)Values('"+name+"','"+time+"','"+ip+"','"+content+"','"+(long)0+"')";
        my.ExecuteNonQuery(sql);
        JS.Text = "留言成功！等待管理员回复！";
    }
}
