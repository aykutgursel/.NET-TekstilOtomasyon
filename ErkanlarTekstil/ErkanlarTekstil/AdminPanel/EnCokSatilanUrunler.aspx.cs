using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_EnCokSatilanUrunler : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetir_Click(object sender, EventArgs e)
    {
        if (ddlEnCokSatilan.SelectedValue == "0")
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Lütfen seçim yapın";
            txtUrunadi.Text = "";
            txtUrunAciklama.Text = "";
            return;
        }

        DataRow drGrup = mtd.GetDataRow("SELECT taecsu.* FROM dbo.tbl_anasayfaEnCokSatilanUrunler taecsu Where  taecsu.Id=" + ddlEnCokSatilan.SelectedValue);
        txtUrunadi.Text = drGrup["urunAdi1"].ToString();
        txtUrunAciklama.Text = drGrup["urunAciklamasi1"].ToString();
        lblSonuc.Visible = false;
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        try
        {
            if (!fuResimYukle.HasFile)
            {
                lblSonuc.Visible = true;
                lblSonuc.Text = "RESİM YÜKLEYİN";
                return;
            }

            else
            {
                lblSonuc.Text = "Lütfen bir dosya seçiniz.";
            }


            if (ddlEnCokSatilan.SelectedValue == "0")
            {
                txtUrunAciklama.Text = "";
                txtUrunadi.Text = "";
                lblSonuc.Visible = true;
                lblSonuc.Text = "Lütfen güncellemek için seçim yapın";
                return;
            }

            if (fuResimYukle.HasFile)//Kullanıcı fileupload ile bir dosya seçmiş ise işlemleri gerçekleştir.
            {
                DateTime dt = DateTime.Now;
                var gun = dt.Day;
                var ay = dt.Month;
                var yil = dt.Year;
                var saat = dt.Hour;
                var dakika = dt.Minute;
                var saniye = dt.Second;
                var sanise = dt.Millisecond;
                string resimAdi = gun + "" + ay + "" + yil + "" + saat + "" + dakika + "" + saniye + "" + sanise + "" + ".jpg";

                fuResimYukle.SaveAs(Server.MapPath("~/images/enCokSatilan/") + resimAdi);
                //Sunucuda ki resimler klasörünün içerisine resmi olduğu gibi yükledik.
                lblSonuc.Text = "Dosya yüklendi.";

                string yol = "images\\enCokSatilan\\";

                string birlestirme = yol + resimAdi;

                SqlConnection baglanti = mtd.baglan();
                SqlCommand cmd = new SqlCommand("Update dbo.tbl_anasayfaEnCokSatilanUrunler SET dbo.tbl_anasayfaEnCokSatilanUrunler.resimYol1='" + birlestirme + "',dbo.tbl_anasayfaEnCokSatilanUrunler.urunAdi1='" + txtUrunadi.Text + "',dbo.tbl_anasayfaEnCokSatilanUrunler.urunAciklamasi1='" + txtUrunAciklama.Text + "' Where dbo.tbl_anasayfaEnCokSatilanUrunler.Id=" + ddlEnCokSatilan.SelectedValue, baglanti);
                cmd.ExecuteNonQuery();
                lblSonuc.Visible = true;
                lblSonuc.Text = "Yeni Resim başarıyla yüklendi";
                txtUrunAciklama.Text = "";
                txtUrunadi.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Resim güncellenirken hata oluştu";

        }


    }
}