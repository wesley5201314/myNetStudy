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
using System.Text.RegularExpressions;

public partial class admin_addcontent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            DB my = new DB();
            string sql = "select * from sw_chennel";
            OleDbDataAdapter da = my.DataAdapter(sql);
            DataSet ds = my.GetDataSet(da);
            DataTable dt = ds.Tables[0];
            list li = new list();
            li.GetContentChennel(DropDownList1, dt);
           // Button1.Attributes.Add("OnClick", "javascrit:inserthtml();");
        }
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
        string filepatch = patch +"\\"+ filename + "." + filetype;
        if (filetype == "gif" || filetype == "jpg" || filetype == "bmp" || filetype == "png" || filetype == "jpeg")
        {
            FileUpload1.SaveAs(filepatch);
            filepatch = Application["installdir"].ToString() + filepatch.Substring(filepatch.LastIndexOf("upload"));
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
                case("mp3"):
                    inhtml = "<object classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'  id='MediaPlayer' width='450' height='70'><param name='howStatusBar' value='-1'><param name='AutoStart' value='False'><param name='Filename' value='"+filepatch+"'></object>";
                    FCKeditor1.Value += inhtml;
                    //string script = "<script>document.getElementById('ctl00_ContentPlaceHolder1_FCKeditor1').insertHTML('" + inhtml + "')</script>";
                    //string script = "<script>var oEditor = FCKeditorAPI.GetInstance('FCKeditor1')";
                    //script += ";oEditor.InsertHtml('" + filepatch + "')</script>"; 
                   // Literal1.Text = script;
                    break;
                case("wma"):
                    inhtml = "<object classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'  id='MediaPlayer' width='450' height='70'><param name='howStatusBar' value='-1'><param name='AutoStart' value='False'><param name='Filename' value='" + filepatch + "'></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case("rm"):
                    inhtml = "<object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='300'><param name='SRC' value='"+filepatch+"' /><param name='CONTROLS' VALUE='ImageWindow' /><param name='CONSOLE' value='one' /><param name='AUTOSTART' value='true' /><embed src='"+filepatch+"' nojava='true' controls='ImageWindow' console='one' width='400' height='300'></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='StatusBar' /><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='"+filepatch+"' nojava='true' controls='StatusBar' console='one' width='400' height='24' /></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='ControlPanel'/><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='"+filepatch+"' nojava='true' controls='ControlPanel' console='one' width='400' height='24' autostart='true' loop='false' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case("rmvb"):
                    inhtml = "<object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='300'><param name='SRC' value='" + filepatch + "' /><param name='CONTROLS' VALUE='ImageWindow' /><param name='CONSOLE' value='one' /><param name='AUTOSTART' value='true' /><embed src='" + filepatch + "' nojava='true' controls='ImageWindow' console='one' width='400' height='300'></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='StatusBar' /><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='" + filepatch + "' nojava='true' controls='StatusBar' console='one' width='400' height='24' /></object><br/><object classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' width='400' height='32' /><param name='CONTROLS' value='ControlPanel' /><param name='AUTOSTART' value='true' /><param name='CONSOLE' value='one' /><embed src='" + filepatch + "' nojava='true' controls='ControlPanel' console='one' width='400' height='24' autostart='true' loop='false' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case("asf"):
                    inhtml = "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902' type='application/x-oleobject' standby='Loading...' width='400' height='300'><param name='FileName' VALUE='" + filepatch + "' /><param name='ShowStatusBar' value='-1' /><param name='AutoStart' value='true' /><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/' src='" + filepatch + "' autostart='true' width='400' height='300' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case("avi"):
                    inhtml = "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902' type='application/x-oleobject' standby='Loading...' width='400' height='300'><param name='FileName' VALUE='" + filepatch + "' /><param name='ShowStatusBar' value='-1' /><param name='AutoStart' value='true' /><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/' src='" + filepatch + "' autostart='true' width='400' height='300' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case ("wmv"):
                    inhtml = "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902' type='application/x-oleobject' standby='Loading...' width='400' height='300'><param name='FileName' VALUE='" + filepatch + "' /><param name='ShowStatusBar' value='-1' /><param name='AutoStart' value='true' /><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/' src='" + filepatch + "' autostart='true' width='400' height='300' /></object>";
                    FCKeditor1.Value += inhtml;
                    break;
                case("swf"):
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        DB my = new DB();
        string ct_content = HttpUtility.HtmlEncode(FCKeditor1.Value);
        string ct_title = ctitle.Text;
        string sql = "select * from sw_content where ct_title='" + ct_title + "'";
        string ct_time = DateTime.Now.ToString();
        if (my.Scalar(sql) >= 0)
        {
            js.Text = "该文章标题已存在!";
            return;
        }
        string ct_keywords = ckeywords.Text;
        string ct_description = RemoveTag(FCKeditor1.Value);
        if (ct_description.Length > 240)
        {
            ct_description = ct_description.Substring(0,240);
        }
        string ct_pic = "";
        MatchCollection matchs = Regex.Matches(FCKeditor1.Value, @"<img\s[^>]*src=([""']*)(?<src>[^'""]*)\1[^>]*>", RegexOptions.IgnoreCase);
        if (matchs.Count>0)
        {
            Match m = matchs[0];
            ct_pic = m.Groups["src"].Value;
        }
        long ct_cid = Convert.ToInt64(DropDownList1.SelectedItem.Value);
        long ct_hide,ct_order,ct_commend;
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
        sql = "Insert Into sw_content(ct_title,ct_keywords,ct_description,ct_pic,ct_time,ct_order,ct_cid,ct_hide,ct_commend)values('" + ct_title + "','" + ct_keywords + "','" + ct_description + "','" + ct_pic + "','" + ct_time + "','" + ct_order + "','" + ct_cid + "','" + ct_hide + "','" + ct_commend + "')";
        my.ExecuteNonQuery(sql);
        sql = "select * from sw_content where ct_title='" + ct_title + "'";
        OleDbDataReader dr = my.ExecuteReader(sql);
        dr.Read();
        long aid = Convert.ToInt64(dr["id"]);
        my.Clear();
        ct_content = ct_content.Replace(Server.MapPath("."),"~");
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = my.GetCon();
        cmd.CommandText = "insert into sw_content01(aid,cid,content)values(@ct_aid,@ct_cid,@ct_content)";
        cmd.Parameters.AddWithValue("@ct_aid", aid);
        cmd.Parameters.AddWithValue("@ct_cid", ct_cid);
        cmd.Parameters.AddWithValue("@ct_content", ct_content);
        cmd.ExecuteNonQuery();
        if (matchs.Count>0)
         {
             foreach (Match m in matchs)
             {
                 string url=m.Groups["src"].Value.ToLower();
                 if (url.IndexOf("http") < 0)
                 {
                     string imgtype = url.Substring(url.LastIndexOf(".") + 1).ToLower();
                     sql="insert into sw_upload(aid,cid,up_dir,up_ext)values('"+aid+"','"+ct_cid+"','"+url+"','"+imgtype+"')";
                     my.ExecuteNonQuery(sql);
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
    //去除HTML标签
    public string RemoveTag(string str)
    {
        string clearText = Regex.Replace(str, @"<(.|\n)+?>", "", RegexOptions.Multiline);
        return clearText.Replace('\'', '‘').Replace("&nbsp;", "").Replace("\r\n", "");
    }
}
