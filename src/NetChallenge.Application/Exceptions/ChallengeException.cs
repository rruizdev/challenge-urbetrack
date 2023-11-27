using System.Runtime.Serialization;

namespace NetChallenge.Application.Exceptions
{
    public class ChallengeException : ApplicationException
    {
        public ChallengeException()
        {
        }

        public ChallengeException(string? message) : base(message)
        {
        }

        public ChallengeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChallengeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
