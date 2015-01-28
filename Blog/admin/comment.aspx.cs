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

public partial class admin_comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
    DB my = new DB();
    string sql;
    protected void ListView1_PreRender(object sender, EventArgs e)
    {
        sql = "select * from sw_comment order by id desc";
        OleDbCommand cmd = new OleDbCommand(sql,my.GetCon());
        OleDbDataAdapter da = my.DataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds, "comment");
        sql = "select * from sw_content";
        da = my.DataAdapter(sql);
        da.Fill(ds,"content");
        sql = "select * from sw_chennel";
        da = my.DataAdapter(sql);
        da.Fill(ds, "chennel");
        DataTable dtcomment = ds.Tables["comment"];
        DataTable dtaid=ds.Tables["content"];
        DataTable dtcid=ds.Tables["chennel"];
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("id",typeof(Int64)));
        table.Columns.Add(new DataColumn("ct_title",typeof(string)));
        table.Columns.Add(new DataColumn("name", typeof(string)));
        table.Columns.Add(new DataColumn("say", typeof(string)));
        table.Columns.Add(new DataColumn("time", typeof(string)));
        table.Columns.Add(new DataColumn("shen", typeof(string)));
        foreach (DataRow r in dtcomment.Rows)
        {
            DataRow newrow = table.NewRow();
            newrow["id"] = r["id"];
            newrow["name"] = r["name"];
            newrow["time"] = r["cotime"];
            newrow["say"] = r["say"];
            long aid = Convert.ToInt64(r["aid"]);
            long cid = Convert.ToInt64(r["cid"]);
            if (Convert.ToInt64(r["shen"]) == 0)
            {
                newrow["shen"] = "未审核";
            }
            else
            {
                newrow["shen"] = "审核";
            }
            newrow["ct_title"] = "  [ " + getcid(cid, dtcid) + " ]  " + getaid(aid, dtaid);
            table.Rows.Add(newrow);
        }
        ListView1.DataSource = table.DefaultView;
        ListView1.DataBind();
    }
    public string getaid(Int64 id,DataTable dt)
    {
        string re;
        DataRow[] r1 = dt.Select("id='"+id+"'");
        re=r1[0]["ct_title"].ToString();
        return re;
    }
    public string getcid(Int64 id, DataTable dt)
    {
        string re;
        DataRow[] r1 = dt.Select("id='" + id + "'");
        re = r1[0]["ch_name"].ToString();
        return re;
    }
    protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        ListView1.EditIndex = e.NewEditIndex;
    }
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        long id = Convert.ToInt64(ListView1.DataKeys[e.ItemIndex].Value);
        DropDownList d = (DropDownList)ListView1.Items[e.ItemIndex].FindControl("DropDownList1");
        long shen = Convert.ToInt64(d.SelectedValue);
        string say = Server.HtmlEncode(((TextBox)ListView1.Items[e.ItemIndex].FindControl("cTextBox")).Text.ToString());
        sql = "update sw_comment set say='" + say + "',shen='" + shen + "' where id=" + id;
        my.ExecuteNonQuery(sql);
        ListView1.EditIndex = -1;
    }
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        long id = Convert.ToInt64(ListView1.DataKeys[e.ItemIndex].Value);
        sql = "delete from sw_comment where id=" + id;
        my.ExecuteNonQuery(sql);
    }
    protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        if (e.CancelMode == ListViewCancelMode.CancelingEdit)
        {
            ListView1.EditIndex = -1;
        }
    }
}
