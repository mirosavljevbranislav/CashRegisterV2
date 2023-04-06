using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.ProductCommands;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.ProductHandlers.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!_productService.CheckIfProductExists(id: request.Id))
                return false;
            var productResult = _productService.DeleteProduct(id: request.Id);
            return productResult;
        }
    }
}
