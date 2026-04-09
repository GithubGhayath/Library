using Library.Application.Features.Settings.Dtos;
using Library.Application.Reopsitories.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/Settings")]  // Rout: https://localhost:7170/api/Settings
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public SettingsController(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSettings()
        {
            var Settings = _IUnitOfWork.SettingsRepository.GetAll();

            if (Settings == null)
                return NotFound("Settings not found");

            return Ok(Settings);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateSettings(UpdateSettingsDto setting)
        {
            _IUnitOfWork.SettingsRepository.Update(setting);
            _IUnitOfWork.Save();

            return NoContent();
        }
    }
}
