using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product productToAdd);
        IQueryable<Product> ReadProducts();
        bool EditProduct(Product productEdited);
        bool DeleteProduct(Guid id);
    }
}
