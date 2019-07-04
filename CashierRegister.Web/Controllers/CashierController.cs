using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierRegister.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CashierController : ControllerBase
    {
        public CashierController(
            ICashierRepository cashierRepository,
            ICashRegisterCashierRepository cashRegisterCashierRepository)
        {
            _cashierRepository = cashierRepository;
            _cashRegisterCashierRepository = cashRegisterCashierRepository;
        }

        private readonly ICashierRepository _cashierRepository;
        private readonly ICashRegisterCashierRepository _cashRegisterCashierRepository;

        [HttpPost]
        public IActionResult CreateCashier(string username, string password)
        {
            try
            {
                _cashierRepository.CreateCashier(username, password);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCashier(int id)
        {
            if (_cashierRepository.DeleteCashier(id))
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult EditCashierPassword(int cashierId, string password)
        {
            if (_cashierRepository.EditCashierPassword(cashierId, password))
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        public ICollection<Cashier> ReadCashier()
        {
            return _cashierRepository.ReadCashier().ToList();
        }

        [HttpGet("{id}")]
        public ICollection<CashRegisterCashier> CashRegisterByCashierId(int id)
        {
            var cashRegisters = _cashRegisterCashierRepository.ReadCashRegisterCashierByCashierId(id).ToList();

            return cashRegisters;
        }
    }
}