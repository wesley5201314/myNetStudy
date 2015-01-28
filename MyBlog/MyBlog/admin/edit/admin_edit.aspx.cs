using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace MyBlog.admin.edit
{
    public partial class admin_edit : System.Web.UI.Page
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

                this.Label2.Text = "1";
                this.fenye();
            }
        }
        public void fenye()
        {

            db d1 = new db();
            string path = d1.accessdb3();
            conn = new OleDbConnection(path);
            string sql = "select * from edit order by edit_id desc";
            OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds, "title");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables[0].DefaultView;
            pds.CurrentPageIndex = Convert.ToInt32(Label2.Text) - 1;
            pds.AllowPaging = true;
            pds.PageSize = 10;//设置每个页面显示的数量
            Repeater1.DataSource = pds;
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
            Repeater1.DataBind();

        }
        protected void lbtnpritPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = Convert.ToString(Convert.ToInt32(Label2.Text) - 1);
            this.fenye();
        }
        protected void lbtnFirstPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = "1";
            this.fenye();
        }
        protected void lbtnDownPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = this.Label1.Text;
            this.fenye();
        }

        protected void lbtnNextPage_Click(object sender, EventArgs e)
        {
            this.Label2.Text = Convert.ToString(Convert.ToInt32(Label2.Text) + 1);
            this.fenye();
        } 
    }
}