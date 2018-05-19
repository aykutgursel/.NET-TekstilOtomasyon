using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["KullaniciId"] != null && Session["KullaniciAdi"] != null && Session["GrupAdi"] != null)
        {
            Session.Timeout = 600;
            lblAdSoyad.Text = Session["KullaniciAdi"].ToString();
            lblGorevi.Text = Session["GrupAdi"].ToString();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }

    }

    protected void lnkBtnCikisYap_Click(object sender, EventArgs e)
    {
        Session.Abandon(); //sessionu siliyoruz.
        Response.Redirect("Login.aspx");
    }

    protected void lnkSiteyeGit_Click(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('../Default.aspx','_blank')");
        Response.Write("</script>");
    }
}
