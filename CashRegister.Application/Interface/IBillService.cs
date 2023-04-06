using CashRegister.Domain.Dto;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Interface
{
    public interface IBillService
    {
        public Task<List<Bill>> GetAllBills();

        public Task<Bill> GetBillByBillNumber(string billNumber);

        public Task<bool> CreateNewBill(Bill bill);
        public Task<bool> CheckIfBillExists(string billNumber);
        public Task<bool> UpdateBill(string billNumber, BillDto billDto);
        public Task<bool> DeleteBill(string billNumber);
    }
}