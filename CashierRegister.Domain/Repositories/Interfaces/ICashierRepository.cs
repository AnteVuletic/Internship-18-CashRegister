using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface ICashierRepository
    {
        void CreateCashier(string username, string password);
        IQueryable<Cashier> ReadCashier();
        bool DeleteCashier(int id);
        bool EditCashierPassword(int id, string password);
        Cashier AuthorizeUser(string username, string password);
    }
}
