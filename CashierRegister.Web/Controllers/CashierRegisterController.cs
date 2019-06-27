﻿using System;
using System.Collections.Generic;
using System.Linq;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashierRegister.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CashierRegisterController : ControllerBase
    {
        public CashierRegisterController(
            ICashRegisterRepository cashRegisterRepository,
            ICashRegisterCashierRepository cashRegisterCashierRepository)
        {
            _cashRegisterRepository = cashRegisterRepository;
            _cashRegisterCashierRepository = cashRegisterCashierRepository;
        }

        private readonly ICashRegisterRepository _cashRegisterRepository;
        private readonly ICashRegisterCashierRepository _cashRegisterCashierRepository;

        [HttpPost]
        public IActionResult CreateCashRegister(string location)
        {
            try
            {
                _cashRegisterRepository.RegisterCashRegister(location);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCashRegister(int id)
        {
            if(_cashRegisterRepository.DeleteCashRegister(id))
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        public ICollection<CashRegister> ReadCashRegister()
        {
            return _cashRegisterRepository.ReadCashRegister().ToList();
        }

        [HttpGet("{id}")]
        public ICollection<CashRegisterCashier> CashRegisterByCashRegisterId(int id)
        {
            var cashRegisters = _cashRegisterCashierRepository.ReadCashRegisterCashierByCashRegisterId(id).ToList();

            return cashRegisters;
        }

    }
}