using System;

namespace Fatec.Domain.Entities
{
    public interface IAuditable
    {
        DateTimeOffset? CreatedOn { get; set; }
        DateTimeOffset? UpdatedOn { get; set; }
    }
}
