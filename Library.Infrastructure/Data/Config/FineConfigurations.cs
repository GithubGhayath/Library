using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class FineConfigurations : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.ToTable("Fines");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.PaymentStatus).HasColumnType("BIT").IsRequired(true);
            builder.Property(x => x.NumberOfLateDays).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.FineAmount).HasPrecision(10, 2).HasDefaultValue(0);
            builder.HasOne(f => f.PaymentMethod).WithMany(pm => pm.Fines).HasForeignKey(f => f.PaymentMethodId).IsRequired(true);
            builder.HasOne(f => f.BorrowingRecord).WithOne(b => b.Fine).HasForeignKey<Fine>(f => f.BorrowingRecordId).IsRequired(true);
            builder.Property(f => f.PaymentDate).HasColumnType("datetime2").HasMaxLength(50).IsRequired(false);
        }
    }
}
