using System;
using System.Collections.Generic;
using System.Linq;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
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

        [HttpPost]
        public IActionResult CreateCashier(string username)
        {
            try
            {
                _cashierRepository.CreateCashier(username);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

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

        [HttpPost]
        public IActionResult CreateProduct(string name, int price)
        {
            try
            {
                _productRepository.CreateProduct(name, price);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public Receipt CreateReceipt(int cashRegisterId, ICollection<Product> products)
        {
            var receipt = _receiptRepository.CreateReceipt(cashRegisterId);
            foreach (var product in products)
            {
                _receiptProductRepository.CreateReceiptProduct(receipt.Id, product.Id);
            }

            return receipt;
        }

        [HttpPost]
        public bool LoginCashierToCashRegister(int cashierId, int cashRegisterId)
        {
            return _cashRegisterCashierRepository.StartShift(cashierId, cashRegisterId);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCashier(int id)
        {
            if (_cashierRepository.DeleteCashier(id))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCashRegister(int id)
        {
            if(_cashRegisterRepository.DeleteCashRegister(id))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            if (_productRepository.DeleteProduct(id))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public bool DeleteReceipt(Guid id)
        {
            return _receiptRepository.DeleteReceipt(id);
        }

        [HttpPost]
        public bool EditCashierPassword(int cashierId, string password)
        {
            return _cashierRepository.EditCashierPassword(cashierId, password);
        }

        [HttpPost]
        public IActionResult EditProduct(Guid productId,string name, int price)
        {
            var isSuccessfulEditProduct = _productRepository.EditProduct(productId, name, price);
            if (isSuccessfulEditProduct)
                return Ok();

            return NotFound();
        }

        [HttpGet]
        public ICollection<Cashier> ReadCashier()
        {
            return _cashierRepository.ReadCashier().ToList();
        }

        [HttpGet]
        public ICollection<CashRegister> ReadCashRegister()
        {
            return _cashRegisterRepository.ReadCashRegister().ToList();
        }

        [HttpGet("{id}")]
        public Receipt ReadReceipt(Guid id)
        {
            return _receiptRepository.ReadReceipt(id);
        }

        [HttpPost]
        public bool StartShift(int cashierId, int cashRegisterId)
        {
            return _cashRegisterCashierRepository.StartShift(cashierId, cashRegisterId);
        }

        [HttpPost]
        public bool EndShift(int cashierId, int cashRegisterId)
        {
            return _cashRegisterCashierRepository.EndShift(cashierId, cashRegisterId);
        }

        [HttpPost]
        public bool EditShift(int cashierId, int cashRegisterId, DateTime startOfShift, DateTime endOfShift)
        {
            return _cashRegisterCashierRepository.EditShift(cashierId, cashRegisterId, startOfShift, endOfShift);
        }

        [HttpGet("{id}")]
        public ICollection<CashRegisterCashier> CashRegisterByCashRegisterId(int id)
        {
            var cashRegisters = _cashRegisterCashierRepository.ReadCashRegisterCashierByCashRegisterId(id).ToList();

            return cashRegisters;
        }

        [HttpGet("{id}")]
        public ICollection<CashRegisterCashier> CashRegisterByCashierId(int id)
        {
            var cashRegisters = _cashRegisterCashierRepository.ReadCashRegisterCashierByCashierId(id).ToList();

            return cashRegisters;
        }

        [HttpGet("{id}")]
        public ICollection<Receipt> ReceiptsByShiftId(int id)
        {
            var receipts = _receiptRepository.ReadReceiptByCashRegisterCashierId(id).ToList();

            return receipts;
        }

        [HttpGet]
        public ICollection<Product> ReadProducts()
        {
            var products = _productRepository.ReadProducts().ToList();

            return products;
        }
    }
}