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
    public partial class photo_show : System.Web.UI.UserControl
    {
        OleDbConnection conn;
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["type"]);
            if (!IsPostBack)
            {

                if (id != 0)
                {
                    this.Label2.Text = "1";
                    this.fenye(id);
                }
                else
                {
                    id = 3;
                    this.Label2.Text = "1";
                    this.fenye(id);

                }
            }

        }

        private void fenye(int id)
        {
            id = Convert.ToInt32(id);
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select * from photo where photo_type=" + id + " order by photo_id desc";
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            if (odr.Read())
            {
                odr.Close();
                conn.Close();
                OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                oda.Fill(ds, "title");
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = ds.Tables[0].DefaultView;
                pds.CurrentPageIndex = Convert.ToInt32(Label2.Text) - 1;
                pds.AllowPaging = true;
                pds.PageSize = 12;//设置每个页面显示的数量
                DataList1.DataSource = pds;
                Label1.Text = pds.PageCount.ToString();//获取所有页面
                Label2.Text = (pds.CurrentPageIndex + 1).ToString(); //获取当前页面
                this.lbtnpritPage.Enabled = true;
                this.lbtnFirstPage.Enabled = true;
                this.lbtnNextPage.Enabled = true;
                this.lbtnDownPage.Enabled = true;

                if (pds.CurrentPageIndex < 1)
                {
                    this.lbtnpritPage.Enabled = false;
                    this.lbtnFirstPage.Enabled = false;
                }
                if (pds.CurrentPageIndex == pds.PageCount - 1)
                {
                    this.lbtnNextPage.Enabled = false;
                    this.lbtnDownPage.Enabled = false;
                }
                DataList1.DataBind();
                conn.Close();
            }
            else
            {
                odr.Close();
                conn.Close();
                Label4.Text = "您还没有为该类添加任何相片";
                this.lbtnpritPage.Enabled = false;
                this.lbtnFirstPage.Enabled = false;
                this.lbtnNextPage.Enabled = false;
                this.lbtnDownPage.Enabled = false;
                this.Label1.Text = "0";
            }
        }
        protected void lbtnpritPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = Convert.ToString(Convert.ToInt32(Label2.Text) - 1);
            this.fenye(id);
        }
        protected void lbtnFirstPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = "1";
            this.fenye(id);
        }
        protected void lbtnDownPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = this.Label1.Text;
            this.fenye(id);
        }

        protected void lbtnNextPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = Convert.ToString(Convert.ToInt32(Label2.Text) + 1);
            this.fenye(id);
        }
    }
}