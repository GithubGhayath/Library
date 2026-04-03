using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Password).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired(true);
            builder.Property(u => u.LibraryCardNumber).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired(true);
            builder.Property(u => u.Role).HasColumnType("NVARCHAR").HasMaxLength(5).HasDefaultValue("User").IsRequired(true);
            builder.Property(u => u.IsDeleted).HasColumnType("BIT").HasMaxLength(5).HasDefaultValue(false).IsRequired(true);

            builder.HasOne(u => u.Person).WithOne(p => p.User).HasForeignKey<User>(u => u.PersonId).IsRequired(true);
        }
    }
}
