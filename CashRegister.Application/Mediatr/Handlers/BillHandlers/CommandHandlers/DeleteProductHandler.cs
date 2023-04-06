using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.BillCommands;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.BillHandlers.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteBillCommand, bool>
    {
        private readonly IBillService _billService;

        public DeleteProductHandler(IBillService billService)
        {
            _billService = billService;
        }
        public async Task<bool> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            if (!await _billService.CheckIfBillExists(billNumber: request.BillNumber))
                return false;
            var deletedBill = await _billService.DeleteBill(billNumber: request.BillNumber);
            return deletedBill;
        }
    }
}
