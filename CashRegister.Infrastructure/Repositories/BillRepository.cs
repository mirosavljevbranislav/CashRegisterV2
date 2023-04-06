using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Context;
using CashRegister.Infrastructure.Interface;

namespace CashRegister.Infrastructure.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly CashRegisterDBContext _dbContext;

        public BillRepository(CashRegisterDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }
        public async Task<bool> CreateNewBull(Bill bill)
        {
            _dbContext.Bills.Add(bill);
            return Save();
        }

        public async Task<bool> UpdateBill(Bill bill)
        {
            _dbContext.Bills.Update(bill);
            return Save();
        }

        public async Task<bool> DeleteBill(Bill bill)
        {
            _dbContext.Remove(bill);
            return Save();
        }

        public async Task<Bill> GetBillByBillNumber(string billNumber)
        {
            return _dbContext.Bills.FirstOrDefault(b => b.BillNumber == billNumber);
        }

        public async Task<List<Bill>> GetAllBills()
        {
            return _dbContext.Bills.ToList();
        }

        public async Task<bool> CheckIfBillExists(string billNumber)
        {
            var result = _dbContext.Bills.Any(b => b.BillNumber == billNumber);
            return result;
        }
    }
}
