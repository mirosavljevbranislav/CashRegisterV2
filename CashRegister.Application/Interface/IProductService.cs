using CashRegister.API.Dto;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Interface
{
    public interface IProductService
    {
        bool CheckIfProductExists(int id);
        Task<bool> CreateNewProduct(Product product);
        bool DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
        Product GetProductById(int id);
        bool UpdateProduct(int id, ProductDto productDto);
    }
}