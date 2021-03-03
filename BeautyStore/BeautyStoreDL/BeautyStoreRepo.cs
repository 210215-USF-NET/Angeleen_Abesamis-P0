using BSM = BeautyStore.BeautyStoreModels;
using System;
using System.Collections.Generic;
using Entity = BeautyStoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeautyStoreDL
{
    public class BeautyStoreRepo : IBeautyStoreRepo
    {
        private Entity.ABContext _context;
        private IMapper _mapper;

        public BeautyStoreRepo(Entity.ABContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BSM.Customer AddCustomer(BSM.Customer customerName)
        {
            _context.Customers.Add(_mapper.ParseCustomer(customerName));
            _context.SaveChanges();
            return customerName;
        }

        public BSM.Item AddItem(BSM.Item newItem)
        {
            _context.Items.Add(_mapper.ParseItem(newItem));
            _context.SaveChanges();
            return newItem;
        }

        public BSM.Order AddOrder(BSM.Order order)
        {
            _context.Orders.Add(_mapper.ParseOrder(order));
            _context.SaveChanges();
            return order;
        }

        public BSM.Customer GetCustomerByName(string custName)
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerName == custName);
        }

        public List<BSM.Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public List<BSM.Inventory> GetInventories()
        {
            return _context.Inventories.AsNoTracking().Select(x => _mapper.ParseInventory(x)).ToList();
        }

        public List<BSM.Item> GetItems()
        {
            return _context.Items.AsNoTracking().Select(x => _mapper.ParseItem(x)).ToList();
        }

        public List<BSM.Location> GetLocations()
        {

           return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList();
        }

       public List<BSM.Order> GetOrders()
        {

           return _context.Orders.AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
        }

        public BSM.BeautyProduct GetProductByID(int idNum)
        {

            return _context.BeautyProducts.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.ProductId == idNum);
        }

        public List<BSM.BeautyProduct> GetProducts()
        {

            return _context.BeautyProducts.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList();
        }

        public BSM.ShoppingCart AddCart(BSM.ShoppingCart newShoppingCart)
        {
            _context.ShoppingCarts.Add(_mapper.ParseCart(newShoppingCart));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return newShoppingCart;
        }

        public void EmptyShoppingCart()
        {
            _context.ShoppingCarts.RemoveRange(_context.ShoppingCarts.AsNoTracking().Select(x => x));
        }

        public List<BSM.ShoppingCart> GetShoppingCarts()
        {
            return _context.ShoppingCarts.AsNoTracking().Select(x => _mapper.ParseCart(x)).ToList();
        }
    }
}
