using System;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using CashierRegister.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
                    id = userAuthorized.Id,
                    username = userAuthorized.Username,
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
                    id = user.Id,
                    username = user.Username,
                    token = _jwtHelper.GetJwtToken(user)
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult RegenerateToken()
        {
            var accessToken = Request.Headers["Authorization"];
            return Ok(new
            {
                token = _jwtHelper.GetNewToken(accessToken)
            });
        }

        [HttpGet, Authorize]
        public IActionResult GetUser()
        {
            var accessToken = Request.Headers["Authorization"];
            var id = _jwtHelper.GetUserIdFromToken(accessToken);
            var user = _cashierRepository.ReadCashier(id);
            return Ok(new
            {
                cashierId = user.Id,
                username = user.Username,
                accessToken
            });
        }
    }
}