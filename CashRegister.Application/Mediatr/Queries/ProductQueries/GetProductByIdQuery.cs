using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
