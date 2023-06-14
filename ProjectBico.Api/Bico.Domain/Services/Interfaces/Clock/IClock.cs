using System;

namespace Fatec.Domain.Services.Interfaces.Clock
{
    public interface IClock
    {
        DateTimeOffset UtcDateTimeNow();
    }
}
