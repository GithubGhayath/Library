using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class BookCopyRepository : Repository<BookCopy>, IBookCopyRepository
    {
        private readonly AppDbContext _Context;
        public BookCopyRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public void RemoveAllCopies(int BookId)
        {
            _Context.RemoveRange(_Context.BookCopies.Where(bc => bc.BookId == BookId));
        }

        public void RemoveNumberOfCopies(int NumberOfCopiesToRemove, int BookId)
        {
            var BookCopiesForDelete = _Context.BookCopies.Where(bc => bc.BookId == BookId && bc.IsAvailabile == false).OrderBy(bc => bc.IsAvailabile).ToList();


            if (NumberOfCopiesToRemove > BookCopiesForDelete.Count)
                throw new InvalidOperationException($"The copy that you are trying to delete is booked!");

            _Context.BookCopies.RemoveRange(BookCopiesForDelete);


            /*
            for(int i = 0;i<NumberOfCopiesToRemove;i++) 
            {
                if (!_IsBookCopyReserved(BookCopies[i].Id) && !_IsBookCopyBorrowed(BookCopies[i].Id))
                    _Context.BookCopies.Remove(BookCopies[i]);
                
                else
                    throw new InvalidOperationException($"The copy (with Id: {BookCopies[i].Id}) that you are trying to delete is booked!");
            }
            */
        }

        private bool _IsBookCopyReserved(int CopyId)
        {
            return _Context.Reservations.Any(r => r.BookCopyId == CopyId && r.IsCompleted == false);
        }

        private bool _IsBookCopyBorrowed(int CopyId)
        {
            return _Context.BorrowingRecords.Any(br => br.BookCopyId == CopyId && br.BorrowingSchedule.ActualReturnDate == null);
        }
    }
} 
