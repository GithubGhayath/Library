using Library.Application.Features.Settings.Dtos;
using Library.Application.Reopsitories.Common;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Reopsitories
{
    public interface ISettingsRepository : IRepository<Setting>
    {
        void Update(UpdateSettingsDto settingsDto);
    }
}
