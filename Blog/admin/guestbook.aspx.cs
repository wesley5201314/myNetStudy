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

public partial class admin_guestbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    string sql;
    DB my = new DB();
    protected void ListView1_PreRender(object sender, EventArgs e)
    {
        sql = "select * from sw_guestbook order by id desc";
        OleDbDataAdapter da = my.DataAdapter(sql);
        DataSet ds = my.GetDataSet(da);
        ListView1.DataSource = ds;
        ListView1.DataBind();
    }
    protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        ListView1.EditIndex = e.NewEditIndex;
    }
    protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        if (e.CancelMode == ListViewCancelMode.CancelingEdit)
        {
            ListView1.EditIndex = -1;
        }
    }
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        long id=Convert.ToInt64(ListView1.DataKeys[e.ItemIndex].Value);
        long huifu = 1;
        string review = Server.HtmlEncode(((TextBox)ListView1.Items[e.ItemIndex].FindControl("reTextBox")).Text.ToString());
        string content = Server.HtmlEncode(((TextBox)ListView1.Items[e.ItemIndex].FindControl("cTextBox")).Text.ToString());
        sql = "update sw_guestbook set content='"+content+"',review='"+review+"',huifu='"+huifu+"' where id="+id;
        my.ExecuteNonQuery(sql);
        ListView1.EditIndex = -1;
    }
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        long id = Convert.ToInt64(ListView1.DataKeys[e.ItemIndex].Value);
        sql = "delete from sw_guestbook where id="+id;
        my.ExecuteNonQuery(sql);
    }
}
