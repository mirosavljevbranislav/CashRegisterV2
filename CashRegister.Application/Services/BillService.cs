using AutoMapper;
using CashRegister.Application.Interface;
using CashRegister.Domain.Dto;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;

namespace CashRegister.Application.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public BillService(IBillRepository billRepo, IMapper mapper)
        {
            _billRepository = billRepo;
            _mapper = mapper;
        }


        public async Task<List<Bill>> GetAllBills()
        {
            var listOfBills = await _billRepository.GetAllBills();
            return listOfBills;
        }

        public async Task<Bill> GetBillByBillNumber(string billNumber)
        {
            var bill = await _billRepository.GetBillByBillNumber(billNumber);
            return bill;
        }

        public async Task<bool> CreateNewBill(Bill bill)
        {
            var newBill =  await _billRepository.CreateNewBull(bill);
            return newBill;
        }

        public async Task<bool> CheckIfBillExists(string billNumber)
        {
            var result = await _billRepository.CheckIfBillExists(billNumber);
            return result;
        }

        public async Task<bool> UpdateBill(string billNumber, BillDto billDto)
        {
            var mappedBill = _mapper.Map<Bill>(billDto);
            mappedBill.BillNumber = billNumber;
            var updateBill = await _billRepository.UpdateBill(bill: mappedBill);
            return updateBill;
        }

        public async Task<bool> DeleteBill(string billNumber)
        {
            var bill = await _billRepository.GetBillByBillNumber(billNumber: billNumber);
            var deleteBill = await _billRepository.DeleteBill(bill);
            return deleteBill;
        }
    }
}
