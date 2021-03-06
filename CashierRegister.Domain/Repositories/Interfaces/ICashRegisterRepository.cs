﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface ICashRegisterRepository
    {
        void RegisterCashRegister(string location);
        IQueryable<CashRegister> ReadCashRegister();
        void EditCashRegister(int id, string location);
        bool DeleteCashRegister(int id);
    }
}
