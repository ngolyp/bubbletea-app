/*
Author: Peter Ngo-Ly
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Service that prints employee information
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HangAlexander_NgoLyPeter_ParkYena_GroupProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service3" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service3.svc or Service3.svc.cs at the Solution Explorer and start debugging.
    public class Service3 : IService3
    {
        public string GetEmployeeInfo(string name, string address, string postcode, string phone)
        {
            Employee employee = new Employee();
            employee.name = name;
            employee.address = address;
            employee.postcode = postcode;
            employee.phone = phone;

            string employeeInfo = "Welcome! <br>"
                + "Name: " + employee.name + "<br>"
                + "Address: " + employee.address + "<br>"
                + "Postal Code: " + employee.postcode + "<br>"
                + "Phone: " + employee.phone;

            return employeeInfo;
        }
    }
}
