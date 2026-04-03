using Library.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class BorrowingRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookCopyId { get; set; }
        public BorrowingSchedule BorrowingSchedule {  get; set; }
        public User User { get; set; }
        public BookCopy BookCopy { get; set; }
        public Fine Fine { get; set; }

        private BorrowingRecord() { }
        public BorrowingRecord(int userId, int bookCopyId, DateTime? DueDate)
        {

            UserId = userId;
            BookCopyId = bookCopyId;
            BorrowingSchedule = new BorrowingSchedule(DateTime.Now, DueDate, null);
        }
    }
}
