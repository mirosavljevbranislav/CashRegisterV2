using CashRegister.Application.Interface;
using CashRegister.Application.Mediatr.Commands.BillCommands;
using CashRegister.Application.Mediatr.Commands.HandlerCommands;
using CashRegister.Application.Mediatr.Handlers.BillHandlers.QueryHandlers;
using CashRegister.Application.Mediatr.Queries.BillQueries;
using CashRegister.Domain.Dto;
using CashRegister.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IMediator _billMediator;
        
        public BillController(IMediator mediator)
        {
            _billMediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBills()
        {
            var query = new GetAllBillsQuery();
            var result = await _billMediator.Send(query);
            return result != null ? Ok(result) : BadRequest();
        }


        [HttpGet("{billNumber}")]
        public async Task<IActionResult> GetBillByBillNumber(string billNumber)
        {
            var query = new GetBillByNumberQuery(billNumber: billNumber);
            var result = await _billMediator.Send(query);
            return result == null ? NotFound($" Bill with number: {billNumber} not found.") : Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AddNewBill(Bill bill)
        {
            var query = new AddNewBillCommand(bill: bill);
            var result = await _billMediator.Send(query);
            return result ? Ok(result) : BadRequest();


        }

        [HttpPut("{billNumber}")]
        public async Task<IActionResult> EditBill(string billNumber, [FromBody] BillDto billDto)
        {
            var query = new EditBillCommand(billNumber: billNumber, billDto: billDto);
            var result = await _billMediator.Send(query);
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete("{billNumber}")]
        public async Task<IActionResult> DeleteBill(string billNumber)
        {
            var query = new DeleteBillCommand(billNumber: billNumber);
            var deletedBill = await _billMediator.Send(query);
            return deletedBill ? Ok(deletedBill) : BadRequest();
        }
    }
}
