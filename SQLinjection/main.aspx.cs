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
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection c = new SqlConnection())
            {
                //Basic Login query where the website is vulnerable to sql injection

                string query = "Select count(email) from dbo.data where email = '" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'";

                c.ConnectionString = ConnectionString;
                SqlCommand cmd = new SqlCommand(query, c);
                c.Open();
                object valID = cmd.ExecuteScalar();
                if (Convert.ToInt32(valID) > 0) Response.Redirect("welcome.aspx");

                else
                {
                   
                    Response.Write("INVALID LOGIN ATTEMPT");
                    c.Close();
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("secure.aspx");
        }
    }
}
