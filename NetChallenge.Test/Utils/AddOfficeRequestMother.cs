using NetChallenge.Dto.Input;

namespace NetChallenge.Test.Utils
{
    public static class AddOfficeRequestMother
    {
        public static AddOfficeRequest Default => new AddOfficeRequest
        {
            LocationName = AddLocationRequestMother.Default.Name,
            Name = "Default Office",
            MaxCapacity = 10,
            AvailableResources = new[] { "Internet" }
        };

        public static AddOfficeRequest Blue => Default
            .WithName("Blue Office")
            .WithMaxCapacity(5);

        public static AddOfficeRequest Red => Default
            .WithName("Red Office")
            .WithMaxCapacity(10);

        public static AddOfficeRequest Green => Default
            .WithName("Green Office")
            .WithMaxCapacity(20);

        public static AddOfficeRequest WithLocationName(this AddOfficeRequest request, string locationName)
        {
            request.LocationName = locationName;
            return request;
        }

        public static AddOfficeRequest WithName(this AddOfficeRequest request, string name)
        {
            request.Name = name;
            return request;
        }

        public static AddOfficeRequest WithMaxCapacity(this AddOfficeRequest request, int maxCapacity)
        {
            request.MaxCapacity = maxCapacity;
            return request;
        }

        public static AddOfficeRequest WithAvailableResources(this AddOfficeRequest request, params string[] resources)
        {
            request.AvailableResources = resources;
            return request;
        }
    }
}