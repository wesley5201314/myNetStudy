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

public partial class admin_content : System.Web.UI.Page
{
    CheckBox c1;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataTable table = new DataTable();
    DB my = new DB();
    OleDbDataAdapter da;
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData("0");
        }
    }
    public void BindData(string tag)
    {
        sql = "select * from sw_content order by id desc";
        da = my.DataAdapter(sql);
        da.Fill(ds);
        dt = ds.Tables[0];
        table = SearchTag(dt, table, tag);
        GridView1.DataSource = table.DefaultView;
        GridView1.DataBind();
        foreach (GridViewRow r in GridView1.Rows)
        {
            c1 = (CheckBox)r.FindControl("CheckBox1");
            Label chennel = (Label)r.FindControl("chennel");
            HyperLink yulan = (HyperLink)r.FindControl("yulan");
            HyperLink hide = (HyperLink)r.FindControl("hide");
            HyperLink edit = (HyperLink)r.FindControl("edit");
            long id = Convert.ToInt64(r.Cells[0].Text);
            sql = "select * from sw_content where id=" + id;
            OleDbDataReader dr = my.ExecuteReader(sql);
            dr.Read();
            long cid = Convert.ToInt64(dr["ct_cid"]);
            long ct_hide = Convert.ToInt64(dr["ct_hide"]);
            my.Clear();
            if (ct_hide == 0)
            {
                hide.Text = "正常";
            }
            else
            {
                hide.Text = "隐藏";
            }
            if (selall.Text == "全选")
            {
                c1.Checked = false;
            }
            else
            {
                c1.Checked = true;
            }
            yulan.Attributes.Add("target","_blank");
            hide.NavigateUrl = "hidecontent.aspx?id=" + id.ToString();
            yulan.NavigateUrl = "~/Show.aspx?id=" + id.ToString();
            edit.NavigateUrl = "editcontent.aspx?id=" + id.ToString();
            sql = "select * from sw_chennel where id=" + cid;
            dr = my.ExecuteReader(sql);
            dr.Read();
            chennel.Text = dr["ch_name"].ToString();
            my.Clear();}
    }
    protected void selall_Click(object sender, EventArgs e)
    {
        if (selall.Text == "全不选")
        {
            selall.Text = "全选";
        }
        else
        { selall.Text = "全不选"; }
    }
    protected void delcontent_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GridView1.Rows)
        {
            c1 = (CheckBox)r.FindControl("CheckBox1");
            if (c1.Checked)
            {
                long id = Convert.ToInt64(r.Cells[0].Text);
                string sql = "delete from sw_content where id=" + id;
                my.ExecuteNonQuery(sql);
                sql = "delete from sw_content01 where aid=" + id;
                my.ExecuteNonQuery(sql);
                sql = "delete from sw_comment where aid=" + id;
                my.ExecuteNonQuery(sql);
            }
        }
    }
    protected void search_Click(object sender, EventArgs e)
    {
        string tag = searchtxt.Text.Trim();
        BindData(tag);  
    }
    public DataTable SearchTag(DataTable dt, DataTable table, string tag)
    {
        if (tag == "0")
        {
            table = dt.Copy();
        }
        else
        {
            table = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                string title = row["ct_title"].ToString();
                if (title.IndexOf(tag) >= 0)
                {
                    DataRow r = table.NewRow();
                    r["id"] = Convert.ToInt64(row["id"]);
                    r["ct_title"] = row["ct_title"].ToString();
                    r["ct_keywords"] = row["ct_keywords"].ToString();
                    r["ct_description"] = row["ct_description"].ToString();
                    r["ct_pic"] = row["ct_pic"].ToString();
                    r["ct_time"] = row["ct_time"].ToString();
                    r["ct_views"] = Convert.ToInt64(row["ct_views"]);
                    r["ct_digg"] = Convert.ToInt64(row["ct_digg"]);
                    r["ct_order"] = Convert.ToInt64(row["ct_order"]);
                    r["ct_cid"] = Convert.ToInt64(row["ct_cid"]);
                    r["ct_hide"] = Convert.ToInt64(row["ct_hide"]);
                    r["ct_commend"] = Convert.ToInt64(row["ct_commend"]);
                    table.Rows.Add(r);
                }
            }
        }
        return table;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ((GridView)sender).PageIndex = e.NewPageIndex; 
        BindData("0");
    }
}
