using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Data.OleDb;

namespace MyBlog
{
    public class Global : System.Web.HttpApplication
    {
        OleDbConnection con;

        protected void Application_Start(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb();
            con = new OleDbConnection(path);
            Application["countall"] = 0;
            Application["online"] = 0;
            int count = 0;
            string sql = "select * from [count]";
            con.Open();
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader odr = com.ExecuteReader();
            while (odr.Read())
            {
                count = Convert.ToInt32(odr[1].ToString());
            }
            Application["countall"] = count;
            odr.Close();
            con.Close();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 1;
            Application.Lock();
            Application["online"] = Convert.ToInt32(Application["online"]) + 1;
            Application["countall"] = Convert.ToInt32(Application["countall"]) + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //遍历Post参数，隐藏域除外 
            foreach (string i in this.Request.Form)
            {
                if (i == "__VIEWSTATE") continue;
                this.goErr(this.Request.Form[i].ToString());
            }
            //遍历Get参数。 
            foreach (string i in this.Request.QueryString)
            {
                this.goErr(this.Request.QueryString[i].ToString());

            }
        }

        /// <summary> 
        ///SQL注入过滤 
        /// </summary> 
        /// <param name="InText">要过滤的字符串 </param> 
        /// <returns>如果参数存在不安全字符，则返回true </returns> 
        public bool SqlFilter(string InText)
        {
            string word = "and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join|cmd";
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// 校验参数是否存在SQL字符 
        /// </summary> 
        /// <param name="tm"> </param> 
        private void goErr(string tm)
        {
            if (SqlFilter(tm))
            {
                Response.Write(" <script>window.alert('您输入的数据存在有误参数!');" + " </" + "script>");
            }
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["online"] = System.Convert.ToInt32(Application["online"]) - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            db d1 = new db();
            string path = d1.accessdb();
            con = new OleDbConnection(path);
            con.Open();
            string sql = "update [count] set count_all=" + Convert.ToInt32(Application["countall"]);
            OleDbCommand com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}