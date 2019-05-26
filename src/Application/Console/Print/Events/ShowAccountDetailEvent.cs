using SimpleBankingApp.Models;
using System.Collections.Generic;

namespace SimpleBankingApp.Print.Events
{
    public class ShowAccountDetailEvent
    {
        public ShowAccountDetailEvent(BankingAccountModel accountModel)
        {
            AccountModel = accountModel;
        }

        public BankingAccountModel AccountModel { get; }
    }
}
