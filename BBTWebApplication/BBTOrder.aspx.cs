/*
Author: Peter Ngo-Ly
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Customer can order their favourite bubble tea drink and choose a delivery date.
Data validation user can not submit empty fields and the data is validated before submission.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBTWebApplication
{
    public partial class BBTOrder : System.Web.UI.Page
    {
        //SQL connection
        string connectString = null;
        SqlConnection connection;
        SqlCommand command;

        string id;
        int custId;

        ArrayList flavourArray = new ArrayList(); //store bubble tea flavours in this arraylist

        protected void Page_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=LAPTOP-3GQBPP3T\\SQLEXPRESS;Initial Catalog=BubbleTeaDB; " +
                "Integrated Security=SSPI; " +
                "Persist Security Info=false";
            connection = new SqlConnection(connectString);

            sqlErrorLabel.Visible = false;
            customerDataLabel.Visible = false;
            receiptDataLabel.Visible = false;

            //grab session variables
            string custName = (string)(Session["CustNameKey"]);
            string address = (string)(Session["AddressKey"]);
            string postCode = (string)(Session["PostCodeKey"]);
            string phone = (string)(Session["PhoneKey"]);
            id = (string)(Session["CustIdKey"]);
            custId = int.Parse(id);

            //use service for getting customer information and outputting it appropriately
            ServiceReference2.Service2Client client = new ServiceReference2.Service2Client();
            string result = client.GetCustomerInfo(custName, address, postCode, phone);

            customerDataLabel.Text = result;
            customerDataLabel.Visible = true;

            //try to open connection
            try
            {
                connection.Open();
                string queryString = "SELECT * FROM dbo.BubbleTea";
                command = new SqlCommand(queryString, connection);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    //purpose of this arraylist is once a flavour is added, the BubbleTeaId = index located + 1
                    flavourArray.Add(reader["Flavour"].ToString()); //add flavour to array list
                }
            }
            //catch any errors (SQLException)
            catch (SqlException ex)
            {
                sqlErrorLabel.Visible = true;
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

        //submit order to generate receipt
        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //try to open connection
                try
                {
                    //find price of flavour
                    connection.Open();
                    string queryString = "SELECT * FROM dbo.BubbleTea WHERE Flavour=@flavour";
                    command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@flavour", flavourBox.Text);

                    SqlDataReader reader = command.ExecuteReader();

                    double price = 0.0;

                    if (reader.Read())
                    {
                        price = double.Parse(reader["Price"].ToString()); //store price into variable
                        connection.Close();
                        connection.Open();
                    }

                    //find employee to process order
                    queryString = "SELECT * FROM dbo.Employees";
                    command = new SqlCommand(queryString, connection);
                    int employeeId = 1;

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employeeId = int.Parse(reader["EmpId"].ToString()); //store empid into variable
                        connection.Close();
                        connection.Open();
                    }

                    //query will insert a record
                    command = new SqlCommand("INSERT INTO dbo.Receipts VALUES (@date,@totalprice,@custid,@empid,@bubbleteaid)"
                        , connection);

                    //find BubbleTeaId
                    int bubbleTeaId = flavourArray.IndexOf(flavourBox.Text) + 1;

                    //find total price
                    double totalPrice = 0.0;
                    //find total price, if jelly added then + 0.50
                    if (jellyBox.Text == "Yes")
                    {
                        totalPrice = price + 0.5;
                    }
                    else
                    {
                        totalPrice = price;
                    }
                    
                    //add the parameters into the command
                    command.Parameters.AddWithValue("@date", dateBox.Text);
                    command.Parameters.AddWithValue("@totalprice", totalPrice);
                    command.Parameters.AddWithValue("@custid", custId);
                    command.Parameters.AddWithValue("@empid", employeeId);
                    command.Parameters.AddWithValue("@bubbleteaid", bubbleTeaId);

                    int r = command.ExecuteNonQuery();

                    //use service for getting receipt information and outputting it appropriately
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    string result = client.GetReceiptInfo(flavourBox.Text, iceBox.Text, sugarBox.Text, jellyBox.Text, totalPrice);

                    receiptDataLabel.Text = result;
                    receiptDataLabel.Visible = true;
                }
                //catch any errors (SQLException)
                catch (SqlException ex)
                {
                    sqlErrorLabel.Visible = true;
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
        }

        //redirect to another page of order history made by customer
        protected void historyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOrderHistory.aspx");
        }

        //back button
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerSignIn.aspx");
        }    
    }
}