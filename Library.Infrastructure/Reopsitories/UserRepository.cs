using Library.Application.Features.Users.Dtos;
using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Reopsitories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories
{
    public class UserRepository:Repository<User>, IUserRepository
    {
        private readonly AppDbContext _Context;
        public UserRepository(AppDbContext context):base(context)
        {
            _Context = context;
        }

        public void Update(UpdateUserDto UpdatedUser,int UserId)
        {
            var User = _Context.Users.Include(u => u.Person).SingleOrDefault(u => u.Id == UserId);
            User.Person.FirstName = UpdatedUser.FirstName;
            User.Person.LastName = UpdatedUser.LastName;
            User.Person.Email = new Domain.ValueObjects.Email(UpdatedUser.Email);
            User.Password = BCrypt.Net.BCrypt.HashPassword(UpdatedUser.Password);
            User.Person.AuditTimestamp = new Domain.ValueObjects.AuditTimestamp(User.Person.AuditTimestamp!.CreateAt, DateTime.Now);
        }
        public override void Remove(User entity)
        {
            entity.IsDeleted = true;
        }
    }
}
