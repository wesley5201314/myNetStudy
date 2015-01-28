using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Drawing;

namespace MyBlog.admin.photo
{
    public partial class photo_add : System.Web.UI.Page
    {
        public System.Drawing.Image image;
        string sm, bm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "adminlogin")
            {
                Response.Redirect("../login.aspx");
            }
            if (!Page.IsPostBack)
            {
                db d1 = new db();
                string path = d1.accessdb3();
                OleDbConnection conn = new OleDbConnection(path);
                conn.Open();
                string sql = "select * from type where type_type=2";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataReader odr = comm.ExecuteReader();
                while (odr.Read())
                {
                    DropDownList1.Items.Add(odr[1].ToString());
                }
                odr.Close();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                updata();
                int tp = 0; ;
                db d1 = new db();
                string path = d1.accessdb3();
                OleDbConnection conn = new OleDbConnection(path);
                conn.Open();
                string sql2 = "select type_id from type where type_title=@t_title";
                OleDbCommand com = new OleDbCommand(sql2, conn);
                com.Parameters.Add("@t_title", DropDownList1.SelectedItem.Text);
                OleDbDataReader odr = com.ExecuteReader();
                while (odr.Read())
                {
                    tp = Convert.ToInt32(odr[0].ToString());
                }
                odr.Close();
                string sql = "insert into photo(photo_name,photo_join_time,photo_bigpath,photo_type,photo_edit,photo_smallpath) values(@name,time,@bigpath,@type,@edit,@smallpath)";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                comm.Parameters.Add("@name", TextBox1.Text);
                comm.Parameters.Add("@time", DateTime.Now.ToString());
                comm.Parameters.Add("@bigpath", bm);
                comm.Parameters.Add("@type", tp);
                comm.Parameters.Add("@edit", TextBox3.Text);
                comm.Parameters.Add("@smallpath", sm);
                comm.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('添加成功')</script>");
            }
        }

        public void updata()
        {
            string strFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            string name = FileUpload1.FileName;
            string type = this.FileUpload1.PostedFile.ContentType;　//获取文件类型；
            string type2 = name.Substring(name.LastIndexOf(".") + 1);　//获取文件的后缀名
            string FilePath = Server.MapPath(@"..\..\updata") + "\\" + strFileName + "." + type2;
            string smallFilePath = Server.MapPath(@"..\..\updata\small\") + "\\" + strFileName + "." + type2;
            bm = strFileName + "." + type2;
            sm = strFileName + "." + type2;
            if (type2 == "jpg" || type2 == "gif" || type2 == "bmp" || type2 == "png")
            {

                FileUpload1.SaveAs(FilePath);
                MakeThumbnail(FilePath, smallFilePath, 125, 125);

            }
            else
            {
                Response.Write("<script>alert('上传的类型不对')</script>");
            }
        }
        /// <summary> 
        /// 生成缩略图 
        /// </summary> 
        /// <param name="originalImagePath">源图路径（物理路径）</param> 
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param>   
        public void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = 0;
            int toheight = 0;
            if (originalImage.Width > width && originalImage.Height < height)
            {
                towidth = width;
                toheight = originalImage.Height;
            }

            if (originalImage.Width < width && originalImage.Height > height)
            {
                towidth = originalImage.Width;
                toheight = height;
            }
            if (originalImage.Width > width && originalImage.Height > height)
            {
                towidth = width;
                toheight = height;
            }
            if (originalImage.Width < width && originalImage.Height < height)
            {
                towidth = originalImage.Width;
                toheight = originalImage.Height;
            }
            int x = 0;//左上角的x坐标 
            int y = 0;//左上角的y坐标 


            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, x, y, towidth, toheight);

            try
            {
                //以jpg格式保存缩略图 
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }
}