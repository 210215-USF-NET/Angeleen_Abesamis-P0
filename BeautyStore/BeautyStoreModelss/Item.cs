using BeautyStore.BeautyStoreModels;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace BeautyStore.BeautyStoreModels
{
    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and location.
    /// </summary>
    public class Item
    {
        private int itemsId;
        private int productId;
        private int orderId;
        private int quantity;
        public BeautyProduct BeautyProducts { get; set; }
        public int ItemsId {
            get
            {
                return itemsId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
               itemsId = value;
            }
        }
        public int ProductId {
            get
            {
                return productId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                productId = value;
            }
        }
        public int OrderId {
            get
            {
                return orderId;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                orderId = value;
            }
        }
        public int Quantity {
            get
            {
                return quantity;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                quantity = value;
            }
        }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Cannot accept null value");

            throw new Exception("Null value cannot be accepted!");
        }
    }
}
