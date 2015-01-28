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

public partial class admin_chennel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    DataTable table = new DataTable();
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        DB mydb = new DB();
        string Sql;
        //绑定栏目
         Sql = "select * from sw_chennel";
         OleDbDataAdapter da = mydb.DataAdapter(Sql);
         DataSet ds = mydb.GetDataSet(da);
         DataTable dt = ds.Tables[0];
         DataColumn dc = new DataColumn("id", typeof(Int64));
         DataColumn dc1 = new DataColumn("ch_name",typeof(string));
         DataColumn dc2=new DataColumn("ch_order",typeof(Int64));
         table.Columns.Add(dc);
         table.Columns.Add(dc1);
         table.Columns.Add(dc2);
         foreach (DataRow row in dt.Rows)
         {
             if (Convert.ToInt32(row["ch_father"]) == 0)
             {
                 DataRow tmprow=table.NewRow();
                 tmprow["id"] = row["id"];
                 tmprow["ch_name"] = row["ch_name"];
                 tmprow["ch_order"] = row["ch_order"];
                 table.Rows.Add(tmprow);
                 ChildItem(dt,Convert.ToInt64(row["id"]),1);
             }
         }
         GridView1.DataSource = table.DefaultView;
         GridView1.DataBind();
        foreach (GridViewRow r in GridView1.Rows)
         {
             HyperLink edit = (HyperLink)r.FindControl("edit");
             HyperLink del = (HyperLink)r.FindControl("del");
             string id = r.Cells[0].Text;
             edit.NavigateUrl = "editchennel.aspx?id=" + id;
             del.NavigateUrl = "delchennel.aspx?id=" + id;
         }
    }
    public void ChildItem(DataTable dt, long id, int length)
    {
        DataRow[] rows = dt.Select("ch_father='" + id + "'");//, "id desc");//取出id子节点进行绑定
        for (int i = 0; i < rows.Length; i++)
        {
            DataRow tmprow = table.NewRow();
            tmprow["id"] = rows[i]["id"];
            tmprow["ch_name"] = Space(length) + "├" + rows[i]["ch_name"].ToString();
            tmprow["ch_order"] = rows[i]["ch_order"];
            table.Rows.Add(tmprow);
            ChildItem(dt,Convert.ToInt64(rows[i]["id"]), length + 1);//空白数目加1
        }
    }
    /// <summary>
    /// 子节点前面的空白数
    public string Space(int i)
    {
        string space = "";
        for (int j = 0; j < i; j++)
        {
            space += "　";//注意这里的空白是智能abc输入法状态下的v11字符；
        }
        return space;
    }
}
