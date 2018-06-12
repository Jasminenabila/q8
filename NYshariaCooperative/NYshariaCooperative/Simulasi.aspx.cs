using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NYshariaCooperative
{
    public partial class Simulasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void JangkaP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pinjamnya = Convert.ToInt32(jumlahP.Text) / Convert.ToInt32(JangkaP.Text);
            int minimal = (Convert.ToInt32(gaji.Text) / 100) * 60;
            //Angsuran.Text = "Test";
            if (minimal >= pinjamnya)
            {
                //dataq = reply.Split('#');
                Angsuran.Text = Convert.ToString(pinjamnya);
            }
            else
            {
                string display = "Gabisa Pinjem";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                Angsuran.Text = Convert.ToString(pinjamnya);
            }
        }
    }
}