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
    public partial class Login_Member : System.Web.UI.Page
    {

        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            member.Text = Auto();
            member.Enabled = false;
        }

        protected string Auto()
        {
            string sID = null;
            int ID = 0;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select TOP 1 Member_ID from Member order by Member_ID DESC", con);
            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                sID = (myReader["Member_ID"].ToString());
                ID = Convert.ToInt32(sID.Substring(1, 3));
                ID += 1;
                if (ID <= 9)
                {
                    sID = "K00" + ID;
                }
                else if (ID <= 90)
                {
                    sID = "K0" + ID;
                }
                else if (ID <= 900)
                {
                    sID = "K" + ID;
                }
            }
            else
            {
                sID = "K001";
            }
            con.Close();
            return sID;
        }

        protected void save(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into Member (Member_ID,Member_Name,Date_Of_Birth,Gender,Email,Password) values (@Member_ID,@Member_Name,@Date_Of_Birth,@Gender,@Email,@Password)";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("@Member_ID", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@Member_Name", SqlDbType.VarChar, 225));
                //cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 225));
                cmd.Parameters.Add(new SqlParameter("@Date_Of_Birth", SqlDbType.VarChar, 225));
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.VarChar, 9));
                //cmd.Parameters.Add(new SqlParameter("@Work", SqlDbType.VarChar, 225));
                //cmd.Parameters.Add(new SqlParameter("@Monthly_Income", SqlDbType.VarChar, 225));
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 200));
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 500));

                cmd.Parameters["@Member_ID"].Value = member.Text.ToString();
                cmd.Parameters["@Member_Name"].Value = memberName.Text.ToString();
                //cmd.Parameters["@Address"].Value = Address.Text.ToString(); ;
                cmd.Parameters["@Date_Of_Birth"].Value = Dateof.Text.ToString(); ;
                cmd.Parameters["@Gender"].Value = jk.SelectedItem.ToString(); ;
                //cmd.Parameters["@Work"].Value = Work.Text.ToString(); ;
                //cmd.Parameters["@Monthly_Income"].Value = gaji.Text.ToString(); ;
                cmd.Parameters["@Email"].Value = Email.Text.ToString(); ;
                cmd.Parameters["@Password"].Value = pass.Text.ToString(); ;
                //cmd.Parameters["@No_HP"].Value = Nohp.Text.ToString();
                cmd.ExecuteNonQuery();
                Auto();
                conn.Close();

                Response.Write("<script>alert('Berhasil');</script>");
                Response.Write("<script>window.location='Home.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void member_TextChanged(object sender, EventArgs e)
        {
            Auto();
        }
    }
}