using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Services;
using NetChallenge.Core.Database;
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

        public OfficeRentalServiceTest()
        {
            var context = new ChallengeContext(new DbContextOptionsBuilder<ChallengeContext>()
                .UseInMemoryDatabase("ChallengeDB").Options);

            LocationRepository = new LocationRepository(context);
            OfficeRepository = new OfficeRepository(context);
            BookingRepository = new BookingRepository(context);
            Service = new OfficeRentalService(LocationRepository, OfficeRepository, BookingRepository);
        }
    }
}