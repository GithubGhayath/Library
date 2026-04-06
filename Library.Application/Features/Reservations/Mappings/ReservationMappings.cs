using Library.Application.Features.Reservations.Dtos;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Reservations.Mappings
{
    public static class ReservationMappings
    {
        public static Reservation ToEntity(this CreateReservationDto createReservationDto)
        {
            return new Reservation(createReservationDto.UserId, createReservationDto.BookCopyId);
        }
        public static ReservationDto ToDto(this Reservation reservation)
        {
            return new ReservationDto
            {
                UserName = $"{reservation.User.Person.FirstName} {reservation.User.Person.LastName}",
                BookName = reservation.BookCopy.Book.Titile,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.IsCanceled ? "Reservattion Canceled" : reservation.IsCompleted ? "Reservattion Complete" : "Pending"
            };
        }
    }
}
