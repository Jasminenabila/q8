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
    public partial class UpdatePinjam : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            pinjamID.Enabled = false;
            memberId.Enabled = false;
            memberN.Enabled = false;
            if (!IsPostBack)
            {
                string ID_Pinjam = this.Request["ID_Pinjam"];
                getID(ID_Pinjam);
            }
        }
        protected void getID(string ID_Pinjam)
        {
            string sql = "Select * from Pinjam where ID_Pinjam = @ID_Pinjam";
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ID_Pinjam", SqlDbType.VarChar).Value = ID_Pinjam;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                pinjamID.Text = dr["ID_Pinjam"].ToString();
                memberId.Text = dr["Member_ID"].ToString();
                memberN.Text = dr["Member_Name"].ToString();
                memberN.Text = dr["Monthly_Income"].ToString();
                jumlahP.Text = dr["Jumlah_Pinjam"].ToString();
                JangkaP.Text = dr["Jangka_Pinjam"].ToString();
                Angsuran.Text = dr["Angsuran"].ToString();
                status.SelectedValue = dr["Status"].ToString();

                conn.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "'); </script>");
            }
        }

        protected void update(Object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE Pinjam SET ID_Pinjam = @ID_Pinjam ,Member_ID = @Member_ID, Member_Name = @Member_Name, Monthly_Income = @Monthly_Income, Jumlah_Pinjam = @Jumlah_Pinjam , Jangka_Pinjam = @Jangka_Pinjam, Angsuran = @Angsuran, Status = @Status where ID_Pinjam = @ID_Pinjam";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                string ID_Pinjam = this.Request["ID_Pinjam"];
                cmd.Parameters.Add("@ID_Pinjam", SqlDbType.VarChar, 10).Value = pinjamID.Text;
                cmd.Parameters.Add("@Member_ID", SqlDbType.VarChar, 10).Value = memberId.Text;
                cmd.Parameters.Add("@Member_Name", SqlDbType.VarChar, 255).Value = memberN.Text;
                cmd.Parameters.Add("@Monthly_Income", SqlDbType.VarChar, 255).Value = Gaji.Text;
                cmd.Parameters.Add("@Jumlah_Pinjam", SqlDbType.Int).Value = jumlahP.Text;
                cmd.Parameters.Add("@Jangka_Pinjam", SqlDbType.Int).Value = JangkaP.Text;
                cmd.Parameters.Add("@Angsuran", SqlDbType.Int).Value = Angsuran.Text;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = status.SelectedValue;
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('update sucses');</script>");
                Response.Write("<script>window.location = 'ViewPinjam.aspx'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
    }
}