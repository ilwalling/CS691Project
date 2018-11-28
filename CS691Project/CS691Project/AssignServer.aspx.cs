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
    public partial class AssignServer : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        int restarauntId;
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        string customerId;

        //grabs data from database and loads servers into server dropdown and loads menu orders into order listboxes
        protected void Page_Load(object sender, EventArgs e)
        {
            restarauntId = Convert.ToInt32(restarauntDropDown.SelectedValue);
            if (!IsPostBack)
            {
                serverDropDownList.Items.Clear();
                orderListBox.Items.Clear();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    using (cmd = new SqlCommand("SELECT * FROM Orders WHERE R_id=" + restarauntId, conn))
                    {
                        ada = new SqlDataAdapter(cmd);
                        conn.Open();
                        ada.Fill(dt);
                        conn.Close();
                    }

                    using (cmd = new SqlCommand("SELECT * FROM Waiters WHERE R_id=" + restarauntId, conn))
                    {
                        ada = new SqlDataAdapter(cmd);
                        conn.Open();
                        ada.Fill(dt1);
                        conn.Close();
                    }

                    foreach (DataRow row in dt.Rows)
                    {

                        if(row["WaiterName"].ToString().Trim() == "")
                        {
                            ListItem myItem = new ListItem(row["OrderTime"].ToString().Trim());
                            myItem.Value = row["OrderTime"].ToString().Trim();
                            orderListBox.Items.Add(myItem);
                        }
                        else
                        {
                            ListItem myItem = new ListItem(row["OrderTime"].ToString().Trim());
                            myItem.Value = row["OrderTime"].ToString().Trim();
                            orderAssignedListBox.Items.Add(myItem);
                        }
                        
                    }
                    foreach (DataRow row in dt1.Rows)
                    {
                        ListItem myItem = new ListItem(row["Name"].ToString().Trim());
                        myItem.Value = row["Name"].ToString().Trim();
                        serverDropDownList.Items.Add(myItem);
                    }
                }

                orderStatusDropDownStatus.Items.Add("Received");
                orderStatusDropDownStatus.Items.Add("In Preperation");
                orderStatusDropDownStatus.Items.Add("Adding Final Touch");
                orderStatusDropDownStatus.Items.Add("On The Way");
                orderStatusDropDownStatus.Items.Add("Complete");
            }
        }

        //updates order to add the servers name
        protected void assignButton_Click(object sender, EventArgs e)
        {
            string selectedOrder;
            if (orderListBox.SelectedItem != null)
            {
                selectedOrder = orderListBox.SelectedItem.Text;
            }
            else
            {
                selectedOrder = orderAssignedListBox.SelectedItem.Text;
            }
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (selectedOrder != null && selectedOrder.ToString() != "")
                {
                    cmd = new SqlCommand("UPDATE Orders SET WaiterName ='" + serverDropDownList.SelectedValue.ToString() + "', Status = '"+ orderStatusDropDownStatus.SelectedValue +"' WHERE r_id=" + restarauntId + " AND OrderTime = '"+selectedOrder+"'", conn);
                    cmd.ExecuteNonQuery();

                }
            }


        }

        //changes restaraunt and displays information for selected restaraunt
        protected void restarauntDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            serverDropDownList.Items.Clear();
            orderListBox.Items.Clear();
            orderAssignedListBox.Items.Clear();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (cmd = new SqlCommand("SELECT * FROM Orders WHERE R_id=" + restarauntId +" AND WaiterName IS NULL", conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }

                using (cmd = new SqlCommand("SELECT * FROM Waiters WHERE R_id=" +restarauntId, conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt1);
                    conn.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    ListItem myItem = new ListItem(row["OrderTime"].ToString().Trim());
                    myItem.Value = row["OrderTime"].ToString().Trim();
                    orderListBox.Items.Add(myItem);
                }
                foreach (DataRow row in dt1.Rows)
                {
                    ListItem myItem = new ListItem(row["Name"].ToString().Trim());
                    myItem.Value = row["Name"].ToString().Trim();
                    serverDropDownList.Items.Add(myItem);
                }
            }
            orderStatusDropDownStatus.Items.Add("Received");
            orderStatusDropDownStatus.Items.Add("In Preperation");
            orderStatusDropDownStatus.Items.Add("Adding Final Touch");
            orderStatusDropDownStatus.Items.Add("On The Way");
            orderStatusDropDownStatus.Items.Add("Complete");

        }

        //populates text fields to show order details
        protected void orderAssignedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderListBox.ClearSelection();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (cmd = new SqlCommand("SELECT * FROM Orders WHERE R_id=" + restarauntId, conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (row["OrderTime"].ToString().Trim() == orderAssignedListBox.SelectedValue.ToString().Trim())
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

        //populates text fields to show order details
        protected void orderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderAssignedListBox.ClearSelection();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (cmd = new SqlCommand("SELECT * FROM Orders WHERE R_id=" + restarauntId, conn))
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