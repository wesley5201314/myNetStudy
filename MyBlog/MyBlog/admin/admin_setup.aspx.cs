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
    public partial class admin_setup : System.Web.UI.Page
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
            string sql = "select * from config";
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
            db d1 = new db();
            string path = d1.accessdb2();
            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string sql = "update config set title=@name,footer=@footer";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@name", TextBox2.Text);
            comm.Parameters.Add("@footer", TextBox1.Text);
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('修改成功')</script>");
            show();
        }
    }
}