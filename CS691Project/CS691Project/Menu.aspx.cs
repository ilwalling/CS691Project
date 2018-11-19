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
        SqlDataReader dr;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder htmlCode = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM MenuItem", conn);
                dr = cmd.ExecuteReader();
                
                if (dr.HasRows == true)
                {
                    htmlCode.Append("<table width='90%' bgcolor='#474444'><tr><th></th><th>Name</th><th>Price</th><th>Description</th></tr>");

                    while (dr.Read())
                    {
                        string itemName = dr.GetString(0);
                        string itemDescription = dr.GetString(1);
                        string itemPrice = dr.GetString(2);
                        string itemPhoto = dr.GetString(3);
                        htmlCode.Append("<tr style='border:1px solid black; padding:20px'><th style='padding:15px'><img src='");
                        htmlCode.Append(itemPhoto);
                        htmlCode.Append("' width='60%'/></th><th style='padding:15px'>");
                        htmlCode.Append(itemName);
                        htmlCode.Append("</th><th style='padding:15px'>");
                        htmlCode.Append(itemPrice);
                        htmlCode.Append("</th><th style='padding:15px'>");
                        htmlCode.Append(itemDescription);
                        htmlCode.Append("</th></tr>");

                        //htmlCode.Append("<div Width='90%' BackColor='#474444'>");
                        //htmlCode.Append("< br />");
                        //htmlCode.Append("< div style = 'float:left; width:20%; overflow-y:hidden' >");
                        //htmlCode.Append("< img src = 'Images/pizza.jpg' width = '100%'/>");
                        //htmlCode.Append("</ div >");
                        //htmlCode.Append("< div style = 'width:70%' >");
                        //htmlCode.Append("< h3 style = 'color:lawngreen' > The 3A.M.Group Project Meeting </ h3 >");
                        //htmlCode.Append("< p style = 'color:white' > A large 12 peperroni pizza made to feed a group of 3.Enjoy this with a 2 liter of your favorite soft drink to keep the group working.Ingredients: Cheese, Pepperoni, Wheat </ p >");
                        //htmlCode.Append("</ div >");
                        //htmlCode.Append("< div style = 'float:right; width:10%' >< p style = 'color:white'>00010000</p></div>");
                        //htmlCode.Append("< br />");
                        //htmlCode.Append("< br />");
                        //htmlCode.Append("</ div >");




                    }
                    htmlCode.Append("</table>");
                    dynamicContent.Controls.Add(new LiteralControl(htmlCode.ToString()));
                    dr.Close();




                }

            }




        }
    }
}