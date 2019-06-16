using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class CashRegisterCashierRepository : RepositoryAbstraction, ICashRegisterCashierRepository
    {
        public CashRegisterCashierRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext) {}

        public bool StartShift(int cashierId, int cashRegister)
        {
            var cashierWithId = _dbCashierRegisterContext.Cashiers.Find(cashierId);
            var cashierRegisterWithId = _dbCashierRegisterContext.CashRegisters.Find(cashRegister);

            if (cashierWithId == null || cashierRegisterWithId == null)
                throw new Exception("Invalid Cashier or CashierRegister ID");

            var shift = new CashRegisterCashier
            {
                CashRegisterId = cashRegister,
                CashRegister = cashierRegisterWithId,
                CashierId = cashierId,
                Cashier = cashierWithId,
                StartOfShift = DateTime.Now
            };

            _dbCashierRegisterContext.CashRegisterCashiers.Add(shift);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public IQueryable<CashRegisterCashier> ReadCashRegisterCashierByCashRegisterId(int cashierRegisterId)
        {
            var shiftsOnCashRegister = _dbCashierRegisterContext.CashRegisterCashiers.Where(cashRegisterCashier =>
                cashRegisterCashier.CashRegisterId == cashierRegisterId);

            return shiftsOnCashRegister;
        }
        public IQueryable<CashRegisterCashier> ReadCashRegisterCashierByCashierId(int cashierId)
        {
            var shiftsByCashier = _dbCashierRegisterContext.CashRegisterCashiers.Where(cashRegisterCashier =>
                cashRegisterCashier.CashierId == cashierId);

            return shiftsByCashier;
        }

        public bool EndShift(int cashierId, int cashRegisterId)
        {
            var shiftToEnd = _dbCashierRegisterContext.CashRegisterCashiers
                .FirstOrDefault(cashRegisterCashier =>
                    cashRegisterCashier.CashierId == cashierId &&
                    cashRegisterCashier.CashRegisterId == cashRegisterId &&
                    cashRegisterCashier.EndOfShift == null
                );
            
            if(shiftToEnd == null)
                throw new Exception("There is no shift started with given ID's");

            shiftToEnd.EndOfShift = DateTime.Now;
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public bool EditShift(int cashierId, int cashRegisterId, DateTime startOfShift, DateTime endOfShift)
        {
            var shiftInQuestion = _findShift(_dbCashierRegisterContext, cashierId, cashRegisterId);

            if(shiftInQuestion == null)
                throw new Exception("There is no shift with given ID's");

            shiftInQuestion.StartOfShift = startOfShift;
            shiftInQuestion.EndOfShift = endOfShift;
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public bool DeleteShift(int cashierId, int cashRegisterId)
        {
            var shiftInQuestion = _findShift(_dbCashierRegisterContext, cashierId, cashRegisterId);

            if(shiftInQuestion == null)
                throw new Exception("There is no shift with given ID's");

            _dbCashierRegisterContext.Remove(shiftInQuestion);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        private readonly Func<CashierRegisterContext, int, int, CashRegisterCashier> _findShift
            = (context, cashierId, cashRegisterId) => context.CashRegisterCashiers.FirstOrDefault(cashRegisterCashier =>
                cashRegisterCashier.CashierId == cashierId &&
                cashRegisterCashier.CashRegisterId == cashRegisterId
            );
    }
}
