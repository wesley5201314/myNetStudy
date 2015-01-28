using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///list 的摘要说明
/// </summary>
public class list
{
    //绑定根节点
    public void GetChennel(DropDownList DropDownList1, DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["ch_father"]) == 0)
                {
                    DropDownList1.Items.Add(row["ch_name"].ToString());
                    bindDropChildItem(DropDownList1, dt, Convert.ToInt64(row["id"]), 1);
                }
            }
        }
    }
    //添加文章时的节点绑定
    public void GetContentChennel(DropDownList DropDownList1, DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["ch_father"]) == 0)
                {
                    bool xs=false;
                    if (row["ch_child"].ToString() == "0")
                    {
                        xs = true;
                    }
                    DropDownList1.Items.Add(new ListItem(row["ch_name"].ToString(),row["id"].ToString(),xs));
                    bindChildItem(DropDownList1, dt, Convert.ToInt64(row["id"]), 1);
                }
            }
        }
    }
    public void bindChildItem(DropDownList DropDownList1, DataTable dt, long id, int length)
    {
        DataRow[] rows = dt.Select("ch_father='" + id + "'");//, "id desc");//取出id子节点进行绑定
        for (int i = 0; i < rows.Length; i++)
        {
            bool xs=false;
            if (rows[i]["ch_child"].ToString() == "0")
            {
                xs = true;
            }
            string addname = SpaceLength(length) + "├" + rows[i]["ch_name"].ToString();
            DropDownList1.Items.Add(new ListItem(addname,rows[i]["id"].ToString(),xs));
            bindChildItem(DropDownList1, dt, Convert.ToInt64(rows[i]["id"]), length + 1);//空白数目加1
        }
    }
    /// <summary>
    /// 绑定子节点
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <param name="id"></param>
    /// <param name="length"></param>
    public void bindDropChildItem(DropDownList DropDownList1, DataTable dt, long id, int length)
    {
        DataRow[] rows = dt.Select("ch_father='" + id + "'");//, "id desc");//取出id子节点进行绑定
        for (int i = 0; i < rows.Length; i++)
        {
            string addname = SpaceLength(length) + "├" + rows[i]["ch_name"].ToString();
            DropDownList1.Items.Add(addname);
            bindDropChildItem(DropDownList1, dt, Convert.ToInt64(rows[i]["id"]), length + 1);//空白数目加1
        }
    }
    /// <summary>
    /// 子节点前面的空白数
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public string SpaceLength(int i)
    {
        string space = "";
        for (int j = 0; j < i; j++)
        {
            space += "　";//注意这里的空白是智能abc输入法状态下的v11字符；
        }
        return space;
    }
    public string GetSubString(string str, int len)
    {
        string tmp;
        if (str.Length > len)
        {
            tmp = str.Substring(0, len);
        }
        else
        {
            tmp = str;
        }
        return tmp;
    }
}
