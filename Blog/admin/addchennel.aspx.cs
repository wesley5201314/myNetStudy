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

public partial class admin_addchennel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("顶级栏目");
            DB my = new DB();
            string sql = "select * from sw_chennel";
            OleDbDataAdapter da = my.DataAdapter(sql);
            DataSet ds = my.GetDataSet(da);
            DataTable dt = ds.Tables[0];
            list li = new list();
            li.GetChennel(DropDownList1, dt);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DB my = new DB();
        long order, deep, father, ffather;
        string name, keywords, description, child, sql, topname, childs, fchild, fchilds;
        order = Convert.ToInt64(corder.Text);
        name = cname.Text.Trim();
        keywords = ckeywords.Text.Trim();
        description = cdescription.Text.Trim();
        child = "0";
        fchild = "";
        fchilds = "";
        topname = "";
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('"+DropDownList1.SelectedItem.Text+"');</script>");
        // return;
        if (DropDownList1.SelectedItem.Text == "顶级栏目")
        {
            deep = 0;
            father = 0;
        }
        else
        {
            topname = DropDownList1.SelectedItem.Text.Replace("├", "").Trim();
            sql = "select * from sw_chennel where ch_name='" + topname + "'";
            OleDbDataReader dr = my.ExecuteReader(sql);
            dr.Read();
            deep = Convert.ToInt64(dr["ch_deep"]) + 1;
            father = Convert.ToInt64(dr["id"]);
            my.Clear();
        }
        //检查栏目是否存在
        sql = "select * from sw_chennel where ch_name='" + name + "'";
        if (my.Scalar(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert2", "<script>alert('栏目已存在');</script>");
            return;
        }
        sql = "Insert Into sw_chennel(ch_name,ch_child,ch_childs,ch_keywords,ch_description,ch_father,ch_deep,ch_order)values('" + name + "','" + child + "','" + child + "','" + keywords + "','" + description + "','" + father + "','" + deep + "','" + order + "')";
        my.ExecuteNonQuery(sql);
        //CHILDS添加
        sql = "select * from sw_chennel where ch_name='" + name + "'";
        OleDbDataReader read = my.ExecuteReader(sql);
        read.Read();
        childs = read["id"].ToString();
        ffather = Convert.ToInt64(read["ch_father"]);
        my.Clear();
        sql = "update sw_chennel set ch_childs='" + childs + "' where ch_name='" + name + "'";
        my.ExecuteNonQuery(sql);
        //父级栏目修改
        if (DropDownList1.SelectedItem.Text != "顶级栏目")
        {
            while (ffather != 0)
            {
                sql = "select * from sw_chennel where id=" + ffather;
                OleDbDataReader or = my.ExecuteReader(sql);
                or.Read();
                fchild = or["ch_child"].ToString();
                fchilds = or["ch_childs"].ToString();
                string tmpname = or["ch_name"].ToString();
                long tmpfather = ffather;
                ffather = Convert.ToInt64(or["ch_father"]);
                my.Clear();
                if (tmpname == topname)
                {
                    if (fchild == "0")
                    {
                        fchild = childs;
                    }
                    else
                    {
                        fchild = fchild + "," + childs;
                    }
                }
                fchilds = fchilds + "," + childs;
                sql = "update sw_chennel set ch_child='" + fchild + "',ch_childs='" + fchilds + "'where id=" + tmpfather;
                my.ExecuteNonQuery(sql);
            }
            Response.Redirect("chennel.aspx");
        }
    }
}
