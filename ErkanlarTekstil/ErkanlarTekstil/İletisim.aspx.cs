using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class İletisim : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = mtd.GetDataTable("SELECT TOP 1  ti.il,ti.ilce, ti.mahalle, ti.sokak, ti.firmaAdi,ti.No,ti.tel,ti.tel2,ti.faks,ti.mailAdresi FROM dbo.tbl_iletisim ti ORDER BY ti.id desc");
            rptIletisim.DataSource = dt;
            rptIletisim.DataBind();
        }
        catch (Exception)
        {

            Console.Write("Hata oluştu");
        }
      
    }
}