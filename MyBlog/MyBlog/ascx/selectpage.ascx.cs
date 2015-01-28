using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

namespace MyBlog.ascx
{
    public partial class selectpage : System.Web.UI.UserControl
    {
        int pageid, type;
        OleDbConnection conn;
        OleDbCommand comm;
        OleDbDataReader odr;
        protected void Page_Load(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            conn.Open();
            pageid = Convert.ToInt32(Request.Params["id"]);
            type = Convert.ToInt32(Request.Params["type"]);
            uppage(pageid, type);
            downpage(pageid, type);

            conn.Close();

        }

        private void uppage(int id, int type)
        {
            string sql = "select top 1 edit_id,edit_title,edit_type from edit where edit_id<" + id + " and edit_type=" + type + " order by edit_id desc";
            int pd = 0, tp = 0;
            string pds = "";
            comm = new OleDbCommand(sql, conn);
            odr = comm.ExecuteReader();
            if (odr.Read())
            {
                pd = Convert.ToInt32(odr[0]);

                pds = string.Format("{0}", odr[1]);
                tp = Convert.ToInt32(odr[2]);

                HyperLink1.NavigateUrl = "../edit_show.aspx?id=" + pd + "&type=" + tp;
                Label3.Text = pds;

            }
            else
            {
                Label3.Text = "没有了";

            }
            odr.Close();



        }

        private void downpage(int id, int type)
        {
            string sql = "select top 1 edit_id,edit_title,edit_type from edit where edit_id>" + id + " and edit_type=" + type;
            int pd = 0, tp = 0; ;
            string pds = "";
            comm = new OleDbCommand(sql, conn);
            odr = comm.ExecuteReader();
            if (odr.Read())
            {
                pd = Convert.ToInt32(odr[0]);
                pds = string.Format("{0}", odr[1]);
                tp = Convert.ToInt32(odr[2]);
                HyperLink2.NavigateUrl = "../edit_show.aspx?id=" + pd + "&type=" + tp;
                Label4.Text = pds;
            }


            else
            {
                Label4.Text = "没有了";

            }
            odr.Close();

        }
    }
}