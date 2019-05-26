using System;

namespace SimpleBankingApp.Models
{
    public class CreateAccountRequestModel
    {
        public CreateAccountRequestModel(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
