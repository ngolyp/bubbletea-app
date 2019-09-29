/*
Author: Yena Park
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Service that prints customer information
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HangAlexander_NgoLyPeter_ParkYena_GroupProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        public string GetCustomerInfo(string name, string address, string postcode, string phone)
        {
            Customer customer = new Customer();
            customer.name = name;
            customer.address = address;
            customer.postcode = postcode;
            customer.phone = phone;

            string customerInfo = "Welcome! <br>"
                + "Name: " + customer.name + "<br>"
                + "Address: " + customer.address + "<br>"
                + "Postal Code: " + customer.postcode + "<br>"
                + "Phone: " + customer.phone;

            return customerInfo;
        }
    }
}
