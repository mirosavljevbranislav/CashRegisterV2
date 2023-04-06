using CashRegister.Application.Dto;
using MediatR;

namespace CashRegister.Application.Mediatr.Commands.ProductBillCommands
{
    public class NewProductBillCommand : IRequest<bool>
    {
        public int  ProductID { get; set; }
        public string BillNumber { get; set; }  
        public ProductBillDto ProductBillDto { get; set; }

        public NewProductBillCommand(int productID, string billNumber, ProductBillDto productBillDto)
        {
            ProductID = productID;
            BillNumber = billNumber;
            ProductBillDto = productBillDto;
        }
    }
}
