using System.Runtime.Serialization;

namespace NetChallenge.Application.Exceptions
{
    public class InvalidFieldsException : ChallengeException
    {
        public InvalidFieldsException()
        {
        }

        public InvalidFieldsException(string? message) : base(message)
        {
        }

        public InvalidFieldsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidFieldsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
