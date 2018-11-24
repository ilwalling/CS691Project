using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS691Project
{
    public partial class Contact : Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder htmlCode = new StringBuilder();
            int restarauntId = Convert.ToInt32(restarauntDropDown.SelectedValue);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (cmd = new SqlCommand("SELECT * FROM MenuItem WHERE R_id=" + restarauntId, conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    htmlCode.Append("<table width='90%' bgcolor='#474444'><tr><th></th><th>Name</th><th>Price</th><th>Description</th></tr>");
                    string name = row["Name"].ToString().Trim();
                    string price = row["Price"].ToString().Trim();
                    string description = row["Description"].ToString().Trim();
                    string photo = row["Photo"].ToString().Trim();

                    htmlCode.Append("<tr style='border:1px solid black; padding:20px'><th style='padding:15px'><img src='");
                    htmlCode.Append(photo);
                    htmlCode.Append("' width='40%'/></th><th style='padding:15px'>");
                    htmlCode.Append(name);
                    htmlCode.Append("</th><th style='padding:15px'>");
                    htmlCode.Append(price);
                    htmlCode.Append("</th><th style='padding:15px'>");
                    htmlCode.Append(description);
                    htmlCode.Append("</th></tr>");
                }

                htmlCode.Append("</table>");
                dynamicContent.Controls.Add(new LiteralControl(htmlCode.ToString()));
                

            }




        }
    }
}