using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace MyBlog.admin
{
    public partial class admin_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "adminlogin")
            {
                Response.Redirect("login.aspx");
            }
            if (!Page.IsPostBack)
            {
                show();
            }
        }
        public void show()
        {
            db d1 = new db();
            string path = d1.accessdb2();

            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select * from admin";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader odr = comm.ExecuteReader();
            while (odr.Read())
            {
                TextBox1.Text = odr[1].ToString();
                TextBox2.Text = odr[0].ToString();
            }
            odr.Close();
            conn.Close();
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (TextBox3.Text == TextBox1.Text)
            {
                db d1 = new db();
                string path = d1.accessdb2();
                OleDbConnection conn = new OleDbConnection(path);
                conn.Open();
                string sql = "update admin set admin_name=@name,admin_password=@pass";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                comm.Parameters.Add("@name", TextBox2.Text);
                comm.Parameters.Add("@pass", TextBox1.Text);
                comm.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('修改成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('2次密码输入不对！')</script>");
            }

        }
    }
}