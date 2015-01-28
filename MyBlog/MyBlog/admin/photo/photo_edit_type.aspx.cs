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
    public partial class photo_edit_type : System.Web.UI.Page
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


                this.fenye();
            }
        }

        public void fenye()
        {

            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            string sql = "select * from type where type_type=2 order by type_id desc";
            OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds, "title");
            PagedDataSource pds = new PagedDataSource();
            Repeater1.DataSource = ds.Tables[0].DefaultView;
            Repeater1.DataBind();

        }
    }
}