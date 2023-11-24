namespace NetChallenge.Dto.Output
{
    public class OfficeDto
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public string[] AvailableResources { get; set; }
    }
}