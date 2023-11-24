using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Exceptions;
using NetChallenge.Infrastructure.Abstractions;

namespace NetChallenge.Application.Validations
{
    public class OfficeValidations : IOfficeValidations
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly ILocationRepository _locationRepository;

        public OfficeValidations(IOfficeRepository officeRepository, ILocationRepository locationRepository)
        {
            _officeRepository = officeRepository;
            _locationRepository = locationRepository;
        }

        public void Validate(AddOfficeRequest request)
        {
            if (request.MaxCapacity <= 0)
                throw new ZeroFieldException();

            if (string.IsNullOrWhiteSpace(request.LocationName) || string.IsNullOrWhiteSpace(request.Name) || request.AvailableResources == null)
                throw new NullFieldException();

            if (!_locationRepository.AsEnumerable().Any(location => location.Name == request.LocationName))
                throw new InvalidFieldException();

            if (_officeRepository.AsEnumerable().Any(office => office.LocationName == request.LocationName && office.Name == request.Name))
                throw new RepeatedRegistryException();
        }
    }
}
