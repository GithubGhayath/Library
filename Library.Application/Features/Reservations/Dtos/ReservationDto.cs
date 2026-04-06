using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Reservations.Dtos
{
    public class ReservationDto
    {
        public string UserName { get; set; }
        public string BookName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }  // Commleted , Canceled
    }
}
