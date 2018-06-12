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
    public partial class Login : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save(object sender, EventArgs e)
        {
            string str = "Select * from Member where Member_ID = @Member_ID and Password = @Password";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(str, con);

            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@Member_ID", Username.Text);
                cmd.Parameters.AddWithValue("@Password", pass.Text);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Session["Member_ID"] = Username.Text;
                    HttpCookie LoginCookies = new HttpCookie("LoginCookies");

                    LoginCookies.Value = Username.Text;
                    LoginCookies.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(LoginCookies);
                    Response.Redirect("HomeMember.aspx");
                }
                else
                {
                    lbl_error.Text = "Username atau Password Salah !";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br/>" + ex.StackTrace);

            }
            finally
            {
                con.Close();
            }
        }
    }
    
}