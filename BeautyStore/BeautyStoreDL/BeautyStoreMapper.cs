using Entity = BeautyStoreDL.Entities;
using BSM = BeautyStore.BeautyStoreModels;
using System;

namespace BeautyStoreDL
{
    public class BeautyStoreMapper : IMapper
    {
        public BSM.Customer ParseCustomer(Entity.Customer customer)
        {
            return new BSM.Customer {
                CustomerID = (int) customer.CustomerId,
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                HomeAddress = customer.HomeAddress,
                BillingAddress = customer.BillingAddress
            };
        }

        public Entity.Customer ParseCustomer(BSM.Customer customer)
        {
            return new Entity.Customer {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                HomeAddress = customer.HomeAddress,
                BillingAddress = customer.BillingAddress
            };
        }

        public BSM.Inventory ParseInventory(Entity.Inventory inventory)
        {
            return new BSM.Inventory {
                InventoriesId = inventory.InventoriesId,
                Quantity = inventory.Quantity,
                LocationId = (int) inventory.LocationId,
                ProductId = (int) inventory.ProductId
            };
        }

        public Entity.Inventory ParseInventory(BSM.Inventory inventory)
        {
            return new Entity.Inventory {
                InventoriesId = inventory.InventoriesId,
                Quantity = inventory.Quantity,
                LocationId = (int) inventory.LocationId,
                ProductId = (int) inventory.ProductId
            };
        }

        public BSM.Item ParseItem(Entity.Item item)
        {
            return new BSM.Item {
                ItemsId = item.ItemsId,
                Quantity = (int) item.Quantity,
                ProductId = (int) item.ProductId,
                OrderId = item.OrderId
            };
        }

        public Entity.Item ParseItem(BSM.Item item)
        {
            return new Entity.Item {
                ItemsId = item.ItemsId,
                Quantity = item.Quantity,
                ProductId = item.ProductId,
                OrderId = item.OrderId
            };
        }

        public BSM.Location ParseLocation(Entity.Location location)
        {
            return new BSM.Location {
                LocationId = location.LocationId,
                LocationName = location.LocationName,
                Address = location.Address
            };
        }

        public Entity.Location ParseLocation(BSM.Location location)
        {
            return new Entity.Location {
                LocationId = location.LocationId,
                LocationName = location.LocationName,
                Address = location.Address
            };
        }

        public BSM.Order ParseOrder(Entity.Order order)
        {
            return new BSM.Order {
                CustomerId = (int) order.CustomerId,
                OrderId = (int) order.OrderId,
                LocationId = (int) order.LocationId,
                OrderDate = order.OrderDate
            };
        }

        public Entity.Order ParseOrder(BSM.Order order)
        {
            return new Entity.Order {
                CustomerId = (int) order.CustomerId,
                OrderId = (int) order.OrderId,
                LocationId = (int) order.LocationId,
                OrderDate = order.OrderDate
            };
        }

        public BSM.BeautyProduct ParseProduct(Entity.BeautyProduct product)
        {
            return new BSM.BeautyProduct {
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                Price = product.Price,
                Description = product.Description
            };
        }

        public Entity.BeautyProduct ParseProduct(BSM.BeautyProduct product)
        {
            return new Entity.BeautyProduct{
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                Price = (decimal)product.Price,
                Description = product.Description
            };
        }

        public BSM.ShoppingCart ParseCart(Entity.ShoppingCart shoppingCart)
        {
            return new BSM.ShoppingCart
            {
                ShoppingCartId = shoppingCart.ShoppingCartId,
                CustomerId = shoppingCart.CustomerId,
                LocationId = shoppingCart.LocationId,
                ProductId = shoppingCart.ProductId,
                Quantity = shoppingCart.Quantity
            };
        }
        public Entity.ShoppingCart ParseCart(BSM.ShoppingCart shoppingCart)
        {
            return new Entity.ShoppingCart
            {
                ShoppingCartId = shoppingCart.ShoppingCartId,
                CustomerId = shoppingCart.CustomerId,
                LocationId = shoppingCart.LocationId,
                ProductId = shoppingCart.ProductId,
                Quantity = shoppingCart.Quantity
            };
        }
    }
}
