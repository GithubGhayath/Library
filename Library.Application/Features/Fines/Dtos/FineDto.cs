using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Fines.Dtos
{
    public class FineDto
    {
        public int NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public string PaymentBy { get; set; }
        public string Status { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
