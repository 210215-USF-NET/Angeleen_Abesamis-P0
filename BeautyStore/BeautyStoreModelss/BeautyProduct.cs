using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyStore.BeautyStoreModels
{
    public class BeautyProduct
    {
        private int productId;
        private string productName;
        private decimal? price;
        private string brands;
        private string types;
        private string color;
        private string sizes;
        private string description;

        public int ProductId
        {
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

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Cannot accept null value.");
            throw new Exception("Null value not valid!");
        }

        public override string ToString()
        {
            return $"Product Name: {this.ProductName}\n\t Price: {this.Price}\n\t Description: {this.Description}";
        }

        public string ToStringSet()
        {
            return $"Product Name: {this.ProductName}\n\t Price: {this.Price}\n\t Description: {this.Description}";
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                productName = value;
            }
        }
        public decimal? Price {
            get
            {
                return price;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                price= value;
            }
        }
        public string Brands {
            get
            {
                return brands;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                brands = value;
            }
        }
        public string Types {
            get
            {
                return types;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                types = value;
            }
        }
        public string Color {
            get
            {
                return color;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                color = value;
            }
        }
        public string Sizes {
            get
            {
                return sizes;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                sizes = value;
            }
        }
        public string Description {
            get
            {
                return description;
            }
            set
            {
                if (value.Equals(null))
                {
                    ThrowNullException();
                }
                description = value;
            }
        }
    }
}
