using System;
using System.Collections.Generic;

#nullable disable

namespace BeautyStoreDL.Entities
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual BeautyProduct Product { get; set; }
    }
}
