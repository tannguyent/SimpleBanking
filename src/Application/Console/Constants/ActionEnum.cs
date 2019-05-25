using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankingApp.Constants
{
    public enum ActionEnum
    {
        CreateAccount = 1,
        Login = 2,
        CreateDeposit = 3,
        CreateWithDraw = 4, 
        CheckBalance = 5,
        ListTransactions = 6,
        Logout = 7,
        Close = 8,
    }
}
