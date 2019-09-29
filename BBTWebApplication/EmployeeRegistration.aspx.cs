/*
Author: Alexander Hang
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Data validation must pass correct data and can not be empty.
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
    public partial class EmployeeRegistration : System.Web.UI.Page
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
            successLabel.Visible = false;
        }

        //submit employee information
        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //try to open connection
                try
                {
                    connection.Open();
                    //query will insert a record
                    command = new SqlCommand("INSERT INTO dbo.Employees VALUES (@username,@password,@name,@address,@postcode,@phone)"
                        , connection);

                    //add the parameters into the command
                    command.Parameters.AddWithValue("@username", usernameBox.Text);
                    command.Parameters.AddWithValue("@password", passwordBox.Text);
                    command.Parameters.AddWithValue("@name", nameBox.Text);
                    command.Parameters.AddWithValue("@address", addressBox.Text);
                    command.Parameters.AddWithValue("@postcode", postalcodeBox.Text);
                    command.Parameters.AddWithValue("@phone", phoneBox.Text);

                    int r = command.ExecuteNonQuery();

                    successLabel.Visible = true;
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

        //back button
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeSignIn.aspx");
        }
    }
}