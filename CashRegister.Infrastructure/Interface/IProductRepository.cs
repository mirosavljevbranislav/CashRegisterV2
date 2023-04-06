using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure.Interface
{
    public interface IProductRepository
    {
        public Task<bool> CreateNewProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Product GetProductById(int id);
        public bool CheckIfProductExists(int id);
        bool Save();
    }
}