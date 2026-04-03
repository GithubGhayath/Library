using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class BookCopyConfigurations : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder.ToTable("BookCopies");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.IsAvailabile).HasColumnType("BIT");

            builder.HasOne(bc => bc.Book).WithMany(b => b.BookCopies).HasForeignKey(bc => bc.BookId).IsRequired(true);
        }
    }
}
