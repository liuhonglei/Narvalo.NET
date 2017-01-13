﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance.Utilities
{
    // Used to share methods between Currency and CurrencyUnit<TCurrency>.
    internal static class CurrencyHelpers
    {
        private const char META_CURRENCY_MARK = 'X';

        // TODO: What about EUR, CFP (legacy) for this, is it enough to check the country code too
        // (ie the first two letters)?
        public static bool IsMetaCurrency(string code)
        {
            Demand.NotNullOrEmpty(code);

            return code[0] == META_CURRENCY_MARK;
        }

        public static bool IsPseudoCurrency(string code, short? minorUnits)
        {
            Demand.NotNullOrEmpty(code);

            return IsMetaCurrency(code) && !minorUnits.HasValue;
        }
    }
}
