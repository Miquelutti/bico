using Fatec.Domain.Services.Interfaces.Clock;
using System;

namespace Fatec.Domain.Services.Clock
{
    public class Clock : IClock
    {
        public DateTimeOffset UtcDateTimeNow()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}
