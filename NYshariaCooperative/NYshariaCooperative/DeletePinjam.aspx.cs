using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace NYshariaCooperative
{
    public partial class DeletePinjam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hapusData(this.Request["ID_Pinjam"]);
        }
        protected void hapusData(string ID_Pinjam)
        {
            try
            {
                string connStr =
               ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                string sql = "delete from Pinjam where ID_Pinjam = @ID_Pinjam";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add(new SqlParameter("@ID_Pinjam", SqlDbType.VarChar, 10)).Value = ID_Pinjam;
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Berhasil Delete');</script>");
                Response.Write("<script>window.location = 'ViewPinjam.aspx'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}