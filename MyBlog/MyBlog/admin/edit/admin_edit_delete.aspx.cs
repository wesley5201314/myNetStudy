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
    public partial class admin_edit_delete : System.Web.UI.Page
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
                int id = Convert.ToInt32(Request.Params["id"]);

                dataview(id);

            }
        }

        public void dataview(int id)
        {
            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "delete from edit where edit_id=" + id;
            OleDbCommand ocm = new OleDbCommand(sql, conn);
            ocm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("admin_edit.aspx");

        }
    }
}