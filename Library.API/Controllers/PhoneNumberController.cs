using Library.Application.Common.Constants;
using Library.Application.Features.PhoneNumber.Dtos;
using Library.Application.Features.PhoneNumber.Mappings;
using Library.Application.Reopsitories.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/PhoneNumber")]  // Rout: https://localhost:7170/api/PhoneNumber
    [ApiController]
    public class PhoneNumberController : ControllerBase
    { 
        private readonly IUnitOfWork _IUnitOfWork;
        public PhoneNumberController(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;
        }

        [HttpGet("{personId}/Person")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPhoneNumberByPersonId(int personId)
        {
            if (personId <= 0)
                return BadRequest("Invalid personId");

            var PhoneNumber = _IUnitOfWork.PhoneNumberRepository.GetAll(ph => ph.PersonId == personId, include: query => query.Include(ph => ph.Person));

            if (PhoneNumber == null)
                return NotFound($"No phone number for person: {personId}");

            return Ok(PhoneNumber.Select(p=>p.ToDto()));

        }

        [HttpGet("{id}",Name ="GetPhoneNumberById")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPhoneNumberById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid data");

            var PhoneNumber = _IUnitOfWork.PhoneNumberRepository.Get(p => p.Id == id, include: query => query.Include(ph => ph.Person));
            
            if (PhoneNumber == null)
                return NotFound($"Phone number with id: {id} not found!");

            return Ok(PhoneNumber.ToDto());
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePhoneNumber(CreatePhoneNumberDto phoneNumber)
        {
            if (phoneNumber == null) 
                return BadRequest("Invalid info");

            var PhoneNumberForAdding = phoneNumber.ToEntity();
            _IUnitOfWork.PhoneNumberRepository.Add(PhoneNumberForAdding);
            _IUnitOfWork.Save();
            return CreatedAtRoute("GetPhoneNumberById", new { PhoneNumberForAdding.Id }, _IUnitOfWork.PhoneNumberRepository.GetAll(p => p.Id == PhoneNumberForAdding.Id, include: query => query.Include(ph => ph.Person)).Select(ph=>ph.ToDto()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePhoneNumber(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid data");

            var PhoneNumberForDelete = _IUnitOfWork.PhoneNumberRepository.Get(ph => ph.Id == id);

            if (PhoneNumberForDelete == null)
                return NotFound($"Phone Number With Id: {id} Not Found!");

            _IUnitOfWork.PhoneNumberRepository.Remove(PhoneNumberForDelete);
            _IUnitOfWork.Save();

            return NoContent();
        }

       



    }
}
