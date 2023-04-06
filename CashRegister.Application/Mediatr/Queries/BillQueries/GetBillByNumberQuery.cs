using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Queries.BillQueries
{
    public class GetBillByNumberQuery : IRequest<Bill>
    {
        public string BillNumber { get; set; }

        public GetBillByNumberQuery(string billNumber)
        {
            BillNumber = billNumber;
        }
    }
}
