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
    public class PaymentTC : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(u => u.Id);
            builder.Property(p => p.Total).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.TransactionData).IsRequired();
            builder.Property(p => p.TransacitonType).IsRequired();
            builder.HasOne(p => p.Client)
                .WithMany(c => c.Payments)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
