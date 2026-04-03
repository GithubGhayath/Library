using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public int BorrowingRecordId { get; set; }
        public int NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool PaymentStatus { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
        public BorrowingRecord BorrowingRecord { get; set; }
        private Fine() { }
        public Fine(int borrowingRecordId, int numberOfLateDays, decimal fineAmount, bool paymentStatus)
        {
            BorrowingRecordId = borrowingRecordId;
            NumberOfLateDays = numberOfLateDays;
            FineAmount = fineAmount;
            PaymentStatus = paymentStatus;
        }
    }
}
