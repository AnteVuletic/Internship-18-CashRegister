using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface ICashierRepository
    {
        Cashier CreateCashier(string username);
        Cashier ReadCashier(int id);
        bool DeleteCashier(int id);
        bool EditCashierPassword(int id, string password);
    }
}
