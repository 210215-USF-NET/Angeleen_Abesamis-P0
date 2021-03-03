using Entity = BeautyStoreDL.Entities;
using BSM = BeautyStore.BeautyStoreModels;

namespace BeautyStoreDL
{
    public interface IMapper
    {
        BSM.Customer ParseCustomer(Entity.Customer customer);
        Entity.Customer ParseCustomer(BSM.Customer customer);

        BSM.Order ParseOrder(Entity.Order order);
        Entity.Order ParseOrder(BSM.Order order);

        BSM.Location ParseLocation(Entity.Location location);
        Entity.Location ParseLocation(BSM.Location location);

        BSM.BeautyProduct ParseProduct(Entity.BeautyProduct product);
        Entity.BeautyProduct ParseProduct(BSM.BeautyProduct product);

        BSM.Item ParseItem(Entity.Item orderItem);
        Entity.Item ParseItem(BSM.Item item);

        BSM.Inventory ParseInventory(Entity.Inventory inv);
        Entity.Inventory ParseInventory(BSM.Inventory inv);

        BSM.ShoppingCart ParseCart(Entity.ShoppingCart cart);
        Entity.ShoppingCart ParseCart(BSM.ShoppingCart cart);
    }
}
