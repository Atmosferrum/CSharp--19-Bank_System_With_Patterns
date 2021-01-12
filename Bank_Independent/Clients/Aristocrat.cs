using System;

namespace Bank_Independent
{
    class Aristocrat : Client
    {

        #region Constructor;

        public Aristocrat(string Name,
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
