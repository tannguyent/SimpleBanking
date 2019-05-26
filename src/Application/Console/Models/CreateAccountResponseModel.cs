using System;

namespace SimpleBankingApp.Models
{
    public class CreateAccountResponseModel
    {
        public CreateAccountResponseModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
