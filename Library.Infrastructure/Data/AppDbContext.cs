using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Library.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("constr").Value!);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
