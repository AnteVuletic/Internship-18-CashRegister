using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
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
        public IActionResult CreateProduct([FromBody]Product product)
        {
            try
            {
                _productRepository.CreateProduct(product);
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
        public IActionResult EditProduct([FromBody]Product productEdited)
        {
            var isSuccessfulEditProduct = _productRepository.EditProduct(productEdited);
            if (isSuccessfulEditProduct)
                return Ok();

            return NotFound();
        }

        [HttpGet]
        public ICollection<Product> ReadProducts()
        {
            var products = _productRepository.ReadProducts().ToList();

            return products;
        }

    }
}