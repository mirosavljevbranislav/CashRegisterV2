using CashRegister.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Mediatr.Queries.ProductBillQueries
{
    public class GetAllProductBillsQuery : IRequest<List<ProductBill>>
    {
    }
}
