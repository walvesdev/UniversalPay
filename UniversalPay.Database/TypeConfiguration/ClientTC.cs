using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.TypeConfiguration
{
    public class ClientTC : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.AccountId).IsRequired(false);

            //builder.HasOne(p => p.Account)
            //    .WithOne(c => c.Client)                
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Payments)
             .WithOne(c => c.Client)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
