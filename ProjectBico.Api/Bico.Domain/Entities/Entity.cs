using System;

namespace Fatec.Domain.Entities
{
    public abstract class Entity : IAuditable
    {
        protected Entity() { }

        public virtual long Id { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
