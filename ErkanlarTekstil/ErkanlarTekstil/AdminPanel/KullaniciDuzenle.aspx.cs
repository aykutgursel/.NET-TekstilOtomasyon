using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_KullaniciDuzenle : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    string KullaniciId = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            KullaniciId = Request.QueryString["KullaniciId"];
            DataRow drKullanici = mtd.GetDataRow("SELECT tk.GrupId,tkg.GrupAdi,tk.KullaniciAdi,tk.Sifre, tk.Adres, tk.AdSoyad, tk.Telefon, tk.Mail, tk.Engel, i.idAdi, i2.ilceAdi, m.mahalleAdi, s.semtAdi FROM dbo.tbl_Kullanicilar tk INNER JOIN dbo.iller i ON tk.il_id = i.id INNER JOIN dbo.ilceler i2 ON tk.ilce_id = i2.id INNER JOIN dbo.mahalleler m ON tk.mahalle_id = m.id INNER JOIN dbo.semtler s ON tk.semt_id = s.id INNER JOIN dbo.tbl_KullaniciGrup tkg ON tk.GrupId = tkg.GrupId where tk.KullaniciId=" + KullaniciId);
            il();

            txtAdSoyad.Text = drKullanici["AdSoyad"].ToString();
            txtAdres.Text = drKullanici["Adres"].ToString();
            txtKulAdi.Text = drKullanici["KullaniciAdi"].ToString();
            txtSifre.Text = drKullanici["Sifre"].ToString();
            txtTelefon.Text = drKullanici["Telefon"].ToString();
            txtMail.Text = drKullanici["Mail"].ToString();
            ddlGorevi.SelectedValue = drKullanici["GrupId"].ToString();





            bool engelDurum = false;
            if (drKullanici["Engel"].ToString() == engelDurum.ToString())
            {
                chckbxEngelle.Checked = false;
            }
            if (drKullanici["Engel"].ToString() != engelDurum.ToString())
            {
                chckbxEngelle.Checked = true;
            }

            DataTable ddlYukle = mtd.GetDataTable("Select GrupId,GrupAdi from tbl_KullaniciGrup");
            ddlGorevi.DataTextField = "GrupAdi";
            ddlGorevi.DataValueField = "GrupId";
            ddlGorevi.DataSource = ddlYukle;
            ddlGorevi.DataBind();

        }
    }

    void il()
    {
        if (cbx_il.SelectedValue == "0")
        {
            cbx_ilce.SelectedValue = "0";
            cbx_mahalle.SelectedValue = "0";
            cbx_semt.SelectedValue = "0";
            return;
        }

        DataTable dtiller = mtd.GetDataTable("Select * from iller");
        cbx_il.DataTextField = "idAdi";
        cbx_il.DataValueField = "id";
        cbx_il.DataSource = dtiller;
        cbx_il.DataBind();
        cbx_il.Items.Insert(0, "Seçiniz");
        ilce();
    }

    void ilce()
    {
        if (cbx_il.SelectedValue == "0" || cbx_il.SelectedValue == "")
        {
            cbx_ilce.SelectedValue = "0";
            cbx_mahalle.SelectedValue = "0";
            cbx_semt.SelectedValue = "0";
            cbx_mahalle.Items.Clear();
            cbx_semt.Items.Clear();
            cbx_ilce.Items.Clear();
            return;
        }
        DataTable dtilce = mtd.GetDataTable("Select * from ilceler where il_id=" + cbx_il.SelectedValue);
        cbx_ilce.DataTextField = "ilceAdi";
        cbx_ilce.DataValueField = "id";
        cbx_ilce.DataSource = dtilce;
        cbx_ilce.DataBind();
        cbx_ilce.Items.Insert(0, "Seçiniz");


    }

    void mahalle()
    {
        if(cbx_ilce.SelectedValue=="" || cbx_ilce.SelectedValue == null)
        {
            cbx_mahalle.SelectedValue = "0";
            cbx_semt.SelectedValue = "0";
            cbx_mahalle.Items.Clear();
            cbx_semt.Items.Clear();
            return;
        }
        DataTable dtmahalle = mtd.GetDataTable("Select * from mahalleler where il_id='" + cbx_il.SelectedValue + "' and ilce_id='" + cbx_ilce.SelectedValue + "'");
        cbx_mahalle.DataTextField = "mahalleAdi";
        cbx_mahalle.DataValueField = "id";
        cbx_mahalle.DataSource = dtmahalle;
        cbx_mahalle.DataBind();
        cbx_mahalle.Items.Insert(0, "Seçiniz");
    }

    void semt()
    {
        if(cbx_ilce.SelectedValue == "" || cbx_ilce.SelectedValue == null)
        {
            cbx_mahalle.SelectedValue = "0";
            cbx_semt.SelectedValue = "0";
            cbx_mahalle.Items.Clear();
            cbx_semt.Items.Clear();
            return;
        }
        DataTable dtsemt = mtd.GetDataTable("Select * from semtler where il_id='" + cbx_il.SelectedValue + "' and ilce_id='" + cbx_ilce.SelectedValue + "'");
        cbx_semt.DataTextField = "semtAdi";
        cbx_semt.DataValueField = "id";
        cbx_semt.DataSource = dtsemt;
        cbx_semt.DataBind();
        cbx_semt.Items.Insert(0, "Seçiniz");
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtAdSoyad.Text) || string.IsNullOrEmpty(txtSifre.Text) || string.IsNullOrEmpty(txtKulAdi.Text) || cbx_ilce.SelectedValue == "" || cbx_mahalle.SelectedValue == "" || cbx_semt.SelectedValue == "")
        {

            lblDurumId.Visible = true;
            lblDurumText.Visible = true;
            lblDurumId.Text = "Durum : ";
            lblDurumText.Text = "Boş Alan bırakmayın";
            return;
        }

        if(string.IsNullOrEmpty(cbx_il.SelectedValue) || string.IsNullOrEmpty(cbx_ilce.SelectedValue) || string.IsNullOrEmpty(cbx_mahalle.SelectedValue) || string.IsNullOrEmpty(cbx_semt.SelectedValue))
        {
            lblDurumId.Visible = true;
            lblDurumText.Visible = true;
            lblDurumId.Text = "Durum : ";
            lblDurumText.Text = "Lütfen adres tanımlamalarını yapınız";
            return;
        }

        DataRow drKullanici = mtd.GetDataRow("SELECT * from tbl_Kullanicilar");
        if (drKullanici["KullaniciAdi"].ToString() == txtKulAdi.Text)
        {
            lblDurumId.Visible = true;
            lblDurumText.Visible = true;
            lblDurumId.Text = "Durum : ";
            lblDurumText.Text = "Sistemde bu kullanıcı adında kayıt vardır";
            return;
        }

        KullaniciId = Request.QueryString["KullaniciId"];
        string cevir = DateTime.Now.ToString("dd-MM-yyyy.HH.mm");

        bool deger;
        if (chckbxEngelle.Checked)
            deger = true;
        else
            deger = false;
            

        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("UPDATE tk SET tk.GrupId='" + ddlGorevi.SelectedValue + "',tk.KullaniciAdi='" + txtKulAdi.Text + "', tk.Sifre='" + txtSifre.Text + "', tk.il_id='" + cbx_il.SelectedValue + "', tk.ilce_id='" + cbx_ilce.SelectedValue + "', tk.mahalle_id='" + cbx_mahalle.SelectedValue + "',tk.semt_id='" + cbx_semt.SelectedValue + "',tk.Adres='" + txtAdres.Text + "',tk.AdSoyad='" + txtAdSoyad.Text + "',tk.Telefon='" + txtTelefon.Text + "',tk.Mail='" + txtMail.Text + "',tk.OlusturmaTarihi='" + cevir + "',tk.Engel='" + deger + "' FROM dbo.tbl_Kullanicilar tk WHERE tk.KullaniciId='" + KullaniciId + "'", baglanti);
        cmd.ExecuteNonQuery();

        lblDurumId.Visible = true;
        lblDurumText.Visible = true;
        lblDurumId.Text = "Durum : ";
        lblDurumText.Text = "Kayıt başarıyla güncellendi.";

    }

    protected void cbx_ilce_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        mahalle();
        semt();
    }

    protected void cbx_il_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ilce();
    }
}