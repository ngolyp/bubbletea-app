/*
Author: Peter Ngo-Ly
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Customer can view their previous order / receipt.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBTWebApplication
{
    public partial class CustomerOrderHistory : System.Web.UI.Page
    {
        //global declarations
        string connectString = null;
        SqlConnection connection;
        SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=LAPTOP-3GQBPP3T\\SQLEXPRESS;Initial Catalog=BubbleTeaDB; " +
                "Integrated Security=SSPI; " +
                "Persist Security Info=false";
            connection = new SqlConnection(connectString);

            //grab session variables
            int custId = int.Parse((string)(Session["CustIdKey"]));
            string custName = (string)(Session["CustNameKey"]);

            Response.Write("<b>" + custName + "'s Order History: </b>");

            //try to open connection
            try
            {
                connection.Open();
                string queryString = "SELECT * FROM dbo.Receipts WHERE CustId=@custid";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@custid", custId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //display order information
                    Response.Write("<br><br>ReceiptId: " + reader["ReceiptId"].ToString());
                    Response.Write("<br>Date: " + reader["Date"].ToString());
                    Response.Write("<br>Total Price: $" + reader["TotalPrice"].ToString());
                    Response.Write("<br>EmpId: " + reader["EmpId"].ToString());
                    Response.Write("<br>BubbleTeaId: " + reader["BubbleTeaId"].ToString());
                }

            }
            //catch any errors (SQLException)
            catch (SqlException ex)
            {
                Response.Write("Opps, something went wrong. Please try again.");
            }
            //close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        //back button
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("BBTOrder.aspx");
        }
    }
}