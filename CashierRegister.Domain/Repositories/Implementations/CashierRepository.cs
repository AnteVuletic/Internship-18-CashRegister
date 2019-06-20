using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class CashierRepository : RepositoryAbstraction, ICashierRepository
    {
        public CashierRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext){}

        public void CreateCashier(string username)
        {
            var doesCashierExist = _dbCashierRegisterContext.Cashiers.Any(cashier =>
                string.Equals(cashier.Username, username, StringComparison.CurrentCultureIgnoreCase));

            if(doesCashierExist)
                throw new Exception("Cashier exists exception");

            var newCashier = new Cashier
            {
                Username = username
            };
            _dbCashierRegisterContext.Cashiers.Add(newCashier);
            _dbCashierRegisterContext.SaveChanges();
        }

        public IQueryable<Cashier> ReadCashier()
        {
            var cashiers = _dbCashierRegisterContext.Cashiers;

            return cashiers;
        }

        private Cashier ReadCashier(int id)
        {
            var cashierWithId = _dbCashierRegisterContext.Cashiers.Find(id);

            if(cashierWithId == null) 
                throw new Exception($"Cashier with ID: {id} not exists exception");

            return cashierWithId;
        }

        public bool DeleteCashier(int id)
        {
            var cashierWithId = ReadCashier(id);

            _dbCashierRegisterContext.Cashiers.Remove(cashierWithId);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public bool EditCashierPassword(int id, string password)
        {
            var cashierWithId = ReadCashier(id);

            cashierWithId.Password = password;
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }
    }
}
