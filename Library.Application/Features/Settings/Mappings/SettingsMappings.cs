using Library.Application.Features.Settings.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Settings.Mappings
{
    public static class SettingsMappings
    {
        public static Domain.Entities.Setting ToEntity(this UpdateSettingsDto SettingsDto)
        {
            return new Domain.Entities.Setting(SettingsDto.DefualtBorrrowDays,SettingsDto.DefaultFinePerDay);
        }
    }
}
