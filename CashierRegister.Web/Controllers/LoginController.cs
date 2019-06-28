using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using CashierRegister.Infrastructure.DataTransferObjects;
using CashierRegister.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CashierRegister.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        public LoginController(
            ICashierRepository cashierRepository,
            JwtHelper jwtHelper)
        {
            _cashierRepository = cashierRepository;
            _jwtHelper = jwtHelper;
        }

        private readonly ICashierRepository _cashierRepository;
        private readonly JwtHelper _jwtHelper;

        [HttpPost]
        public IActionResult LoginCashier([FromBody] Cashier cashier)
        {
            try
            {
                var userAuthorized = _cashierRepository.AuthorizeUser(cashier.Username, cashier.Password);
                return Ok(new
                {
                    userAuthorized.Id,
                    userAuthorized.Username,
                    token = _jwtHelper.GetJwtToken(userAuthorized)
                });
            }
            catch (Exception)
            {
                return ValidationProblem();
            }
        }

        [HttpPost]
        public IActionResult RegisterCashier([FromBody] Cashier cashier)
        {
            try
            {
                var user = _cashierRepository.CreateCashier(cashier.Username, cashier.Password);
                return Ok(new
                {
                    user.Id,
                    user.Username,
                    token = _jwtHelper.GetJwtToken(user)
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult RegenerateToken([FromBody] string token)
        {
            return Ok(new
            {
                token = _jwtHelper.GetNewToken(token)
            });
        }
    }
}