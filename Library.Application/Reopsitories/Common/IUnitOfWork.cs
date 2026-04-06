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
        IDbContextTransaction BeginTransaction();

        int Save();
        
    }
}
