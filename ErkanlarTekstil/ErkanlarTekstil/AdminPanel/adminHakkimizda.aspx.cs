using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_adminHakkimizda : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    string resimAdi = "";
    string uzanti = "";
    string pcName = HttpContext.Current.Request.LogonUserIdentity.Name;
    string userName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      //  userName = User.Identity.
      
    }

    protected void btnYukle_Click(object sender, EventArgs e)
    {
        try
        {


            //int yil = DateTime.Now.Year;
            //int ay = DateTime.Now.Month;
            //int gun = DateTime.Now.Day;
            //int saat = DateTime.Now.Hour;
            //int dakika = DateTime.Now.Minute;
            //int saniye = DateTime.Now.Second;
            //int milisaniye = DateTime.Now.Millisecond;



            //if (fuResim.HasFile)
            //{
            //    uzanti = Path.GetExtension(fuResim.PostedFile.FileName);
            //    resimAdi = yil.ToString() + ay.ToString() + gun.ToString() + saat.ToString() + dakika.ToString() + saniye.ToString() + milisaniye.ToString();   
            //    fuResim.SaveAs(Server.MapPath("~/images/hakkimizdaResimler/" + resimAdi + uzanti));

            //}
        }
        catch (Exception)
        {

            throw;
        }
       
    }

    protected void btnGetir_Click(object sender, EventArgs e)
    {
     
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlHakkimizda.SelectedValue == "0")
            {
                lblSonuc.Visible = true;
                lblSonuc.Text = "Lütfen güncellemek için seçim yapın";
                pnlBilgiler.Visible = false;
                return;
            }

            pnlBilgiler.Visible = true;
            DateTime dt = DateTime.Now;
            string dtFormat = dt.ToString("yyyy-MM-dd hh:mm.ss.fff");
            SqlConnection baglanti = mtd.baglan();
            SqlCommand cmd = new SqlCommand("Update dbo.tbl_hakkimizda SET dbo.tbl_hakkimizda.aciklama='" + Editor1.Content + "',dbo.tbl_hakkimizda.pcName='" + pcName + "',dbo.tbl_hakkimizda.userName='" + userName + "',dbo.tbl_hakkimizda.OlusturmaTarihi='" + dtFormat + "' Where dbo.tbl_hakkimizda.id=" + ddlHakkimizda.SelectedValue, baglanti);
            cmd.ExecuteNonQuery();
            lblSonuc.Visible = true;
            lblSonuc.Text = "Hakkımızdaki alan başarıyla güncellenmiştir";
        }
        catch (Exception ex)
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Güncellenirken teknik bir hata oluştu";
        }
    }



    protected void ddlHakkimizda_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHakkimizda.SelectedValue == "0")
        {
            lblSonuc.Visible = true;
            lblSonuc.Text = "Lütfen seçim yapın";
            txtHakkimizda.Text = "";
            pnlBilgiler.Visible = false;
            return;
        }
        pnlBilgiler.Visible = true;
        DataRow drGrup = mtd.GetDataRow("SELECT * FROM dbo.tbl_hakkimizda tsm Where  tsm.id=" + ddlHakkimizda.SelectedValue);
        Editor1.Content = drGrup["aciklama"].ToString();
        lblSonuc.Visible = false;
    }
}