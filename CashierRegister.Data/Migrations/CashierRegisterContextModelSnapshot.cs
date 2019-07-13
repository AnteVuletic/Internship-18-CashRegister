﻿// <auto-generated />
using System;
using CashierRegister.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashierRegister.Data.Migrations
{
    [DbContext(typeof(CashierRegisterContext))]
    partial class CashierRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.CashRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.ToTable("CashRegisters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Split"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Zagreb"
                        });
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.CashRegisterCashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CashRegisterId");

                    b.Property<int>("CashierId");

                    b.Property<DateTime>("EndOfShift");

                    b.Property<DateTime>("StartOfShift");

                    b.HasKey("Id");

                    b.HasIndex("CashRegisterId");

                    b.HasIndex("CashierId");

                    b.ToTable("CashRegisterCashiers");
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Cashiers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "tj3ZAukuZcd7AYunJd4BHY3Ve/71Rvork5Yf334cQeWvnbge",
                            Username = "Test"
                        });
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountInStorage");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"),
                            CountInStorage = 12,
                            Name = "Kupus",
                            Price = 3
                        },
                        new
                        {
                            Id = new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"),
                            CountInStorage = 12,
                            Name = "Camel",
                            Price = 5
                        },
                        new
                        {
                            Id = new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"),
                            CountInStorage = 12,
                            Name = "Lubenica",
                            Price = 2
                        },
                        new
                        {
                            Id = new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"),
                            CountInStorage = 12,
                            Name = "Čips",
                            Price = 4
                        },
                        new
                        {
                            Id = new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"),
                            CountInStorage = 12,
                            Name = "Coca-cola",
                            Price = 6
                        },
                        new
                        {
                            Id = new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"),
                            CountInStorage = 12,
                            Name = "Šunka",
                            Price = 3
                        },
                        new
                        {
                            Id = new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"),
                            CountInStorage = 12,
                            Name = "Burek",
                            Price = 8
                        },
                        new
                        {
                            Id = new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"),
                            CountInStorage = 12,
                            Name = "Lucky Strike",
                            Price = 5
                        },
                        new
                        {
                            Id = new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"),
                            CountInStorage = 12,
                            Name = "Philip Morris",
                            Price = 5
                        },
                        new
                        {
                            Id = new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"),
                            CountInStorage = 12,
                            Name = "Malboro",
                            Price = 6
                        },
                        new
                        {
                            Id = new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"),
                            CountInStorage = 12,
                            Name = "Banana",
                            Price = 3
                        });
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.ProductTax", b =>
                {
                    b.Property<int>("ProductTaxId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ProductId");

                    b.Property<int>("TaxId");

                    b.HasKey("ProductTaxId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TaxId");

                    b.ToTable("ProductTaxes");

                    b.HasData(
                        new
                        {
                            ProductTaxId = 1,
                            ProductId = new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 2,
                            ProductId = new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 3,
                            ProductId = new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 4,
                            ProductId = new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 5,
                            ProductId = new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 6,
                            ProductId = new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 7,
                            ProductId = new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 8,
                            ProductId = new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 9,
                            ProductId = new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 10,
                            ProductId = new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 11,
                            ProductId = new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"),
                            TaxId = 1
                        },
                        new
                        {
                            ProductTaxId = 12,
                            ProductId = new Guid("4698c02b-0f01-4a1d-9b7e-258f79798493"),
                            TaxId = 2
                        },
                        new
                        {
                            ProductTaxId = 13,
                            ProductId = new Guid("cc6d22e0-1884-449d-8cb6-253a2538dca4"),
                            TaxId = 3
                        },
                        new
                        {
                            ProductTaxId = 14,
                            ProductId = new Guid("e4c7288b-892f-42ff-9ff3-9ecb44ef0491"),
                            TaxId = 2
                        },
                        new
                        {
                            ProductTaxId = 15,
                            ProductId = new Guid("6c76166f-5ffb-437b-b44a-d9c77b25b109"),
                            TaxId = 2
                        },
                        new
                        {
                            ProductTaxId = 16,
                            ProductId = new Guid("cc34e56e-aabb-4119-863b-146e3d8300f7"),
                            TaxId = 2
                        },
                        new
                        {
                            ProductTaxId = 17,
                            ProductId = new Guid("71ee9982-cb38-4de8-8a81-0310b4d015d2"),
                            TaxId = 2
                        },
                        new
                        {
                            ProductTaxId = 18,
                            ProductId = new Guid("96e677c3-145d-40ab-8206-f8c5627c536b"),
                            TaxId = 2
                        },
                        new
                        {
                            ProductTaxId = 19,
                            ProductId = new Guid("adf014c5-eae5-4c97-aed3-d13782c29092"),
                            TaxId = 3
                        },
                        new
                        {
                            ProductTaxId = 20,
                            ProductId = new Guid("60d7631b-933a-4d74-b853-c661a8b3b13e"),
                            TaxId = 3
                        },
                        new
                        {
                            ProductTaxId = 21,
                            ProductId = new Guid("eb7cab11-e485-4dcb-bd86-cb4d8d781184"),
                            TaxId = 3
                        },
                        new
                        {
                            ProductTaxId = 22,
                            ProductId = new Guid("1a5cacc1-1250-4242-a8e6-b64c5f37e88f"),
                            TaxId = 2
                        });
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.Receipt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CashRegisterCashierId");

                    b.Property<DateTime>("DateTimeCreated");

                    b.Property<int>("DirectTaxAtCreation");

                    b.Property<int>("ExciseTaxAtCreation");

                    b.Property<int>("PostTaxPriceAtCreation");

                    b.Property<int>("PreTaxPriceAtCreation");

                    b.HasKey("Id");

                    b.HasIndex("CashRegisterCashierId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.ReceiptProduct", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("ReceiptId");

                    b.Property<int>("ProductCount");

                    b.Property<int>("ProductDirectPercentageAtCreation");

                    b.Property<int>("ProductExcisePercentageAtCreation");

                    b.Property<int>("ProductPriceAtCreation");

                    b.HasKey("ProductId", "ReceiptId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ReceiptProducts");
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Percentage");

                    b.Property<int>("TaxType");

                    b.HasKey("Id");

                    b.ToTable("Taxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Direct",
                            Percentage = 25,
                            TaxType = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hrana",
                            Percentage = 0,
                            TaxType = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Duhanski proizvodi",
                            Percentage = 130,
                            TaxType = 0
                        });
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.CashRegisterCashier", b =>
                {
                    b.HasOne("CashierRegister.Data.Entities.Models.CashRegister", "CashRegister")
                        .WithMany("CashRegisterCashiers")
                        .HasForeignKey("CashRegisterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashierRegister.Data.Entities.Models.Cashier", "Cashier")
                        .WithMany("Cashiers")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.ProductTax", b =>
                {
                    b.HasOne("CashierRegister.Data.Entities.Models.Product", "Product")
                        .WithMany("ProductTaxes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashierRegister.Data.Entities.Models.Tax", "Tax")
                        .WithMany("ProductTaxes")
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.Receipt", b =>
                {
                    b.HasOne("CashierRegister.Data.Entities.Models.CashRegisterCashier", "CashRegisterCashier")
                        .WithMany()
                        .HasForeignKey("CashRegisterCashierId");
                });

            modelBuilder.Entity("CashierRegister.Data.Entities.Models.ReceiptProduct", b =>
                {
                    b.HasOne("CashierRegister.Data.Entities.Models.Product", "Product")
                        .WithMany("ReceiptProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashierRegister.Data.Entities.Models.Receipt", "Receipt")
                        .WithMany("ReceiptProducts")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
