using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using BeautyStoreBL;
using System.Linq;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreAppUI
{
    public class OrderHistoryList : IBeautyStoreMenu
    {
        private IBeautyStoreBL _repo;
        private Customer _customer;
        List<Order> orders;
        List<BeautyProduct> beautyProducts;
        List<Item> items;
        Boolean stay = true;

        public OrderHistoryList(IBeautyStoreBL repo, Customer customer)
        {
            _repo = repo;
            _customer = customer;
            orders = GetOrderHistory(_repo.GetOrders());
            items = _repo.GetItems();

            for(int i = 0; i < orders.Count; i++)
            {
                orders[i].Total = TotalAmount(orders[i]);
            }
        }
        public void Start()
        {
            do
            {
                foreach (Order order in orders)
                {
                    Console.WriteLine(order.ToString());
                    beautyProducts = GetOrderBeautyProducts(order);
                    foreach (BeautyProduct product in beautyProducts)
                    {
                       Console.WriteLine(product.ToStringSet());
                    }
                }
                Console.WriteLine("Sort order history by:");
                Console.WriteLine("[0] Order Date");
                Console.WriteLine("[1] Order Cost");
                Console.WriteLine("[2] Go Back");
                string strInput = Console.ReadLine();
                switch (strInput)
                {
                    case "0":
                        orders = SortByDate();
                        break;
                    case "1":
                        orders = SortByCost();
                        break;
                    case "2":
                        stay = false;
                        break;
                    default:
                        Log.Error("Invalid input! Please enter an appropriate option.");
                        break;
                }
            } while (stay);
        }
        private List<Order> GetOrderHistory(List<Order> _orders)
        {
            List<Order> newOrderList = new List<Order>();
            foreach(Order order in _orders)
            {
                if (order.CustomerId == _customer.CustomerID)
                {
                    newOrderList.Add(order);
                }
            } return newOrderList;
        }
        private List<BeautyProduct> GetOrderBeautyProducts(Order order)
        {
            beautyProducts = new List<BeautyProduct>();
            foreach(Item item in items)
            {
                if(order.OrderId == item.OrderId)
                {
                    beautyProducts.Add(_repo.GetBeautyProductByID(item.ProductId));
                }
            } return beautyProducts;
        }
        private decimal? TotalAmount(Order order)
        {
            decimal? OrderId = order.OrderId;
            decimal? TotalPrice = 0;
            foreach(Item item in items)
            {
                if (item.OrderId == OrderId)
                {
                    TotalPrice += _repo.GetBeautyProductByID(item.ProductId).Price;
                }
            } return TotalPrice;
        }
        private List<Order> SortByDate()
        {
            return orders.OrderBy(h => h.OrderDate).ToList();
        }
        private List<Order> SortByCost()
        {
            return orders.OrderBy(h => h.Total).ToList();
        }
    }
}
