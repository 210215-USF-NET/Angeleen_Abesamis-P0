using System;
using System.Collections.Generic;
using System.Text;
using BeautyStore.BeautyStoreModels;

namespace BeautyStoreDL
{
    public interface IBeautyStoreRepo
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer customerName);
        Customer GetCustomerByName(string name);
        Order AddOrder(Order order);
        List<Order> GetOrders();
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Location> GetLocations();
        List<BeautyProduct> GetProducts();
        BeautyProduct GetProductByID(int idNum);
        List<Inventory> GetInventories();
        ShoppingCart AddCart(ShoppingCart newShoppingCart);
        List<ShoppingCart> GetShoppingCarts();
        void EmptyShoppingCart();
    }
}
