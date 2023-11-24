using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Services;

namespace NetChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IOfficeRentalService _officeRentalService;

        public BookingController(IOfficeRentalService officeRentalService)
        {
            _officeRentalService = officeRentalService;
        }

        [HttpGet("{locationName}/{officeName}")]
        public IActionResult GetAll([FromRoute] string locationName, [FromRoute] string officeName) =>
            Ok(_officeRentalService.GetBookings(locationName, officeName));

        [HttpPost]
        public IActionResult Book([FromBody] BookOfficeRequest request)
        {
            _officeRentalService.BookOffice(request);

            return Ok();
        }
    }
}
