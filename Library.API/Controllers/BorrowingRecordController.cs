using Library.Application.Common.Constants;
using Library.Application.Features.Books.Dtos;
using Library.Application.Features.BorrowingRecord.Dtos;
using Library.Application.Features.BorrowingRecord.Mappings;
using Library.Application.Reopsitories.Common;
using Library.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/BorrowingRecords")] // Rout: https://localhost:7170/api/BorrowingRecords 
    [ApiController]
    public class BorrowingRecordController : ControllerBase
    {
        private readonly IUnitOfWork _IUniteOfWork;
        public BorrowingRecordController(IUnitOfWork unitOfWork)
        {
            _IUniteOfWork = unitOfWork;
        }



        [HttpGet("{id}", Name = "GetBorrowingRecordByID")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBorrowingRecord(int id) 
        {
            var borrowingRecord = _IUniteOfWork.BorrowingRecordRepository.Get(br => br.Id == id, include: query => query
                                                                                                                .Include(br => br.User)
                                                                                                                    .ThenInclude(u => u.Person)
                                                                                                                 .Include(br => br.BookCopy)
                                                                                                                     .ThenInclude(bc => bc.Book));

            if(borrowingRecord == null) 
                return NotFound("Borrowing record not found.");

            return Ok(borrowingRecord.ToDto());
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BorroweBook(CreateBorrowingRecordDto borrowingRecordDto)
        {
            var bookCopy = _IUniteOfWork.BookCopyRepository.Get(bc => bc.BookId == borrowingRecordDto.BookId && bc.IsAvailabile);

            if(bookCopy == null) 
                return BadRequest("No available copies of the book.");

            var BorrowingRecord = borrowingRecordDto.ToEntity(bookCopy.Id);


            var Transaction = _IUniteOfWork.BeginTransaction();

            try
            {
                bookCopy.IsAvailabile = false;
                _IUniteOfWork.BorrowingRecordRepository.Add(BorrowingRecord);
                _IUniteOfWork.Save();

                Transaction.Commit();
                return CreatedAtRoute("GetBorrowingRecordByID", new { BorrowingRecord.Id }, _IUniteOfWork.BorrowingRecordRepository.Get(br => br.Id == BorrowingRecord.Id, include: query => query
                                                                                                                .Include(br => br.User)
                                                                                                                    .ThenInclude(u => u.Person)
                                                                                                                 .Include(br => br.BookCopy)
                                                                                                                     .ThenInclude(bc => bc.Book))!.ToDto());
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpPut("{id}/{NumberOfDaysToIncrease}")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult IncreaseNumberOfBorrowingDays(int id, int NumberOfDaysToIncrease)
        {
            var borrowingRecord = _IUniteOfWork.BorrowingRecordRepository.Get(br => br.Id == id);

            if (borrowingRecord == null)
                return NotFound("Borrowing record not found.");

            if (borrowingRecord.BorrowingSchedule.ActualReturnDate != null)
                return BadRequest("Cannot increase borrowing days for a returned book.");


            borrowingRecord.BorrowingSchedule = new BorrowingSchedule(borrowingRecord.BorrowingSchedule.BorrowingDate, borrowingRecord.BorrowingSchedule.DueDate!.Value.AddDays(NumberOfDaysToIncrease), null);

            _IUniteOfWork.Save();
            return NoContent();
        }
    }
}
