using DocumentFormat.OpenXml.Office2010.Excel;
using Library.Application.Common.Constants;
using Library.Application.Features.Reservations.Dtos;
using Library.Application.Features.Reservations.Mappings;
using Library.Application.Reopsitories.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/Reservations")] // Rout: https://localhost:7170/api/Reservations
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IUnitOfWork _IUnityOfWork; 
        public ReservationController(IUnitOfWork IUnityOfWork)
        { 
            _IUnityOfWork = IUnityOfWork;
        }
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllReservations()
        {
            var reservations = _IUnityOfWork.ReservationRepository.GetAll(include: query => query
                                                                            .Include(r => r.User)
                                                                                .ThenInclude(u => u.Person)
                                                                            .Include(r => r.BookCopy)
                                                                                .ThenInclude(bc => bc.Book)).Select(r => r.ToDto());

            if (reservations.Count() == 0)
                return NotFound();

            return Ok(reservations);
        }

        [HttpPut("{id}/Cancel")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CancelReservation(int id)
        {
            var reservation = _IUnityOfWork.ReservationRepository.Get(r => r.Id == id);

            if (reservation == null)
                return NotFound("No reservation found with the provided ID.");


            if (reservation.IsCompleted)
                return BadRequest("This reservation is already completed.");

            if (reservation.IsCanceled)
                return BadRequest("This reservation is already canceled.");


            _IUnityOfWork.ReservationRepository.CancelReservation(reservation);
            _IUnityOfWork.Save();
            return NoContent();


        }

        [HttpPut("{id}/Complete")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CompleteReservation(int id)
        {
            var reservation = _IUnityOfWork.ReservationRepository.Get(r => r.Id == id);

            if (reservation == null)
                return NotFound("No reservation found with the provided ID.");


            if (reservation.IsCompleted)
                return BadRequest("This reservation is already completed.");

            if (reservation.IsCanceled)
                return BadRequest("This reservation is already canceled.");


            _IUnityOfWork.ReservationRepository.CompleteReservation(reservation);
            _IUnityOfWork.Save();
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateReservationAsync(CreateReservationDto createReservationDto, [FromServices] IAuthorizationService authorizationService)
        {
            // Policy-based authorization check done here
            var authResult = await authorizationService.AuthorizeAsync(user: User, createReservationDto.UserId, policyName: "ClientOwnerOrAdmin");

            if (!authResult.Succeeded)
                return Forbid(); // 403


            if (createReservationDto == null)
                return BadRequest("Reservation data is required.");

            var reservation = createReservationDto.ToEntity();

            try
            {
                _IUnityOfWork.ReservationRepository.Add(reservation);
                _IUnityOfWork.Save();
                return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, _IUnityOfWork.ReservationRepository.Get(r => r.Id == reservation.Id, include: query => query
                                                                                                                                                              .Include(r => r.User)
                                                                                                                                                                        .ThenInclude(u => u.Person)
                                                                                                                                                                    .Include(r => r.BookCopy)
                                                                                                                                                                        .ThenInclude(bc => bc.Book))!.ToDto());
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetRerervationById")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetReservationById(int id)
        {
            if (id < 0) return BadRequest("Invalid reservation ID.");

            var Reservation = _IUnityOfWork.ReservationRepository.Get(r => r.Id == id, include: query => query
                                                                            .Include(r => r.User)
                                                                                .ThenInclude(u => u.Person)
                                                                            .Include(r => r.BookCopy)
                                                                                .ThenInclude(bc => bc.Book));

            if(Reservation == null) return NotFound("No reservation found with the provided ID.");

            return Ok(Reservation.ToDto());
        }
    }
}