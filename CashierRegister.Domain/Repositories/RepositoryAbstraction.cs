using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities;

namespace CashierRegister.Domain.Repositories
{
    public abstract class RepositoryAbstraction
    {
        protected readonly CashierRegisterContext _dbCashierRegisterContext;

        protected RepositoryAbstraction(CashierRegisterContext cashierRegisterContext)
        {
            _dbCashierRegisterContext = cashierRegisterContext;
        }
    }
}
