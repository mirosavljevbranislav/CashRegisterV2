using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Queries.ProductQueries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

    }
}
