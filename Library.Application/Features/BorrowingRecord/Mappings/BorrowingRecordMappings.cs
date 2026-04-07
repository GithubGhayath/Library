using Library.Application.Features.BorrowingRecord.Dtos;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.BorrowingRecord.Mappings
{
    public static class BorrowingRecordMappings
    {
        

        public static Domain.Entities.BorrowingRecord ToEntity(this CreateBorrowingRecordDto BorrowingRecordDto,int BookCopyId)
        {
            return new Domain.Entities.BorrowingRecord
            (
                userId: BorrowingRecordDto.UserId,
                bookCopyId: BookCopyId, 
                DueDate: BorrowingRecordDto.DueDate
            );
        }

        public static BorrowingRecordDto ToDto(this Domain.Entities.BorrowingRecord BorrowingRecord)
        {
            return new BorrowingRecordDto
            {
                UserName = BorrowingRecord.User.Person.FirstName+" "+ BorrowingRecord.User.Person.LastName, 
                BookName = BorrowingRecord.BookCopy.Book.Titile,
                CopyNumber = BorrowingRecord.BookCopy.Id, // Assuming Id is BookCopy 
                BorrowingDate = BorrowingRecord.BorrowingSchedule.BorrowingDate,
                DueDate = BorrowingRecord.BorrowingSchedule.DueDate,
                ActualReturnDate = BorrowingRecord.BorrowingSchedule.ActualReturnDate
            };
        }
    }
}
