﻿using System;
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
    public partial class BuildCart : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        int restarauntId;
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string customerId;
        HttpCookie nameCookie;

        //populates checkboxlist to show menu items for selected restaraunt
        protected void Page_Load(object sender, EventArgs e)
        {
            restarauntId = Convert.ToInt32(restarauntDropDown.SelectedValue);
            nameCookie = Request.Cookies["Name"];
            customerId = Server.HtmlEncode(nameCookie.Value);
            if (!IsPostBack)
            {
                checkBoxMenuItems.Items.Clear();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    using (cmd = new SqlCommand("SELECT * FROM MenuItem WHERE R_id=" + restarauntId, conn))
                    {
                        ada = new SqlDataAdapter(cmd);
                        conn.Open();
                        ada.Fill(dt);
                        conn.Close();
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        ListItem myItem = new ListItem(row["Name"].ToString().Trim());
                        myItem.Value = row["Name"].ToString().Trim();
                        checkBoxMenuItems.Items.Add(myItem);
                    }
                }
            }
               
        }

        //builds string of selected items and stores menu items, time, restaraunt id, and username in order database
        protected void submitButton_Click(object sender, EventArgs e)
        {
            string itemsSelected="";
            for (int i = 0; i < checkBoxMenuItems.Items.Count; i++)
            {
                if (checkBoxMenuItems.Items[i].Selected)
                {
                    if (itemsSelected == "")
                    {
                        itemsSelected += checkBoxMenuItems.Items[i].Value;
                    }
                    else
                    {
                        itemsSelected += ", " + checkBoxMenuItems.Items[i].Value;
                    }
                }
            }


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                
                cmd = new SqlCommand("INSERT INTO Orders (OrderTime, MenuItems, R_id, CustomerUsername,Tip) " +
                    "VALUES (@date, @items, @R_id, @C_username, @tip)", conn);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@items", itemsSelected);
                cmd.Parameters.AddWithValue("@R_id", restarauntId);
                cmd.Parameters.AddWithValue("@C_username", customerId);
                if(int.TryParse(tipTextbox.Text, out int n))
                {
                    cmd.Parameters.AddWithValue("@tip", Convert.ToInt32(tipTextbox.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@tip", 0);
                }
                

                cmd.ExecuteNonQuery();
                checkBoxMenuItems.ClearSelection();
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //changes restaraunt and updates with restaraunt information
        protected void restarauntDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxMenuItems.Items.Clear();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                using (cmd = new SqlCommand("SELECT * FROM MenuItem WHERE R_id=" + restarauntId, conn))
                {
                    ada = new SqlDataAdapter(cmd);
                    conn.Open();
                    ada.Fill(dt);
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    ListItem myItem = new ListItem(row["Name"].ToString().Trim());
                    myItem.Value = row["Name"].ToString().Trim();
                    checkBoxMenuItems.Items.Add(myItem);
                }
            }

        }

        protected void viewOrders_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(nameCookie);
            Response.Redirect("ViewMyOrders.aspx");
        }
    }
}