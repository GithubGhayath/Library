using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Dtos
{
    public class FullDetailsBookDto
    {
        public string Titile { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; }
        public int NumberOfCopies { get; set; }
        public string AdditionalDetails { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        
    }
}
