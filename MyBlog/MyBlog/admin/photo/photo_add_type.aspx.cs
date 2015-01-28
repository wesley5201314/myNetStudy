using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace MyBlog.admin.photo
{
    public partial class photo_add_type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "adminlogin")
            {
                Response.Redirect("../login.aspx");
            }
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
            string sql = "select * from type where type_type=2";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader odr = comm.ExecuteReader();
            while (odr.Read())
            {
                DropDownList1.Items.Add(odr[1].ToString());
            }
            odr.Close();
            conn.Close();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb3();
            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string sql = "insert into type(type_title,type_type) values(@title,@type)";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@title", TextBox1.Text);
            comm.Parameters.Add("@type", 2);
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('添加成功')</script>");
            DropDownList1.Items.Clear();
            show();
        }
    }
}