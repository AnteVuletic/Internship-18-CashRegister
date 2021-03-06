﻿using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Infrastructure.DataTransferObjects
{
    public class ReceiptDto
    {
        public Receipt Receipt { get; set; }
        public ICollection<ProductDto> ProductsOnReceipt { get; set; }
    }
}
