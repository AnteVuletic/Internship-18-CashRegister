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

        public void CreateProduct(Product productToAdd)
        {
            var hasProductName = _dbCashierRegisterContext.Products.Any(product =>
                string.Equals(product.Name, productToAdd.Name, StringComparison.CurrentCultureIgnoreCase));

            if (hasProductName)
                throw new Exception($"Product with name: {productToAdd.Name} already exists");

            var newProduct = new Product
            {
                Id = new Guid(),
                Name = productToAdd.Name,
                Price = productToAdd.Price,
                CountInStorage =  productToAdd.CountInStorage
            };

            _dbCashierRegisterContext.Products.Add(newProduct);
            _dbCashierRegisterContext.SaveChanges();
        }

        private Product ReadProduct(Guid id)
        {
            var productInQuestion = _dbCashierRegisterContext.Products.Find(id);

            if (productInQuestion == null)
                throw new Exception($"No product with ID: {id}");

            return productInQuestion;
        }

        public IQueryable<Product> ReadProducts()
        {
            var products = _dbCashierRegisterContext.Products;

            return products;
        }

        public bool EditProduct(Product productEdited)
        {
            var productInQuestion = ReadProduct(productEdited.Id);

            productInQuestion.Name = productEdited.Name;
            productInQuestion.Price = productEdited.Price;
            productInQuestion.CountInStorage = productEdited.CountInStorage;

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
