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
using System.Data.OleDb;

/// <summary>
///DB 的摘要说明
/// </summary>
public class DB
{
    OleDbConnection Conn = null;
    OleDbCommand cmd = new OleDbCommand();
    public DB()
    {
        string Dbname = ConfigurationSettings.AppSettings["ConnString"];
        string Connstr = "PROVIDER=Microsoft.Jet.OLEdb.4.0;Data Source=" + Dbname;
        Conn = new OleDbConnection(Connstr);
    }
    public OleDbConnection GetCon()
    {
        if (Conn.State == ConnectionState.Closed)
            Conn.Open();
        return Conn;
    }
    public void Clear()
    {
        if (Conn.State == ConnectionState.Open)
            Conn.Close();
    }
    public int Scalar(string strSql)
    {
        cmd.Connection = GetCon();
        cmd.CommandText = strSql;
        int result;
        try
        {
            result =Convert.ToInt32(cmd.ExecuteScalar().ToString());
        }
        catch
        {
            result = -1;
        }
        Clear();
        return result;
    }
    public void ExecuteNonQuery(string strSql)
    {
        cmd.Connection = GetCon();
        cmd.CommandText = strSql;
        cmd.ExecuteNonQuery();
        Clear();
    }
    public DataSet GetDataSet(OleDbDataAdapter da)
    {
        DataSet dr = new DataSet();
        da.Fill(dr);
        Clear();
        return dr;
    }
    public OleDbDataAdapter DataAdapter(string strSql)
    {
        cmd.Connection = GetCon();
        cmd.CommandText = strSql;
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        Clear();
        return da;
    }
    public void UpDataSet(DataSet ds, OleDbDataAdapter da)
    {
        GetCon();
        OleDbCommandBuilder ocb = new OleDbCommandBuilder(da);
        da.UpdateCommand = ocb.GetUpdateCommand();
        da.Update(ds);
        ds.AcceptChanges();
        Clear();
    }
    public OleDbDataReader ExecuteReader(string strSql)
    {
        cmd.Connection = GetCon();
        cmd.CommandText = strSql;
        OleDbDataReader dr=cmd.ExecuteReader();
        return dr;
    }
}
