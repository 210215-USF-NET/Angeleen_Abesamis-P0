using System;
using System.Collections.Generic;

#nullable disable

namespace BeautyStoreDL.Entities
{
    public partial class Item
    {
        public int ItemsId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual BeautyProduct Product { get; set; }
    }
}
