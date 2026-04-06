using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Reopsitories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        void CancelReservation(Reservation reservation);
        void CompleteReservation(Reservation reservation);
    }
}
