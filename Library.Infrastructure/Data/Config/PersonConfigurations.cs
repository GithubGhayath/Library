using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.LastName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Gender).HasColumnType("VARCHAR").HasMaxLength(1).IsRequired(true);

            builder.OwnsOne(p => p.Address, a => 
            {
                a.Property(x => x.City).HasColumnType("NVARCHAR").HasMaxLength(50).HasColumnName("City").IsRequired(true);
                a.Property(x => x.Street).HasColumnType("NVARCHAR").HasMaxLength(50).HasColumnName("Street").IsRequired(true);
                a.Property(x => x.ZipCode).HasColumnType("NVARCHAR").HasMaxLength(50).HasColumnName("ZipCode").IsRequired(true);
            });


            builder.OwnsOne(p => p.Email, e => 
            {
                e.Property(x => x.Value).HasColumnType("NVARCHAR").HasMaxLength(50).HasColumnName("Email").IsRequired(true);
            });

            builder.OwnsOne(p => p.AuditTimestamp, a =>
            {
                a.Property(x => x.CreateAt).HasColumnType("datetime2").HasMaxLength(50).HasColumnName("CreateAt").IsRequired(true);
                a.Property(x => x.UpdateAt).HasColumnType("datetime2").HasMaxLength(50).HasColumnName("UpdateAt").IsRequired(false);
            });
        }
    }
}
