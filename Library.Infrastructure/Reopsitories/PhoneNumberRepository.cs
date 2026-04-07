using Library.Application.Features.PhoneNumber.Dtos;
using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        private readonly AppDbContext _Context;
        public PhoneNumberRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }
     
    }
}
