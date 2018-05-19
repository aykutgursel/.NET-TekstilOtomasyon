using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable drEnCokSatilanUrunler1 = mtd.GetDataTable("Select TOP 6 * from tbl_anasayfaEnCokSatilanUrunler");
        rptEnCokSatılan.DataSource = drEnCokSatilanUrunler1;
        rptEnCokSatılan.DataBind();

    }
}