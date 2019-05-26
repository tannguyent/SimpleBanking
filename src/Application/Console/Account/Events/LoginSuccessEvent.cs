using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankingApp.Account.Events
{
    public class LoginSuccessEvent
    {
        public LoginSuccessEvent(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
