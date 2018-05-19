using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGirisYap_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txt_LoginKullaniciAdi.Text) || string.IsNullOrEmpty(txt_LoginSifre.Text))
        {
            lblDurum.Visible = true;
            lblDurumSonuc.Visible = true;
            lblDurumSonuc.Text = "Kullanıcı adı ve parola boş bırakılamaz";
            txt_LoginSifre.Text = "";
            txt_LoginKullaniciAdi.Text = "";
        }

        else
        {
            DataRow drGiris = mtd.GetDataRow("Select tk.Engel,tk.KullaniciId,tk.KullaniciAdi,tkg.GrupAdi from tbl_Kullanicilar tk INNER JOIN dbo.tbl_KullaniciGrup tkg ON tk.GrupId = tkg.GrupId where KullaniciAdi='" + LoginConfig.Temizle(txt_LoginKullaniciAdi.Text) + "' and Sifre='" + LoginConfig.Temizle(txt_LoginSifre.Text) + "'");
            if (drGiris != null)
            {
                if (drGiris["Engel"].ToString() == "True")
                {
                    lblDurum.Visible = true;
                    lblDurumSonuc.Visible = true;
                    lblDurumSonuc.Text = "Engelli kullanıcı, Giriş yapamazsınız.";
                    return;
                }
                Session["KullaniciId"] = drGiris["KullaniciId"].ToString();
                Session["KullaniciAdi"] = drGiris["KullaniciAdi"].ToString();
                Session["GrupAdi"] = drGiris["GrupAdi"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblDurum.Visible = true;
                lblDurumSonuc.Visible = true;
                lblDurumSonuc.Text = "Hatalı Kullanıcı Adı veya Parola";
                return;
            }
        }

    }
}