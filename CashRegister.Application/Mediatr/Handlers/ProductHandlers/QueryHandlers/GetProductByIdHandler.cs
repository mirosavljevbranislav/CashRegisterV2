using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Queries.ProductQueries;
using CashRegister.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.ProductHandlers.QueryHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductService _productService;
        private readonly IValidator<Product> _productValidator;

        public GetProductByIdHandler(IProductService productService, IValidator<Product> productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
        }

        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _productService.GetProductById(request.Id);
            ValidationResult result = await _productValidator.ValidateAsync(product);
            if (!result.IsValid)
            {
                return null;
            }
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
