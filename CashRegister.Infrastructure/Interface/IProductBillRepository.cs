using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure.Interface
{
    public interface IProductBillRepository
    {
        Task<bool> CreateProductBill(ProductBill pb);
        Task<bool> DeleteProductBill(ProductBill pb);
        Task<List<ProductBill>> GetAllPB();
        Task<ProductBill> GetProductBillByNumberAndId(string billNumber, int productId);
        bool Save();
        Task<bool> UpdateProductBill(ProductBill pb);
    }
}