using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.BillCommands;
using MediatR;

namespace CashRegister.Application.Mediatr.Handlers.BillHandlers.CommandHandlers
{
    public class AddNewBillHandler : IRequestHandler<AddNewBillCommand, bool>
    {
        private readonly IBillService _billService;
        private readonly IValidationService _validationService;

        public AddNewBillHandler(IBillService billService, IValidationService validationService)
        {
            _billService = billService;
            _validationService = validationService;

        }
        public async Task<bool> Handle(AddNewBillCommand request, CancellationToken cancellationToken)
        {
            if (!_validationService.IsValidBillNumber(request.Bill.BillNumber) && !_validationService.isValidCreditCard(request.Bill.CreditCardNumber))
            {
                return false;
            }
            var bill = await _billService.CreateNewBill(bill: request.Bill);

            return bill;
        }
    }
}
