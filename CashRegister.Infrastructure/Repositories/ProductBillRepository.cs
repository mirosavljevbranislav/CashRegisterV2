using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Context;
using CashRegister.Infrastructure.Interface;

namespace CashRegister.Infrastructure.Repositories
{
    public class ProductBillRepository : IProductBillRepository
    {

        private readonly CashRegisterDBContext _dbContext;

        public ProductBillRepository(CashRegisterDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }


        public async Task<bool> DeleteProductBill(ProductBill pb)
        {
            _dbContext.ProductBills.Remove(pb);
            return Save();
        }

        public async Task<bool> UpdateProductBill(ProductBill pb)
        {
            _dbContext.ProductBills.Update(pb);
            return Save();
        }

        public async Task<bool> CreateProductBill(ProductBill pb)
        {
            _dbContext.ProductBills.Add(pb);
            return Save();
        }

        public async Task<List<ProductBill>> GetAllPB()
        {
            return _dbContext.ProductBills.ToList();
        }

        public async Task<ProductBill> GetProductBillByNumberAndId(string billNumber, int productId)
        {
            var result = _dbContext.ProductBills.FirstOrDefault(b => b.BillNumber == billNumber && b.ProductId == productId);
            return result;
        }

        public async Task<bool> IncreaseProductQuantity(ProductBill pb)
        {
            _dbContext.ProductBills.Update(pb);
            return Save();
        }
    }
}
