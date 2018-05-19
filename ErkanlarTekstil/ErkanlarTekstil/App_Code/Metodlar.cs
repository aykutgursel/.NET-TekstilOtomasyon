using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Metodlar
/// </summary>
public class Metodlar
{

    public Metodlar()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection baglan()
    {
        SqlConnection baglanti = new SqlConnection("Data Source=Localhost; Initial Catalog=ErkanlarTekstil; Integrated Security=true;Connection Timeout=600");
        baglanti.Open();
        return (baglanti);
    }

    public int cmd(string sqlcumle)
    {
        SqlConnection baglanti = this.baglan();
        SqlCommand cmd = new SqlCommand(sqlcumle, baglanti);
        int sonuc = 0;
        try
        {
            sonuc = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message + "(" + sqlcumle + ")");
        }
        cmd.Dispose();
        baglanti.Close();
        baglanti.Dispose();
        return (sonuc);
    }

    public DataTable GetDataTable(string sqlcumle)
    {
        SqlConnection baglanti = this.baglan();
        SqlDataAdapter dap = new SqlDataAdapter(sqlcumle, baglanti);
        DataTable dt = new DataTable();
        try
        {
            dap.Fill(dt);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message + "(" + sqlcumle + ")");
        }
        dap.Dispose();
        baglanti.Close();
        baglanti.Dispose();
        return dt;
    }

    public DataRow GetDataRow (string sqlcumle)
    {
        DataTable dt = GetDataTable(sqlcumle);
        if (dt.Rows.Count == 0)
            return null;
        else
            return dt.Rows[0];
    }

    public string GetDataCell(string sqlcumle)
    {
        DataTable dt = GetDataTable(sqlcumle);
        if (dt.Rows.Count == 0)
            return null;
        else
            return dt.Rows[0][0].ToString();
    }


}

