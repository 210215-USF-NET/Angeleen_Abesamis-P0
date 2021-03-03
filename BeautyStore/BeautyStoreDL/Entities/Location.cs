using System;
using System.Collections.Generic;

#nullable disable

namespace BeautyStoreDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
