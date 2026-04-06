using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Fines.Dtos
{
    public class BookInfoForInternalUsing
    {
        public string BookTitle { get; set; }
        public DateTime? BorrowedDate { get; set; } 
        public DateTime? ReturnedDate { get; set; }

        public BookInfoForInternalUsing(string bookTitle, DateTime? returnedDate,DateTime? borrowedDate)
        {
            BookTitle = bookTitle;
            ReturnedDate = returnedDate;
            BorrowedDate = borrowedDate;
        }
    }
}
