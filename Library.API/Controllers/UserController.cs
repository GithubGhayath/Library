using Library.Application.Features.Users.Dtos;
using Library.Application.Features.Users.Mappings;
using Library.Application.Reopsitories.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/Users")]     // Rout: https://localhost:7170/api/Users
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public UserController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserList()
        {
            var UserList = _IUnitOfWork.UserRepository.GetAll(include: query => query.Include(u => u.Person)).Select(u => u.ToUserSummaryDto());

            if(UserList.Count()==0)
                return NotFound("No users found.");

            return Ok(UserList);
        }

        [HttpGet("Summary/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSummaryUserById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID. ID must be a positive integer.");

            var User = _IUnitOfWork.UserRepository.Get(u => u.Id == id, include: query => query.Include(u => u.Person));

            if (User == null)
                return NotFound($"No user found with ID {id}.");
            return Ok(User.ToUserSummaryDto());
        }

        [HttpGet("Details/{id}",Name = "GetDetailsUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDetailsUserById(int id)
        {
            if(id<= 0)
                return BadRequest("Invalid user ID. ID must be a positive integer.");


            var User = _IUnitOfWork.UserRepository.Get(u => u.Id == id, include: query => query.Include(u => u.Person));

            if (User == null)
                return NotFound($"No user found with ID {id}.");

            var PhoneNumbers = _IUnitOfWork.PhoneNumberRepository.GetAll(p => p.PersonId == User.PersonId).Select(pn => pn.phone).ToList();

            return Ok(User.ToUserDetailsDto(PhoneNumbers));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNewUser(CreateUserDto NewUserDto)
        {
            if(NewUserDto == null)
                return BadRequest("User data is required.");

            var Transaction = _IUnitOfWork.BeginTransaction();

            try
            {
                var NewPerson = NewUserDto.ToPersonEntity();
                _IUnitOfWork.PersonRepository.Add(NewPerson);
                _IUnitOfWork.Save();

                var NewUser = NewUserDto.ToUserEntity(NewPerson.Id);
                _IUnitOfWork.UserRepository.Add(NewUser);



                var PhoneNumbers = NewUserDto.ToEntities(NewUser.PersonId);

                _IUnitOfWork.PhoneNumberRepository.AddRange(PhoneNumbers);

                _IUnitOfWork.Save();
                Transaction.Commit();
                return CreatedAtRoute("GetDetailsUserById", new { id = NewPerson.User.Id }, NewUser.ToUserDetailsDto(PhoneNumbers.Select(ph=>ph.phone).ToList()));
            }
            catch (Exception ex) 
            {
                Transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the user: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int id,UpdateUserDto updateUserDto)
        {
            if(updateUserDto == null)
                return BadRequest("User data is required.");

            if (!_IUnitOfWork.UserRepository.IsExist(u => u.Id == id))
                return NotFound($"No user found with ID {id}.");

            _IUnitOfWork.UserRepository.Update(updateUserDto, id);
            _IUnitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID. ID must be a positive integer.");
            var UserToDelete = _IUnitOfWork.UserRepository.Get(u => u.Id == id);

            if (UserToDelete is null)
                return NotFound($"No user found with ID {id}.");

            _IUnitOfWork.UserRepository.Remove(UserToDelete);
            _IUnitOfWork.Save();
            return NoContent();
        }

    }
}
