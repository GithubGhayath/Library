using Library.Application.Features.Books.Dtos;
using Library.Application.Features.Books.Mappings;
using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/Books")]   // Rout: https://localhost:7170/api/Books
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetBookList()
        {

            var BookList = _UnitOfWork.BookRepository.GetAll(include: q => q.Include(b => b.BookCopies)).Select(b => b.ToDto());

            if (BookList.Count() == 0)
                return NotFound();

            return Ok(BookList);
        }


        [HttpGet("{id}", Name = "GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookById(int id)
        {
            var Book = _UnitOfWork.BookRepository.Get(b => b.Id == id,include:query=>query.Include(b=>b.BookCopies));

            if (Book == null)
                return NotFound();

            return Ok(Book.ToDetailsDto());
        }

        [HttpGet("Search",Name ="GetBookByName")]
        public IActionResult GetBookByName(string BookName)
        {
            var Book = _UnitOfWork.BookRepository.Get(b => b.Titile == BookName, include: query => query.Include(b => b.BookCopies));

            if (Book == null)
                return NotFound();

            return Ok(Book.ToDto());
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNewBook(CreateBookDto book)
        {
            if (book == null)
                return BadRequest();

            using var transaction = _UnitOfWork.BeginTransaction();

            try
            {
                var newBook = book.ToEntity();

                _UnitOfWork.BookRepository.Add(newBook);
                _UnitOfWork.Save(); // generate Id

                var copies = book.GenerateBookCopiesRecord(newBook.Id);
                _UnitOfWork.BookCopyRepository.AddRange(copies);

                _UnitOfWork.Save(); // save everything

                transaction.Commit();

                return CreatedAtRoute("GetBookById", new { id = newBook.Id }, book);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateBook(int id, UpdateBookDto BookDto)
        {
            if (BookDto == null)
                return BadRequest();

            if (!_UnitOfWork.BookRepository.IsExist(b => b.Id == id))
                return NotFound();

            using var transaction = _UnitOfWork.BeginTransaction();

            try
            {
                _UnitOfWork.BookRepository.Update(BookDto, id);


                int OldNumberOfCopies = _UnitOfWork.BookCopyRepository.GetAll(Filter: bc => bc.BookId == id).ToList().Count;
                int NewNumberOfCopies = BookDto.NumberOfCopies;


                if (NewNumberOfCopies > OldNumberOfCopies)
                {
                    List<BookCopy> bookCopies = BookDto.GenerateBookCopiesRecord(OldNumberOfCopies, id);
                    _UnitOfWork.BookCopyRepository.AddRange(bookCopies);
                }
                if(NewNumberOfCopies < OldNumberOfCopies)
                    _UnitOfWork.BookCopyRepository.RemoveNumberOfCopies(OldNumberOfCopies - NewNumberOfCopies, id);


                _UnitOfWork.Save(); // save everything


                transaction.Commit();
                return NoContent();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(int id)
        {
            var Book = _UnitOfWork.BookRepository.Get(b => b.Id == id);

            if (Book == null)
                return NotFound();

            try
            {
                _UnitOfWork.BookRepository.Remove(Book);
                _UnitOfWork.Save();
                
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
         
        }
    }
}
