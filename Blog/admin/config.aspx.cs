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
using System.Data.OleDb;
using System.IO;

public partial class admin_config : System.Web.UI.Page
{
    DB my = new DB();
    string sql, title, name, pass, headpatch, keywords, description, jianjie,installdir;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "select * from sw_config";
            OleDbDataReader dr = my.ExecuteReader(sql);
            dr.Read();
            title = dr["title"].ToString();
            name = dr["name"].ToString();
            pass = dr["pass"].ToString();
            headpatch = dr["head"].ToString();
            keywords = dr["keywords"].ToString();
            description = dr["description"].ToString();
            jianjie = dr["jianjie"].ToString();
            installdir = dr["installdir"].ToString();
            my.Clear();
            cinstalldir.Text = installdir;
            ctitle.Text = title;
            cname.Text = name;
            ckeywords.Text = keywords;
            cdescription.Text = description;
            Image1.ImageUrl = headpatch;
            cjianjie.Text = jianjie;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        title = Server.HtmlEncode(ctitle.Text.ToString());
        name = Server.HtmlEncode(cname.Text.ToString()).Trim();
        keywords = Server.HtmlEncode(ckeywords.Text.ToString());
        description = Server.HtmlEncode(cdescription.Text.ToString());
        jianjie = Server.HtmlEncode(cjianjie.Text.ToString());
        installdir = cinstalldir.Text.ToString();
        if (cpass.Text.ToString() != "")
        {
            pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(cpass.Text.ToString(), "md5").ToLower();
            sql = "update sw_config set name='" + name + "',pass='" + pass + "',title='" + title + "',keywords='" + keywords + "',description='" + description + "',jianjie='" + jianjie + "',installdir='" + installdir + "'";
        }
        else
        {
            sql = "update sw_config set name='" + name + "',title='" + title + "',keywords='" + keywords + "',description='" + description + "',jianjie='" + jianjie + "',installdir='" + installdir + "'";
        }
        my.ExecuteNonQuery(sql);
        Application.Lock();
        Application["title"] = title;
        Application["keywords"] = keywords;
        Application["description"] = description;
        Application["jianjie"] = jianjie;
        Application["installdir"] = installdir;
        Application.UnLock();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改成功');window.location.href='Default.aspx';</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string patch = Server.MapPath(@"..\images\");
        string name = FileUpload1.FileName;
        string filetype = name.Substring(name.LastIndexOf(".") + 1).ToLower();　//获取文件的后缀名
        string filepatch = patch  + "head" + "." + filetype;
        if (filetype == "gif" || filetype == "jpg" || filetype == "bmp" || filetype == "png" || filetype == "jpeg")
        {
            FileUpload1.SaveAs(filepatch);
            filepatch = Application["installdir"].ToString()+ filepatch.Substring(filepatch.LastIndexOf("images"));
            Image1.ImageUrl = filepatch;
            sql = "update sw_config set head='" + filepatch + "'";
            my.ExecuteNonQuery(sql);
            Application.Lock();
            Application["head"] = filepatch;
            Application.UnLock();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('文件类型不正确');</script>");
        }
    }
}