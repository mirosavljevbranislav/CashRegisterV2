using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure.Interface
{
    public interface IBillRepository
    {
        Task<bool> CreateNewBull(Bill bill);
        Task<bool> DeleteBill(Bill bill);
        Task<List<Bill>> GetAllBills();
        Task<Bill> GetBillByBillNumber(string billNumber);
        bool Save();
        Task<bool> UpdateBill(Bill bill);

        Task<bool> CheckIfBillExists(string billNumber);
    }
}