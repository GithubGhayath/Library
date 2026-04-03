using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
           
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);

            // Properties
            // Note: domain class uses property name `Titile` (typo) so map it to column `Title`.
            builder.Property(b => b.Titile)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("Title");

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("ISBN");

            // Make ISBN unique
            builder.HasIndex(b => b.ISBN).IsUnique();

            builder.Property(b => b.PublicationDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(b => b.Genre)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(b => b.AdditionalDetails)
                .HasMaxLength(1000)
                .IsRequired(false);

            // Owned value object configuration for audit timestamps
            builder.OwnsOne(b => b.AuditTimestamps, at =>
            {
                at.Property(a => a.CreateAt)
                    .HasColumnName("CreatedAt")
                    .HasColumnType("datetime2");

                at.Property(a => a.UpdateAt)
                    .HasColumnName("UpdatedAt")
                    .HasColumnType("datetime2");
            });
        }
    }
}
