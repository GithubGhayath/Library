using Library.Application.Features.Fines.Mappings;
using Library.Application.Reopsitories.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/Fines")]    // Rout: https://localhost:7170/api/Fines
    [ApiController]
    public class FineController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public FineController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }

        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFineList()
        {
            var FinesList = _IUnitOfWork.FinesRepository.GetAll(include: query => query.Include(f=>f.PaymentMethod)
                                                                                    .Include(f => f.BorrowingRecord)
                                                                                        .ThenInclude(br => br.User)
                                                                                            .ThenInclude(u => u.Person)
                                                                                     .Include(f => f.BorrowingRecord)
                                                                                        .ThenInclude(br => br.BookCopy)
                                                                                            .ThenInclude(bc => bc.Book)).Select(f=>f.ToDto());

            
            if(FinesList.Count() == 0)
            {
                return NotFound("No Fines Found");
            }

            return Ok(FinesList);
        }

        [HttpGet("{id}", Name = "GetFineById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFine(int id)
        {
            var Fine = _IUnitOfWork.FinesRepository.Get(f => f.Id == id, include: query => query.Include(f => f.PaymentMethod)
                                                                                    .Include(f => f.BorrowingRecord)
                                                                                        .ThenInclude(br => br.User)
                                                                                            .ThenInclude(u => u.Person)
                                                                                     .Include(f => f.BorrowingRecord)
                                                                                        .ThenInclude(br => br.BookCopy)
                                                                                            .ThenInclude(bc => bc.Book));

            if(Fine == null)
            {
                return NotFound($"No Fine Found With Id: {id}");
            }

            return Ok(Fine.ToDto());
        }

        [HttpGet("Users/{UserId}/Report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetReport(int UserId) 
        {
            var UserFinesReport = _IUnitOfWork.FinesRepository.GetAll(f=>f.BorrowingRecord.UserId == UserId,
                                                             include: query => query.Include(f => f.PaymentMethod)
                                                                                    .Include(f => f.BorrowingRecord)
                                                                                        .ThenInclude(br => br.User)
                                                                                            .ThenInclude(u => u.Person)
                                                                                     .Include(f => f.BorrowingRecord)
                                                                                        .ThenInclude(br => br.BookCopy)
                                                                                            .ThenInclude(bc => bc.Book)).Select(f=>f.ToUserFinesReportDto());

            if(UserFinesReport.Count() == 0)
            {
                return NotFound($"No Fines Found For User With Id: {UserId}");
            }

            return Ok(UserFinesReport);
        }

    }
}
