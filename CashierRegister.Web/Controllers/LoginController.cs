using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Domain.Helpers;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult LoginCashier(string username, string password)
        {
            try
            {
                var userAuthorized = _cashierRepository.AuthorizeUser(username, password);
                return Ok(new {token = _jwtHelper.GetJwtToken(userAuthorized)});
            }
            catch (Exception)
            {
                return ValidationProblem();
            }
        }
    }
}