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
    public partial class newshow : System.Web.UI.UserControl
    {
        OleDbConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fengye();
            }
        }

        private void fengye()
        {
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select top 8 * from edit order by edit_id desc";
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            if (odr.Read())
            {
                odr.Close();

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
                conn.Close();
            }
            else
            {
                Label1.Text = "您还没有添加任何文章";
                odr.Close();
                conn.Close();
            }

        }
        public string GetSubString(string strTemp, int intLen, int IntClen)//控制显示文字的字数
        {
            int intCLenCount = System.Text.Encoding.Default.GetBytes(strTemp).Length;

            string strTempA = "";

            if (intCLenCount > intLen)
            {
                strTempA = strTemp.Substring(0, IntClen) + "......";
            }
            else
            {
                strTempA = strTemp.ToString();
            }

            return strTempA;
        }   
    }
}