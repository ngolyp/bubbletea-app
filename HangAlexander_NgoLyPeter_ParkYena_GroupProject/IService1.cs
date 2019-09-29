/*
Author: Alexander Hang
Project: Bubble Tea Web Application
Course: PROG37721 Web Services Using .NET & C# Programming
Due Date: August 13, 2019
Description: Service that prints out receipt details of the customer
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HangAlexander_NgoLyPeter_ParkYena_GroupProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //method to get the receipt details
        [OperationContract]
        string GetReceiptInfo(string flavour, string ice, string sugar, string jelly, double price);
    }

    //Receipt class
    [DataContract]
    public class Receipt
    {
        [DataMember]
        public string flavour { get; set; }
        public string ice { get; set; }
        public string sugar { get; set; }
        public string jelly { get; set; }
        public double price { get; set; }
        public double totalPrice { get; set; }
    }
}
