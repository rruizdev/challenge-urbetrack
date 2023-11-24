using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Services;

namespace NetChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IOfficeRentalService _officeRentalService;

        public LocationController(IOfficeRentalService officeRentalService)
        {
            _officeRentalService = officeRentalService;
        }

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_officeRentalService.GetLocations());

        [HttpPost]
        public IActionResult Add([FromBody] AddLocationRequest request)
        {
            _officeRentalService.AddLocation(request);

            return Ok();
        }
    }
}
