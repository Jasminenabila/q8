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
    public partial class Pinjam : System.Web.UI.Page
    {
        string find;
        string reply;
        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            pinjamID.Text = Auto();
            pinjamID.Enabled = false;
            status.Enabled = false;
            if (!this.IsPostBack)
            {
                string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Member_ID FROM Member"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        IDanggota.DataSource = cmd.ExecuteReader();
                        IDanggota.DataValueField = "Member_ID";
                        IDanggota.DataBind();
                        con.Close();
                    }
                }
                IDanggota.Items.Insert(0, new ListItem("--Select Your ID--", "0"));
            }
        }

        protected string Auto()
        {
            string sID = null;
            int ID = 0;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select TOP 1 ID_Pinjam from Pinjam order by ID_Pinjam DESC", con);
            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                sID = (myReader["ID_Pinjam"].ToString());
                ID = Convert.ToInt32(sID.Substring(1, 3));
                ID += 1;
                if (ID <= 9)
                {
                    sID = "P00" + ID;
                }
                else if (ID <= 90)
                {
                    sID = "P0" + ID;
                }
                else if (ID <= 900)
                {
                    sID = "P" + ID;
                }
            }
            else
            {
                sID = "P001";
            }
            con.Close();
            return sID;
        }

        protected void save(Object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into Pinjam (ID_Pinjam,Member_ID,Member_Name,Monthly_Income,Jumlah_Pinjam,Jangka_Pinjam,Angsuran,Status) values (@ID_Pinjam,@Member_ID, @Member_Name,@Monthly_Income, @Jumlah_Pinjam,@Jangka_Pinjam,@Angsuran,@Status)";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID_Pinjam", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Member_ID", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Member_Name", SqlDbType.VarChar, 255));
                cmd.Parameters.Add(new SqlParameter("@Monthly_Income", SqlDbType.VarChar, 255));
                cmd.Parameters.Add(new SqlParameter("@Jumlah_Pinjam", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Jangka_Pinjam", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Angsuran", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

                cmd.Parameters["@ID_Pinjam"].Value = pinjamID.Text.ToString();
                cmd.Parameters["@Member_ID"].Value = IDanggota.SelectedItem.ToString();
                cmd.Parameters["@Member_Name"].Value = Gaji.Text.ToString();
                cmd.Parameters["@Monthly_Income"].Value = memberN.Text.ToString();
                cmd.Parameters["@Jumlah_Pinjam"].Value = int.Parse(jumlahP.Text);
                cmd.Parameters["@Jangka_Pinjam"].Value = int.Parse(Jp.SelectedItem.Text);
                cmd.Parameters["@Angsuran"].Value = int.Parse(Angsuran.Text);
                cmd.Parameters["@Status"].Value = status.Text.ToString();

                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("<script>alert('Berhasil');</script>");
                Response.Write("<script>window.location='Terimakasih.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public string FindAccount(string find)
        {
            string info = "";
            string data = "";
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "select * from Member where Member_ID = @Member_ID";
                    SqlCommand sqlcom = new SqlCommand(sql, con);
                    sqlcom.Parameters.Add(new SqlParameter("@Member_ID", find));
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        data += (dr[0] + "#").ToString();
                        data += (dr[1] + "#").ToString();
                        data += (dr[6] + "#").ToString();

                    }
                    info = "OK";
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                info = ex.Message;
            }

            return data;
        }

        private string ValidationFind()
        {
            string info = "";
            if (IDanggota.Text.Length == 0)
            {
                string display = "Please insert Your ID Member";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                info = "NO";
            }
            else
            {
                info = "OK";
            }

            return info;
        }

        //private void angsuran()
        //{
        //    string info = "";
        //    int data = 0;
        //    int gaji;
        //    int pinjam = 0;
        //    int waktu = 0;
        //    int hasil1;
        //    int hasil2;
        //    try
        //    {

        //        gaji = Convert.ToInt32(Gaji.Text) + data;
        //        waktu = Convert.ToInt32(Jp.SelectedItem.ToString()) + data;
        //        hasil1 = gaji / waktu;
        //        hasil2 = 60 / 100 * hasil1;
        //        Angsuran.Text = hasil2.ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        info = ex.Message;
        //    }

        //}

        protected void jumlahP_TextChanged(object sender, EventArgs e)
        {
            //int potong_gaji = Convert.ToInt32(Gaji.Text) / Convert.ToInt32(Jp.SelectedItem.Text);
            //int angsuran = potong_gaji / 100 * 60;
            //Angsuran.Text = Convert.ToString(angsuran);
        }

        protected void IDanggota_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] data;
            if (ValidationFind() == "OK")
            {
                find = IDanggota.Text.ToUpper();
                reply = FindAccount(find);

                if (reply.Length != 0)
                {

                    string display = "Data find";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                    data = reply.Split('#');
                    IDanggota.Text = data[0].ToString();
                    memberN.Text = data[1].ToString();
                    Gaji.Text = data[2].ToString();
                }
                else
                {
                    string display = "Data not find";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
        }

        protected void Jp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string[] dataq;
            int pinjamnya = Convert.ToInt32(jumlahP.Text) / Convert.ToInt32(Jp.Text);
            //int pinjamnya = Convert.ToInt32(jumlahP.Text) / 2;
            int minimal = (Convert.ToInt32(Gaji.Text) / 100) * 60;
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

        protected void Jp_TextChanged(object sender, EventArgs e)
        {
            //Angsuran.Text = "Test";
            //Gaji.Text = "Test";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Angsuran.Text = "Test";
            //Gaji.Text = "Test";
        }
    }
}

