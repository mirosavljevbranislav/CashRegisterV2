using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Queries.BillQueries
{
    public class GetAllBillsQuery : IRequest<List<Bill>>
    {
    }
}
