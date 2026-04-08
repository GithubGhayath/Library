using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class PersonRepository:Repository<Person>,IPersonRepository
    {
        private readonly AppDbContext _Context;

        public PersonRepository(AppDbContext Context) : base(Context)
        {
            _Context = Context;
        }   

    }
}
