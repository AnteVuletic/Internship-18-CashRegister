using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace CashierRegister.Data.ExampleDataSeeds
{
    public static class DataSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cashier>().HasData(
                new Cashier
                {
                    Id = 1,
                    Password = Hash("12345"),
                    Username = "Test"
                });

            modelBuilder.Entity<CashRegister>().HasData(new List<CashRegister>
            {
                new CashRegister
                {
                    Id = 1,
                    Location = "Split"
                },
                new CashRegister
                {
                    Id = 2,
                    Location = "Zagreb"
                }
            });

            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("4698c02b-0f01-4a1d-9b7e-258f79798493"),
                    Name = "Kupus",
                    Price = 3
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("cc6d22e0-1884-449d-8cb6-253a2538dca4"),
                    Name = "Camel",
                    Price = 5
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"),
                    Name = "Lubenica",
                    Price = 2
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("6c76166f-5ffb-437b-b44a-d9c77b25b109"),
                    Name = "Čips",
                    Price = 4
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("cc34e56e-aabb-4119-863b-146e3d8300f7"),
                    Name = "Coca-cola",
                    Price = 6
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("71ee9982-cb38-4de8-8a81-0310b4d015d2"),
                    Name = "Šunka",
                    Price = 3
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("96e677c3-145d-40ab-8206-f8c5627c536b"),
                    Name = "Burek",
                    Price = 8
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("adf014c5-eae5-4c97-aed3-d13782c29092"),
                    Name = "Lucky Strike",
                    Price = 5
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("60d7631b-933a-4d74-b853-c661a8b3b13e"),
                    Name = "Philip Morris",
                    Price = 5
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("eb7cab11-e485-4dcb-bd86-cb4d8d781184"),
                    Name = "Malboro",
                    Price = 6
                },
                new Product
                {
                    CountInStorage = 12,
                    Id = Guid.Parse("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"),
                    Name = "Banana",
                    Price = 3
                }
            });

            modelBuilder.Entity<Tax>().HasData(new List<Tax>
            {
                new Tax
                {
                    Id = 1,
                    Percentage = 25,
                    TaxType = TaxType.Direct,
                    Name = "Direct"
                },
                new Tax
                {
                    Id = 2,
                    Percentage = 0,
                    Name = "Hrana",
                    TaxType = TaxType.Excise
                },
                new Tax
                {
                    Id = 3,
                    Percentage = 130,
                    Name = "Duhanski proizvodi",
                    TaxType = TaxType.Excise
                }
            });

            modelBuilder.Entity<ProductTax>().HasData(new List<ProductTax>
            {
                new ProductTax
                {
                    ProductTaxId = 1,
                    ProductId = Guid.Parse("4698c02b-0f01-4a1d-9b7e-258f79798493"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 2,
                    ProductId = Guid.Parse("cc6d22e0-1884-449d-8cb6-253a2538dca4"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 3,
                    ProductId = Guid.Parse("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 4,
                    ProductId = Guid.Parse("6c76166f-5ffb-437b-b44a-d9c77b25b109"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 5,
                    ProductId = Guid.Parse("cc34e56e-aabb-4119-863b-146e3d8300f7"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 6,
                    ProductId = Guid.Parse("71ee9982-cb38-4de8-8a81-0310b4d015d2"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 7,
                    ProductId = Guid.Parse("96e677c3-145d-40ab-8206-f8c5627c536b"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 8,
                    ProductId = Guid.Parse("adf014c5-eae5-4c97-aed3-d13782c29092"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 9,
                    ProductId = Guid.Parse("60d7631b-933a-4d74-b853-c661a8b3b13e"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 10,
                    ProductId = Guid.Parse("eb7cab11-e485-4dcb-bd86-cb4d8d781184"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 11,
                    ProductId = Guid.Parse("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"),
                    TaxId = 1
                },
                new ProductTax
                {
                    ProductTaxId = 12,
                    ProductId = Guid.Parse("4698c02b-0f01-4a1d-9b7e-258f79798493"),
                    TaxId = 2
                },
                new ProductTax
                {
                    ProductTaxId = 13,
                    ProductId = Guid.Parse("cc6d22e0-1884-449d-8cb6-253a2538dca4"),
                    TaxId = 3
                },
                new ProductTax
                {
                    ProductTaxId = 14,
                    ProductId = Guid.Parse("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"),
                    TaxId = 2
                },
                new ProductTax
                {
                    ProductTaxId = 15,
                    ProductId = Guid.Parse("6c76166f-5ffb-437b-b44a-d9c77b25b109"),
                    TaxId = 2
                },
                new ProductTax
                {
                    ProductTaxId = 16,
                    ProductId = Guid.Parse("cc34e56e-aabb-4119-863b-146e3d8300f7"),
                    TaxId = 2
                },
                new ProductTax
                {
                    ProductTaxId = 17,
                    ProductId = Guid.Parse("71ee9982-cb38-4de8-8a81-0310b4d015d2"),
                    TaxId = 2
                },
                new ProductTax
                {
                    ProductTaxId = 18,
                    ProductId = Guid.Parse("96e677c3-145d-40ab-8206-f8c5627c536b"),
                    TaxId = 2
                },
                new ProductTax
                {
                    ProductTaxId = 19,
                    ProductId = Guid.Parse("adf014c5-eae5-4c97-aed3-d13782c29092"),
                    TaxId = 3
                },
                new ProductTax
                {
                    ProductTaxId = 20,
                    ProductId = Guid.Parse("60d7631b-933a-4d74-b853-c661a8b3b13e"),
                    TaxId = 3
                },
                new ProductTax
                {
                    ProductTaxId = 21,
                    ProductId = Guid.Parse("eb7cab11-e485-4dcb-bd86-cb4d8d781184"),
                    TaxId = 3
                },
                new ProductTax
                {
                    ProductTaxId = 22,
                    ProductId = Guid.Parse("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"),
                    TaxId = 2
                }
            });
        }

        private static string Hash(string password)
        {
            const int SaltSize = 16;
            const int HashSize = 20;
            const int NumberOfIterations = 1000;
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            //create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, NumberOfIterations);
            var hash = pbkdf2.GetBytes(HashSize);

            //combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            //convert to base64
            return Convert.ToBase64String(hashBytes);
        }
    }
}
