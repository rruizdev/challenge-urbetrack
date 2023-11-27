using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Dto.Output;
using NetChallenge.Application.Exceptions;
using NetChallenge.Core.Domain;
using NetChallenge.Infrastructure.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NetChallenge.Application.Services
{
    public class OfficeRentalService : IOfficeRentalService
    {
        private readonly IRepository<Location> _locationRepository;
        private readonly IRepository<Office> _officeRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public OfficeRentalService(IRepository<Location> locationRepository, 
            IRepository<Office> officeRepository, IRepository<Booking> bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public void AddLocation(AddLocationRequest request) => 
            _locationRepository.Add(Validate(new Location()
            {
                Name = request.Name,
                Neighborhood = request.Neighborhood
            }));

        public void AddOffice(AddOfficeRequest request)
        {
            if (!GetLocations().Any(loc => loc.Name == request.LocationName))
            {
                throw new LocationNotFoundException();
            }

            _officeRepository.Add(Validate(new Office()
            {
                LocationName = request.LocationName,
                MaxCapacity = request.MaxCapacity,
                Name = request.Name,
                OfficeResources = request.AvailableResources.Select(ar => new OfficeResource()
                {
                    OfficeId = 0,
                    ResourceName = ar
                }).ToList()
            }));
        }          

        public void BookOffice(BookOfficeRequest request)
        {
            if (GetBookings(request.LocationName, request.OfficeName)
                .Any(bo => bo.DateTime < request.DateTime + request.Duration && request.DateTime < bo.DateTime + bo.Duration))
                throw new ExistentBookingException();

            _bookingRepository.Add(Validate(new Booking()
            {
                DateTime = request.DateTime,
                Duration = request.Duration.Hours,
                LocationName = request.LocationName,
                UserName = request.UserName,
                OfficeId = _officeRepository.AsEnumerable()
                    .First(off => off.LocationName == request.LocationName 
                        && off.Name == request.OfficeName).Id
            }));
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName) => 
            _bookingRepository.AsEnumerable()
                .Where(bo => bo.LocationName == locationName && bo.Office.Name == officeName)
                .Select(bo => new BookingDto()
                {
                    DateTime = bo.DateTime,
                    LocationName = bo.LocationName,
                    OfficeName = bo.Office.Name,
                    UserName = bo.UserName,
                    Duration = TimeSpan.FromHours(bo.Duration)
                });

        public IEnumerable<LocationDto> GetLocations() =>
            _locationRepository.AsEnumerable().Select(loc => new LocationDto()
            {
                Name = loc.Name,
                Neighborhood = loc.Neighborhood
            });

        public IEnumerable<OfficeDto> GetOffices(string locationName) => 
            _officeRepository.AsEnumerable()
                .Where(off => off.Location.Name == locationName)
                .Select(Parse);

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request) => 
            _officeRepository.AsEnumerable()
                .Where(off => off.MaxCapacity >= request.CapacityNeeded)
                .Where(off => request.ResourcesNeeded.All(r => off.OfficeResources.Any(ofr => ofr.ResourceName == r)))
                .OrderByDescending(off => off.Location.Neighborhood == request.PreferedNeigborHood)
                .ThenBy(off => off.MaxCapacity)
                .ThenBy(off => off.OfficeResources.Count)
                .Select(Parse);

        private static OfficeDto Parse(Office off) => new OfficeDto()
        {
            LocationName = off.LocationName,
            MaxCapacity = off.MaxCapacity,
            Name = off.Name,
            AvailableResources = off.OfficeResources.Select(ofr => ofr.ResourceName).ToArray()
        };

        private static T Validate<T>(T _) where T : class
        {
            if (!Validator.TryValidateObject(_, new ValidationContext(_), null, true))
            {
                throw new InvalidFieldsException();
            }

            return _;
        }
    }
}