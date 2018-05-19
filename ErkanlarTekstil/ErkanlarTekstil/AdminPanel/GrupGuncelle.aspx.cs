using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_GrupGuncelle : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    string GrupId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GrupId = Request.QueryString["GrupId"];

        if (!Page.IsPostBack)
        {
            DataRow drGrup = mtd.GetDataRow("Select * from tbl_KullaniciGrup Where GrupId=" + GrupId);
            txtGrupAdi.Text = drGrup["GrupAdi"].ToString();
        }

    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        SqlConnection baglanti = mtd.baglan();
        SqlCommand cmd = new SqlCommand("Update tbl_KullaniciGrup SET GrupAdi='" + txtGrupAdi.Text + "' Where GrupId=" + GrupId, baglanti);
        cmd.ExecuteNonQuery();
        Response.Redirect("GrupYonetimi.aspx");
    }
}