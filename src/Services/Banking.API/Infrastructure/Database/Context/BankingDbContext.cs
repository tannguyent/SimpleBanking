using Banking.API.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Database.Context
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options)
        : base(options)
        {
        }

        public DbSet<BankingAccount> BankingAccounts { get; set; }
        public DbSet<DebitBankingAccount> DebitBankingAccounts { get; set; }
        public DbSet<CreditBankingAccount> CreaditBankingAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DebitBankingAccount>()
                   .HasBaseType<BankingAccount>();

            builder.Entity<CreditBankingAccount>()
                   .HasBaseType<BankingAccount>();
        }
    }
}
