using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace CashierRegister.Web.DataSeeds
{
    public static class TaxSeed
    {
        public static void CreateTaxSeed(CashierRegisterContext dbContext)
        {
            if (dbContext.Taxes.Count() != 0) return;

            dbContext.Taxes.Add(new Tax
            {
                Name = "Direct",
                Percentage = 25,
                TaxType = TaxType.Direct
            });

            dbContext.SaveChanges();
        }
    }
}
