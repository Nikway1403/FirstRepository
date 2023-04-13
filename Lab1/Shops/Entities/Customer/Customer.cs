using System.Collections.ObjectModel;
namespace Shops.Entities.Customer
{
    public class Customer
    {
        private readonly List<Product.Product> _customerCart = new List<Product.Product>();
        private readonly string _name;
        private float _balance;
        public Customer(string name, float balance)
        {
            _balance = balance;
            _name = name;
        }

        public float GetBalance() { return _balance; }
        public void SetBalance(float newBalance) { _balance = newBalance; }

        public string GetName() { return _name; }

        public ReadOnlyCollection<Product.Product> GetCustomerCart()
        {
            return _customerCart.AsReadOnly();
        }
    }
}