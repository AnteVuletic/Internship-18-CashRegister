using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Infrastructure.DataTransferObjects;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product productToAdd,Tax taxToAdd);
        ICollection<ProductDto> ReadProducts();
        bool EditProduct(Product productEdited,Tax taxEdited);
        bool DeleteProduct(Guid id);
    }
}
