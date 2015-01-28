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

public partial class admin_delchennel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                DB my = new DB();
                long id = Convert.ToInt64(Request.QueryString["id"]);
                string sql = "select * from sw_chennel where id=" + id;
                OleDbDataReader dr = my.ExecuteReader(sql);
                dr.Read();
                string childs = dr["ch_childs"].ToString();
                my.Clear();
                char[] douhao = { ',' };
                string[] arrchild = childs.Split(douhao);
                foreach (string i in arrchild)
                {
                    id = Convert.ToInt64(i);
                    sql = "delete from sw_chennel where id="+id;
                    my.ExecuteNonQuery(sql);
                    sql = "delete from sw_content where ct_cid=" + id;
                    my.ExecuteNonQuery(sql);
                    sql = "delete from sw_content01 where cid=" + id;
                    my.ExecuteNonQuery(sql);
                    sql = "delete from sw_comment where cid=" + id;
                    my.ExecuteNonQuery(sql);
                }
                Response.Redirect("chennel.aspx");
               // ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功');window.location.href='chennel.aspx';</script>");
            }
        }
    }
}
