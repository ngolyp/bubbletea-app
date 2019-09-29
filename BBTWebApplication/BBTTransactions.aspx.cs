/*
Author: Alexander Hang
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Employee can view all transaction to date. Employee can edit and delete any invalid transaction.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBTWebApplication
{
    public partial class BBTTransactions : System.Web.UI.Page
    {
        //SQL connection
        string connectString = null;
        SqlConnection connection;
        SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=LAPTOP-3GQBPP3T\\SQLEXPRESS;Initial Catalog=BubbleTeaDB; " +
                "Integrated Security=SSPI; " +
                "Persist Security Info=false";
            connection = new SqlConnection(connectString);

            sqlErrorLabel.Visible = false;
            employeeDataLabel.Visible = false;
            pleaseSelectLabel.Visible = false;
            receiptIdLabel.Visible = false;

            //grab session variables
            string empName = (string)(Session["EmpNameKey"]);
            string address = (string)(Session["AddressKey"]);
            string postCode = (string)(Session["PostCodeKey"]);
            string phone = (string)(Session["PhoneKey"]);

            //use service for getting employee information and outputting it appropriately
            ServiceReference3.Service3Client client = new ServiceReference3.Service3Client();
            string result = client.GetEmployeeInfo(empName, address, postCode, phone);

            employeeDataLabel.Text = result;
            employeeDataLabel.Visible = true;
        }
                 
        //show all receipts
        protected void showAllButton_Click(object sender, EventArgs e)
        {
            //try to open connection
            try
            {
                this.outputBox.Items.Clear();

                connection.Open();
                //requires inner join since bubble tea information in BubbleTea table
                string queryString = "SELECT * FROM dbo.Receipts r INNER JOIN dbo.BubbleTea b ON r.BubbleTeaId = b.BubbleTeaId";
                command = new SqlCommand(queryString, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //convert each col value for the record to string
                    this.outputBox.Items.Add(reader["ReceiptId"].ToString()
                        + "," + reader["Date"].ToString()
                        + "," + reader["Flavour"].ToString()
                        + "," + reader["TotalPrice"].ToString());
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

        //edit a receipt
        protected void editButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid) //user must have selected a record to edit and passes all validation checks
            {
                //try to open connection
                try
                {
                    if (outputBox.SelectedIndex != -1)
                    {
                        connection.Open();

                        //first part of select statement will find the BubbleTeaId based on the bubble tea option selected
                        string queryString = "SELECT * FROM dbo.BubbleTea WHERE Flavour=@flavour";
                        command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@flavour", flavourBox.Text);

                        SqlDataReader reader = command.ExecuteReader();

                        int bubbleTeaId = 0;

                        if (reader.Read())
                        {
                            bubbleTeaId = int.Parse(reader["BubbleTeaId"].ToString()); //store BubbleTeaId into variable
                            connection.Close();
                            connection.Open();
                        }

                        queryString = "UPDATE dbo.Receipts SET Date=@date, " +
                            "BubbleTeaId=@bubbleteaid, TotalPrice=@totalprice WHERE ReceiptId=@receiptid";
                        command = new SqlCommand(queryString, connection);

                        //add the parameters into the command
                        command.Parameters.AddWithValue("@date", dateBox.Text);
                        command.Parameters.AddWithValue("@bubbleteaid", bubbleTeaId);
                        command.Parameters.AddWithValue("@totalprice", totalPriceBox.Text);
                        command.Parameters.AddWithValue("@receiptid", receiptIdLabel.Text);

                        int r = command.ExecuteNonQuery();
                    }
                    //explain to user to select a record to edit
                    else
                    {
                        pleaseSelectLabel.Visible = true;
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
            //explain to user to select a record to edit
            else
            {
                pleaseSelectLabel.Visible = true;
            }
        }

        //delete a receipt
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                //try to open connection
                try
                {
                    //user must have selected a record to delete
                    if (outputBox.SelectedIndex != -1)
                    {
                        connection.Open();

                        //query will find the record with the criteria listed and delete it from the table
                        command = new SqlCommand("DELETE FROM dbo.Receipts WHERE ReceiptId=@receiptid", connection);
                        //add the parameters into the command
                        command.Parameters.AddWithValue("@receiptid", receiptIdLabel.Text);

                        int r = command.ExecuteNonQuery();

                        outputBox.Items.RemoveAt(outputBox.SelectedIndex);
                        receiptIdLabel.Visible = false;
                        dateBox.Text = "";
                        totalPriceBox.Text = "";
                    }
                    //explain to user to select a record to remove
                    else
                    {
                        pleaseSelectLabel.Visible = true;
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
            //explain to user to select a record to edit
            else
            {
                pleaseSelectLabel.Visible = true;
            }
        }

        //changes the textboxes according to selected record
        protected void outputBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputBox.SelectedIndex != -1)
            {
                string record = outputBox.SelectedItem.ToString(); //get the record line and store as char array
                string[] delimiter = { "," }; //delimiter options

                string[] recordParts = record.Split(delimiter, StringSplitOptions.RemoveEmptyEntries); //split the record into parts

                this.receiptIdLabel.Text = recordParts[0];
                this.dateBox.Text = recordParts[1];
                this.flavourBox.Text = recordParts[2];
                this.totalPriceBox.Text = recordParts[3];

                receiptIdLabel.Visible = true;
            }
        }

        //back button
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeSignIn.aspx");
        }
    }
}