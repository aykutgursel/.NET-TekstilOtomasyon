using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Hakkimizda : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow AnaAciklama = mtd.GetDataRow("SELECT th.aciklama FROM dbo.tbl_hakkimizda th where th.id=" + 1);
        DataRow OrtaKisim = mtd.GetDataRow("SELECT th.aciklama FROM dbo.tbl_hakkimizda th where th.id=" + 2);
        DataRow AltKisim = mtd.GetDataRow("SELECT th.aciklama FROM dbo.tbl_hakkimizda th where th.id=" + 3);
        DataRow Kapanis = mtd.GetDataRow("SELECT th.aciklama FROM dbo.tbl_hakkimizda th where th.id=" + 4);

        string anaAciklama = AnaAciklama["aciklama"].ToString();
        string ortaKisim = OrtaKisim["aciklama"].ToString();
        string altKisim = AltKisim["aciklama"].ToString();
        string kapanis = Kapanis["aciklama"].ToString();


        lblHakkimizda.Text = anaAciklama + "<br/><br/>" + ortaKisim + "<br/><br/>" + altKisim + "<br/><br/>" + kapanis;
    }
}