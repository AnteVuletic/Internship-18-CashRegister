using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface ICashRegisterCashierRepository
    {
        bool StartShift(int cashierId, int cashierRegisterId);
        IQueryable<CashRegisterCashier> ReadCashRegisterCashierByCashRegisterId(int cashRegisterId);
        IQueryable<CashRegisterCashier> ReadCashRegisterCashierByCashierId(int cashierId);
        CashRegisterCashier GetStartedShiftOrDefault(int cashierId);
        bool EndShift(int cashierId, int cashRegisterId);
        bool EditShift(CashRegisterCashier editedCashRegisterCashier);
        bool DeleteShift(int cashierId, int cashRegisterId);
    }
}
