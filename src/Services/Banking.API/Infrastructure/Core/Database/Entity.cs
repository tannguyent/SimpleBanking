using System;

namespace Banking.API.Infrastructure.Core
{
    public abstract class Entity : IEntity
    {
        public virtual Guid Id { get; set; }
    }
}