using System;

namespace Banking.API.Infrastructure.Service.Models
{
    public abstract class BaseModel
    {
        public virtual Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
