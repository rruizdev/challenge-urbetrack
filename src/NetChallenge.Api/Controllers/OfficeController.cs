using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;

namespace NetChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeRentalService _service;

        public OfficeController(IOfficeRentalService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAsync([FromQuery] string location) =>
            Ok(_service.GetOffices(location));

        [HttpGet("suggestions")]
        public IActionResult GetSuggestionsAsync([FromBody] SuggestionsRequest request) =>
            Ok(_service.GetOfficeSuggestions(request));

        [HttpPost]
        public IActionResult AddAsync([FromBody] AddOfficeRequest request)
        {
            _service.AddOffice(request);
            return Ok();
        }
    }
}
