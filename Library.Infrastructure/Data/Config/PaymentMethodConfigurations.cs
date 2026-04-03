using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class PaymentMethodConfigurations : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("VARCHAR").HasMaxLength(60).IsRequired(true);
            builder.Property(p => p.Description).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired(true);

        }
    }
}
