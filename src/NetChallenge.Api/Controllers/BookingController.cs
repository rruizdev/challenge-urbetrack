using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;

namespace NetChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IOfficeRentalService _service;

        public BookingController(IOfficeRentalService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAsync([FromQuery] string location, [FromQuery] string office) =>
            Ok(_service.GetBookings(location, office));

        [HttpPost]
        public IActionResult AddAsync(BookOfficeRequest request)
        {
            _service.BookOffice(request);
            return Ok();
        }
    }
}
