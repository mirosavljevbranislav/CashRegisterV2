using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Commands.BillCommands
{
    public class DeleteBillCommand : IRequest<bool>
    {
        public string BillNumber { get; set; }

        public DeleteBillCommand(string billNumber)
        {
            BillNumber = billNumber;
        }
    }
}
