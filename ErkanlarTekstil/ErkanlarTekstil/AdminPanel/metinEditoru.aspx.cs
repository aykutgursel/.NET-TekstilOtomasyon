using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using basePageTemplate;
using System.Drawing.Imaging;
using System.Drawing;

public partial class AdminPanel_metinEditoru : System.Web.UI.Page
{
    Metodlar mtd = new Metodlar();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       

      // SqlConnection baglanti = mtd.baglan();
      // SqlCommand cmd = new SqlCommand("Insert into tbl_test(yazi) Values ('" + RadEditor1.Content + "')", baglanti);
      //     cmd.ExecuteNonQuery();
      //
      // DataRow getir = mtd.GetDataRow("SELECT * from tbl_test where id=2");
      // Label1.Text = getir["yazi"].ToString();

     // Alert("Tamamdır");

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Fotograf.yukle(FileUpload1, 150);
    }
}