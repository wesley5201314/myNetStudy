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
    public partial class time : System.Web.UI.UserControl
    {
        OleDbConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                db d1 = new db();
                string path = d1.accessdb();
                conn = new OleDbConnection(path);
                wenzhan();
                liuyan();
                photo();
                conn.Close();
            }
        }

        public void wenzhan()
        {

            conn.Open();
            string sql = "select count(*) from edit";
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                Label1.Text = "文章总数:" + odr[0].ToString();
            }

            odr.Close();

        }

        public void liuyan()
        {

            string sql = "select count(*) from post";
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                Label2.Text = "留言总数:" + odr[0].ToString();
            }

            odr.Close();

        }

        public void photo()
        {

            string sql = "select count(*) from photo";
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                Label3.Text = "相片总数:" + odr[0].ToString();
            }

            odr.Close();

        }
    }
}