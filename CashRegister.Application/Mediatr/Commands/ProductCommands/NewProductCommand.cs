using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Commands.ProductCommands
{
    public class NewProductCommand : IRequest<bool>
    {
        public Product Product { get; set; }

        public NewProductCommand(Product product)
        {
            Product = product;
        }

    }
}
