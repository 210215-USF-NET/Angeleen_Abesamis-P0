using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using BeautyStoreBL;
using BeautyStoreDL;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreAppUI
{
    public class CustomerMenu : IBeautyStoreMenu
    {
        private Location location;
        private IBeautyStoreBL _repo;
        private Customer _customer;

        public CustomerMenu(IBeautyStoreBL repo, Customer customer)
        {
            _repo = repo;
            _customer = customer;
        }

        public IBeautyStoreBL Repo { get; }
        public Customer FindCustomer { get; }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Boolean stay = true;
            IBeautyStoreMenu menu;
            do
            {
                //Customer UI
                Console.WriteLine("Options:");
                Console.WriteLine("[0] Buy Perfume");
                Console.WriteLine("[1] Customer Order History");
                Console.WriteLine("[2] Go Back");
                string customerInput = Console.ReadLine();

                switch (customerInput)
                {
                    case "0":
                        menu = new SelectLocation(_repo, _customer);
                        menu.Start();
                        break;
                    case "1":
                        menu = new OrderHistoryList(_repo, _customer);
                        menu.Start();
                        break;
                    case "2":
                        stay = false;
                        break;
                    default:
                        Log.Error("Invalid input!");
                        Console.WriteLine("Please enter an appropriate option.");
                        break;
                }
            } while (stay);
        }
    }
}
