using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierRegister.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CashierRegisterController : ControllerBase
    {
        public CashierRegisterController(
            ICashierRepository cashierRepository,
            ICashRegisterCashierRepository cashRegisterCashierRepository,
            ICashRegisterRepository cashRegisterRepository,
            IProductRepository productRepository,
            IReceiptProductRepository receiptProductRepository,
            IReceiptRepository receiptRepository
            )
        {
            _cashierRepository = cashierRepository;
            _cashRegisterCashierRepository = cashRegisterCashierRepository;
            _cashRegisterRepository = cashRegisterRepository;
            _productRepository = productRepository;
            _receiptProductRepository = receiptProductRepository;
            _receiptRepository = receiptRepository;
        }

        private readonly ICashierRepository _cashierRepository;
        private readonly ICashRegisterCashierRepository _cashRegisterCashierRepository;
        private readonly ICashRegisterRepository _cashRegisterRepository;
        private readonly IProductRepository _productRepository;
        private readonly IReceiptProductRepository _receiptProductRepository;
        private readonly IReceiptRepository _receiptRepository;

    }
}