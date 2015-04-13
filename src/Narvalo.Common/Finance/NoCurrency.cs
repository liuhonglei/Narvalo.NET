﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents the pseudo-currency for transactions where no currency is involved.
    /// </summary>
    public static class NoCurrency
    {
        internal const string Code = "XXX";

        private static readonly Currency s_Currency = new Currency(Code);

        /// <summary>
        /// Gets the pseudo-currency for transactions where no currency is involved.
        /// </summary>
        /// <value>The pseudo-currency for transactions where no currency is involved.</value>
        public static Currency Currency
        {
            get
            {
                Contract.Ensures(Contract.Result<Currency>() != null);

                return s_Currency;
            }
        }
    }
}