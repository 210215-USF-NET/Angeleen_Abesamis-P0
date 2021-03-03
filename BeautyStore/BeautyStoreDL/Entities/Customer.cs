using System;
using System.Collections.Generic;

#nullable disable

namespace BeautyStoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string BillingAddress { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
