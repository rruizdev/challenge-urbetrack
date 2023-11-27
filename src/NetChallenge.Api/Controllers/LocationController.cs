using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;

namespace NetChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IOfficeRentalService _service;

        public LocationController(IOfficeRentalService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAsync() =>
            Ok(_service.GetLocations());

        [HttpPost]
        public IActionResult AddAsync(AddLocationRequest request)
        {
            _service.AddLocation(request);
            return Ok();
        }
    }
}
