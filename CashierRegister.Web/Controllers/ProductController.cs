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
    public class ProductController : ControllerBase
    {
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private readonly IProductRepository _productRepository;

        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductDto productDto)
        {
            try
            {
                _productRepository.CreateProduct(productDto.Product, productDto.ProductTax);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            if (_productRepository.DeleteProduct(id))
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult EditProduct([FromBody]ProductDto productDto)
        {
            var isSuccessfulEditProduct = _productRepository.EditProduct(productDto.Product, productDto.ProductTax);
            if (isSuccessfulEditProduct)
                return Ok();

            return NotFound();
        }

        [HttpGet]
        public ICollection<ProductDto> ReadProducts()
        {
            var products = _productRepository.ReadProducts();

            return products;
        }

    }
}