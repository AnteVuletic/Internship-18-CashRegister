using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class CashRegisterRepository : RepositoryAbstraction, ICashRegisterRepository
    {
        public CashRegisterRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext){}

        public CashRegister RegisterCashRegister(string location)
        {
            var newCashRegister = new CashRegister
            {
                Location = location
            };
            _dbCashierRegisterContext.CashRegisters.Add(newCashRegister);
            _dbCashierRegisterContext.SaveChanges();

            return newCashRegister;
        }

        public CashRegister ReadCashRegister(int id)
        {
            var cashRegisterWithId = _dbCashierRegisterContext.CashRegisters.Find(id);
            
            if(cashRegisterWithId == null)
                throw new Exception($"CashRegister with ID: {id} not exists");

            return cashRegisterWithId;
        }

        public bool DeleteCashRegister(int id)
        {
            var cashRegisterWithId = ReadCashRegister(id);

            _dbCashierRegisterContext.Remove(cashRegisterWithId);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }
    }
}
