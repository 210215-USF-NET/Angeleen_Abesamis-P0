using System;
using System.Collections.Generic;

#nullable disable

namespace BeautyStoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int LocationId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
