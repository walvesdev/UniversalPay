using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.TypeConfiguration
{
    public class ClientTC : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(u => u.Id);

            builder.HasOne(p => p.Account)
                .WithOne(c => c.Client)
                .HasForeignKey<Client>(c => c.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Payments)
             .WithOne(c => c.Client)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
