<%@ Application Language="C#" %>
<%@   Import   Namespace="System.Data.OleDb" %>   
<%@   Import   Namespace="System.IO" %>   
<%@ Import Namespace="System.Data" %>
<script runat="server">
    DB my = new DB();
    string sql;
    string countpatch;
    void Application_Start(object sender, EventArgs e) 
    {
        countpatch = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        countpatch = countpatch + "\\count.txt";
        sql = "select * from sw_config";
        OleDbDataReader dr = my.ExecuteReader(sql);
        StreamReader sr = new StreamReader(countpatch);
        long count = Convert.ToInt64(sr.ReadLine());
        sr.Close();
        dr.Read();
        Application["online"] = (long)0;
        Application["count"] = count;
        Application["title"] = dr["title"].ToString();
        Application["keywords"] = dr["keywords"].ToString();
        Application["description"] = dr["description"].ToString();
        Application["head"] = dr["head"].ToString();
        Application["jianjie"] = dr["jianjie"].ToString();
        Application["installdir"] = dr["installdir"].ToString();
        my.Clear();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        StreamWriter sw = new StreamWriter(countpatch);
        sw.WriteLine(Application["count"].ToString());
        sw.Close();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Session.Timeout = 1;
        Application.Lock();
        Application["online"] = Convert.ToInt64(Application["online"]) + 1;
        Application["count"] = Convert.ToInt64(Application["count"]) + 1;
        Application.UnLock();

    }

    void Session_End(object sender, EventArgs e) 
    {
        Application.Lock();
        Application["online"] = Convert.ToInt64(Application["online"]) - 1;
        Application.UnLock();
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
