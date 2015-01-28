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
    public partial class login : System.Web.UI.Page
    {
        OleDbConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["admin"] == "adminlogin")
            {
                Response.Redirect("index.aspx");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb2();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select admin_password from admin ";
            string pass = null;
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader odr = comm.ExecuteReader();
            while (odr.Read())
            {
                pass = string.Format("{0}", odr[0]);


            }
            odr.Close();
            conn.Close();

            if (password.Value == pass)
            {
                Session["admin"] = "adminlogin";
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert('查无此用户或密码错误')</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            name.Value = "";
            password.Value = "";

        }
    }
}