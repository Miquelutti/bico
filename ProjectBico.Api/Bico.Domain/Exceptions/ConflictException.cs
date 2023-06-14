﻿using System;
using System.Runtime.Serialization;

namespace Fatec.Domain.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message)
            : base(message)
        {
        }

        public ConflictException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ConflictException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
