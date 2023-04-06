using AutoMapper;
using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.ProductBillCommands;
using CashRegister.Application.Services;
using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.ProductBillHandlers.CommandHandlers
{
    public class AddNewProductBillHandler : IRequestHandler<NewProductBillCommand, bool>
    {
        private readonly IProductBillService _productBillService;
        private readonly IProductService _productService;
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public AddNewProductBillHandler(IProductBillService productBillService,IProductService productService, IBillService billService, IMapper mapper)
        {
            _productBillService = productBillService;
            _productService = productService;
            _billService = billService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(NewProductBillCommand request, CancellationToken cancellationToken)
        {
            var pb = _productBillService.GetProductBill(productId: request.ProductID, billNumber: request.BillNumber);
            var product = _productService.GetProductById(request.ProductID);
            var bill = await _billService.GetBillByBillNumber( request.BillNumber);
            request.ProductBillDto.ProductId = request.ProductID;
            request.ProductBillDto.BillNumber = request.BillNumber;
            var mappedPb = _mapper.Map<ProductBill>(request.ProductBillDto);
           
            mappedPb.Product = product;
            mappedPb.Bill = bill;
            mappedPb.ProductQuantity = 0;
            mappedPb.ProductsPrice = 0;
            var newPb = await _productBillService.CreateProductBill(mappedPb);
            return newPb;
           
           
        }
    }
}
