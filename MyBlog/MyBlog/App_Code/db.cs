using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// db 的摘要说明
/// </summary>
namespace MyBlog
{
    public class db : System.Web.UI.Page
    {
        public db()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public string accessdb()
        {
            string path = "provider=microsoft.jet.oledb.4.0;data source=" + Server.MapPath(@"App_Data\db.mdb");
            return path;
        }
        public string accessdb2()
        {
            string path = "provider=microsoft.jet.oledb.4.0;data source=" + Server.MapPath(@"..\App_Data\db.mdb");
            return path;
        }
        public string accessdb3()
        {
            string path = "provider=microsoft.jet.oledb.4.0;data source=" + Server.MapPath(@"..\..\App_Data\db.mdb");
            return path;
        }
    }
}

