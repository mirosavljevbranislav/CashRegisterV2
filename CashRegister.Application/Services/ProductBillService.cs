using AutoMapper;
using CashRegister.Application.Interface;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;

namespace CashRegister.Application.Services
{
    public class ProductBillService : IProductBillService
    {
        private readonly IProductBillRepository _productBillRepository;
        public ProductBillService(IProductBillRepository productBillRepository)
        {
            _productBillRepository = productBillRepository;
        }

        public async Task<bool> CreateProductBill(ProductBill productBill)
        {
            var addResult = await _productBillRepository.CreateProductBill(productBill);

            return addResult;
        }

        public async Task<List<ProductBill>> GetAllProductBills()
        {
            var productBills = await _productBillRepository.GetAllPB();
            return productBills;
        }

        public async Task<ProductBill> GetProductBill(int productId, string billNumber) 
        {
            var pb = await _productBillRepository.GetProductBillByNumberAndId(billNumber: billNumber, productId: productId);
            return pb;
        }

        public async Task<bool> IncreaseProductQuantity(ProductBill productBill)
        {
            var productQuantityUpdate = await _productBillRepository.UpdateProductBill(productBill);
            return productQuantityUpdate;
        }

        public async Task<bool> CheckIfExists(int productId, string billNumber)
        {
            var pb = await _productBillRepository.GetProductBillByNumberAndId(billNumber: billNumber, productId: productId);
            return pb != null ? true : false;
        }

    }
}
