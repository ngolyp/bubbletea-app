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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetReceiptInfo(string flavour, string ice, string sugar, string jelly, double price)
        {
            Receipt receipt = new Receipt();
            receipt.flavour = flavour;
            receipt.ice = ice;
            receipt.sugar = sugar;
            receipt.jelly = jelly;
            receipt.price = price;

            receipt.totalPrice = 0.0;

            if (jelly == "Yes")
            {
                receipt.totalPrice = price + 0.50;
            }

            else
            {
                receipt.totalPrice = price;
            }

            string receiptInfo = "Here is your receipt: <br>"
                + "Flavour: " + receipt.flavour + "<br>"
                + "Price: $" + receipt.price + "<br>"
                + "Ice: " + receipt.ice + "<br>"
                + "Sugar: " + receipt.sugar + "<br>"
                + "Jelly: " + receipt.jelly + "<br>"
                + "Total Price: $" + receipt.totalPrice + "<br>"
                + "Thank you!";

            return receiptInfo;
        }
    }
}
