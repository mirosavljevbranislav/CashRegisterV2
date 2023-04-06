using AutoMapper;
using CashRegister.Application.Interface;
using CashRegister.Application.Services;
using CashRegister.Domain.Dto;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;
using Moq;

namespace CashRegisterTests.ServiceTests
{
    public class BillServiceTest
    {
        public Mock<IBillRepository> _billRepoMock = new Mock<IBillRepository>();
        public Mock<IMapper> _mapperMock = new Mock<IMapper>();
        public Mock<IPriceCalculator> _calculatorService = new Mock<IPriceCalculator>();
        public BillService _sut;

        public BillServiceTest()
        {
            _sut = new BillService(_billRepoMock.Object, _mapperMock.Object);
        }
        [Fact]
        public async Task BillService_GetAllBills_ReturnsListOfBillDtos()
        {
            //Arrange
            List<Bill> bills = new List<Bill> { new Bill { BillNumber = "", CreditCardNumber = "", PaymentMethod = "", TotalPrice = 100 } };
            var mappedBills = new List<BillDto> { new BillDto { BillNumber = bills[0].BillNumber, TotalPrice = bills[0].TotalPrice,
                PaymentMethod = bills[0].PaymentMethod, CreditCardNumber = bills[0].CreditCardNumber } };

            _mapperMock.Setup(m => m.Map<List<BillDto>>(bills)).Returns(mappedBills);
            _billRepoMock.Setup(b => b.GetAllBills()).ReturnsAsync(bills);

            //Act
            var result = await _sut.GetAllBills();

            //Assert
            Assert.NotNull(result);
            //Assert.Equal(result, mappedBills);
            Assert.IsType<List<BillDto>>(result);
        }
        [Fact]
        public async Task BillService_GetBillByNumber_ReturnsDisplayBillDto()
        {
            //Arrange
            var billNumber = "123";
            var bill = new Bill { BillNumber = billNumber, CreditCardNumber = "", PaymentMethod = "" };
            var mappedBill = new BillDto { BillNumber = bill.BillNumber, PaymentMethod = bill.PaymentMethod, CreditCardNumber = bill.CreditCardNumber };

            _mapperMock.Setup(m => m.Map<BillDto>(bill)).Returns(mappedBill);
            _billRepoMock.Setup(b => b.GetBillByBillNumber(billNumber)).ReturnsAsync(bill);

            //Act
            var result = await _sut.GetBillByBillNumber(billNumber);

            //Assert
            Assert.IsType<BillDto>(result);
            //Assert.Equal(result, mappedBill);
        }


    }
}
