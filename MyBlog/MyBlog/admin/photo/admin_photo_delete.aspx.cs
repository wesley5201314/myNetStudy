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
    public partial class admin_photo_delete : System.Web.UI.Page
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
            string sp = Server.MapPath("../../" + "/updata/small/" + Request.Params["name"]);
            string bp = Server.MapPath("../../" + "/updata/" + Request.Params["name"]);
            FilePicDelete(sp, bp);
            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "delete from photo where photo_id=" + id;
            OleDbCommand ocm = new OleDbCommand(sql, conn);
            ocm.ExecuteNonQuery();
            sql = "delete from photo where photo_id=" + id;
            ocm = new OleDbCommand(sql, conn);
            ocm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("admin_photo.aspx");

        }

        public void FilePicDelete(string smallpath, string bigpath)
        {

            System.IO.FileInfo smallfile = new System.IO.FileInfo(smallpath);
            System.IO.FileInfo bigfile = new System.IO.FileInfo(bigpath);
            if (smallfile.Exists)
            {
                smallfile.Delete();
            }
            if (bigfile.Exists)
            {
                bigfile.Delete();
            }


        }
    }
}