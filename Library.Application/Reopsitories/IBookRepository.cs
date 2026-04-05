using Library.Application.Features.Books.Dtos;
using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;

namespace Library.Application.Reopsitories
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(UpdateBookDto book,int Id);
    }
}
