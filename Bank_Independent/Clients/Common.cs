using System;

namespace Bank_Independent
{
    class Common : Client
    {

        #region Constructor;

        public Common(string Name,
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
