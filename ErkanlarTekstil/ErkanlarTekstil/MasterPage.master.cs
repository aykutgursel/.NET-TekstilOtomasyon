using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {
   
            DataTable dt = mtd.GetDataTable("SELECT TOP 3 dbo.tbl_sosyalMedyaStatus.sosyalAd,dbo.tbl_sosyalMedya.link FROM dbo.tbl_sosyalMedya INNER JOIN dbo.tbl_sosyalMedyaStatus ON dbo.tbl_sosyalMedya.sosyalMedyaStatus = dbo.tbl_sosyalMedyaStatus.id");
            rptSosyalMedya.DataSource = dt;
            rptSosyalMedya.DataBind();

            DataTable dtr = mtd.GetDataTable("SELECT TOP 1 tai.ilIlce, tai.Mail, tai.Telefon FROM dbo.tbl_anasayaIletisim tai");
            rptAnaIletisim.DataSource = dtr;
            rptAnaIletisim.DataBind();

            DataTable dtKategori = mtd.GetDataTable("SELECT tk.KategoriAdi, tk.sayfa FROM dbo.tbl_kategoriler tk");
            rptKategoriler.DataSource = dtKategori;
            rptKategoriler.DataBind();

            DataTable dtAnasayfaBilgi = mtd.GetDataTable("SELECT tab.bilgiAdi, tab.sayfaAdi FROM dbo.tbl_anasayfaBilgi tab");
            rptAnasayfaBilgi.DataSource = dtAnasayfaBilgi;
            rptAnasayfaBilgi.DataBind();

            DataTable dtAnasayfaUrunler = mtd.GetDataTable("SELECT tau.* FROM dbo.tbl_anasayfaUrunler tau where tau.mainKategori=0");
            rptAnasayfaUrunler.DataSource = dtAnasayfaUrunler;
            rptAnasayfaUrunler.DataBind();

    }

    protected void rpAnaKategori_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rp = (Repeater)e.Item.FindControl("rpAltKategori"); //İç tarafdaki rpAltKategori kontrolüne erişiyoruz ve rp değişkenine atıyoruz

        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmdAltKat = new SqlCommand("SELECT tau.* FROM dbo.tbl_anasayfaUrunler tau where tau.anaKategori='" + Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "id").ToString())+"' order by tau.id desc", baglanti);
        rp.DataSource = cmdAltKat.ExecuteReader();
        rp.DataBind();

    }


}
