using System;
using System.Runtime.Serialization;

namespace Fatec.Domain.Exceptions
{
    public class IsValidationException : Exception
    {
        public IsValidationException()
        {
        }

        public IsValidationException(string message)
            : base(message)
        {
        }

        public IsValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IsValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
