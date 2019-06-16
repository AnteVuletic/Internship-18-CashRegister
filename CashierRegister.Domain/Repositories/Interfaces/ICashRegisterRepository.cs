using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface ICashRegisterRepository
    {
        CashRegister RegisterCashRegister(string location);
        CashRegister ReadCashRegister(int id);
        bool DeleteCashRegister(int id);
    }
}
