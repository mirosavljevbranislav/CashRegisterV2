using AutoMapper;
using CashRegister.Application.Dto;
using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.ProductBillCommands;
using CashRegister.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductBillController : ControllerBase
    {
        private readonly IProductBillService _pbService;
        private readonly IBillService _billService;
        private readonly IProductService _productService;
        private readonly IPriceCalculator _priceCalculator;
        private readonly IMapper _mapper;
        private readonly IMediator _pbMediator;

        public ProductBillController(IProductBillService pbService,
            IBillService billService,
            IProductService productService,
            IPriceCalculator priceCalculator,
            IMapper mapper,
            IMediator mediator)
        {
            _pbService = pbService;
            _billService = billService;
            _productService = productService;
            _priceCalculator = priceCalculator;
            _mapper = mapper;
            _pbMediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProductBills()
        {
            var pbs = _pbService.GetAllProductBills();
            return pbs == null ? NotFound("No results found") : Ok(pbs);
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetProductBill(int productId, string billNumber)
        {
            var pb = await _pbService.GetProductBill(productId, billNumber);
            
            return pb != null ? Ok(pb) : NotFound("No results found");
        }

        [HttpPost("addNewPb")]
        public async Task<IActionResult> CreateNewProductBill(int productId, string billNumber, [FromBody] ProductBillDto pbDto)
        {  
            //var pb = _pbService.GetProductBill(productId: pbDto.ProductId, billNumber: pbDto.BillNumber);
            var query = new NewProductBillCommand(productID: productId, billNumber: billNumber, productBillDto: pbDto);
            var result = await _pbMediator.Send(query);
            //var product = _productService.GetProductById(pbDto.ProductId);
            //var bill = await _billService.GetBillByBillNumber(pbDto.BillNumber);
           
            //if (product == null || bill == null) 
            //{
            //    return NotFound("Not found, check product id or bill number again please.");
            //}
            //else 
            //    return BadRequest("Something went wrong or that pb already exists, please try again.");
            return result ? Ok(result) : NotFound();
        }


        [HttpPut("addProduct")]
        public async Task<IActionResult> AddProductToBill(int quantity, string currency, [FromBody] ProductBillDto pbDto)
        {
            var product = _productService.GetProductById(id: pbDto.ProductId);
            var pb = await _pbService.GetProductBill(productId: pbDto.ProductId, billNumber: pbDto.BillNumber);
            pb.ProductQuantity += quantity;
            pb.ProductsPrice = (int)_priceCalculator.CalculatePrice(pb, product.Price, currency);
            var updatedPb = await _pbService.IncreaseProductQuantity(pb);
            return updatedPb ? Ok(updatedPb) : BadRequest("Idk something went wrong...");
        }


    }
}
