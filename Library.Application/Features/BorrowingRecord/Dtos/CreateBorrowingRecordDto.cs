using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.BorrowingRecord.Dtos
{
    public class CreateBorrowingRecordDto
    {
        public int UserId { get; set; }
        public DateTime? DueDate {  get; set; }
        public int BookId { get; set; }
    }
}
