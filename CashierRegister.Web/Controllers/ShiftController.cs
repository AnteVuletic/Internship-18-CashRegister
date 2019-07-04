using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierRegister.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        public ShiftController(
            ICashRegisterCashierRepository cashRegisterCashierRepository)
        {
            _cashRegisterCashierRepository = cashRegisterCashierRepository;
        }

        private readonly ICashRegisterCashierRepository _cashRegisterCashierRepository;

        [HttpPost]
        public IActionResult StartShift([FromBody] CashRegisterCashier cashRegisterCashier)
        {
            if (_cashRegisterCashierRepository.StartShift(cashRegisterCashier.CashierId,
                cashRegisterCashier.CashRegisterId))
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult EndShift([FromBody] CashRegisterCashier cashRegisterCashier)
        {
            if (_cashRegisterCashierRepository.EndShift(cashRegisterCashier.CashierId,
                cashRegisterCashier.CashRegisterId))
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult EditShift([FromBody] CashRegisterCashier cashRegisterCashier)
        {
            if (_cashRegisterCashierRepository.EditShift(cashRegisterCashier))
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteShift([FromBody] CashRegisterCashier cashRegisterCashier)
        {
            if (_cashRegisterCashierRepository.DeleteShift(cashRegisterCashier.CashierId,
                cashRegisterCashier.CashRegisterId))
                return Ok();
            return BadRequest();
        }
    }
}