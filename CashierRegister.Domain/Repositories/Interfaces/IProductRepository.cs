using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        bool CreateProduct(string name, int price);
        Product ReadProduct(Guid id);
        bool EditProduct(Guid id, string name, int price);
        bool DeleteProduct(Guid id);
    }
}
