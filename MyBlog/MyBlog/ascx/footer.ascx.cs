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
    public partial class footer : System.Web.UI.UserControl
    {
        public string footer1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                db d1 = new db();
                string path = d1.accessdb();

                OleDbConnection conn = new OleDbConnection(path);
                conn.Open();
                string sql = "select * from config";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataReader odr = comm.ExecuteReader();
                while (odr.Read())
                {
                    footer1 = odr[1].ToString();
                }
                odr.Close();
                conn.Close();
            }
        }
    }
}