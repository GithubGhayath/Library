using Library.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Titile { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate {  get; set; }
        public string Genre {  get; set; }
        public string AdditionalDetails { get; set; }
        public AuditTimestamp? AuditTimestamps { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; }
        private Book() { }
        public Book(string title, string isbn, DateTime publicationDate, string genre, string additionalDetails)
        {
            Titile = title;
            ISBN = isbn;
            PublicationDate = publicationDate;
            Genre = genre;
            AdditionalDetails = additionalDetails;
            AuditTimestamps = new AuditTimestamp(DateTime.Now, null);
        }
    }
}
