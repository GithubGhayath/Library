using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class PhoneNumberConfigurations : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.phone).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired(true);
            builder.HasOne(ph => ph.Person).WithMany(p => p.PhoneNumbers).HasForeignKey(ph => ph.PersonId).IsRequired(true);
        }
    }
}
