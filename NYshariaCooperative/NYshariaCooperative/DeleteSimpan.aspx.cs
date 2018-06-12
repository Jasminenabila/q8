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
    public partial class DeleteSimpan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hapusData(this.Request["ID_Simpan"]);

        }
        protected void hapusData(string ID_Simpan)
        {
            try
            {
                string connStr =
               ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                string sql = "delete from Simpan where ID_Simpan = @ID_Simpan";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add(new SqlParameter("@ID_Simpan", SqlDbType.VarChar, 10)).Value = ID_Simpan;
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Berhasil Delete');</script>");
                Response.Write("<script>window.location = 'ViewSimpan.aspx'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}