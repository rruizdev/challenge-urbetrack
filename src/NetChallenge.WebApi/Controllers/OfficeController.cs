using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Services;

namespace NetChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeRentalService _officeRentalService;

        public OfficeController(IOfficeRentalService officeRentalService)
        {
            _officeRentalService = officeRentalService;
        }

        [HttpGet("{locationName}")]
        public IActionResult GetAll([FromRoute] string locationName) =>
            Ok(_officeRentalService.GetOffices(locationName));

        [HttpPost]
        public IActionResult Add([FromBody] AddOfficeRequest request)
        {
            _officeRentalService.AddOffice(request);

            return Ok();
        }
    }
}
