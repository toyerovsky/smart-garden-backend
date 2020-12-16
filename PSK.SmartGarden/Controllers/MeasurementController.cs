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
        private readonly IMeasurementQueryService _measurementQueryService;

        public MeasurementController(
            ILogger<MeasurementController> logger,
            IMeasurementQueryService measurementQueryService)
        {
            _logger = logger;
            _measurementQueryService = measurementQueryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetMeasurementListOutputDto), StatusCodes.Status200OK)]
        public IActionResult GetMeasurementList([FromQuery] GetMeasurementListInputDto input)
        {
            if (!ModelState.IsValid)
            {    
                return BadRequest();
            }

            var response = _measurementQueryService.GetMeasurementList(input);

            return Ok(response);
        }
    }
}