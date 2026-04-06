namespace Library.Application.Features.Fines.Dtos
{
    public class UserFinesReportDto
    {
        public int FineID { get; set; }
        public string UserName { get; set; }
        public BookInfoForInternalUsing BookInfo { get; set; }
        public int NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
    }

}
