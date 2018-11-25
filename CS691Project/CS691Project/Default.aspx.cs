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
        DataTable dt = new DataTable();
        string companyName;
        string welcomeMessage;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int restarauntId = Convert.ToInt32(restarauntDropDown.SelectedValue);
            StringBuilder htmlCode = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                
                
                using (cmd = new SqlCommand("SELECT * FROM WebTitles WHERE R_id=" + restarauntId, conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }
                
                foreach(DataRow row in dt.Rows)
                {
                    if(row["MessageType"].ToString().Trim() == "CompanyName")
                    {
                        companyName = row["MessageText"].ToString();
                    }
                    if (row["MessageType"].ToString().Trim() == "WelcomeMessage")
                    {
                        welcomeMessage = row["MessageText"].ToString();
                    }
                }
                      
                        htmlCode.Append("<h1 style='color: lawngreen' class='typewriter'>");
                        htmlCode.Append(companyName);
                        htmlCode.Append("");
                        htmlCode.Append("<h3 id='welcomeMsg' style='color: white'>");
                        htmlCode.Append(welcomeMessage);
                        htmlCode.Append("</h3>");
              
                    dynamicContent.Controls.Add(new LiteralControl(htmlCode.ToString()));
                    
   

            }

        }
    }
}