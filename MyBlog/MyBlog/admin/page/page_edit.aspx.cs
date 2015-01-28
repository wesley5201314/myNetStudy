using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace MyBlog.admin.page
{
    public partial class page_edit : System.Web.UI.Page
    {
        OleDbConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "adminlogin")
            {
                Response.Redirect("../login.aspx");
            }
            if (!IsPostBack)
            {
                show();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb3();
            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string sql = "update page set page_name=@name,page_edit=@edit where page_id=3";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@name", TextBox1.Text);
            comm.Parameters.Add("@edit", FreeTextBox1.Text);
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('添加成功')</script>");
            show();
        }

        public void show()
        {
            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select * from page where page_id=3";
            OleDbCommand ocm = new OleDbCommand(sql, conn);
            OleDbDataReader odr = ocm.ExecuteReader();
            while (odr.Read())
            {
                TextBox1.Text = string.Format("{0}", odr[1]);
                FreeTextBox1.Text = string.Format("{0}", odr[2]);

            }
            odr.Close();
            conn.Close();
        }
    }
}