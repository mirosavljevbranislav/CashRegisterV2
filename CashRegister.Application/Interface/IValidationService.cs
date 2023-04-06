namespace CashRegister.Application.Interface
{
    public interface IValidationService
    {
        bool IsValidBillNumber(string billNumber);
        bool isValidCreditCard(string creditCard);
    }
}