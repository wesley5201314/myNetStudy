using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace MyBlog.ascx
{
    public partial class edit_wz : System.Web.UI.UserControl
    {
        OleDbConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.Params["id"]);

                dataview(id);

            }
        }
        public void dataview(int id)
        {
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select * from edit where edit_id=" + id;
            OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds, "title");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables[0].DefaultView;
            pds.CurrentPageIndex = 0;
            pds.AllowPaging = true;
            pds.PageSize = 8;//设置每个页面显示的数量
            DataList1.DataSource = pds;
            DataList1.DataBind();
        }
    }
}