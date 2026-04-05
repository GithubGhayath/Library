using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Reopsitories
{
    public interface IBookCopyRepository:IRepository<BookCopy>
    {
        void RemoveAllCopies(int BookId);
        void RemoveNumberOfCopies(int NumberOfCopiesToRemove,int BookId);
    }
}
