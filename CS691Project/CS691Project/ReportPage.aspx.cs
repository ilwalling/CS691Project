using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", conn))
                {
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    
                    ada.Fill(dt);
                    conn.Close();
                }
                OrderReport or = new OrderReport();
                or.SetDataSource(dt);
                CrystalReportViewer1.ReportSource = or;
                CrystalReportViewer1.RefreshReport();
            }
            }
    }
}