using CashRegister.Application.Mediatr.Queries.BillQueries;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.BillHandlers.QueryHandlers
{
    public class GetAllBillsHandler : IRequestHandler<GetAllBillsQuery, List<Bill>>
    {

        private readonly IBillRepository _billRepository;

        public GetAllBillsHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public async Task<List<Bill>> Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
        {
            var listOfBills = await _billRepository.GetAllBills();
            return listOfBills;
        }
    }
}
