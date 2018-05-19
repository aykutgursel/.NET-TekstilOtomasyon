using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_AnasayfaDuzenle : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataRow drGrup = mtd.GetDataRow("SELECT TOP 1 tai.ilIlce, tai.Mail, tai.Telefon FROM dbo.tbl_anasayaIletisim tai");
            txtIl_ilce.Text = drGrup["ilIlce"].ToString();
            txtMail.Text = drGrup["Mail"].ToString();
            txtTelefon.Text = drGrup["Telefon"].ToString();

            DataTable ddlYukle = mtd.GetDataTable("SELECT tk.id, tk.KategoriAdi FROM dbo.tbl_kategoriler tk");
            ddlKategori.DataTextField = "KategoriAdi";
            ddlKategori.DataValueField = "id";
            ddlKategori.DataSource = ddlYukle;
            ddlKategori.DataBind();
            ddlKategori.Items.Insert(0, "Seçiniz");



            DataTable ddlYuklee = mtd.GetDataTable("SELECT tk.id, tk.KategoriAdi FROM dbo.tbl_kategoriler tk");
            ddlKateogoriSil.DataTextField = "KategoriAdi";
            ddlKateogoriSil.DataValueField = "id";
            ddlKateogoriSil.DataSource = ddlYuklee;
            ddlKateogoriSil.DataBind();
            ddlKateogoriSil.Items.Insert(0, "Seçiniz");


            DataTable ddlBilgiYukle = mtd.GetDataTable("SELECT ab.id, ab.BilgiAdi FROM dbo.tbl_anasayfaBilgi ab");
            ddlBilgi.DataTextField = "BilgiAdi";
            ddlBilgi.DataValueField = "id";
            ddlBilgi.DataSource = ddlBilgiYukle;
            ddlBilgi.DataBind();
            ddlBilgi.Items.Insert(0, "Seçiniz");
        }
    }


    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtIl_ilce.Text) || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtTelefon.Text))
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Lütfen Boşluk Bırakmayın";
            return;
        }

            SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("update dbo.tbl_anasayaIletisim	SET dbo.tbl_anasayaIletisim.ilIlce ='" + txtIl_ilce.Text + "',dbo.tbl_anasayaIletisim.Mail ='" + txtMail.Text + "',dbo.tbl_anasayaIletisim.Telefon = '" + txtTelefon.Text + "'" , baglanti);
            cmd.ExecuteNonQuery();
            lblSonuc.Visible = true;
            lblSonuc.Text = "Yeni Adres bilgileriniz başarıyla güncellendi";
        txtIl_ilce.Text = "";
        txtMail.Text = "";
        txtTelefon.Text = "";

    }

    protected void ddlAnasayfaAlanlari_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAnasayfaAlanlari.SelectedValue == "0")
        {
            pnlKategoriler.Visible = false;
            pnlIletisim.Visible = false;
            lblSonuc.Visible = true;
            pnlBilgi.Visible = false;
            pnlKategoriSil.Visible = false;
            lblSonuc.Text = "Lütfen seçim yapın";
            return;
        }

        if (ddlAnasayfaAlanlari.SelectedValue == "1")
        {
            pnlIletisim.Visible = true;
            pnlKategoriler.Visible = false;
            pnlSosyalMedya.Visible = false;
            pnlKategoriSil.Visible = false;
            pnlBilgi.Visible = false;
            lblSonuc.Visible = false;
            return;
        }


        if (ddlAnasayfaAlanlari.SelectedValue == "2")
        {
            pnlKategoriler.Visible = false;
            pnlIletisim.Visible = false;
            pnlKategoriSil.Visible = false;
            pnlSosyalMedya.Visible = false;
            lblSonuc.Visible = false;
            pnlBilgi.Visible = true;
            return;
        }

        if (ddlAnasayfaAlanlari.SelectedValue == "3")
        {
            pnlKategoriler.Visible = true;
            pnlIletisim.Visible = false;
            pnlKategoriSil.Visible = false;
            pnlBilgi.Visible = false;
            pnlSosyalMedya.Visible = false;
            lblSonuc.Visible = false;
            return;
        }

        if(ddlAnasayfaAlanlari.SelectedValue=="4")
        {
            pnlKategoriler.Visible = false;
            pnlIletisim.Visible = false;
            pnlKategoriSil.Visible = false;
            pnlBilgi.Visible = false;
            pnlSosyalMedya.Visible = true;
            lblSonuc.Visible = false;
            return;
        }


    }

    //protected void btnGetir_Click(object sender, EventArgs e)
    //{
    //}

    protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKategori.SelectedIndex.ToString()     == "0")
        {
            pnlKategorileriGoster.Visible = false;
            return;
        }
        pnlKategorileriGoster.Visible = true;

        DataRow drKullanici = mtd.GetDataRow("SELECT tk.id, tk.KategoriAdi, tk.sayfa FROM dbo.tbl_kategoriler tk where tk.id=" + ddlKategori.SelectedValue);
        txtKategoriAdiGuncelle.Text = drKullanici["KategoriAdi"].ToString();
        txtKategoriAdresiGuncelle.Text = drKullanici["sayfa"].ToString();



    }


    protected void btnKategoriGuncelle_Click1(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtKategoriAdiGuncelle.Text) || string.IsNullOrEmpty(txtKategoriAdresiGuncelle.Text))
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Lütfen Boşluk Bırakmayın";
            return;
        }

        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("UPDATE dbo.tbl_kategoriler SET dbo.tbl_kategoriler.KategoriAdi ='" + txtKategoriAdiGuncelle.Text + "', dbo.tbl_kategoriler.sayfa = '" + txtKategoriAdresiGuncelle.Text + "' where dbo.tbl_kategoriler.id=" + ddlKategori.SelectedValue, baglanti);
        cmd.ExecuteNonQuery();
        lblKategoriSonuc.Text = "Kategori Başarıyla Güncellendi";

    }

    protected void btnSosyalMedyaGuncelle_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSosyalMedyaHesaplari.SelectedValue == "0")
            {
                lblSonuc.Visible = true;
                lblSonuc.Text = "Lütfen güncellemek için seçim yapın";
                return;
            }

            SqlConnection baglanti = mtd.baglan();
            SqlCommand cmd = new SqlCommand("Update dbo.tbl_sosyalMedya SET dbo.tbl_sosyalMedya.link='" + txtSosyalMedyaLinki.Text + "' Where dbo.tbl_sosyalMedya.sosyalMedyaStatus=" + ddlSosyalMedyaHesaplari.SelectedValue, baglanti);
            cmd.ExecuteNonQuery();
            lblSosyalDurum.Visible = true;
            lblSosyalDurum.Text = "Yeni sosyal medya linkiniz başarıyla güncellendi";
        }
        catch (Exception)
        {
            lblSonuc.Text = "Sosyal medya linkiniz güncellenirken hata oluştu";

        }


    }

    protected void btnGetir_Click(object sender, EventArgs e)
    {
        if (ddlSosyalMedyaHesaplari.SelectedValue == "0")
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Lütfen seçim yapın";
            txtSosyalMedyaLinki.Text = "";
            return;
        }

        DataRow drGrup = mtd.GetDataRow("SELECT * FROM dbo.tbl_sosyalMedya tsm Where  tsm.sosyalMedyaStatus=" + ddlSosyalMedyaHesaplari.SelectedValue);
        txtSosyalMedyaLinki.Text = drGrup["link"].ToString();
        lblSonuc.Visible = false;
    }

    protected void btnKategoriEkle_Click(object sender, EventArgs e)
    {
        pnlKategoriEkle.Visible = true;
        pnlKategoriSil.Visible = false;
    }

    protected void btnKategoriyiEkle_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtKategoriAdiEkle.Text) || string.IsNullOrEmpty(txtKategoriAdresiEkle.Text))
        {
            lblDurum.Text = "Boş bırakmayın";
            return;
        }
        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("Insert into tbl_kategoriler(KategoriAdi,sayfa) Values ('" + txtKategoriAdiEkle.Text + "','" + txtKategoriAdresiEkle.Text + "')", baglanti);
        cmd.ExecuteNonQuery();
        lblDurum.Text = "Kategori Eklendi";

    }

    protected void btnKategoriSil_Click(object sender, EventArgs e)
    {
        pnlKategoriEkle.Visible = false;


        pnlKategoriSil.Visible = true;
        pnlKategoriler.Visible = false;
        pnlKategorileriGoster.Visible = false;
    }

    protected void btnSil_Click(object sender, EventArgs e)
    {
        if (ddlKateogoriSil.SelectedIndex.ToString() == "0")
        {
            lblKategoriSilDurum.Text = "Lütfen silmek için seçim yapın";
            return;
        }

        mtd.cmd("delete tk FROM dbo.tbl_kategoriler tk WHERE tk.id = " + ddlKateogoriSil.SelectedValue);
        lblKategoriSilDurum.Text = "Silme işlemi başarılı";
        Response.Redirect("AnasayfaDuzenle.aspx");

    }

    protected void btnBilgiEkle_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtBilgiAdi.Text) || string.IsNullOrEmpty(txtBilgiAdresi.Text))
        {
            lblDurum.Text = "Boş bırakmayın";
            return;
        }
        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("Insert into tbl_anasayfaBilgi(bilgiAdi,sayfaAdi) Values ('" + txtBilgiAdi.Text + "','" + txtBilgiAdresi.Text + "')", baglanti);
        cmd.ExecuteNonQuery();
        lblBilgiSonuc.Text = "Bilgi Başarıyla Eklendi";
    }

    protected void btnBilgiSil_Click(object sender, EventArgs e)
    {
        if (ddlBilgi.SelectedIndex.ToString() == "0")
        {
            lblBilgiSonuc.Text = "Lütfen silmek için seçim yapın";
            return;
        }

        mtd.cmd("delete ab FROM dbo.tbl_anasayfaBilgi ab WHERE ab.id = " + ddlBilgi.SelectedValue);
        lblBilgiSonuc.Text = "Silme işlemi başarılı";
        Response.Redirect("AnasayfaDuzenle.aspx");

    }
}