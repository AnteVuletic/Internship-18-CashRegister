using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Data.Enums;
using CashierRegister.Domain.Repositories.Interfaces;
using CashierRegister.Infrastructure.DataTransferObjects;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class ProductRepository : RepositoryAbstraction, IProductRepository
    {
        public ProductRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext)
        {
        }

        public void CreateProduct(Product productToAdd,Tax taxToAdd)
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

            var taxOrDefault = _dbCashierRegisterContext.Taxes.SingleOrDefault(tax => tax.Name == taxToAdd.Name);
            if (taxOrDefault == null)
            {
                taxOrDefault = new Tax
                {
                    Name = taxToAdd.Name,
                    Percentage = taxToAdd.Percentage,
                    TaxType = TaxType.Excise
                };

                _dbCashierRegisterContext.Taxes.Add(taxOrDefault);
            }

            var taxesOnProduct = new ProductTax
            {
                Product = newProduct,
                ProductId = newProduct.Id,
                Tax = taxOrDefault,
                TaxId = taxOrDefault.Id
            };

            _dbCashierRegisterContext.ProductTaxes.Add(taxesOnProduct);

            var directTax = _dbCashierRegisterContext.Taxes.First(tax => tax.TaxType == TaxType.Direct);

            var directTaxOnProduct = new ProductTax
            {
                Product = newProduct,
                ProductId = newProduct.Id,
                Tax = directTax,
                TaxId = directTax.Id
            };

            _dbCashierRegisterContext.ProductTaxes.Add(directTaxOnProduct);

            _dbCashierRegisterContext.SaveChanges();
        }

        private Product ReadProduct(Guid id)
        {
            var productInQuestion = _dbCashierRegisterContext.Products.Find(id);

            if (productInQuestion == null)
                throw new Exception($"No product with ID: {id}");

            return productInQuestion;
        }

        public ICollection<ProductDto> ReadProducts()
        {
            var productQueryable = _dbCashierRegisterContext.Products;
            var taxesQueryable = _dbCashierRegisterContext.Taxes;

            var productsDtoList = _createProductDtoCollection(productQueryable, taxesQueryable);

            return productsDtoList;
        }

        public ICollection<ProductDto> ReadProductsByName(string searchFilter)
        { 
            var productsFilteredQueryable = _dbCashierRegisterContext.Products.Where(product =>
                product.Name.ToLower().Contains(searchFilter.ToLower()));
            var taxesQueryable = _dbCashierRegisterContext.Taxes;

            var productsDtoList = _createProductDtoCollection(productsFilteredQueryable, taxesQueryable);

            return productsDtoList;
        }

        public ProductDto ReadProductById(Guid id)
        {
            var productWithId = _dbCashierRegisterContext.Products.Find(id);
            var taxesQueryable = _dbCashierRegisterContext.Taxes;

            var productDtoWithId = _createProductDto(productWithId, taxesQueryable);

            return productDtoWithId;
        }

        public bool EditProduct(Product productEdited,Tax taxEdited)
        {
            var productInQuestion = ReadProduct(productEdited.Id);

            productInQuestion.Name = productEdited.Name;
            productInQuestion.Price = productEdited.Price;
            productInQuestion.CountInStorage = productEdited.CountInStorage;

            var productExciseTaxOrDefault = _dbCashierRegisterContext.Taxes.FirstOrDefault(tax => tax.Name == taxEdited.Name);

            if (productExciseTaxOrDefault != null)
            {
                productExciseTaxOrDefault.Percentage = taxEdited.Percentage;
            }
            else
            {
                productExciseTaxOrDefault = new Tax
                {
                    Name = taxEdited.Name,
                    Percentage = taxEdited.Percentage,
                    TaxType = TaxType.Excise
                };

                _dbCashierRegisterContext.Taxes.Add(productExciseTaxOrDefault);

                var productTax = new ProductTax
                {
                    Product = productInQuestion,
                    ProductId = productInQuestion.Id,
                    Tax = productExciseTaxOrDefault,
                    TaxId = productExciseTaxOrDefault.Id
                };

                _dbCashierRegisterContext.ProductTaxes.Add(productTax);
            }

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

        private ICollection<ProductDto> _createProductDtoCollection(IQueryable<Product> productQueryable, IQueryable<Tax> taxesQueryable)
        {
            var productsDtoList = new List<ProductDto>();
            foreach (var product in productQueryable)
            {
                var taxOnProduct = taxesQueryable.First(tax => tax.ProductTaxes.Any(productTax => productTax.ProductId == product.Id) && tax.TaxType == TaxType.Excise);
                productsDtoList.Add(new ProductDto
                {
                    Product = product,
                    ProductTax = taxOnProduct
                });
            }

            return productsDtoList;
        }

        private ProductDto _createProductDto(Product productWithId, IQueryable<Tax> taxesQueryable)
        {
            var taxOnProduct = taxesQueryable.First(tax => tax.ProductTaxes.Any(productTax => productTax.ProductId == productWithId.Id) && tax.TaxType == TaxType.Excise);
            var productDtoWithId = new ProductDto
            {
                Product = productWithId,
                ProductTax = taxOnProduct
            };

            return productDtoWithId;
        }
    }
}
