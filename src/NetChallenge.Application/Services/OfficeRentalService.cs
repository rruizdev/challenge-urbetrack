using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Dto.Output;
using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Domain;

namespace NetChallenge.Application.Services
{
    public class OfficeRentalService : IOfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;

        private readonly IOfficeValidations _officeValidations;
        private readonly ILocationValidations _locationValidations;
        private readonly IBookingValidations _bookingValidations;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, 
            IBookingRepository bookingRepository, IOfficeValidations officeValidations, ILocationValidations locationValidations,
            IBookingValidations bookingValidations)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;

            _locationValidations = locationValidations;
            _officeValidations = officeValidations;
            _bookingValidations = bookingValidations;
        }

        public void AddLocation(AddLocationRequest request)
        {
            _locationValidations.Validate(request);

            _locationRepository.Add(new Location()
            {
                Name = request.Name,
                Neighborhood = request.Neighborhood
            });
        }

        public void AddOffice(AddOfficeRequest request)
        {
            _officeValidations.Validate(request);

            _officeRepository.Add(new Office()
            {
                AvailableResources = request.AvailableResources,
                LocationName = request.LocationName,
                Name = request.Name,
                MaxCapacity = request.MaxCapacity
            });
        }

        public void BookOffice(BookOfficeRequest request)
        {
            _bookingValidations.Validate(request);

            _bookingRepository.Add(new Booking()
            {
                LocationName = request.LocationName,
                DateTime = request.DateTime,
                Duration = request.Duration,
                OfficeName = request.OfficeName,
                UserName = request.UserName
            });
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName) =>
            _bookingRepository.AsEnumerable()
                .Where(booking => booking.LocationName == locationName && booking.OfficeName == officeName)
                .Select(booking => new BookingDto()
                {
                    DateTime = booking.DateTime,
                    Duration = booking.Duration,
                    OfficeName = booking.OfficeName,
                    LocationName = booking.LocationName,
                    UserName = booking.UserName
                });

        public IEnumerable<LocationDto> GetLocations() =>
            _locationRepository.AsEnumerable()
                .Select(location => new LocationDto()
                {
                    Name = location.Name,
                    Neighborhood = location.Neighborhood
                });

        public IEnumerable<OfficeDto> GetOffices(string locationName) =>
            _officeRepository.AsEnumerable().Where(office => office.LocationName == locationName)
                .Select(office => new OfficeDto()
                {
                    Name = office.Name,
                    AvailableResources = office.AvailableResources.ToArray(),
                    LocationName = office.LocationName,
                    MaxCapacity = office.MaxCapacity
                });


        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            return _officeRepository.AsEnumerable()
                .Where(office => request.CapacityNeeded <= office.MaxCapacity)
                .Where(office => !request.ResourcesNeeded.Any() || request.ResourcesNeeded
                    .All(resource => office.AvailableResources
                    .Any(available => available == resource)))
                .Join(_locationRepository.AsEnumerable(),
                    office => office.LocationName,
                    location => location.Name,
                    (office, location) => new OfficeLocation()
                    {
                        Office = office,
                        Location = location
                    })
                .OrderByDescending(ol => ol.Location.Neighborhood == request.PreferedNeigborHood)
                .ThenBy(ol => ol.Office.MaxCapacity)
                .ThenBy(ol => ol.Office.AvailableResources.Count())
                .Select(ol => new OfficeDto()
                {
                    Name = ol.Office.Name,
                    AvailableResources = ol.Office.AvailableResources.ToArray(),
                    LocationName = ol.Office.LocationName,
                    MaxCapacity = ol.Office.MaxCapacity
                });
        }
    }
}