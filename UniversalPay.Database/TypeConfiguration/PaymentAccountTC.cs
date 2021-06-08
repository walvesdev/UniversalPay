using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.TypeConfiguration
{
    public class PaymentAccountTC : IEntityTypeConfiguration<PaymentAccount>
    {
        public void Configure(EntityTypeBuilder<PaymentAccount> builder)
        {
            builder.ToTable("PaymentAccounts");
            builder.HasKey(u => u.Id);
            builder.Property(p => p.Total).HasColumnType("decimal(18, 2)"); 
            builder.HasIndex(u => u.Code).IsUnique();
            builder.HasOne(p => p.Client)
                .WithOne(c => c.Account)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
