using System;
using System.Collections.Generic;
using System.Text;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreBL
{
    public interface IBeautyStoreBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer custName);
        Customer GetCustomerByName(string name);
        void AddOrder(Order order);
        List<Order> GetOrders();
        List<Location> GetLocations();
        List<BeautyProduct> GetBeautyProducts();
        BeautyProduct GetBeautyProductByID(int idNum);
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Inventory> GetInventories();
        ShoppingCart AddShoppingCart(ShoppingCart newShoppingCart);
        List<ShoppingCart> GetShoppingCarts();
        void EmptyCart();
    }
}
