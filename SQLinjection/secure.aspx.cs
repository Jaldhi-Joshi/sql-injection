using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SQLinjection
{
    public partial class secure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection con = new SqlConnection())
            {

                //Parameterised query to stop SQL Injection attempt.

                string query = "select count(email) from dbo.data where email = @email and password = @password";
                con.ConnectionString = ConnectionString;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@email", TextBox1.Text);
                param[1] = new SqlParameter("@password", TextBox2.Text);
                cmd.Parameters.Add(param[0]);
                cmd.Parameters.Add(param[1]);

                object valID = cmd.ExecuteScalar();
                con.Close();
                if (Convert.ToInt32(valID) > 0) Response.Redirect("welcome.aspx");
                else
                 Response.Write("INVALID LOGIN ATTEMPT");
                return;

            }

        }
    }
  }