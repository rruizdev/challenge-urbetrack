using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Core.Domain
{
    public class Location
    {
        [Key, Required, StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string? Neighborhood { get; set; }

        public List<Office> Offices { get; set; }
    }
}