using NetChallenge.Application.Dto.Input;

namespace NetChallenge.Test.Utils
{
    public static class SuggestionsRequestMother
    {
        public static SuggestionsRequest Default => new()
        {
            CapacityNeeded = 1,
            PreferedNeigborHood = null,
            ResourcesNeeded = Array.Empty<string>()
        };

        public static SuggestionsRequest WithCapacityNeeded(this SuggestionsRequest request, int capacity)
        {
            request.CapacityNeeded = capacity;
            return request;
        }

        public static SuggestionsRequest WithPreferedNeigborHood(this SuggestionsRequest request, string neighborhood)
        {
            request.PreferedNeigborHood = neighborhood;
            return request;
        }

        public static SuggestionsRequest WithResourcesNeeded(this SuggestionsRequest request, params string[] resources)
        {
            request.ResourcesNeeded = resources;
            return request;
        }
    }
}