using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace BeautyStore.BeautyStoreModels
{
    /// <summary>
    /// This class contains necessary properties and field for customer information.
    /// </summary>
    public class Customer
    {
        private string customerName;
        private string password;
        private int customerId;
        private string phoneNumber;
        private string emailAddress;
        private string homeAddress;
        private string billingAddress;

        public string CustomerName
        {
            get { return customerName; }
            set
            {
              if (value.Equals(null)) {
                  ThrowNullException();
                } 
                customerName = value;}
        }
        public string Password
        {
            get { return password; }
            set { 
               if (value.Equals(null)) {
                  ThrowNullException();
               }
                password = value; }
        }
        public int CustomerID
        {
            get { return customerId; }
            set { 
                if (value.Equals(null)) {
                   ThrowNullException();
               }
                customerId = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { 
                if (value.Equals(null)) {
                    ThrowNullException();
               }
                emailAddress = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { 
               if (value.Equals(null)) {
                   ThrowNullException();
                }
                phoneNumber = value; }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set { 
                if (value.Equals(null)) {
                    ThrowNullException();
                }
                homeAddress = value; }
        }
        public string BillingAddress
        {
            get { return billingAddress; }
            set { 
                if (value.Equals(null)) {
                    ThrowNullException();
                }
                billingAddress = value; }
        }
       public void ThrowNullException(){
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Cannot accept null value.");
            throw new Exception("Null value cannot be accepted!");
        }
        public override string ToString()
        {
            return $"Name: {customerName} \n\t ID: {customerId}     Phone Number: {phoneNumber} \n\t Email Address: {emailAddress} \n\t Home Address: {homeAddress} \n\t Billing Address: {billingAddress}";
        }
    }
}
