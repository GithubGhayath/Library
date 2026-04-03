using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Config
{
    public class SettingConfigurations : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DefualtBorrrowDays).HasColumnType("INT").IsRequired(true);
            builder.Property(x => x.DefaultFinePerDay).HasColumnType("INT").IsRequired(true);
        }
    }
}
