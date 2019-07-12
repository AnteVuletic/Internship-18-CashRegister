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
        public IActionResult CreateReceipt([FromBody]ReceiptDto receiptDto)
        {
            if (receiptDto.ProductsOnReceipt.Count == 0)
                return BadRequest();
            var receiptSavedDto = _receiptRepository.CreateReceipt(receiptDto);
            return Ok(receiptSavedDto);
        }


        [HttpGet("{id}")]
        public Receipt ReadReceipt(Guid id)
        {
            return _receiptRepository.ReadReceipt(id);
        }

    }
}