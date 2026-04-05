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

        IDbContextTransaction BeginTransaction();

        int Save();
        
    }
}
