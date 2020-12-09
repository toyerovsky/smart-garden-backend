using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PSK.SmartGarden.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class MeasurementController : ControllerBase
    {
        private readonly ILogger<MeasurementController> _logger;

        public MeasurementController(ILogger<MeasurementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetMeasurementList(GetMeasurementListInputDto input)
        {
            var rng = new Random();
            return Ok(new GetMeasurementListOutputDto
            {
                Data = Enumerable.Range(1, 5).Select(index => new GetMeasurementListOutputDto.ListItemDto
                    {
                        MeasurementDate = DateTime.Now.AddDays(index),
                        AirTemperature = rng.Next(10, 30),
                        AirHumidity = rng.Next(50, 60),
                        SoilMoisture = rng.Next(80, 98),
                    })
                    .ToArray()
            });
        }
    }
}