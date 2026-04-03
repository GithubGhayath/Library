using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookCopyId { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime ReservationDate {  get; set; }


        public User User {  get; set; }
        public BookCopy BookCopy { get; set; }

        private Reservation() { }
        public Reservation(int userId, int bookCopyId)
        {
            UserId = userId;
            BookCopyId = bookCopyId;
            IsCanceled = false;
            ReservationDate = DateTime.Now;
        }

    }
}
