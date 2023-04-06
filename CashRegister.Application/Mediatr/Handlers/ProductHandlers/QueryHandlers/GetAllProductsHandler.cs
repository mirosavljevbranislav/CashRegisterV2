using CashRegister.Application.Mediatr.Queries.ProductQueries;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.ProductHandlers.QueryHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var listOfProducts = await _productRepository.GetAllProducts();
            return listOfProducts;
        }
    }
}
