using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace MyBlog
{
    public partial class guest : System.Web.UI.Page
    {
        OleDbConnection conn;
        public string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                rizhi();
                photo_();
                config();
            }
        }

        public void rizhi()
        {
            string url = "";
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select top 1 type_id from type where type_type=1";
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                url = "edit.aspx?type=" + odr[0];
            }
            HyperLink1.NavigateUrl = url;
            odr.Close();
            conn.Close();
        }

        public void photo_()
        {
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select top 1 type_id from type where type_type=2";
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                HyperLink2.NavigateUrl = "photo.aspx?type=" + odr[0];
            }

            odr.Close();
            conn.Close();
        }

        public void config()
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
                title = odr[0].ToString();
            }
            odr.Close();
            conn.Close();
        }
    }
}