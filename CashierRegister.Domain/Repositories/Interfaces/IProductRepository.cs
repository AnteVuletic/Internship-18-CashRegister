using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product CreateProduct(string name, int price);
        Product ReadProduct(Guid id);
        IQueryable<Product> ReadProducts();
        bool EditProduct(Guid id, string name, int price);
        bool DeleteProduct(Guid id);
    }
}
