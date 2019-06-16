using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CashierRegister.Data.Entities
{
    public class CashierRegisterContext : DbContext
    {
        public CashierRegisterContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<CashRegisterCashier> CashRegisterCashiers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptProduct> ReceiptProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashRegisterCashier>()
                .HasKey(cashRegisterCashier => new
                        {
                            cashRegisterCashier.CashRegisterId,
                            cashRegisterCashier.CashierId
                        }
                );

            modelBuilder.Entity<CashRegisterCashier>()
                .HasOne(cashRegisterCashier => cashRegisterCashier.CashRegister)
                .WithMany(cashRegister => cashRegister.CashRegisterCashiers)
                .HasForeignKey(cashRegisterCashier => cashRegisterCashier.CashRegisterId);

            modelBuilder.Entity<CashRegisterCashier>()
                .HasOne(cashRegisterCashier => cashRegisterCashier.Cashier)
                .WithMany(cashier => cashier.Cashiers)
                .HasForeignKey(cashRegisterCashier => cashRegisterCashier.CashierId);

            modelBuilder.Entity<ReceiptProduct>()
                .HasKey(receiptProduct => new
                        {
                            receiptProduct.ProductId,
                            receiptProduct.ReceiptId
                        }
                );

            modelBuilder.Entity<ReceiptProduct>()
                .HasOne(receiptProduct => receiptProduct.Receipt)
                .WithMany(receipt => receipt.ReceiptProducts)
                .HasForeignKey(receiptProduct => receiptProduct.ReceiptId);

            modelBuilder.Entity<ReceiptProduct>()
                .HasOne(receiptProduct => receiptProduct.Product)
                .WithMany(product => product.ReceiptProducts)
                .HasForeignKey(receiptProduct => receiptProduct.ProductId);
        }
    }
}
