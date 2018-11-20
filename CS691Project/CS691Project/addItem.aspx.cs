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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listboxItems.Items.Clear();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    conn.Open();
                    cmd = new SqlCommand("SELECT * FROM MenuItem", conn);
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
                    cmd = new SqlCommand("INSERT INTO MenuItem (Name, Description, Price, Photo) " +
                        "VALUES (@name, @description, @price, @photo)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@photo", photo);

                    cmd.ExecuteNonQuery();
                    itemTextBox.Text = "";
                    photoDropDown.ClearSelection();
                    itemPrice.Text = "";
                    itemDescriptionTextArea.InnerText = "";
                }
            }




        }

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
                    cmd = new SqlCommand("SELECT * FROM MenuItem WHERE Name='" + selectedItem + "'", conn);
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

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string selectedItem = listboxItems.SelectedItem.ToString();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (selectedItem != null)
                {
                    cmd = new SqlCommand("DELETE FROM MenuItem WHERE Name='" + selectedItem + "'", conn);
                    cmd.ExecuteNonQuery();

                }
            }

        }

        protected void updateWelcome_Click(object sender, EventArgs e)
        {
            StringBuilder newMsg = new StringBuilder();
            newMsg.Append(welcomeTextArea.InnerText);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                if (newMsg != null && newMsg.ToString() !="")
                {
                    cmd = new SqlCommand("UPDATE WelcomeMessage SET WelcomeText ='" + newMsg.ToString() + "' WHERE Id=0", conn);
                    cmd.ExecuteNonQuery();

                }
            }

        }
    }
}