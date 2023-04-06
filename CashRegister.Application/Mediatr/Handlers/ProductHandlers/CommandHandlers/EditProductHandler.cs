using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.ProductCommands;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.ProductHandlers.CommandHandlers
{
    public class EditProductHandler : IRequestHandler<EditProductCommand, bool>
    {
        private readonly IProductService _productService;

        public EditProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            if (!_productService.CheckIfProductExists(id: request.Id))
                return false;
            var productResult = _productService.UpdateProduct(id: request.Id, productDto: request.ProductDto);
            return productResult;
        }
    }
}
