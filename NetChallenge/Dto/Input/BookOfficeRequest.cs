using System;

namespace NetChallenge.Dto.Input
{
    public class BookOfficeRequest
    {
        public string LocationName { get; set; }
        public string OfficeName { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string UserName { get; set; }
    }
}