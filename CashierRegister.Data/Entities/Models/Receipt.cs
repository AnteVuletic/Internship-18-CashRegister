﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int CashRegisterCashierId { get; set; }
        public CashRegisterCashier CashRegisterCashier { get; set; }
        public ICollection<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
