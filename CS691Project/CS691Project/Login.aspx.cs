using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CS691Project
{
    public partial class Login : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter ada = new SqlDataAdapter();
        SqlDataReader dr;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            


              
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();

                if (username != null && username != "" && password != null && password != "")
                {
                    cmd = new SqlCommand("SELECT * FROM Login where Username='" + username + "' and Password='" + password + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        Response.Redirect("addItem.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "alert('Invalid Password')", true);
                    }
                }
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}