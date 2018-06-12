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
    public partial class DeleteMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hapusData(this.Request["Member_ID"]);
        }
        protected void hapusData(string Member_ID)
        {
            try
            {
                string connStr =
               ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                string sql = "delete from Member where Member_ID = @Member_ID";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add(new SqlParameter("@Member_ID", SqlDbType.VarChar, 10)).Value = Member_ID;
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Berhasil Delete');</script>");
                Response.Write("<script>window.location = 'ViewMember.aspx'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}