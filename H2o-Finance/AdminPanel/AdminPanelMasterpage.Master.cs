using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2o_Finance.AdminPanel
{
    public partial class AdminPanelMasterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"]!=null)
            {
                Yoneticiler y = (Yoneticiler)Session["yonetici"];
                lbl_kisiadi.Text = y.Isim + " " + y.Soyisim;
            }
            else
            {
                Response.Redirect("AdminGiris.aspx");
            }
        }

        protected void ltbn_cikis_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminGiris.aspx");
        }
    }
}