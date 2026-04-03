using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string LibraryCardNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Person Person { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<BorrowingRecord> BorrowingRecords { get; set; }
        private User() { }

        public User(int personId, string libraryCardNumber, string password, string? role = null)
        {
            PersonId = personId;
            LibraryCardNumber = libraryCardNumber.Trim();
            Password = password;

            if (!string.IsNullOrEmpty(role))
                Role = role;
        }
    }
}
