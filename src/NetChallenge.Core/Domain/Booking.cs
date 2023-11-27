using System.ComponentModel.DataAnnotations;

namespace NetChallenge.Core.Domain
{
    public class Booking
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string UserName { get; set; }

        public DateTime DateTime { get; set; }

        [Range(1, int.MaxValue)]
        public int Duration { get; set; }

        public int OfficeId { get; set; }

        public Office Office { get; set; }

        public string LocationName { get; set; }
    }
}