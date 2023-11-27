using System.Runtime.Serialization;

namespace NetChallenge.Application.Exceptions
{
    public class ExistentBookingException : ChallengeException
    {
        public ExistentBookingException() : base() { }

        public ExistentBookingException(string? message) : base(message)
        {
        }

        public ExistentBookingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExistentBookingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
