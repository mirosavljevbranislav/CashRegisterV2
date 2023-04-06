using CashRegister.Domain.Models;

namespace CashRegister.Application.Interface
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(ProductBill pb, int productPrice, string currency);
    }
}