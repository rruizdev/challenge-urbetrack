using System;
using NetChallenge.Dto.Input;

namespace NetChallenge.Test.Utils
{
    public static class BookOfficeRequestMother
    {
        public static BookOfficeRequest Default => new BookOfficeRequest
        {
            LocationName = AddOfficeRequestMother.Default.LocationName,
            OfficeName = AddOfficeRequestMother.Default.Name,
            DateTime = new DateTime(2022, 10, 10, 10, 0, 0, DateTimeKind.Utc),
            Duration = TimeSpan.FromHours(1),
            UserName = "test_user"
        };

        public static BookOfficeRequest WithDate(this BookOfficeRequest request, DateTime dateTime)
        {
            request.DateTime = dateTime;
            return request;
        }

        public static BookOfficeRequest WithDuration(this BookOfficeRequest request, TimeSpan duration)
        {
            request.Duration = duration;
            return request;
        }

        public static BookOfficeRequest WithOfficeName(this BookOfficeRequest request, string officeName)
        {
            request.OfficeName = officeName;
            return request;
        }

        public static BookOfficeRequest WithLocationName(this BookOfficeRequest request, string locationName)
        {
            request.LocationName = locationName;
            return request;
        }

        public static BookOfficeRequest WithUserName(this BookOfficeRequest request, string userName)
        {
            request.UserName = userName;
            return request;
        }
    }
}