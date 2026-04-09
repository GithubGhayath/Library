using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Reopsitories.Common
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IBookCopyRepository BookCopyRepository { get; }
        IFinesRepository FinesRepository { get; }
        IReservationRepository ReservationRepository {  get; }
        IBorrowingRecordRepository BorrowingRecordRepository { get; }
        IPhoneNumberRepository PhoneNumberRepository { get; }
        IUserRepository UserRepository { get; }
        IPersonRepository PersonRepository { get; }
        ISettingsRepository SettingsRepository { get; }
        IDbContextTransaction BeginTransaction();

        int Save();
        
    }
}
