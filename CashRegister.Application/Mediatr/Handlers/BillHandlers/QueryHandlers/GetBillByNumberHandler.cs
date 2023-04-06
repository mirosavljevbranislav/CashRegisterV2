using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Queries.BillQueries;
using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.BillHandlers.QueryHandlers
{
    public class GetBillByNumberHandler : IRequestHandler<GetBillByNumberQuery, Bill>
    {
        private readonly IBillService _billService;
        public GetBillByNumberHandler(IBillService billService)
        {
            _billService = billService;
        }
        public async Task<Bill> Handle(GetBillByNumberQuery request, CancellationToken cancellationToken)
        {
            var bill = await _billService.GetBillByBillNumber(billNumber: request.BillNumber);
            return bill;
        }
    }
}
