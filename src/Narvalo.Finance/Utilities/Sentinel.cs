﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance.Utilities
{
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    using Narvalo.Finance.Properties;

    using static Narvalo.Finance.Utilities.AsciiHelpers;

    internal static partial class Sentinel
    {
        public static partial class Require
        {
            [ContractArgumentValidator]
            public static void CurrencyCode(string code, string parameterName)
            {
                Narvalo.Require.NotNull(code, parameterName);

                // A currency code MUST only contain uppercase ASCII letters.
                Narvalo.Require.True(IsUpperLetter(code), parameterName);

                // A currency code MUST be composed of exactly 3 letters.
                Narvalo.Require.Range(code.Length == 3, parameterName,
                    Strings.Sentinel_OutOfRangeCurrencyAlphabeticCode);
            }
        }

        public static partial class Demand
        {
            [DebuggerHidden]
            [ContractAbbreviator]
            [Conditional("CONTRACTS_FULL")]
            [ExcludeFromCodeCoverage(
                Justification = "OpenCover can't discover the tests because of the CONTRACTS_FULL conditional.")]
            public static void CurrencyCode(string code)
            {
                Narvalo.Demand.NotNull(code);

                // A currency code MUST only contain uppercase ASCII letters.
                Narvalo.Demand.True(IsUpperLetter(code));

                // A currency code MUST be composed of exactly 3 letters.
                Narvalo.Demand.Range(code.Length == 3);
            }
        }

        public static partial class Expect
        {
            [DebuggerHidden]
            [ContractAbbreviator]
            [Conditional("CONTRACTS_FULL")]
            [ExcludeFromCodeCoverage(
                Justification = "OpenCover can't discover the tests because of the CONTRACTS_FULL conditional.")]
            public static void CurrencyCode(string code)
            {
                Narvalo.Expect.NotNull(code);

                // A currency code MUST only contain uppercase ASCII letters.
                Narvalo.Expect.True(IsUpperLetter(code));

                // A currency code MUST be composed of exactly 3 letters.
                Narvalo.Expect.Range(code.Length == 3);
            }
        }
    }
}