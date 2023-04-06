using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<ProductBill> ProductBills { get; set; }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Name).NotNull();
            RuleFor(p => p.Price).NotNull();
        }

    }
}
