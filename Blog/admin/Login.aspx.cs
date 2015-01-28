using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        TextBox txtImage = Login1.FindControl("ChkCode") as TextBox;
        string imagecode = Session["CheckCode"].ToString().Trim();
        string chkcode = Server.HtmlEncode(txtImage.Text.ToString()).Trim().ToUpper();
        string username = Server.HtmlEncode(Login1.UserName.ToString()).Trim();//得到输入的用户名
        string password = Server.HtmlEncode(Login1.Password.ToString()).Trim();//得到输入的密码
        string md5pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5").ToLower();
        string logSql = "select * from [sw_config] where [name]='" + username + "' and [pass]='" + md5pwd + "'";
        if (chkcode == imagecode)
        {
            DB myDB = new DB();
            if (myDB.Scalar(logSql) > 0)
            {
                Session["swadmin"] = username;
                Session.Timeout = 20;
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;//登录不通过
            }
        }
        else
        {
            e.Authenticated = false;
            Login1.FailureText = "验证码不正确！";
        }
    }
}
