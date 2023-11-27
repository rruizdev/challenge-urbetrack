using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Core.Domain
{
    public class Office
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxCapacity { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string LocationName { get; set; }

        public Location Location { get; set; }

        public List<OfficeResource> OfficeResources { get; set; }
    }
}