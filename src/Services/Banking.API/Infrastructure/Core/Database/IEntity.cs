using System;

namespace Banking.API.Infrastructure.Core
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}