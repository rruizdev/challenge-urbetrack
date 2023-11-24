using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Services;
using NetChallenge.Application.Validations;
using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Repositories;

namespace NetChallenge.Test
{
    public class OfficeRentalServiceTest
    {
        protected OfficeRentalService Service;

        protected ILocationRepository LocationRepository;
        protected IOfficeRepository OfficeRepository;
        protected IBookingRepository BookingRepository;

        protected ILocationValidations LocationValidations;
        protected IOfficeValidations OfficeValidations;
        protected IBookingValidations BookingValidations;

        public OfficeRentalServiceTest()
        {
            LocationRepository = new LocationRepository();
            OfficeRepository = new OfficeRepository();
            BookingRepository = new BookingRepository();

            LocationValidations = new LocationValidations(LocationRepository);
            OfficeValidations = new OfficeValidations(OfficeRepository, LocationRepository);
            BookingValidations = new BookingValidations(BookingRepository, OfficeRepository, LocationRepository);

            Service = new OfficeRentalService(LocationRepository, OfficeRepository, BookingRepository, 
                OfficeValidations, LocationValidations, BookingValidations);
        }
    }
}