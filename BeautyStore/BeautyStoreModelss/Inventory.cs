using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyStore.BeautyStoreModels
{
    public class Inventory
    {
        public int InventoriesId { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
    }
}
