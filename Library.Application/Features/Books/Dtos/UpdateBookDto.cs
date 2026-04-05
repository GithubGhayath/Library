using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Dtos
{
    public class UpdateBookDto
    {
        public string Titile { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; } 
        public string AdditionalDetails { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
