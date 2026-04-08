using Library.Application.Features.Users.Dtos;
using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Reopsitories
{
    public interface IUserRepository:IRepository<User>
    {
        void Update(UpdateUserDto UpdatedUser, int UserId);
    }
}
