﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    using Narvalo.Internal;

    /// <summary>
    /// Provides helper methods to check for conditions on parameters.
    /// </summary>
    /// <remarks>
    /// <para>The methods WON'T be recognized by FxCop as parameter validators
    /// against <see langword="null"/> value.</para>
    /// <para>The methods MUST appear after all Code Contracts.</para>
    /// <para>If a condition does not hold, an unrecoverable exception is thrown
    /// in debug builds.</para>
    /// <para>This class MUST NOT be used in place of proper validation routines of public
    /// arguments but is only useful in very specialized use cases. Be wise.
    /// Personally, I can only see one situation where these helpers make sense:
    /// for protected overridden methods in a sealed class when the base method
    /// declares a contract (otherwise you should use <see cref="Promise"/>),
    /// when you know for certain that all callers will satisfy the condition
    /// and most certainly when you own all base classes. As you can see, that
    /// makes a lot of prerequisites...
    /// </para>
    /// </remarks>
    [DebuggerStepThrough]
    public static class Check
    {
        [Conditional("DEBUG")]
        [Conditional("CONTRACTS_FULL")]
        public static void True(bool testCondition) => TrueInner(testCondition);

        [Conditional("DEBUG")]
        [Conditional("CONTRACTS_FULL")]
        public static void False(bool testCondition) => TrueInner(!testCondition);

        [ContractAbbreviator]
        [Conditional("DEBUG")]
        [Conditional("CONTRACTS_FULL")]
        private static void TrueInner(bool testCondition)
        {
            // TODO: Explain Requires vs Assert here.
            Contract.Requires(testCondition);
            Debug.Assert(testCondition);
        }

        public static class DebugOnly
        {
            [Conditional("DEBUG")]
            public static void True(bool testCondition) =>  Debug.Assert(testCondition);

            [Conditional("DEBUG")]
            public static void False(bool testCondition) => True(!testCondition);
        }
    }
}
