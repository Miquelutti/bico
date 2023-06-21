using System;
using System.Runtime.Serialization;

namespace Bico.Domain.Exceptions
{
    public class AuthenticateException : Exception
    {
        public AuthenticateException() { }

        public AuthenticateException(string message) : base(message) { }

        public AuthenticateException(string message, Exception inner)
            : base(message, inner) { }

        protected AuthenticateException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
