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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService3" in both code and config file together.
    [ServiceContract]
    public interface IService3
    {
        //method to get the employee details
        [OperationContract]
        string GetEmployeeInfo(string name, string address, string postcode, string phone);
    }

    //Customer class
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string name { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string phone { get; set; }
    }
}
