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
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            


              
            
        }

        //checks to see if the username and pasword are a match, then redirects the user based on their position
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            HttpCookie cookName = new HttpCookie("Name");
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                

                if (username != null && username != "" && password != null && password != "")
                {
                    using (cmd = new SqlCommand("SELECT * FROM Login where Username='" + username + "' and Password='" + password + "'", conn))
                    {
                        ada = new SqlDataAdapter(cmd);
                        conn.Open();
                        ada.Fill(dt);
                        conn.Close();
                    }

                    if (dt.Rows.Count >= 1)
                    {
                        
                        foreach (DataRow row in dt.Rows)
                        {
                            
                            cookName.Value = username;
                            Response.Cookies.Add(cookName);
                            if (row["Position"].ToString().Trim() == "Owner")
                            {
                                
                                Response.Redirect("addItem.aspx");
                            }
                            else if(row["Position"].ToString().Trim() == "Customer")
                            {
                                Response.Redirect("BuildCart.aspx");
                            }
                            else if (row["Position"].ToString().Trim() == "Director")
                            {
                                Response.Redirect("AssignServer.aspx");
                            }
                        }
                        
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