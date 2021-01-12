using System;

namespace Bank_Independent
{
    class Royal : Client
    {

        #region Constructor;

        public Royal(string Name,
                     string LastName,
                     int Deposit,
                     float Percent,
                     DateTime DateOfDeposit)
            : base(Name,
                   LastName,
                   Deposit,
                   Percent,
                   DateOfDeposit)
        { }

        #endregion Constructor
    }
}
