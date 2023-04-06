using CashRegister.Application.Mediatr.Queries.ProductBillQueries;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.ProductBillHandlers.QueryHandlers
{
    public class GetAllPbHandler : IRequestHandler<GetAllProductBillsQuery, List<ProductBill>>
    {
        private readonly IProductBillRepository _productBillRepository;

        public GetAllPbHandler(IProductBillRepository productBillRepo)
        {
            _productBillRepository = productBillRepo;
        }
        public async Task<List<ProductBill>> Handle(GetAllProductBillsQuery request, CancellationToken cancellationToken)
        {
            var listOfPbs = await _productBillRepository.GetAllPB();
            return listOfPbs;
        }
    }
}
