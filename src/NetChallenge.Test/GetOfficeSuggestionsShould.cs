using System.Linq;
using NetChallenge.Test.Utils;
using Xunit;

namespace NetChallenge.Test
{
    public class GetOfficeSuggestionsShould : OfficeRentalServiceTest
    {
        public GetOfficeSuggestionsShould()
        {
            Service.AddLocation(AddLocationRequestMother.Default);
            Service.AddLocation(AddLocationRequestMother.Central);
            Service.AddLocation(AddLocationRequestMother.Almagro);
            Service.AddLocation(AddLocationRequestMother.Palermo);
        }

        [Fact]
        public void ReturnEmptyWhenThereAreNoOffices()
        {
            var request = SuggestionsRequestMother.Default;

            var response = Service.GetOfficeSuggestions(request);

            Assert.Empty(response);
        }

        [Fact]
        public void ReturnEmptyWhenNoCapacityAvailable()
        {
            Service.AddOffice(AddOfficeRequestMother.Blue.WithMaxCapacity(5));
            Service.AddOffice(AddOfficeRequestMother.Red.WithMaxCapacity(10));

            var request = SuggestionsRequestMother.Default.WithCapacityNeeded(20);

            var response = Service.GetOfficeSuggestions(request);

            Assert.Empty(response);
        }

        [Fact]
        public void ReturnEmptyWhenResourcesNotAvailable()
        {
            Service.AddOffice(AddOfficeRequestMother.Blue);
            Service.AddOffice(AddOfficeRequestMother.Red);

            var request = SuggestionsRequestMother.Default.WithResourcesNeeded("Unsupported resource");

            var response = Service.GetOfficeSuggestions(request);

            Assert.Empty(response);
        }

        [Fact]
        public void PreferOfficeOnSelectedNeighborhood()
        {
            Service.AddOffice(AddOfficeRequestMother.Blue.WithMaxCapacity(5).WithLocationName(AddLocationRequestMother.Almagro.Name));
            Service.AddOffice(AddOfficeRequestMother.Red.WithMaxCapacity(10).WithLocationName(AddLocationRequestMother.Palermo.Name));

            var request = SuggestionsRequestMother.Default.WithPreferedNeigborHood(AddLocationRequestMother.Palermo.Neighborhood);

            var response = Service.GetOfficeSuggestions(request);

            Assert.Equal(2, response.Count());
            Assert.Equal(AddOfficeRequestMother.Red.Name, response.First().Name);
        }

        [Fact]
        public void ReturnAnotherNeighborhoodWhenNoOneMatches()
        {
            Service.AddOffice(AddOfficeRequestMother.Blue.WithMaxCapacity(5).WithLocationName(AddLocationRequestMother.Almagro.Name));
            Service.AddOffice(AddOfficeRequestMother.Red.WithMaxCapacity(10).WithLocationName(AddLocationRequestMother.Palermo.Name));

            var request = SuggestionsRequestMother.Default
                .WithCapacityNeeded(8)
                .WithPreferedNeigborHood(AddLocationRequestMother.Almagro.Neighborhood);

            var response = Service.GetOfficeSuggestions(request);

            Assert.Equal(AddOfficeRequestMother.Red.Name, response.Single().Name);
        }

        [Fact]
        public void ReturnSmallerMatchingOffice()
        {
            Service.AddOffice(AddOfficeRequestMother.Blue.WithMaxCapacity(5));
            Service.AddOffice(AddOfficeRequestMother.Green.WithMaxCapacity(20));
            Service.AddOffice(AddOfficeRequestMother.Red.WithMaxCapacity(10));

            var request = SuggestionsRequestMother.Default
                .WithCapacityNeeded(6);

            var response = Service.GetOfficeSuggestions(request);

            Assert.Equal(2, response.Count());
            Assert.Equal(AddOfficeRequestMother.Red.Name, response.First().Name);
        }

        [Fact]
        public void ReturnOfficeWithFewerResources()
        {
            Service.AddOffice(AddOfficeRequestMother.Blue.WithMaxCapacity(10).WithAvailableResources("Internet", "TV", "Projector", "Whiteboard", "Phone"));
            Service.AddOffice(AddOfficeRequestMother.Red.WithMaxCapacity(10).WithAvailableResources("Internet"));
            Service.AddOffice(AddOfficeRequestMother.Green.WithMaxCapacity(10).WithAvailableResources("Internet", "Whiteboard"));

            var request = SuggestionsRequestMother.Default;

            var response = Service.GetOfficeSuggestions(request);

            Assert.Equal(3, response.Count());
            Assert.Equal(AddOfficeRequestMother.Red.Name, response.First().Name);
        }
    }
}