using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
namespace basePageTemplate
{
    public abstract class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {

        }


        public void Alert(string message)
        {

            //RadWindowManager RadWindowManager1 = (RadWindowManager)this.Master.FindControl("RadWindowManager1");
            //RadWindowManager1.RadAlert(message, 200, 100, "Durum", "");



            //  RadWindowManager rwm=new RadWindowManager();
            //  rwm.RadAlert(message, 200, 100, "Durum", "");
            //RadWindowManager rwm2 = (RadWindowManager)this.Master.FindControl("rwm2");
            //rwm2.RadAlert(message, 300, 100, "", "");
        }



    }
}
