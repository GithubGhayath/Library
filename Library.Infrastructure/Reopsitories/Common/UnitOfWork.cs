using Library.Application.Reopsitories;
using Library.Application.Reopsitories.Common;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Context;
        public UnitOfWork(AppDbContext context) 
        {
            _Context = context;
            BookRepository = new BookRepository(_Context);
            BookCopyRepository = new BookCopyRepository(_Context);
            ReservationRepository= new ReservationRepository(_Context);
            FinesRepository= new FinesRepository(_Context);
            BorrowingRecordRepository = new BorrowingRecordRepository(_Context);
            PhoneNumberRepository = new PhoneNumberRepository(_Context);
            UserRepository = new UserRepository(_Context);  
            PersonRepository = new PersonRepository(_Context);
            SettingsRepository = new SettingsRespository(_Context); 
        }

        public IBookRepository BookRepository { get; }

        public IBookCopyRepository BookCopyRepository { get; }

        public IReservationRepository ReservationRepository { get; }

        public IFinesRepository FinesRepository { get; }

        public IBorrowingRecordRepository BorrowingRecordRepository { get; }

        public IPhoneNumberRepository PhoneNumberRepository {  get; }

        public IUserRepository UserRepository { get; }

        public IPersonRepository PersonRepository { get; }

        public ISettingsRepository SettingsRepository { get; }

        public IDbContextTransaction BeginTransaction()
        {
            return _Context.Database.BeginTransaction();
        }

        public int Save()
        {
            return _Context.SaveChanges();
        }
    }
}
