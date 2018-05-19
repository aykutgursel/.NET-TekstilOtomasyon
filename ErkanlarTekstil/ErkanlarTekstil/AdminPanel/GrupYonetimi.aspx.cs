using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_GrupYonetimi : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    string GrupId = "";
    string islem = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GrupId = Request.QueryString["GrupId"];
        islem = Request.QueryString["islem"];

        if(islem=="sil")
        {
            mtd.cmd("Delete from tbl_KullaniciGrup Where GrupId=" + GrupId);
        }

        DataTable dtGruplar = mtd.GetDataTable("Select * from tbl_KullaniciGrup");
        rptGruplar.DataSource = dtGruplar;
        rptGruplar.DataBind();

    }

    protected void btn_Ekle_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tx_GrupAdi.Text))
        {
            pnlDurum.Visible = true;
            lblDurumAciklama.Text = "Hatalı giriş";
            return;
        }
        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("Insert into tbl_KullaniciGrup (GrupAdi) Values ('" + tx_GrupAdi.Text + "')", baglanti);
        cmd.ExecuteNonQuery();
        Response.Redirect("GrupYonetimi.aspx");

    }
}