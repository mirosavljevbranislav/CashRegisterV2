using CashRegister.Domain.Dto;
using MediatR;

namespace CashRegister.Application.Mediatr.Commands.HandlerCommands
{
    public class EditBillCommand : IRequest<bool>
    {
        public string BillNumber { get; set; }

        public BillDto BillDto { get; set; }

        public EditBillCommand(string billNumber, BillDto billDto)
        {
            BillNumber = billNumber;
            BillDto = billDto;
        }
    }
}
