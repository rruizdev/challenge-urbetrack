using System.Collections.Generic;

namespace NetChallenge.Application.Dto.Input
{
    public class SuggestionsRequest
    {
        public int CapacityNeeded { get; set; }
        public string PreferedNeigborHood { get; set; }
        public IEnumerable<string> ResourcesNeeded { get; set; }
    }
}