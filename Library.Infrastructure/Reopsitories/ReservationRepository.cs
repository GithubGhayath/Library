using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly AppDbContext _Context;
        public ReservationRepository(AppDbContext context):base(context) 
        {
            _Context = context;
        }

        public void CancelReservation(Reservation reservation)
        {
            reservation.IsCanceled = true;
        }

      
        public void CompleteReservation(Reservation reservation)
        {
            reservation.IsCompleted = true;
        }

        public override void Add(Reservation entity)
        {
            var BookCopy = _Context.BookCopies.Find(entity.BookCopyId);

            if(BookCopy!.IsAvailabile==false)
                throw new InvalidOperationException("This book copy is not available for reservation.");


            BookCopy!.IsAvailabile = false;

            base.Add(entity);
        }
    }
}
