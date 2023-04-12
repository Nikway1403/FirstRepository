using Shops.Entities.Customer;
using Shops.Entities.Product;
using Shops.Entities.Shop;

namespace Shops.Services
{
    public interface IShopManagement
    {
        Shop AddShop(string name, string address, float shopBalance);
        Customer CreateNewCustomer(string name, int balance);
        void BuyingSomeGoods(Dictionary<Product, int> newCustomerList, Customer newCustomer, Shop newShop);
        void AddProductToTheShop(Shop shop, Product product, int amount);
        Product ChangePrice(Product product, float newPrice);
        Shop FindShop(List<Product> productsList);
    }
}