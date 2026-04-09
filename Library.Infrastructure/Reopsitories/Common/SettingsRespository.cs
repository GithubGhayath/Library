using Library.Application.Features.Settings.Dtos;
using Library.Application.Reopsitories;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Reopsitories.Common
{
    public class SettingsRespository : Repository<Setting>, ISettingsRepository
    {
        private readonly AppDbContext _Context;
        public SettingsRespository(AppDbContext context) : base(context)
        {
            _Context = context;
        }
        public void Update(UpdateSettingsDto settingsDto)
        {
            var Settings = _Context.Settings.First();

            Settings.DefualtBorrrowDays = settingsDto.DefualtBorrrowDays;
            Settings.DefaultFinePerDay = settingsDto.DefaultFinePerDay;
        }
    }
}
