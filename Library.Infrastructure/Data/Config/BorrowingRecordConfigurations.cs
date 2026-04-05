using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class BorrowingRecordConfigurations : IEntityTypeConfiguration<BorrowingRecord>
    {
        public void Configure(EntityTypeBuilder<BorrowingRecord> builder)
        {
            builder.ToTable("BorrowingRecords");
            // Primary Key
            builder.HasKey(b => b.Id);



            // Owned Value Object
            builder.OwnsOne(b => b.BorrowingSchedule, schedule =>
            {
                schedule.Property(s => s.BorrowingDate)
                        .HasColumnName("BorrowingDate")
                        .HasColumnType("datetime2").IsRequired(true);

                schedule.Property(s => s.DueDate)
                        .HasColumnName("DueDate")
                        .HasColumnType("datetime2").IsRequired(false);

                schedule.Property(s => s.ActualReturnDate)
                        .HasColumnName("ActualReturnDate")
                        .HasColumnType("datetime2").IsRequired(false);

                // Optional: make the owned object required
                schedule.WithOwner();
            });

            builder.HasOne(b => b.User).WithMany(u => u.BorrowingRecords).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.BookCopy).WithMany(bc => bc.BorrowingRecords).HasForeignKey(b => b.BookCopyId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
