using System;
using System.Collections.Generic;

#nullable disable

namespace BeautyStoreDL.Entities
{
    public partial class Inventory
    {
        public int InventoriesId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual BeautyProduct Product { get; set; }
    }
}
