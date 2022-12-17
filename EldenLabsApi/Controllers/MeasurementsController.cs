using CsvHelper;
using EldenLabsApi.Database.Entities;
using EldenLabsApi.DTOs;
using EldenLabsApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace EldenLabsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementsController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpGet]
        public Task<IEnumerable<Measurement>> GetAll(string? startDate, string? endDate)
        {
            return _measurementService.GetAll(startDate, endDate);
        }

        [HttpPost]
        [Route("csv")]
        public async Task<IActionResult> CreateFromCsv()
        {
            try
            {
                IFormFileCollection formFiles = Request.Form.Files;

                if (formFiles.Count() == 0)
                {
                    return BadRequest("No se adjunto el archivo.");
                }

                IFormFile csvFile = formFiles[0];
                await _measurementService.CreateFromCsv(csvFile);

                return Ok("Registros creados.");
            }
            catch (Exception ex)
            {
                return Problem("Ocurrió un error procesando el archivo.");
            }
        }
    }
}
