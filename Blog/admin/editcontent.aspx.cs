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
using System.Text.RegularExpressions;
using System.IO;

public partial class admin_editcontent : System.Web.UI.Page
{
    DB my = new DB();
    string sql, ct_title, ct_keywords, ct_description, ct_pic,content;
    long ct_order, ct_cid, ct_hide, ct_commend,id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request.QueryString["id"] != null)
        {
            DropDownList1.Items.Clear();
            sql = "select * from sw_chennel";
            OleDbDataAdapter da = my.DataAdapter(sql);
            DataSet ds = my.GetDataSet(da);
            DataTable dt = ds.Tables[0];
            list li = new list();
            li.GetContentChennel(DropDownList1, dt);
            id = Convert.ToInt64(Request.QueryString["id"]);
            sql = "select * from sw_content where id=" + id;
            OleDbDataReader dr = my.ExecuteReader(sql);
            dr.Read();
            ct_title = dr["ct_title"].ToString();
            ct_keywords = dr["ct_keywords"].ToString();
            ct_description = dr["ct_description"].ToString();
            ct_pic = dr["ct_pic"].ToString();
            ct_order = Convert.ToInt64(dr["ct_order"]);
            ct_cid = Convert.ToInt64(dr["ct_cid"]);
            ct_hide = Convert.ToInt64(dr["ct_hide"]);
            ct_commend = Convert.ToInt64(dr["ct_commend"]);
            my.Clear();
            sql = "select * from sw_content01 where aid=" + id;
            dr = my.ExecuteReader(sql);
            dr.Read();
            content = dr["content"].ToString();
            my.Clear();
            DropDownList1.SelectedValue = ct_cid.ToString();
            ctitle.Text = ct_title;
            if (ct_commend == 1)
            {
                ccommend.Checked = true;
            }
            if (ct_hide == 1)
            {
                chide.Checked = true;
            }
            ckeywords.Text = ct_keywords;
            corder.Text = ct_order.ToString();
            FCKeditor1.Value =Server.HtmlDecode(content);
        }
        if (IsPostBack)
        {
            id = Convert.ToInt64(Request.QueryString["id"]);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        content = HttpUtility.HtmlEncode(FCKeditor1.Value);
        ct_title = ctitle.Text;
        ct_keywords = ckeywords.Text;
        ct_description = RemoveTag(FCKeditor1.Value);
        MatchCollection matchs = Regex.Matches(FCKeditor1.Value, @"<img\s[^>]*src=([""']*)(?<src>[^'""]*)\1[^>]*>", RegexOptions.IgnoreCase);
        if (matchs.Count > 0)
        {
            Match m = matchs[0];
            ct_pic = m.Groups["src"].Value;
        }
        ct_cid = Convert.ToInt64(DropDownList1.SelectedItem.Value);
        ct_order = Convert.ToInt64(corder.Text.Trim());
        ct_hide = 0; ct_commend = 0;
        if (chide.Checked)
        {
            ct_hide = 1;
        }
        if (ccommend.Checked)
        {
            ct_commend = 1;
        }
        sql = "update sw_content set ct_title='" + ct_title + "',ct_keywords='" + ct_keywords + "',ct_description='" + ct_description + "',ct_pic='" + ct_pic + "',ct_order='" + ct_order + "',ct_cid='" + ct_cid + "',ct_hide='" + ct_hide + "',ct_commend='" + ct_commend + "' where id=" + id;
        my.ExecuteNonQuery(sql);
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = my.GetCon();
        cmd.CommandText = "update sw_content01 set cid=@ct_cid,content=@content where aid=@id";
        cmd.Parameters.AddWithValue("@ct_cid", ct_cid);
        cmd.Parameters.AddWithValue("@content",content);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        if (matchs.Count > 0)
        {
            foreach (Match m in matchs)
            {
                string url = m.Groups["src"].Value.ToLower();
                if (url.IndexOf("http") < 0)
                {
                    string imgtype = url.Substring(url.LastIndexOf(".") + 1).ToLower();
                    sql = "select * from sw_upload where up_dir='"+url+"'";
                    if (my.Scalar(sql) <= 0)
                    {
                        sql = "insert into sw_upload(aid,cid,up_dir,up_ext)values('" + id + "','" + ct_cid + "','" + url + "','" + imgtype + "')";
                        my.ExecuteNonQuery(sql);
                    }
                }
            }
        }
        Response.Redirect("content.aspx");
    }
    protected void ctitle_TextChanged(object sender, EventArgs e)
    {
        string ct_title = ctitle.Text;
        string sql = "select * from sw_content where ct_title='" + ct_title + "'";
        DB my = new DB();
        if (my.Scalar(sql) >= 0)
        {
            js.Text = "该文章标题已存在!";
        }
    }
    public string RemoveTag(string str)
    {
        string clearText = Regex.Replace(str, @"<(.|\n)+?>", "", RegexOptions.Multiline);
        return clearText.Replace('\'', '‘').Replace("&nbsp", "").Replace("\r\n", "");
    }
    protected void UPfile_Click(object sender, EventArgs e)
    {
        string patch1 = Server.MapPath(@"..\upload\") + DateTime.Now.ToString("yyyyMM");
        string patch = patch1 + "\\" + DateTime.Now.ToString("dd");
        if (!Directory.Exists(patch1))
        {
            Directory.CreateDirectory(patch1);
        }
        if (!Directory.Exists(patch))
        {
            Directory.CreateDirectory(patch);
        }
        string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
        string name = FileUpload1.FileName;
        int big = FileUpload1.PostedFile.ContentLength / 1024;//获得文件大小
        string filetype = name.Substring(name.LastIndexOf(".") + 1).ToLower();　//获取文件的后缀名
        string filepatch = patch + "\\" + filename + "." + filetype;
        if (filetype == "gif" || filetype == "jpg" || filetype == "bmp" || filetype == "png" || filetype == "jpeg")
        {
            FileUpload1.SaveAs(filepatch);
            filepatch = Application["installdir"].ToString()+filepatch.Substring(filepatch.LastIndexOf("upload"));
            FCKeditor1.Value += "<img src='" + filepatch + "'></img>";
        }
        else if (filetype == "mp3" || filetype == "wma" || filetype == "rm" || filetype == "rmvb" || filetype == "asf"
            || filetype == "avi" || filetype == "wmv" || filetype == "swf")
        {
            FileUpload1.SaveAs(filepatch);
            filepatch = Application["installdir"].ToString() + filepatch.Substring(filepatch.LastIndexOf("upload"));
            string inhtml;
            switch (filetype)
            {
                case ("mp3"):
                    inhtml = "<object classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'  id='MediaPlayer' width='450' height='70'><param name='howStatusBar' value='-1'><param name='AutoStart' value='False'><param name='Filename' value='" + filepatch + "'></object>";
                    FCKeditor1.Value += inhtml;
                    //string script = "<script>document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').insertHTML('" + inhtml + "')</script>";
                    //string script = "<script>var oEditor = FCKeditorAPI.GetInstance('FCKeditor1')";
                    //script += ";oEditor.InsertHtml('" + filepatch + "')</script>"; 
                    // Literal1.Text = script;
                    break;
                case ("wma"):
                    inhtml = "<object classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'  id='MediaPlayer' width='450' height='70'><param name='howStatusBar' value='-1'><param name='AutoStart' value='False'><param name='Filename' value='" + filepatch + "'></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("rm"):
                    inhtml = "<object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='300'><param name='SRC' value='" + filepatch + "' /><param name='CONTROLS' VALUE='ImageWindow' /><param name='CONSOLE' value='one' /><param name='AUTOSTART' value='true' /><embed src='" + filepatch + "' nojava='true' controls='ImageWindow' console='one' width='400' height='300'></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='StatusBar' /><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='" + filepatch + "' nojava='true' controls='StatusBar' console='one' width='400' height='24' /></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='ControlPanel'/><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='" + filepatch + "' nojava='true' controls='ControlPanel' console='one' width='400' height='24' autostart='true' loop='false' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("rmvb"):
                    inhtml = "<object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='300'><param name='SRC' value='" + filepatch + "' /><param name='CONTROLS' VALUE='ImageWindow' /><param name='CONSOLE' value='one' /><param name='AUTOSTART' value='true' /><embed src='" + filepatch + "' nojava='true' controls='ImageWindow' console='one' width='400' height='300'></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='StatusBar' /><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='" + filepatch + "' nojava='true' controls='StatusBar' console='one' width='400' height='24' /></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='ControlPanel' /><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='" + filepatch + "' nojava='true' controls='ControlPanel' console='one' width='400' height='24' autostart='true' loop='false' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("asf"):
                    inhtml = "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902' type='application/x-oleobject' standby='Loading...' width='400' height='300'><param name='FileName' VALUE='" + filepatch + "' /><param name='ShowStatusBar' value='-1' /><param name='AutoStart' value='true' /><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/' src='" + filepatch + "' autostart='true' width='400' height='300' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("avi"):
                    inhtml = "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902' type='application/x-oleobject' standby='Loading...' width='400' height='300'><param name='FileName' VALUE='" + filepatch + "' /><param name='ShowStatusBar' value='-1' /><param name='AutoStart' value='true' /><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/' src='" + filepatch + "' autostart='true' width='400' height='300' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("wmv"):
                    inhtml = "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902' type='application/x-oleobject' standby='Loading...' width='400' height='300'><param name='FileName' VALUE='" + filepatch + "' /><param name='ShowStatusBar' value='-1' /><param name='AutoStart' value='true' /><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/' src='" + filepatch + "' autostart='true' width='400' height='300' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("swf"):
                    inhtml = "<embed src='" + filepatch + "' width='400' height='300' scale='exactfit' play='true' loop='true' menu='true' wmode='Window' quality='1' type='application/x-shockwave-flash'></embed>";
                    FCKeditor1.Value += inhtml;
                    break;
            }
        }
        else
        {
            js.Text = "文件类型不正确";
        }
    }
}
