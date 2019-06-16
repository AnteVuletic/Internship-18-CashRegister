using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class ProductRepository : RepositoryAbstraction, IProductRepository
    {
        public ProductRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext) {}

        public bool CreateProduct(string name, int price)
        {
            var hasProductName = _dbCashierRegisterContext.Products.Any(product =>
                string.Equals(product.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (hasProductName)
                throw new Exception($"Product with name: {name} already exists");

            var newProduct = new Product
            {
                Id = new Guid(),
                Name = name,
                Price = price
            };

            _dbCashierRegisterContext.Products.Add(newProduct);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public Product ReadProduct(Guid id)
        {
            var productInQuestion = _dbCashierRegisterContext.Products.Find(id);

            if (productInQuestion == null)
                throw new Exception($"No product with ID: {id}");

            return productInQuestion;
        }

        public bool EditProduct(Guid id, string name, int price)
        {
            var productInQuestion = ReadProduct(id);

            productInQuestion.Name = name;
            productInQuestion.Price = price;

            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            var productInQuestion = ReadProduct(id);

            _dbCashierRegisterContext.Remove(productInQuestion);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }
    }
}
