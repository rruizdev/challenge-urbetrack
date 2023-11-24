using System.Collections.Generic;

namespace NetChallenge.Dto.Input
{
    public class AddOfficeRequest
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public IEnumerable<string> AvailableResources { get; set; }
    }
}