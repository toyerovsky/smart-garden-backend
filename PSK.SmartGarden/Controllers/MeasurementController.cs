using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSK.SmartGarden.Application;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class MeasurementController : ControllerBase
    {
        private readonly ILogger<MeasurementController> _logger;
        private readonly IMeasurementService _measurementService;

        public MeasurementController(
            ILogger<MeasurementController> logger,
            IMeasurementService measurementService)
        {
            _logger = logger;
            _measurementService = measurementService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetMeasurementListOutputDto), StatusCodes.Status200OK)]
        public IActionResult GetMeasurementList([FromQuery] GetMeasurementListInputDto input)
        {
            if (!ModelState.IsValid)
            {    
                return BadRequest();
            }

            var response = _measurementService.GetMeasurementList(input);

            return Ok(response);
        }
    }
}