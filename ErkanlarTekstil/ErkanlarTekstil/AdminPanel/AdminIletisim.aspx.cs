using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class iletisim : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataRow drGrup = mtd.GetDataRow("SELECT TOP 1 * FROM dbo.tbl_iletisim tsm ORDER BY tsm.id DESC");
            string id = drGrup["id"].ToString();
            txtIl.Text = drGrup["il"].ToString();
            txtIlce.Text = drGrup["ilce"].ToString();
            txtMahalle.Text = drGrup["mahalle"].ToString();
            txtSokak.Text = drGrup["sokak"].ToString();
            txtFirmaAdi.Text = drGrup["firmaAdi"].ToString();
            txtNo.Text = drGrup["No"].ToString();
            txtTelNo.Text = drGrup["tel"].ToString();
            txtTelNo2.Text = drGrup["tel2"].ToString();
            txtFaks.Text = drGrup["faks"].ToString();
            txtMailAdresi.Text = drGrup["mailAdresi"].ToString();
        }
    }

    protected void btnIletisimEkle_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtIl.Text) || string.IsNullOrEmpty(txtFirmaAdi.Text) || string.IsNullOrEmpty(txtIlce.Text) || string.IsNullOrEmpty(txtMahalle.Text) || string.IsNullOrEmpty(txtSokak.Text))
        {
            pnlDurum.Visible = true;
            lblDurumAciklama.Text = "Boş bırakılan alan var";
            return;
        }

        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("Insert into tbl_iletisim(il,ilce,mahalle,sokak,firmaAdi,No,tel,tel2,faks,mailAdresi) Values ('" + txtIl.Text + "','" + txtIlce.Text + "','" + txtMahalle.Text + "','" + txtSokak.Text + "','" + txtFirmaAdi.Text + "','" + txtNo.Text + "','" + txtTelNo.Text + "','" + txtTelNo2.Text + "','" + txtFaks.Text + "','"+txtMailAdresi.Text+"')", baglanti);
        cmd.ExecuteNonQuery();
        pnlDurum.Visible = true;

        lblDurumAciklama.Text = "İletişim adresi eklenmiştir";
        txtIl.Text = "";
        txtIlce.Text = "";
        txtMahalle.Text = "";
        txtSokak.Text = "";
        txtNo.Text = "";
        txtFirmaAdi.Text = "";
        txtTelNo.Text = "";
        txtTelNo2.Text = "";
        txtFaks.Text = "";
        txtMailAdresi.Text = "";




    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        DataRow drGrup = mtd.GetDataRow("SELECT TOP 1 * FROM dbo.tbl_iletisim tsm order by tsm.id desc");
        string id = drGrup["id"].ToString();

        try
        {
            SqlConnection baglanti = mtd.baglan();
            SqlCommand cmd = new SqlCommand("Update ti SET ti.il='" + txtIl.Text + "',ti.ilce='" + txtIlce.Text + "',ti.mahalle='" + txtMahalle.Text + "',ti.sokak='" + txtSokak.Text + "',ti.firmaAdi='" + txtFirmaAdi.Text + "',ti.No='" + txtNo.Text + "',ti.tel='" + txtTelNo.Text + "',ti.tel2='" + txtTelNo2.Text + "',ti.faks='" + txtFaks.Text + "',ti.mailAdresi='" + txtMailAdresi.Text + "' FROM dbo.tbl_iletisim ti where ti.id='" + id + "'", baglanti);
            cmd.ExecuteNonQuery();
            lblDurumAciklama.Text = "İletişim Bilgileri başarıyla güncellenmiştir";
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {

            throw;
        }
      
    }
}