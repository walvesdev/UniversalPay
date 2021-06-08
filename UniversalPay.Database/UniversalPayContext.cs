using Microsoft.EntityFrameworkCore;
using UniversalPay.Domain.Entities;
using System.Configuration;
using System;
using Microsoft.Extensions.Configuration;

namespace UniversalPay.Database
{
    public class UniversalPayContext : DbContext
    {

        public DbSet<PaymentAccount> Accounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public UniversalPayContext()
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("Default");

            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversalPayContext).Assembly);          

            base.OnModelCreating(modelBuilder);
        }

    }
}
