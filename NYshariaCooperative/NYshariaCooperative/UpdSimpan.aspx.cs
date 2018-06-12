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
    public partial class UpdSimpan : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID_Simpan = this.Request["ID_Simpan"];
                getID(ID_Simpan);
            }
        }
        protected void getID(string ID_Simpan)
        {
            string sql = "Select * from Simpan where ID_Simpan = @ID_Simpan";
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ID_Simpan", SqlDbType.VarChar).Value = ID_Simpan;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                simpanID.Text = dr["ID_Simpan"].ToString();
                memberId.Text = dr["Member_ID"].ToString();
                memberN.Text = dr["Member_Name"].ToString();
                bayar.Text = dr["Pembayaran_Perbulan"].ToString();

                conn.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "'); </script>");
            }
        }
        protected void updateSimpan(Object sender, EventArgs e)
        {

            try
            {
                string sql = "UPDATE Simpan SET ID_Simpan = @ID_Simpan ,Member_ID = @Member_ID, Member_Name = @Member_Name, Pembayaran_Perbulan = @Pembayaran_Perbulan where ID_Simpan = @ID_Simpan";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                string ID_Simpan = this.Request["ID_Simpan"];
                cmd.Parameters.Add("@ID_Simpan", SqlDbType.VarChar, 10).Value = simpanID.Text;
                cmd.Parameters.Add("@Member_ID", SqlDbType.VarChar, 10).Value = memberId.Text;
                cmd.Parameters.Add("@Member_Name", SqlDbType.VarChar, 255).Value = memberN.Text;
                cmd.Parameters.Add("@Pembayaran_Perbulan", SqlDbType.Int).Value = bayar.Text;
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('update sucses');</script>");
                Response.Write("<script>window.location = 'ViewSimpan.aspx'</script>");
            }
           
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
            //Response.Write("<script>alert('update Gagal');</script>");
        }


    }

}