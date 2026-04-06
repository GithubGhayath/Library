using Library.Application.Features.Fines.Dtos;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Fines.Mappings
{
    public static class FineMappings
    {
        public static FineDto ToDto(this Fine fine)
        {
            return new FineDto
            {
                NumberOfLateDays = fine.NumberOfLateDays,
                FineAmount = fine.FineAmount,
                PaymentBy = fine.PaymentMethod.Name,
                Status = fine.PaymentStatus ? "Paid" : "Unpaid",
                BookTitle = fine.BorrowingRecord.BookCopy.Book.Titile,
                UserName = fine.BorrowingRecord.User.Person.FirstName + " " + fine.BorrowingRecord.User.Person.LastName,
                PaymentDate = fine.PaymentDate 
            };  
        }

        public static UserFinesReportDto ToUserFinesReportDto(this Fine fine)
        {
            Console.WriteLine($"\n\n{fine.BorrowingRecord.BookCopy.Book.Titile} , {fine.BorrowingRecord.BorrowingSchedule.BorrowingDate} , {fine.BorrowingRecord.BorrowingSchedule.ActualReturnDate}");
            return new UserFinesReportDto
            {
                FineID = fine.Id,
                UserName = fine.BorrowingRecord.User.Person.FirstName + " " + fine.BorrowingRecord.User.Person.LastName,
                NumberOfLateDays = fine.NumberOfLateDays,
                FineAmount = fine.FineAmount,
                PaymentStatus = fine.PaymentStatus ? "Paid" : "Unpaid",
                PaymentMethod = fine.PaymentMethod.Name,
                PaymentDate = fine.PaymentDate,

                BookInfo = new BookInfoForInternalUsing(fine.BorrowingRecord.BookCopy.Book.Titile, fine.BorrowingRecord.BorrowingSchedule.ActualReturnDate, fine.BorrowingRecord.BorrowingSchedule.BorrowingDate)

            };
        }
    }
}
