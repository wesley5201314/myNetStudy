using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace MyBlog.admin.edit
{
    public partial class admin_edit_edit : System.Web.UI.Page
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
                db d1 = new db();
                string path = d1.accessdb3();

                conn = new OleDbConnection(path);
                conn.Open();
                string sql = "select * from type where type_type=1";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataReader odr = comm.ExecuteReader();
                while (odr.Read())
                {
                    DropDownList1.Items.Add(odr[1].ToString());
                }
                odr.Close();
                conn.Close();
                dataview(id);
            }
        }

        public void dataview(int id)
        {
            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select * from edit where edit_id=" + id;
            OleDbCommand ocm = new OleDbCommand(sql, conn);
            OleDbDataReader odr = ocm.ExecuteReader();
            while (odr.Read())
            {
                TextBox1.Text = string.Format("{0}", odr[1]);
                FreeTextBox1.Text = string.Format("{0}", odr[3]);

            }
            odr.Close();
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tp = 0; ;
            db d1 = new db();
            string path = d1.accessdb3();
            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string sql2 = "select type_id from type where type_title=@t_title";
            OleDbCommand com = new OleDbCommand(sql2, conn);
            com.Parameters.Add("@t_title", DropDownList1.SelectedItem.Text);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                tp = Convert.ToInt32(odr[0].ToString());
            }
            odr.Close();
            string sql = "update edit set edit_title=@title,edit_edit=@edit,edit_type=@type where edit_id=" + id;
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@title", TextBox1.Text);
            comm.Parameters.Add("@edit", FreeTextBox1.Text);
            comm.Parameters.Add("@type", tp);
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('修改成功')</script>");
        }
    }
}