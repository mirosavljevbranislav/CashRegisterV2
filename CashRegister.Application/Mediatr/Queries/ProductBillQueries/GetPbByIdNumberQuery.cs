using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Queries.ProductBillQueries
{
    public class GetPbByIdNumberQuery : IRequest<ProductBill>
    {
        public int ProductId { get; set; }   
        public string BillNumber { get; set; }

        public GetPbByIdNumberQuery(int productId, string billNumber)
        {
            ProductId = productId;
            BillNumber = billNumber;
        }

    }
}
