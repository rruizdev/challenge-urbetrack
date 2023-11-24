using System;
using System.Linq;
using NetChallenge.Test.Utils;
using Xunit;

namespace NetChallenge.Test
{
    public class AddLocationShould : OfficeRentalServiceTest
    {
        [Fact]
        public void AddLocation()
        {
            var request = AddLocationRequestMother.Default;

            Service.AddLocation(request);

            var location = Service.GetLocations().Single();
            Assert.Equal(request.Name, location.Name);
            Assert.Equal(request.Neighborhood, location.Neighborhood);
        }

        [Fact]
        public void AddMultipleLocations()
        {
            var requestCentral = AddLocationRequestMother.Central;
            var requestAlmagro = AddLocationRequestMother.Almagro;
            var requestPalermo = AddLocationRequestMother.Palermo;

            Service.AddLocation(requestCentral);
            Service.AddLocation(requestAlmagro);
            Service.AddLocation(requestPalermo);

            var locations = Service.GetLocations();
            Assert.Equal(3, locations.Count());
            Assert.Contains(locations, x => x.Name == requestCentral.Name && x.Neighborhood == requestCentral.Neighborhood);
            Assert.Contains(locations, x => x.Name == requestAlmagro.Name && x.Neighborhood == requestAlmagro.Neighborhood);
            Assert.Contains(locations, x => x.Name == requestPalermo.Name && x.Neighborhood == requestPalermo.Neighborhood);
        }

        [Fact]
        public void ThrowWhenLocationNameIsEmpty()
        {
            var request = AddLocationRequestMother.Default.WithName("");

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact]
        public void ThrowWhenLocationNameIsNull()
        {
            var request = AddLocationRequestMother.Default.WithName(null);

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact]
        public void ThrowWhenLocationNeighborhoodIsEmpty()
        {
            var request = AddLocationRequestMother.Default.WithNeighborhood("");

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact]
        public void ThrowWhenLocationNeighborhoodIsNull()
        {
            var request = AddLocationRequestMother.Default.WithNeighborhood(null);

            Assert.ThrowsAny<Exception>(() => { Service.AddLocation(request); });
        }

        [Fact]
        public void ThrowWhenLocationNameAlreadyExists()
        {
            var request1 = AddLocationRequestMother.Central;
            var request2 = AddLocationRequestMother.Default.WithName(request1.Name);
            Service.AddLocation(request1);

            Assert.ThrowsAny<Exception>(() =>
            {
                Service.AddLocation(request2);
            });
        }
    }
}