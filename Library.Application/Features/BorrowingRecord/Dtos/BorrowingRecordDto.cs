using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.BorrowingRecord.Dtos
{
    public class BorrowingRecordDto
    {
        public string UserName { get; set; }    
        public string BookName { get; set; }
        public int CopyNumber { get; set; } 
        public DateTime? BorrowingDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
    }
}
