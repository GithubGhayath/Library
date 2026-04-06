using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class FinesRepository :Repository<Fine>, IFinesRepository
    {
        private readonly AppDbContext _Context;
        public FinesRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }
    }
}
