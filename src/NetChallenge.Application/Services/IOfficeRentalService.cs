using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Dto.Output;

namespace NetChallenge.Application.Services
{
    public interface IOfficeRentalService
    {
        void AddLocation(AddLocationRequest request);

        void AddOffice(AddOfficeRequest request);

        void BookOffice(BookOfficeRequest request);

        IEnumerable<BookingDto> GetBookings(string locationName, string officeName);

        IEnumerable<LocationDto> GetLocations();

        IEnumerable<OfficeDto> GetOffices(string locationName);

        IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request);
    }
}
