using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public bool IsAvailabile{ get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<BorrowingRecord> BorrowingRecords { get; set; }
        public Book Book { get; set; }

        public BookCopy(int bookId, bool availabilityStatus)
        {
            BookId = bookId;
            IsAvailabile = availabilityStatus;   
        }

        private BookCopy() { }
    }
}
