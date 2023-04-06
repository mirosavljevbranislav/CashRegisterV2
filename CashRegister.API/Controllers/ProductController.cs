using CashRegister.API.Dto;
using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.ProductCommands;
using CashRegister.Application.Mediatr.Queries.ProductQueries;
using CashRegister.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<Product> _productValidator;
        private readonly IMediator _productMediator;

        public ProductController(IProductService productService, IMediator productMediator)
        {
            _productService = productService;
            _productMediator = productMediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProductsRequest()
        {
            var allProductQuery = new GetAllProductsQuery();
            var result = await _productMediator.Send(allProductQuery);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productQuery = new GetProductByIdQuery(id);
            var result = await _productMediator.Send(productQuery);
            return result != null ? Ok(result) : NotFound();
            
        }

        [HttpPost()]
        public async Task<IActionResult> AddNewProduct(Product product)
        {
            var query = new NewProductCommand(product);
            var result = await _productMediator.Send(query);
            return result ? Ok("Product added successfuly") : BadRequest("Something went wrong");

           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new EditProductCommand(id: id, productDto: productDto);
            var updateResult = await _productMediator.Send(query);   
            return updateResult ? Ok("Product updated successfuly") : BadRequest("Something went wrong, product not updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var query = new DeleteProductCommand(id);
            var deletedResult = await _productMediator.Send(query);
            return deletedResult ? Ok("Product successfuly deleted.") : BadRequest("Somethign went wrong. product not deleted");
        }
    }
}
