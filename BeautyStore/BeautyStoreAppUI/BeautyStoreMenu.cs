using System;
using BeautyStore.BeautyStoreModels;
using BeautyStoreBL;
using Serilog;
using System.Collections.Generic;

namespace BeautyStoreAppUI
{
    public class BeautyStoreMenu : IBeautyStoreMenu
    {
        private IBeautyStoreBL _repo;
        
        public BeautyStoreMenu(IBeautyStoreBL repo)
        {
            _repo = repo;
        }

        public void Start()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            IBeautyStoreMenu menu;
            Boolean stay = true;
            do
            {
                Console.WriteLine("Welcome to Perfume Candy!");
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("[0] Register");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Manager Login");
                Console.WriteLine("[3] Exit");
                string customerInput = Console.ReadLine();
                switch (customerInput)
                {
                    case "0":
                        _repo.AddCustomer(newAccount());
                        List<Customer> customerList = _repo.GetCustomers();

                        foreach(Customer cust in customerList)
                        {
                            Console.WriteLine(cust.ToString());
                        }
                        Console.WriteLine("Your account has been successfully added!");
                        break;
                    case "1":
                        Console.WriteLine("Please enter your name:");
                        string strname = Console.ReadLine();
                        Customer findCustomer = _repo.GetCustomerByName(strname);

                        if(findCustomer == null)
                        {
                            Console.WriteLine("Sorry, no customer has been found. Please try again!");
                        } else
                        {
                            Console.WriteLine($"Welcome, {findCustomer.CustomerName}!");
                            menu = new CustomerMenu(_repo, findCustomer);
                            menu.Start();//else if ( findCustomer.CustomerName.Equals("Angeleen")) //Stretch goal: use DB for this
                        }break;
                    case "2":
                        Console.WriteLine("Please enter your name:");
                        string managerName = Console.ReadLine();
                        if(managerName.Equals("Angeleen")) {
                            menu = new Admin(_repo);
                            menu.Start();
                        } 
                        break;
                    case "3":
                        stay = false;
                        Console.WriteLine("Thank you for shopping with us!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (stay);
        }
        public Customer newAccount()
        {
            Customer newCustomer = new Customer();
            //Register a new customer.
            Console.WriteLine("Please enter your name:");
            newCustomer.CustomerName = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            newCustomer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter your email address:");
            newCustomer.EmailAddress = Console.ReadLine();
            Console.WriteLine("Please enter your home address:");
            newCustomer.HomeAddress = Console.ReadLine();
            Console.WriteLine("Please enter your billing address:");
            newCustomer.BillingAddress = Console.ReadLine();

            return newCustomer;
        }
    }
}