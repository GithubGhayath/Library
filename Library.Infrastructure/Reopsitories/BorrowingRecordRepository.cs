using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class BorrowingRecordRepository:Repository<BorrowingRecord>, IBorrowingRecordRepository
    {
        private readonly AppDbContext _Context;
        public BorrowingRecordRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }
    }
}
