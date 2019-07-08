using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using CashierRegister.Web.DataSeeds;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class TaxRepository : RepositoryAbstraction, ITaxRepository
    {
        public TaxRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext)
        {
            TaxSeed.CreateTaxSeed(cashierRegisterContext);
        }

        public IQueryable<Tax> ReadTaxes()
        {
            return _dbCashierRegisterContext.Taxes;
        }
    }
}
