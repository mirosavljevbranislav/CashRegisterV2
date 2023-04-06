using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.HandlerCommands;
using CashRegister.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Application.Mediatr.Handlers.BillHandlers.CommandHandlers
{
    internal class EditBillhandler : IRequestHandler<EditBillCommand, bool>
    {
        private readonly IBillService _billService;

        public EditBillhandler(IBillService billService)
        {
            _billService = billService;
        }
        public async Task<bool> Handle(EditBillCommand request, CancellationToken cancellationToken)
        {
            if (!await _billService.CheckIfBillExists(billNumber: request.BillNumber))
                return false;
            var updatedBill = await _billService.UpdateBill(billNumber: request.BillNumber, billDto: request.BillDto);
            return updatedBill;
        }
    }
}
