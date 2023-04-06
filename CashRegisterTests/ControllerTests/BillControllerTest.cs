using CashRegister.API.Controllers;
using CashRegister.Application.Mediatr.Queries.BillQueries;
using CashRegister.Domain.Dto;
using CashRegister.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CashRegisterTests.ServiceTests
{
    public class BillControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private readonly BillController _sut;

        public BillControllerTest()
        {
            _sut = new BillController(_mediatorMock.Object);
        }

        [Fact]
        public async Task BillController_GetAllBills_ShouldReturnOKList()
        {
            List<BillDto> expected = new List<BillDto> { new BillDto {BillNumber = "260-0056010016113-79",
                PaymentMethod = "Cash", TotalPrice = 100, CreditCardNumber = "371449635398431" } };

            var querry = new Mock<GetAllBillsQuery>();
            //_mediatorMock
            //        .Setup(s => s.Send(It.IsAny<GetAllBillsQuery>(), It.IsAny<CancellationToken>()))
            //        .Returns(expected);

            //Act
            var result = await _sut.GetAllBills();
            var okResult = result as ObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.IsType<List<BillDto>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
        [Fact]
        public async Task BillController_GetBillById_ShouldReturnOKBill()
        {
            BillDto expected = new BillDto
            {
                BillNumber = "260-0056010016113-79",
                PaymentMethod = "Cash",
                TotalPrice = 100,
                CreditCardNumber = "371449635398431"
            };

            var querry = new Mock<GetBillByNumberQuery>();
            //_mediatorMock
            //        .Setup(s => s.Send(It.IsAny<GetBillByNumberQuery>(), It.IsAny<CancellationToken>()))
            //        .ReturnsAsync(expected);

            //Act
            var result = await _sut.GetBillByBillNumber("260-0056010016113-79");
            var okResult = result as ObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.IsType<BillDto>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
        
    }
}
