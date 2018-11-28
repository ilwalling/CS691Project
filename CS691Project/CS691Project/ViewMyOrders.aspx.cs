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
    public partial class ViewMyOrders : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        int restarauntId;
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string customerId;
        HttpCookie nameCookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nameCookie = Request.Cookies["Name"];
                customerId = Server.HtmlEncode(nameCookie.Value);
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    using (cmd = new SqlCommand("SELECT * FROM Orders", conn))
                    {
                        ada = new SqlDataAdapter(cmd);
                        conn.Open();
                        ada.Fill(dt);
                        conn.Close();
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["CustomerUsername"].ToString().Trim() == customerId)
                        {
                            ListItem myItem = new ListItem(row["OrderTime"].ToString().Trim());
                            myItem.Value = row["OrderTime"].ToString().Trim();
                            orderListBox.Items.Add(myItem);
                        }

                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["OrderTime"].ToString().Trim() == orderListBox.SelectedValue.ToString().Trim())
                        {
                            customerIdTextbox.Text = row["CustomerUsername"].ToString().Trim();
                            menuItemsTextBox.Text = row["MenuItems"].ToString().Trim();
                            waiterNameTextBox.Text = row["WaiterName"].ToString().Trim();
                            orderStatusDropDownStatus.SelectedValue = row["Status"].ToString().Trim();
                            tipTextBox.Text = row["Tip"].ToString().Trim();
                        }

                    }
                }
                orderStatusDropDownStatus.Items.Add("Received");
                orderStatusDropDownStatus.Items.Add("In Preperation");
                orderStatusDropDownStatus.Items.Add("Adding Final Touch");
                orderStatusDropDownStatus.Items.Add("On The Way");
                orderStatusDropDownStatus.Items.Add("Complete");

            }
        }

        protected void orderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (cmd = new SqlCommand("SELECT * FROM Orders", conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (row["OrderTime"].ToString().Trim() == orderListBox.SelectedValue.ToString().Trim())
                    {
                        customerIdTextbox.Text = row["CustomerUsername"].ToString().Trim();
                        menuItemsTextBox.Text = row["MenuItems"].ToString().Trim();
                        waiterNameTextBox.Text = row["WaiterName"].ToString().Trim();
                        orderStatusDropDownStatus.SelectedValue = row["Status"].ToString().Trim();
                        tipTextBox.Text = row["Tip"].ToString().Trim();
                    }

                }
            }
        }
    }
}