/*
Author: Yena Park
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Welcome page where you can select whether you are an employee or customer.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBTWebApplication
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //redirect to employee sign in page
        protected void employeeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeSignIn.aspx");
        }

        //redirect to customer sign in page
        protected void customerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerSignIn.aspx");
        }
    }
}