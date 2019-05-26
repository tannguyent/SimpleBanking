﻿// <auto-generated />
using System;
using Banking.API.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banking.API.Migrations
{
    [DbContext(typeof(BankingDbContext))]
    [Migration("20190526074237_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.BankingAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("CurrentBalance");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BankingAccounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BankingAccount");
                });

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("BankingAccountId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BankingAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.TransactionHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Note");

                    b.Property<int>("Status");

                    b.Property<Guid>("TransactionId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.CreditBankingAccount", b =>
                {
                    b.HasBaseType("Banking.API.Infrastructure.Database.Models.BankingAccount");

                    b.HasDiscriminator().HasValue("CreditBankingAccount");
                });

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.DebitBankingAccount", b =>
                {
                    b.HasBaseType("Banking.API.Infrastructure.Database.Models.BankingAccount");

                    b.HasDiscriminator().HasValue("DebitBankingAccount");
                });

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.Transaction", b =>
                {
                    b.HasOne("Banking.API.Infrastructure.Database.Models.BankingAccount", "BankingAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("BankingAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Banking.API.Infrastructure.Database.Models.TransactionHistory", b =>
                {
                    b.HasOne("Banking.API.Infrastructure.Database.Models.Transaction")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
