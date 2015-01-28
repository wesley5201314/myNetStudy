using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace MyBlog.admin.edit
{
    public partial class edit_type_edit : System.Web.UI.Page
    {
        OleDbConnection conn;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "adminlogin")
            {
                Response.Redirect("../login.aspx");
            }
            id = Convert.ToInt32(Request.Params["id"]);
            if (!Page.IsPostBack)
            {
                show();
            }
        }

        public void show()
        {
            db d1 = new db();
            string path = d1.accessdb3();
            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select * from type where type_id=" + id;
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader odr = comm.ExecuteReader();
            while (odr.Read())
            {
                TextBox1.Text = odr[1].ToString();
            }
            odr.Close();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "update type set type_title=@title where type_id=" + id;
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@title", TextBox1.Text);
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('修改成功')</script>");
        }
    }
}