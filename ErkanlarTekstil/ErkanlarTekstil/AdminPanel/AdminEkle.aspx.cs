using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminEkle : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            il();

            DataTable ddlYukle = mtd.GetDataTable("Select GrupId,GrupAdi from tbl_KullaniciGrup");
            ddlGorevi.DataTextField = "GrupAdi";
            ddlGorevi.DataValueField = "GrupId";
            ddlGorevi.DataSource = ddlYukle;
            ddlGorevi.DataBind();

            if (string.IsNullOrEmpty(txtKulAdi.Text) || string.IsNullOrEmpty(txtSifre.Text) || string.IsNullOrEmpty(txtTelefon.Text))
            {
                lblDurumAciklama.Text = "Boş bırakılan alan var";
                return;
            }

         
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
        if (cbx_ilce.SelectedValue == "" || cbx_ilce.SelectedValue == null)
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
        if (cbx_ilce.SelectedValue == "" || cbx_ilce.SelectedValue == null)
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






    protected void cbx_ilce_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        mahalle();
        semt();
    }

    protected void cbx_il_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ilce();
    }

    protected void btnKullaniciEkle_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtAdSoyad.Text) || string.IsNullOrEmpty(txtSifre.Text) || string.IsNullOrEmpty(txtKulAdi.Text) || cbx_ilce.SelectedValue=="" || cbx_mahalle.SelectedValue=="" ||cbx_semt.SelectedValue=="")
        {

            lblDurumId.Visible = true;
            lblDurumText.Visible = true;
            lblDurumId.Text = "Durum : ";
            lblDurumText.Text = "Boş Alan bırakmayın";
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

        try
        {
            DateTime dt = DateTime.Now;
            string cevir = dt.ToString();

            SqlConnection baglanti = mtd.baglan();
            SqlCommand cmd = new SqlCommand("Insert into tbl_Kullanicilar(GrupId,KullaniciAdi,Sifre,il_id,ilce_id,mahalle_id,semt_id,Adres,AdSoyad,Telefon,Mail,OlusturmaTarihi,Engel) Values ('" + ddlGorevi.SelectedValue + "','" + txtKulAdi.Text + "','" + txtSifre.Text + "','" + cbx_il.SelectedValue + "','" + cbx_ilce.SelectedValue + "','" + cbx_mahalle.SelectedValue + "','" + cbx_semt.SelectedValue + "','" + txtAdres.Text + "','" + txtAdSoyad.Text + "','" + txtTelefon.Text + "','" + txtMail.Text + "','" + cevir + "','0')", baglanti);
            cmd.ExecuteNonQuery();
            lblDurumId.Visible = true;
            lblDurumText.Visible = true;
            lblDurumId.Text = "Durum : ";
            lblDurumText.Text = "Kayıt Başarıyla Eklendi";
        }
        catch (Exception ex)
        {

            throw;
        }
      

    }
}