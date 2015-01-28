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
    public partial class photo_type_delete : System.Web.UI.Page
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
            string sql = "delete from type where type_id=" + id;
            OleDbCommand ocm = new OleDbCommand(sql, conn);
            ocm.ExecuteNonQuery();
            sql = "delete from photo where photo_type=" + id;
            ocm = new OleDbCommand(sql, conn);
            ocm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("photo_edit_type.aspx");
            //这边缺少把硬盘上的图片也一并删除，解决方法新建一个专门删除图片的类难后用FOR循环调用删除。待解决。

        }
    }
}