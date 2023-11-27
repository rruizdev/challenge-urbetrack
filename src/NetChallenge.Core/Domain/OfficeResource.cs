namespace NetChallenge.Core.Domain
{
    public class OfficeResource
    {
        public int OfficeId { get; set; }

        public string ResourceName { get; set; }

        public Office Office { get; set; }

        public Resource Resource { get; set; }
    }
}
