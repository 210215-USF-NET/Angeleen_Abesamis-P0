using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using BeautyStore.BeautyStoreModels;
using BeautyStoreBL;

namespace BeautyStoreAppUI
{
    public class SelectLocation : IBeautyStoreMenu
    {
        private Location loc;
        private IBeautyStoreBL _repo;
        private Customer _customer;
        public List<Location> location;
        public SelectLocation(IBeautyStoreBL repo, Customer customer)
        {
            _repo = repo;
            _customer = customer;
            location = _repo.GetLocations();
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Boolean stay = true, redFlag = true;
            IBeautyStoreMenu menu;
            do
            {
                Console.WriteLine("Enter store location:");
                Console.WriteLine("Philippines");
                Console.WriteLine("Texas");
                Console.WriteLine("California");
                Console.WriteLine("[0] Go Back");
                string customerInput = Console.ReadLine();
                if (customerInput.Equals("0"))
                {
                    Buy();
                    stay = false;
                    break;
                }
                foreach (Location store in location)
                {
                    Console.WriteLine(store.LocationName);
                    if (customerInput.Equals(store.LocationName))
                    {
                        loc = store;
                        redFlag = false;
                        menu = new BeautyProductChoiceMenu(store, _repo, _customer);
                        menu.Start();
                        break;
                    }
                }
                if (redFlag)
                {
                    Log.Error("Invalid input. Please enter an appropriate option!");
                    Console.ReadLine();
                }
            } while (stay);
        }
         private void Buy() {
            Boolean buyFlag = true;
            do {
                Console.WriteLine("Ready to checkout or Do you want to empty your cart?");
                Console.WriteLine("[0] View Shopping Cart");
                Console.WriteLine("[1] Checkout");
                Console.WriteLine("[2] Empty Cart and Go Back");
                string customerInput = Console.ReadLine();
                switch(customerInput) {
                    case "0":
                        List<ShoppingCart> customerShoppingCart = _repo.GetShoppingCarts();
                        decimal? price = 0;
                        foreach(ShoppingCart sc in customerShoppingCart) {
                            BeautyProduct bp = _repo.GetBeautyProductByID(sc.ProductId);
                            price += bp.Price;
                            Console.WriteLine(bp.ToString());
                        } break;
                    case "1":
                        customerShoppingCart = _repo.GetShoppingCarts();
                        Order order = new Order() {
                            CustomerId = _customer.CustomerID,
                            LocationId = loc.LocationId,
                            OrderDate = DateTime.Now,
                        };
                        _repo.AddOrder(order);
                        foreach(ShoppingCart shoppingCart in customerShoppingCart) {
                            Item item = new Item() {
                                OrderId = (_repo.GetOrders().Count),
                                ProductId = shoppingCart.ProductId,
                                Quantity = shoppingCart.Quantity
                            };
                            _repo.AddItem(item);
                        }
                        _repo.EmptyCart();
                        buyFlag = false;
                        break;
                    case "2":
                        _repo.EmptyCart();
                        buyFlag = false;
                        break;
                }
            } while(buyFlag);
        }
    }
}
