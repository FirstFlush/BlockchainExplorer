using Microsoft.EntityFrameworkCore;
using BlockchainExplorer.App.Models;
using System;


namespace BlockchainExplorer.App.Data
{
    public class BlockchainContext : DbContext
    {
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            if (string.IsNullOrEmpty(connectionString)) 
            {
                throw new InvalidOperationException("Connection string not found in environment variables!");
            }
            optionsBuilder.UseSqlServer(connectionString);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<TransactionModel>().HasKey(t => t.TransactionId);
        // }

    }

}