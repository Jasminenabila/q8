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
    public partial class HomeMember : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            member.Enabled = false;
            if (!IsPostBack)
            {
                string Member_ID = this.Request["Member_ID"];
                getID(Member_ID);
            }
        }

        protected void update(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE Member SET Member_ID = @Member_ID ,Member_Name = @Member_Name, Address = @Address, Date_Of_Birth = @Date_Of_Birth , Gender = @Gender, Work = @Work, Monthly_Income = @Monthly_Income, Email = @Email, No_HP = @No_HP, Password = @Password where Member_ID = @Member_ID";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                string Member_ID = this.Request["Member_ID"];
                cmd.Parameters.Add("@Member_ID", SqlDbType.VarChar, 10).Value = member.Text;
                cmd.Parameters.Add("@Member_Name", SqlDbType.VarChar, 225).Value = memberName.Text;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 225).Value = Address.Text;
                cmd.Parameters.Add("@Date_Of_Birth", SqlDbType.VarChar, 225).Value = Dateof.Text;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 9).Value = Gender.SelectedValue;
                cmd.Parameters.Add("@Work", SqlDbType.VarChar, 225).Value = Work.Text;
                cmd.Parameters.Add("@Monthly_Income", SqlDbType.VarChar, 225).Value = gaji.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200).Value = Email.Text;
                cmd.Parameters.Add("@No_HP", SqlDbType.VarChar, 20).Value = Nohp.Text;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 500).Value = pass.Text;

                int res = cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('update sucses');</script>");
                Response.Write("<script>window.location = 'HomeMember.aspx'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        protected void getID(string Member_ID)
        {
            string sql = "Select * from Member where Member_ID = @Member_ID";
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Member_ID", SqlDbType.VarChar).Value = Member_ID;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                member.Text = dr["Member_ID"].ToString();
                memberName.Text = dr["Member_Name"].ToString();
                Address.Text = dr["Address"].ToString();
                Dateof.Text = dr["Date_Of_Birth"].ToString();
                Gender.SelectedValue = dr["Gender"].ToString();
                Work.Text = dr["Work"].ToString();
                gaji.Text = dr["Monthly_Income"].ToString();
                Email.Text = dr["Email"].ToString();
                Nohp.Text = dr["No_HP"].ToString();
                pass.Text = dr["Password"].ToString();

                conn.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "'); </script>");
            }
        }
    }
}