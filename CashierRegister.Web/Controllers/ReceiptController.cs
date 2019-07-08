using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using CashierRegister.Infrastructure.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierRegister.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReceiptController : ControllerBase
    {
        public ReceiptController(
            IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        private readonly IReceiptRepository _receiptRepository;

        [HttpPost]
        public Receipt CreateReceipt([FromBody]ReceiptDto receiptDto)
        {
            var receipt = _receiptRepository.CreateReceipt(receiptDto.CashRegisterId, receiptDto.ProductsOnReceipt);
            return receipt;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReceipt(Guid id)
        {
            if (_receiptRepository.DeleteReceipt(id))
                return Ok();
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Receipt ReadReceipt(Guid id)
        {
            return _receiptRepository.ReadReceipt(id);
        }

        [HttpGet("{id}")]
        public ICollection<Receipt> ReceiptsByShift(int id)
        {
            var receipts = _receiptRepository.ReadReceiptByCashRegisterCashierId(id).ToList();

            return receipts;
        }
    }
}