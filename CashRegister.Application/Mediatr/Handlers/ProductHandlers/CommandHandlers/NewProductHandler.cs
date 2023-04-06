using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.ProductCommands;
using CashRegister.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CashRegister.Application.Mediatr.Handlers.ProductHandlers.CommandHandlers
{
    public class NewProductHandler : IRequestHandler<NewProductCommand, bool>
    {

        private readonly IProductService _productService;

        public NewProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<bool> Handle(NewProductCommand request, CancellationToken cancellationToken)
        {
            var productResult = await _productService.CreateNewProduct(product: request.Product);
            return productResult;
        }
    }
}
