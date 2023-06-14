using System;
using System.Runtime.Serialization;

namespace Fatec.Domain.Exceptions
{
    public class AddressDoesntExistsException : Exception
    {
        public AddressDoesntExistsException()
        {
        }

        public AddressDoesntExistsException(string message)
            : base(message)
        {
        }

        public AddressDoesntExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected AddressDoesntExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
