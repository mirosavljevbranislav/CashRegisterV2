using CashRegister.API.Dto;
using MediatR;

namespace CashRegister.Application.Mediatr.Commands.ProductCommands
{
    public class EditProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public ProductDto ProductDto { get; set; }
        public EditProductCommand( int id, ProductDto productDto)
        {
            Id = id;
            ProductDto = productDto;
        }
    }
}
