using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Exceptions;
using NetChallenge.Infrastructure.Abstractions;

namespace NetChallenge.Application.Validations
{
    public class LocationValidations : ILocationValidations
    { 
        private readonly ILocationRepository _locationRepository;

        public LocationValidations(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void Validate(AddLocationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Neighborhood))
                throw new NullFieldException();

            if (_locationRepository.AsEnumerable().Any(location => location.Name == request.Name))
                throw new RepeatedRegistryException();
        }
    }
}
