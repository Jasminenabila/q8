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
    public partial class Simpan : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            simpanID.Text = Auto();
            simpanID.Enabled = false;
            bayarBln.Enabled = false;
        }

        protected string Auto()
        {
            string sID = null;
            int ID = 0;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select TOP 1 ID_Simpan from Simpan order by ID_Simpan DESC", con);
            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                sID = (myReader["ID_Simpan"].ToString());
                ID = Convert.ToInt32(sID.Substring(1, 3));
                ID += 1;
                if (ID <= 9)
                {
                    sID = "S00" + ID;
                }
                else if (ID <= 90)
                {
                    sID = "S0" + ID;
                }
                else if (ID <= 900)
                {
                    sID = "S" + ID;
                }
            }
            else
            {
                sID = "S001";
            }
            con.Close();
            return sID;
        }

        protected void save(Object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into Simpan (ID_Simpan,Member_ID,Member_Name,Pembayaran_Perbulan) values (@ID_Simpan,@Member_ID, @Member_Name,@Pembayaran_Perbulan)";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID_Simpan", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Member_ID", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Member_Name", SqlDbType.VarChar, 255));
                cmd.Parameters.Add(new SqlParameter("@Pembayaran_Perbulan", SqlDbType.Int));

                cmd.Parameters["@ID_Simpan"].Value = simpanID.Text.ToString();
                cmd.Parameters["@Member_ID"].Value = memberId.Text.ToString();
                cmd.Parameters["@Member_Name"].Value = memberN.Text.ToString();
                cmd.Parameters["@Pembayaran_Perbulan"].Value = int.Parse(bayarBln.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("<script>alert('Berhasil');</script>");
                Response.Write("<script>window.location='ViewSimpan.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}