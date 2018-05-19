using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_AdminYonetimi : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    string aranacak = "";
    string islem = "";
    string KullaniciId = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            aranacak = Request.QueryString["aranacak"];
            islem = Request.QueryString["islem"];
            KullaniciId = Request.QueryString["KullaniciId"];
        }
        catch (Exception)
        { }

        if (islem == "sil")
        {
            int deger = mtd.cmd("Delete from tbl_Kullanicilar where KullaniciId=" + KullaniciId);
            if(deger>0)
            {
                lblAramaBilgi.Text = "Kayıt başarıyla silindi";
                return;
            }
           // Response.Redirect("AdminYonetimi.aspx");
        }

        if (!string.IsNullOrEmpty(aranacak))
        {
            DataTable dtKullanici = mtd.GetDataTable("SELECT dbo.tbl_Kullanicilar.*, dbo.tbl_KullaniciGrup.GrupAdi FROM dbo.tbl_KullaniciGrup INNER JOIN dbo.tbl_Kullanicilar ON dbo.tbl_KullaniciGrup.GrupId = dbo.tbl_Kullanicilar.GrupId where AdSoyad like '%" + aranacak + "%' or KullaniciAdi like '%" + aranacak + "%'");
            dlKullaniciAra.DataSource = dtKullanici;
            dlKullaniciAra.DataBind();
            if (dtKullanici.Rows.Count > 0)
            {
                lblAramaBilgi.Text = dtKullanici.Rows.Count.ToString() + " Adet kullanıcı bulunmuştur.";
                dlKullaniciAra.Visible = true;
            }
           
            else
            {
                lblAramaBilgi.Text = "Aradığınız isimde kullanıcı bulunamadı";
                dlKullaniciAra.Visible = false;
            }
        }
        if (string.IsNullOrEmpty(aranacak))
        {
            lblAramaBilgi.Text = "Aramak için birşeyler girin";
            return;
        }
    }



    protected void btnYonetici_Click(object sender, EventArgs e)
    {
        DataRow drKullanici = mtd.GetDataRow("Select GrupId from tbl_KullaniciGrup where GrupAdi='" + "Yönetici" + "'");
        DataTable dtKullanici = mtd.GetDataTable("SELECT dbo.tbl_Kullanicilar.*, dbo.tbl_KullaniciGrup.GrupAdi FROM dbo.tbl_KullaniciGrup INNER JOIN dbo.tbl_Kullanicilar ON dbo.tbl_KullaniciGrup.GrupId = dbo.tbl_Kullanicilar.GrupId where dbo.tbl_Kullanicilar.GrupId=" + drKullanici["GrupId"].ToString());
        if (dtKullanici == null || dtKullanici.Rows.Count == 0)
        {
            datalistKullanicilar.Visible = false;
            return;
        }
        datalistKullanicilar.Visible = true;
        datalistKullanicilar.DataSource = dtKullanici;
        datalistKullanicilar.DataBind();

    }

    protected void btnYardimciYonetici_Click(object sender, EventArgs e)
    {
        DataRow drKullanici = mtd.GetDataRow("Select GrupId from tbl_KullaniciGrup where GrupAdi='" + "Yardımcı Yönetici" + "'");
        DataTable dtKullanici = mtd.GetDataTable("SELECT dbo.tbl_Kullanicilar.*, dbo.tbl_KullaniciGrup.GrupAdi FROM dbo.tbl_KullaniciGrup INNER JOIN dbo.tbl_Kullanicilar ON dbo.tbl_KullaniciGrup.GrupId = dbo.tbl_Kullanicilar.GrupId where dbo.tbl_Kullanicilar.GrupId=" + drKullanici["GrupId"].ToString());
        if (dtKullanici == null || dtKullanici.Rows.Count == 0)
        {
            datalistKullanicilar.Visible = false;
            return;
        }
        datalistKullanicilar.Visible = true;
        datalistKullanicilar.DataSource = dtKullanici;
        datalistKullanicilar.DataBind();

    }

    protected void btnKullanicilar_Click(object sender, EventArgs e)
    {
        DataRow drKullanici = mtd.GetDataRow("Select GrupId from tbl_KullaniciGrup where GrupAdi='" + "Kullanıcı" + "'");
        DataTable dtKullanici = mtd.GetDataTable("SELECT dbo.tbl_Kullanicilar.*, dbo.tbl_KullaniciGrup.GrupAdi FROM dbo.tbl_KullaniciGrup INNER JOIN dbo.tbl_Kullanicilar ON dbo.tbl_KullaniciGrup.GrupId = dbo.tbl_Kullanicilar.GrupId where dbo.tbl_Kullanicilar.GrupId=" + drKullanici["GrupId"].ToString());
        if (dtKullanici == null || dtKullanici.Rows.Count == 0)
        {
            datalistKullanicilar.Visible = false;
            return;
        }
        datalistKullanicilar.Visible = true;
        datalistKullanicilar.DataSource = dtKullanici;
        datalistKullanicilar.DataBind();

    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminYonetimi.aspx?aranacak=" + LoginConfig.Temizle(txtAra.Text));
    }

    protected void btnSonOnKayit_Click(object sender, EventArgs e)
    {
        DataTable dtKullanici = mtd.GetDataTable("SELECT TOP 10 dbo.tbl_Kullanicilar.*, dbo.tbl_KullaniciGrup.GrupAdi FROM dbo.tbl_KullaniciGrup INNER JOIN dbo.tbl_Kullanicilar ON dbo.tbl_KullaniciGrup.GrupId = dbo.tbl_Kullanicilar.GrupId ORDER BY KullaniciId DESC");
        if (dtKullanici == null || dtKullanici.Rows.Count == 0)
        {
            datalistKullanicilar.Visible = false;
            return;
        }
        datalistKullanicilar.Visible = true;
        datalistKullanicilar.DataSource = dtKullanici;
        datalistKullanicilar.DataBind();
    }
}