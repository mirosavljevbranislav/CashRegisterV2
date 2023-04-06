﻿// <auto-generated />
using CashRegister.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CashRegister.Infrastructure.Migrations
{
    [DbContext(typeof(CashRegisterDBContext))]
    [Migration("20230328082300_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CashRegister.Domain.Models.Bill", b =>
                {
                    b.Property<string>("BillNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("BillNumber");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("CashRegister.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CashRegister.Domain.Models.ProductBill", b =>
                {
                    b.Property<string>("BillNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductsPrice")
                        .HasColumnType("int");

                    b.HasKey("BillNumber", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBills");
                });

            modelBuilder.Entity("CashRegister.Domain.Models.ProductBill", b =>
                {
                    b.HasOne("CashRegister.Domain.Models.Bill", "Bill")
                        .WithMany("ProductBills")
                        .HasForeignKey("BillNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashRegister.Domain.Models.Product", "Product")
                        .WithMany("ProductBills")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CashRegister.Domain.Models.Bill", b =>
                {
                    b.Navigation("ProductBills");
                });

            modelBuilder.Entity("CashRegister.Domain.Models.Product", b =>
                {
                    b.Navigation("ProductBills");
                });
#pragma warning restore 612, 618
        }
    }
}
