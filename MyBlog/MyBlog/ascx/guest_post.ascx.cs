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
    public partial class guest_post : System.Web.UI.UserControl
    {
        OleDbConnection conn;
        int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                this.Label2.Text = "1";
                this.fenye();

            }
        }
        public int getcount()
        {

            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select top 1 post_count from post order by post_id desc";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader odr; odr = comm.ExecuteReader();
            if (odr.Read())
            {
                count = Convert.ToInt32(odr[0].ToString()) + 1;
                odr.Close();
                conn.Close();
                return count;
            }
            else
            {
                odr.Close();
                conn.Close();

                return count;
            }



        }
        private void fenye()
        {
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select * from post order by post_id desc";
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
                pds.PageSize = 10;//设置每个页面显示的数量
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
                Label4.Text = "还有没有给你留言！";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);

            count = getcount();
            conn.Open();
            string name = TextBox1.Text;
            string qq = TextBox2.Text;
            string from = TextBox3.Text;
            string email = TextBox4.Text;
            string edit = TextBox5.Text;
            name = CheckStr(name);
            qq = CheckStr(qq);
            from = CheckStr(from);
            email = CheckStr(email);
            edit = CheckStr(edit);
            string sql = "insert into post(post_name,post_qq,post_edit,post_mail,post_from,post_count,post_time) values(@name,@qq,@edit,@email,@from,@count,@time)";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@name", name);
            comm.Parameters.Add("@qq", qq);
            comm.Parameters.Add("@edit", edit);
            comm.Parameters.Add("@email", email);
            comm.Parameters.Add("@from", from);
            comm.Parameters.Add("@count", count);
            comm.Parameters.Add("@time", DateTime.Now.ToString());
            comm.ExecuteNonQuery();
            conn.Close();
            fenye();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('留言成功！')", true);


        }

        public static string CheckStr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            html = regex6.Replace(html, ""); //过滤frameset
            html = regex7.Replace(html, ""); //过滤frameset
            html = regex8.Replace(html, ""); //过滤frameset
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }
    }
}