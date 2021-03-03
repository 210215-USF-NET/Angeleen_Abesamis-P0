using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Sinks.File;
using System.Linq;
using BeautyStoreBL;
using BeautyStore.BeautyStoreModels;


namespace BeautyStoreAppUI
{
    public class BeautyProductChoiceMenu : IBeautyStoreMenu
    {
        Location location;
        List<BeautyProduct> beautyProductList = new List<BeautyProduct>();
        Customer customer;
        IBeautyStoreBL repo;
        public BeautyProductChoiceMenu (Location _location, IBeautyStoreBL _repo, Customer _customer)
        {
            location = _location;
            customer = _customer;
            repo = _repo;
            BPList(location);
        }
        private void BPList(Location _location)
        {
            List<Inventory> inventoryList = repo.GetInventories();
            BeautyProduct beautyProd;
            foreach(Inventory i in inventoryList.Reverse<Inventory>())
            {
                if(i.LocationId == _location.LocationId)
                {
                    beautyProd = repo.GetBeautyProductByID(i.ProductId);
                    beautyProductList.Add(beautyProd);
                }
            }
        }
        public void Print(BeautyProduct beautyProduct)
        {
            Console.WriteLine($"Product Name: {beautyProduct.ProductName}\n\t Price: {beautyProduct.Price}\n\t Description: {beautyProduct.Description}");
        }
        public void Start()
        {
            foreach (BeautyProduct beautyProduct in beautyProductList)
            {
                Console.WriteLine(beautyProduct.ToString());
            }
            Console.WriteLine("Product to purchase:");
            string customerInput = Console.ReadLine();

            foreach (BeautyProduct beautyProduct in beautyProductList)
            {
                if (customerInput == beautyProduct.ProductName)
                {
                    Console.WriteLine("Quantity:");
                    int quantity = int.Parse(Console.ReadLine());
                    repo.AddShoppingCart(new ShoppingCart
                    {
                        ProductId = beautyProduct.ProductId,
                        CustomerId = customer.CustomerID,
                        LocationId = location.LocationId,
                        Quantity = quantity
                    });
                    Console.WriteLine($"{quantity} product(s) added to shopping cart.");
                }break;
            }
        }
    }

}
