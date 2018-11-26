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


    public partial class addItem : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        int restarauntId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //set restaraunt id
            restarauntId = Convert.ToInt32(restarauntDropDown.SelectedValue);

            //populating listbox with all items for that restaraunt
            if (!IsPostBack)
            {
                listboxItems.Items.Clear();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    conn.Open();
                    cmd = new SqlCommand("SELECT * FROM MenuItem where R_id=" + restarauntId, conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            ListItem myItem = new ListItem(dr.GetString(0));
                            myItem.Text = dr.GetString(0);
                            listboxItems.Items.Add(myItem);
                        }

                    }

                }
            }
            


        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addItem.aspx");
        }

        //Inserts into database the new item information
        protected void submitButton_Click(object sender, EventArgs e)
        {
            string name = itemTextBox.Text;
            string price = itemPrice.Text;
            string description = itemDescriptionTextArea.InnerText;
            string photo = photoDropDown.SelectedValue;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (name != null && name != "" && price != null && price != "" && description != null && description != "")
                {
                    cmd = new SqlCommand("INSERT INTO MenuItem (Name, Description, Price, Photo, R_id) " +
                        "VALUES (@name, @description, @price, @photo, @R_id)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@photo", photo);
                    cmd.Parameters.AddWithValue("@R_id", restarauntId);

                    cmd.ExecuteNonQuery();
                    itemTextBox.Text = "";
                    photoDropDown.ClearSelection();
                    itemPrice.Text = "";
                    itemDescriptionTextArea.InnerText = "";
                }
            }




        }

        //not currently in use
        protected void EditButton_Click(object sender, EventArgs e)
        {
            string selectedItem = listboxItems.SelectedItem.ToString();
            string sitemName = "";
            string sitemPrice = "";
            string sitemDescription = "";
            string sitemPhoto = "";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (selectedItem != null)
                {
                    cmd = new SqlCommand("SELECT * FROM MenuItem WHERE Name='" + selectedItem + "' AND R_id="+ restarauntId, conn);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            sitemName = dr.GetString(0);
                            sitemDescription = dr.GetString(1);
                            sitemPrice = dr.GetString(2);
                            sitemPhoto = dr.GetString(3);
                        }

                    }
                    
                   
                }
            }
                itemTextBox.Text = sitemName;
                itemPrice.Text = sitemPrice;
                itemDescriptionTextArea.InnerText = sitemDescription;
                photoDropDown.SelectedValue = sitemPhoto;
                photoDropDown.Enabled = false;

        }

        //gets the item that is currently selected and deletes from database
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string selectedItem = listboxItems.SelectedItem.ToString();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (selectedItem != null)
                {
                    cmd = new SqlCommand("DELETE FROM MenuItem WHERE Name='" + selectedItem + "' AND R_id=" + restarauntId , conn);
                    cmd.ExecuteNonQuery();

                }
            }

        }

        //updates welcome message with the textbox message
        protected void updateWelcome_Click(object sender, EventArgs e)
        {
            StringBuilder newMsg = new StringBuilder();
            newMsg.Append(welcomeTextArea.InnerText);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (newMsg != null && newMsg.ToString() !="")
                {
                    cmd = new SqlCommand("UPDATE WebTitles SET MessageText ='" + newMsg.ToString() + "' WHERE r_id=" + restarauntId +" AND MessageType = 'WelcomeMessage'", conn);
                    cmd.ExecuteNonQuery();

                }
            }

        }

        //changes R_id so that all data shown and updated will display the restaraunt selected
        protected void restarauntDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxItems.Items.Clear();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM MenuItem where R_id=" + restarauntId, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem myItem = new ListItem(dr.GetString(0));
                        myItem.Text = dr.GetString(0);
                        listboxItems.Items.Add(myItem);
                    }

                }

            }
        }

        protected void generateReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportPage.aspx");
        }
    }
}