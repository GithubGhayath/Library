using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(r=>r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.IsCanceled).HasColumnType("BIT").HasDefaultValue(false).IsRequired(true);
            builder.Property(r => r.IsCompleted).HasColumnType("BIT").HasDefaultValue(false).IsRequired(true);
            builder.Property(r => r.ReservationDate).HasColumnType("datetime2").IsRequired(true);

            builder.HasOne(r => r.User).WithMany(u => u.Reservations).HasForeignKey(r => r.UserId).IsRequired(true);
            builder.HasOne(r => r.BookCopy).WithMany(bc=>bc.Reservations).HasForeignKey(r => r.BookCopyId).IsRequired(true);
        }
    }
}
