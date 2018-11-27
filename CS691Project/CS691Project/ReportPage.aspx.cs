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
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DateTime weekCutoff = new DateTime();
                weekCutoff = DateTime.Now;
                weekCutoff = weekCutoff.AddDays(-7);
                string sWeekCutoff = weekCutoff.ToString();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE OrderTime > '" +sWeekCutoff +"'", conn))
                {
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM Waiters", conn))
                {
                    SqlDataAdapter ada1 = new SqlDataAdapter(cmd1);
                    conn.Open();
                    ada1.Fill(dt1);
                    conn.Close();
                }

                StringBuilder str = new StringBuilder();
                str.Append("<table >");
                str.Append("<tr><td>Order Time</td><td>Menu Items</td><td>Restaraunt Id</td><td>Customer Username</td><td>Waiter Name</td></tr>");
                foreach(DataRow row in dt.Rows)
                {
                    string orderTime = row["OrderTime"].ToString().Trim();
                    string menuItems = row["MenuItems"].ToString().Trim();
                    string R_id = row["R_id"].ToString().Trim();
                    string customerUsername = row["CustomerUsername"].ToString().Trim();
                    string waiterName = row["WaiterName"].ToString().Trim();

                    str.Append("<tr><td style='border:1px solid black'>" + orderTime +"</td>");
                    str.Append("<td style='border:1px solid black'>" + menuItems + "</td>");
                    str.Append("<td style='border:1px solid black'>" + R_id + "</td>");
                    str.Append("<td style='border:1px solid black'>" + customerUsername + "</td>");
                    str.Append("<td style='border:1px solid black'>" + waiterName + "</td>");
                    str.Append("</tr>");
                }
                str.Append("</table>");
                dynamicContent.Controls.Add(new LiteralControl(str.ToString()));
            }
            }
    }
}