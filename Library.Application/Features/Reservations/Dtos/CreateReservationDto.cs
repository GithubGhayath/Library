using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Reservations.Dtos
{
    public class CreateReservationDto
    {
        public int UserId { get; set; }
        public int BookCopyId { get; set; }
    }
}
