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
    public partial class guest : System.Web.UI.UserControl
    {
        OleDbConnection conn;
        int id1, id2, id3, gcount = 1;
        string path;
        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager1.RegisterAsyncPostBackControl(Button1);
            id3 = Convert.ToInt32(Request.Params["type"]);
            id1 = Convert.ToInt32(Request.Params["id"]);
            fengye();

        }

        public int getcount()
        {

            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            conn.Open();
            string sql = "select top 1 guest_count from guest where guest_shuyu=" + id1 + " order by guest_id desc";
            OleDbCommand comm = new OleDbCommand(sql, conn);

            OleDbDataReader odr; odr = comm.ExecuteReader();
            if (odr.Read())
            {
                gcount = Convert.ToInt32(odr[0].ToString()) + 1;
                odr.Close();
                conn.Close();
                return gcount;
            }
            else
            {
                odr.Close();
                conn.Close();

                return gcount;
            }



        }

        public int fengye()
        {

            db d1 = new db();
            string path = d1.accessdb();
            conn = new OleDbConnection(path);
            string sql = "select * from guest where guest_shuyu=" + id1;
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader odr = com.ExecuteReader();
            if (odr.Read())
            {
                odr.Close();
                OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                oda.Fill(ds, "title");
                DataList1.DataSource = ds.Tables[0].DefaultView;
                DataList1.DataBind();
                conn.Close();
                return 0;
            }
            else
            {
                Label2.Text = "还没有人进行评论";
                odr.Close();
                conn.Close();
                return 0;
            }

        }
        /// <summary>
        /// 对字符串进行JS,HTML,CSS过滤
        /// </summary>
        /// <param name="html">要过滤的字符串</param>
        /// <returns></returns>
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


        /// <summary>
        /// 过滤p /p代码
        /// </summary>
        /// <param name="html">参数传入</param>
        /// <returns></returns>
        public static string InputStr(string html)
        {
            html = html.Replace(@"\<img[^\>]+\>", "");
            html = html.Replace(@"<p>", "");
            html = html.Replace(@"</p>", "");
            return html;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            int cutt;
            cutt = getcount();
            id2 = Convert.ToInt32(Request.Params["id"]);
            db d1 = new db();
            string path = d1.accessdb();
            OleDbConnection conn = new OleDbConnection(path);
            conn.Open();
            string rg = TextBox3.Text;
            string name = TextBox1.Text;
            string number = TextBox2.Text;
            //进行过滤 最终结果只读取字符串 过滤所以特殊字符
            name = CheckStr(name);
            name = InputStr(name);
            number = CheckStr(number);
            number = InputStr(number);
            rg = CheckStr(rg);
            rg = InputStr(rg);//过滤结束
            string sql = "insert into guest(guest_name,guest_qq,guest_edit,guest_time,guest_shuyu,guest_count) values(@name,@qq,@edit,@time,@shuyu,@cut)";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.Parameters.Add("@name", name);
            comm.Parameters.Add("@qq", number);
            comm.Parameters.Add("@edit", rg);
            comm.Parameters.Add("@time", DateTime.Now.ToString());
            comm.Parameters.Add("@shuyu", id2);
            comm.Parameters.Add("@cut", cutt);
            int count = comm.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('评价成功！')", true);
            Label2.Text = "评价成功-----谢谢您的评价O(∩_∩)O";
            fengye();
        }

    }
}