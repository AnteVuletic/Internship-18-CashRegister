using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface ITaxRepository
    {
        IQueryable<Tax> ReadTaxes();
    }
}
