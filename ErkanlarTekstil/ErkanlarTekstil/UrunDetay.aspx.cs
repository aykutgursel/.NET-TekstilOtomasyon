using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrunDetay : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    string urunId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        urunId = Request.QueryString["urunId"].ToString();

        DataRow drUrun = mtd.GetDataRow("Select * from tbl_anasayfaUrunler where id=" + urunId);

        lblUrunAdi.Text = drUrun["urunAd"].ToString();
        


    }
}