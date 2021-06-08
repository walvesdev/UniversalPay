using Microsoft.EntityFrameworkCore;
using UniversalPay.Domain.Entities;

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
            //var connectionString = Configuration.GetConnectionString("MySqlConnection"); // Configuration.GetConnectionString("PostgresSQLConnection");

            //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversalPayContext).Assembly);          

            base.OnModelCreating(modelBuilder);
        }

    }
}
