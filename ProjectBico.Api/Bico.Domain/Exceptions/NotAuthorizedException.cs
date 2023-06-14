using System;
using System.Runtime.Serialization;

namespace Fatec.Domain.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException()
        {
        }

        public NotAuthorizedException(string message)
            : base(message)
        {
        }

        public NotAuthorizedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NotAuthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
