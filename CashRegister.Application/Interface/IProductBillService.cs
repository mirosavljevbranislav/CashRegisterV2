using CashRegister.Domain.Models;

namespace CashRegister.Application.Interface
{
    public interface IProductBillService
    {
        Task<bool> CreateProductBill(ProductBill productBill);
        Task<List<ProductBill>> GetAllProductBills();
        public Task<ProductBill> GetProductBill(int productId, string billNumber);
        public Task<bool> IncreaseProductQuantity(ProductBill productBill);
        public Task<bool> CheckIfExists(int productId, string billNumber);
    }
}