using CashRegister.Domain.Models;
using MediatR;

namespace CashRegister.Application.Mediatr.Commands.BillCommands
{
    public class AddNewBillCommand : IRequest<bool>
    {
        public Bill Bill { get; set; }

        public AddNewBillCommand(Bill bill)
        {
            Bill = bill;
        }
    }
}
