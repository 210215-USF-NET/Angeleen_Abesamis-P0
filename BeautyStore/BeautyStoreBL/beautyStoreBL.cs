using BeautyStore.BeautyStoreModels;
using System;
using System.Collections.Generic;
using Entity = BeautyStoreDL.Entities;
using BeautyStoreDL;

namespace BeautyStoreBL
{
    public class beautyStoreBL : IBeautyStoreBL
    {
        private IBeautyStoreRepo _repo;

        public beautyStoreBL(IBeautyStoreRepo repo)
        {
            _repo = repo;
        }

        public void AddCustomer(Customer custName)
        {
            _repo.AddCustomer(custName);
        }

        public void AddOrder(Order order)
        {
            _repo.AddOrder(order);
        }

        public Item AddItem(Item newItem)
        {
            return _repo.AddItem(newItem);
        }

        public ShoppingCart AddShoppingCart(ShoppingCart newShoppingCart)
        {
            return _repo.AddCart(newShoppingCart);
        }

        public BeautyProduct GetBeautyProductByID(int idNum)
        {
            return _repo.GetProductByID(idNum);
        }

        public List<BeautyProduct> GetBeautyProducts()
        {
            return _repo.GetProducts();
        }

        public List<ShoppingCart> GetShoppingCarts()
        {
            return _repo.GetShoppingCarts();
        }

        public Customer GetCustomerByName(string name)
        {
            //TODO: CHECK FOR INPUT VALIDATION (NULL/EMPTY)
            return _repo.GetCustomerByName(name);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }

        public List<Item> GetItems()
        {
            return _repo.GetItems();
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }

        public void EmptyCart()
        {
            _repo.EmptyShoppingCart();
        }

    }
}
