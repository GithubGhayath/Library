using Library.Application.Features.PhoneNumber.Dtos;
using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Reopsitories
{
    public interface IPhoneNumberRepository:IRepository<PhoneNumber>
    {
    }
}
