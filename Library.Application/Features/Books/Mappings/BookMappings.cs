using Library.Application.Features.Books.Dtos;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Mappings
{
    public static class BookMappings
    {
        public static Book ToEntity(this CreateBookDto createBookDto)
        {
            return new Book(
                createBookDto.Titile,
                createBookDto.ISBN,
                createBookDto.PublicationDate,
                createBookDto.Genre,
                createBookDto.AdditionalDetails
            );
        }

        public static Book ToEntity(this UpdateBookDto UpdatedBookDto)
        {
            return new Book(
                UpdatedBookDto.Titile,
                UpdatedBookDto.ISBN,
                UpdatedBookDto.PublicationDate,
                UpdatedBookDto.Genre,
                UpdatedBookDto.AdditionalDetails
            );
        }

        public static List<BookCopy> GenerateBookCopiesRecord(this CreateBookDto createBookDto,int BookId) 
        {
            List<BookCopy> bookCopies = new List<BookCopy>();

            for(int i =1;i<=createBookDto.NumberOfCopies; i++)
            {
                bookCopies.Add(new BookCopy(BookId, true));
            }

            return bookCopies;
        }

        public static List<BookCopy> GenerateBookCopiesRecord(this UpdateBookDto createBookDto, int NumberOfOldCopies, int BookId)
        {
            List<BookCopy> bookCopies = new List<BookCopy>();

            for (int i = NumberOfOldCopies + 1; i <= createBookDto.NumberOfCopies; i++)
            {
                bookCopies.Add(new BookCopy(BookId, true));
            }

            return bookCopies;
        }
    }
}
