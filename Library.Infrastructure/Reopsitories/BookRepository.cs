using Library.Application.Features.Books.Dtos;
using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Domain.ValueObjects;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _Context;
        public BookRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public void Update(UpdateBookDto BookDto,int Id)
        {
            var Book = _Context.Books.Find(Id);

            Book!.ISBN = BookDto.ISBN;
            Book.Titile = BookDto.Titile;
            Book.PublicationDate = BookDto.PublicationDate;
            Book.Genre = BookDto.Genre;
            Book.AdditionalDetails = BookDto.AdditionalDetails;
            Book.AuditTimestamps = new AuditTimestamp(Book.AuditTimestamps!.CreateAt, DateTime.Now);
        }

       /// <summary>
       /// Removes the specified book from the data store after verifying that there are no incomplete reservations or
       /// active borrowings associated with its copies.
       /// </summary>
       /// <remarks>This method checks for any incomplete reservations or active borrowings related to the
       /// book's copies before removal. If such records exist, the book will not be removed to maintain data
       /// integrity.</remarks>
       /// <param name="entity">The book entity to remove. Must not be null.</param>
       /// <exception cref="InvalidOperationException">Thrown if there are incomplete reservations or active borrowings for any copy of the specified book.</exception>
        public override void Remove(Book entity)
        {

            var BookCopiesIds = _Context.BookCopies.Where(bc => bc.BookId == entity.Id).Select(bc => bc.Id).ToList();

            if (_Context.Reservations.Any(r => BookCopiesIds.Contains(r.BookCopyId) && !r.IsCompleted))
                throw new InvalidOperationException("Incomplete reservations exist.");

            if (_Context.BorrowingRecords.Any(b => BookCopiesIds.Contains(b.BookCopyId) && b.BorrowingSchedule.ActualReturnDate == null))
                throw new InvalidOperationException("Active borrowings exist.");



            // At this point, we can safely remove the book copy ,because all the reservations and borrowing records associated with it are completed.
            _Context.Books.Remove(entity);

        }
    }
}
