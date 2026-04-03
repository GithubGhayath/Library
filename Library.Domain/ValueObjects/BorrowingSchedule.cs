using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.ValueObjects
{
    public class BorrowingSchedule
    {
        public DateTime? BorrowingDate { get; }
        public DateTime? DueDate { get; }
        public DateTime? ActualReturnDate { get; }

        public BorrowingSchedule(DateTime? borrowingDate, DateTime? dueDate, DateTime? actualReturnDate)
        {
            BorrowingDate = borrowingDate;
            DueDate = dueDate;
            ActualReturnDate = actualReturnDate;
        }
        private BorrowingSchedule() { }
    }
}
