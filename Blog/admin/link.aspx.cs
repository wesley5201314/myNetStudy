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

public partial class admin_link : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    DB my = new DB();
    string sql;
    protected void ListView1_PreRender(object sender, EventArgs e)
    {
        sql = "select * from sw_link";
        OleDbDataAdapter da=my.DataAdapter(sql);
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

    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        string sitename = Server.HtmlEncode(((TextBox)ListView1.InsertItem.FindControl("sitenameTextBox")).Text.ToString());
        string siteurl = Server.HtmlEncode(((TextBox)ListView1.InsertItem.FindControl("siteurlTextBox")).Text.ToString());
        string sitelogo = Server.HtmlEncode(((TextBox)ListView1.InsertItem.FindControl("logoTextBox")).Text.ToString());
        long iflogo=0;
        if (sitelogo != "")
        {
            iflogo = 1;
        }
        sql = "insert into sw_link(sitename,siteurl,logo,iflogo)values('" + sitename + "','" + siteurl + "','" + sitelogo + "','" + iflogo + "')";
        my.ExecuteNonQuery(sql);
    }
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        long id = Convert.ToInt64(ListView1.DataKeys[e.ItemIndex].Value);
        sql = "delete from sw_link where id="+id;
        my.ExecuteNonQuery(sql);
    }
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        long id = Convert.ToInt64(ListView1.DataKeys[e.ItemIndex].Value);
        string sitename = Server.HtmlEncode(((TextBox)ListView1.Items[e.ItemIndex].FindControl("sitenameTextBox")).Text.ToString());
        string siteurl = Server.HtmlEncode(((TextBox)ListView1.Items[e.ItemIndex].FindControl("siteurlTextBox")).Text.ToString());
        string sitelogo = Server.HtmlEncode(((TextBox)ListView1.Items[e.ItemIndex].FindControl("logoTextBox")).Text.ToString());
        long iflogo = 0;
        if (sitelogo != "")
        {
            iflogo = 1;
        }
        sql = "update sw_link set sitename='" + sitename + "',siteurl='" + siteurl + "',logo='" + sitelogo + "',iflogo='" + iflogo + "' where id=" + id;
        my.ExecuteNonQuery(sql);
       ListView1.EditIndex = -1;
    }
}
