using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS691Project
{
    public partial class _Default : Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter ada = new SqlDataAdapter();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder htmlCode = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM WelcomeMessage", conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    htmlCode.Append("<h3 id='welcomeMsg' style='color: white'>");

                    while (dr.Read())
                    {
                        
                        string welcomeMessage = dr.GetString(1);
                        htmlCode.Append(welcomeMessage);
                        




                    }
                    htmlCode.Append("</h3>");
                    dynamicMessage.Controls.Add(new LiteralControl(htmlCode.ToString()));
                    dr.Close();




                }

            }

        }
    }
}