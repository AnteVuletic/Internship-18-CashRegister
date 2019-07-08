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
    public class TaxController : ControllerBase
    {
        public TaxController(
            ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        private ITaxRepository _taxRepository;

        [HttpGet]
        public ICollection<Tax> ReadTaxes()
        {
            return _taxRepository.ReadTaxes().ToList();
        }
    }
}