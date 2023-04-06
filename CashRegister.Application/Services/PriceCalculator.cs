using CashRegister.Application.Interface;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(ProductBill pb, int productPrice, string currency)
        {
            decimal totalPrice = pb.ProductsPrice + (pb.ProductQuantity * productPrice);
            switch (currency)
            {
                case "EUR":
                    return totalPrice *= 0.0085m;
                case "USD":
                    return totalPrice *= 0.0093m;
                case "RSD":
                    return totalPrice;
            }
            return totalPrice;
        }
    }
}
