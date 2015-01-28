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

public partial class admin_editchennel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        if (Request.QueryString["id"] != null)
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
                long id = Convert.ToInt64(Request.QueryString["id"]);
                sql = "select * form sw_chennel where id=" + id;
                DataRow[] rows = dt.Select("id="+id);
                DataRow row = rows[0];
                cname.Text = row["ch_name"].ToString();
                corder.Text = row["ch_order"].ToString();
                ckeywords.Text = row["ch_keywords"].ToString();
                cdescription.Text = row["ch_description"].ToString();
                long father = Convert.ToInt64(row["ch_father"]);
                if (father != 0)
                {
                    rows = dt.Select("id='" + father + "'");
                    row = rows[0];
                    string fathername = row["ch_name"].ToString();
                    for (int i = 0; i < DropDownList1.Items.Count;i++ )
                    {
                        if (DropDownList1.Items[i].Text.IndexOf(fathername) >= 0)
                        {
                            DropDownList1.SelectedValue = DropDownList1.Items[i].Text;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("chennel.aspx");
            }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DB my = new DB();
        long order, deep, father;
        string name, keywords, description,sql, topname;
        order = Convert.ToInt64(corder.Text);
        name = cname.Text.Trim();
        keywords = ckeywords.Text.Trim();
        description = cdescription.Text.Trim();
        topname = "";
        long id = Convert.ToInt64(Request.QueryString["id"]);
        sql = "select * from sw_chennel";
        OleDbDataAdapter da = my.DataAdapter(sql);
        DataSet ds = my.GetDataSet(da);
        DataTable dt = ds.Tables[0];
        DataRow[] rows = dt.Select("id="+id);
        DataRow row=rows[0];
        string  oldchild = row["ch_child"].ToString();
        string oldchilds = row["ch_childs"].ToString();
        long oldfather=Convert.ToInt64(row["ch_father"]);
        long olddeep=Convert.ToInt64(row["ch_deep"]);
        if (DropDownList1.SelectedItem.Text == "顶级栏目")
        {
            deep = 0;
            father = 0;
        }
        else
        {
            topname = DropDownList1.SelectedItem.Text.Replace("├", "").Trim();
            DataRow[] rs1 = dt.Select("ch_name='" + topname + "'");
            father = Convert.ToInt64(rs1[0]["id"]);
            deep = Convert.ToInt64(rs1[0]["ch_deep"]) + 1;
        }
        //栏目本身修改
        sql = "update sw_chennel set ch_name='" + name + "',ch_keywords='" + keywords + "',ch_description='" + description + "',ch_order='" + order + "',ch_deep='" + deep + "',ch_father='" + father + "' where id=" + id;
        my.ExecuteNonQuery(sql);
        //下级栏目深度
        if (deep != olddeep)
        {
            long childdeep=deep+1;
            string cchild = oldchild;
            ChildDeep(cchild,childdeep);
        }
        //删除以前上级栏目child,childs
        if (father != oldfather)
        {
            long tmpfather = oldfather;
            while (tmpfather != 0)
            {
                sql = "select * from sw_chennel where id=" + tmpfather;
                OleDbDataReader dr = my.ExecuteReader(sql);
                dr.Read();
                string tmpchild = dr["ch_child"].ToString();
                string tmpchilds = dr["ch_childs"].ToString();
                string tmpname = dr["ch_name"].ToString();
                tmpfather = Convert.ToInt64(dr["ch_father"]);
                my.Clear();
                tmpchild=ReplaceStr(oldchilds,tmpchild);
                tmpchilds = ReplaceStr(oldchilds, tmpchilds);
                sql = "update sw_chennel set ch_child='"+tmpchild+"',ch_childs='"+tmpchilds+"' where ch_name='"+tmpname+"'";
                my.ExecuteNonQuery(sql);
            }
        }
        //如果不是顶级栏目，向上级栏目添加子栏目
        if (father != 0)
        {
            long tmpfather = father;
            int x = 0;//标记，只向上级栏目添加CHILD
            while (tmpfather != 0)
            {
                sql = "select * from sw_chennel where id=" + tmpfather;
                OleDbDataReader dr = my.ExecuteReader(sql);
                dr.Read();
                string tmpchild = dr["ch_child"].ToString();
                string tmpchilds = dr["ch_childs"].ToString();
                string tmpname = dr["ch_name"].ToString();
                tmpfather = Convert.ToInt64(dr["ch_father"]);
                my.Clear();
                //tmpchild = AddStr(oldchilds, tmpchild);
                if (x == 0)
                {
                    if (tmpchild.IndexOf(id.ToString()) < 0)
                    {
                        tmpchild = tmpchild + "," + id.ToString();
                    }
                    x = 1;
                }
                tmpchilds = AddStr(oldchilds, tmpchilds);
                sql = "update sw_chennel set ch_child='" + tmpchild + "',ch_childs='" + tmpchilds + "' where ch_name='" + tmpname + "'";
                my.ExecuteNonQuery(sql);
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改成功');window.location.href='chennel.aspx';</script>");
    }
    //添加新上级栏目childs
    public string AddStr(string Str, string Mstr)
    {
        char[] douhao = { ',' };
        string[] arrstr = Str.Split(douhao);
        foreach (string m in arrstr)
        {
            if (Mstr.IndexOf(m) < 0)
            {
                Mstr = Mstr + "," + m;
            }
        }
        return Mstr;
    }
    //删除以前上级栏目child,childs
    public string ReplaceStr(string Str, string Mstr)
    {
        char[] douhao = { ',' };
        string[] arroldchild = Str.Split(douhao);
        foreach (string m in arroldchild)
        {
            if (Mstr.IndexOf(m) >= 0)
            {
                Mstr = Mstr.Replace(","+m, "");
            }
        }
        return Mstr;
    }
    //子栏目深度修改
    public void ChildDeep(string child,long deep)
    {
        DB my = new DB();
        char[] douhao = {','};
        if (child != "0")
        {
            string[] arrchild = child.Split(douhao);
            foreach (string m in arrchild)
            {
                long childid = Convert.ToInt64(m);
                string sql = "update sw_chennel set ch_deep='" + deep + "' where id=" + childid;
                my.ExecuteNonQuery(sql);
                sql = "select * from sw_chennel where id=" + childid;
                OleDbDataReader dr = my.ExecuteReader(sql);
                dr.Read();
                string tmpchild = dr["ch_child"].ToString();
                long tmpdeep = Convert.ToInt64(dr["ch_deep"]) + 1;
                my.Clear();
                if (tmpchild != "0")
                {
                    ChildDeep(tmpchild,tmpdeep);
                }
            }
        }
    }
}
