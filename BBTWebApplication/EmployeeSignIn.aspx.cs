/*
Author: Alexander Hang
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Employee can log in to their account using their credentials. 
Data validation must pass correct data and can not be empty.
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
    public partial class EmployeeSignIn : System.Web.UI.Page
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

            userpassErrorLabel.Visible = false;
            sqlErrorLabel.Visible = false;
            askManagerLabel.Visible = false;
        }

        //try to log into employee account
        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //try to open connection
                try
                {
                    connection.Open();
                    string queryString = "SELECT * FROM dbo.Employees WHERE EmpUser=@empuser AND EmpPass=@emppass";
                    command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@empuser", usernameBox.Text);
                    command.Parameters.AddWithValue("@emppass", passwordBox.Text);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //creating a session with session variables
                        Session["EmpNameKey"] = reader["EmpName"].ToString();
                        Session["AddressKey"] = reader["Address"].ToString();
                        Session["PostCodeKey"] = reader["PostCode"].ToString();
                        Session["PhoneKey"] = reader["Phone"].ToString();
                        Response.Redirect("BBTTransactions.aspx");
                    }

                    else
                    {
                        userpassErrorLabel.Visible = true;
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
        }

        //redirects to registration page
        protected void newEmployeeButton_Click(object sender, EventArgs e)
        {
            //must use admin privilges to insert a new employee into the system
            if(usernameBox.Text == "admin" && passwordBox.Text == "admin")
            {
                Response.Redirect("EmployeeRegistration.aspx");
            }
            //inform new employee to ask for manager to help set up employee account
            else
            {
                askManagerLabel.Visible = true;
            }
        }

        //back button
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}