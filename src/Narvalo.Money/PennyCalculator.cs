﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.Internal;

    // Standard binary math operators.
    public static partial class PennyCalculator
    {
        public static Moneypenny Add(Moneypenny left, Moneypenny right) => left.Plus(right);

        public static Moneypenny Add(Moneypenny penny, long amount) => penny.Plus(amount);

        public static Moneypenny Subtract(Moneypenny left, Moneypenny right) => left.Minus(right);

        public static Moneypenny Subtract(Moneypenny penny, long amount) => penny.Minus(amount);

        public static Moneypenny Multiply(Moneypenny penny, long multiplier) => penny.MultiplyBy(multiplier);

        public static Moneypenny Divide(Moneypenny dividend, long divisor) => dividend.DivideBy(divisor);

        public static Moneypenny Remainder(Moneypenny dividend, long divisor) => dividend.Mod(divisor);
    }

    // Standard binary math operators under which the Moneypenny type is not closed.
    // NB: Decimal multiplication is always checked.
    public static partial class PennyCalculator
    {
        public static Money Multiply(Moneypenny penny, decimal multiplier)
            => new Money(multiplier * penny.Amount, penny.Currency);

        // This division returns a decimal (we lost the currency unit).
        // It is a lot like computing a percentage (if multiplied by 100, of course).
        public static decimal Divide(Moneypenny dividend, Moneypenny divisor)
            => dividend.Amount / (decimal)divisor.Amount;

        public static Money Divide(Moneypenny dividend, decimal divisor)
            => new Money(dividend.Amount / divisor, dividend.Currency);

        public static Money Remainder(Moneypenny dividend, decimal divisor)
            => new Money(dividend.Amount % divisor, dividend.Currency);
    }

    // Other math operators.
    public static partial class PennyCalculator
    {
        public static Moneypenny Abs(Moneypenny penny) => penny.IsPositiveOrZero ? penny : penny.Negate();

        public static Moneypenny Max(Moneypenny penny1, Moneypenny penny2) => penny1 >= penny2 ? penny1 : penny2;

        public static Moneypenny Min(Moneypenny penny1, Moneypenny penny2) => penny1 <= penny2 ? penny1 : penny2;

        public static Moneypenny Clamp(Moneypenny penny, Moneypenny min, Moneypenny max)
        {
            Require.True(min <= max, nameof(min));

            return penny < min ? min : (penny > max ? max : penny);
        }

        // Divide+Remainder aka DivRem.
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Div", Justification = "[Intentionally] Math.DivRem().")]
        public static Moneypenny DivRem(Moneypenny dividend, long divisor, out Moneypenny remainder)
        {
            long q = Number.DivRem(dividend.Amount, divisor, out long rem);
            remainder = new Moneypenny(rem, dividend.Currency);
            return new Moneypenny(q, dividend.Currency);
        }
    }

    // LINQ-like Sum().
    public static partial class PennyCalculator
    {
        public static Moneypenny Sum(this IEnumerable<Moneypenny> pennies)
        {
            Require.NotNull(pennies, nameof(pennies));

            using (var iter = pennies.GetEnumerator())
            {
                if (!iter.MoveNext()) { goto EMPTY_COLLECTION; }

                var pny = iter.Current;
                var currency = pny.Currency;
                long sum = pny.Amount;

                while (iter.MoveNext())
                {
                    pny = iter.Current;

                    MoneyHelpers.ThrowIfCurrencyMismatch(pny, currency);

                    checked { sum += pny.Amount; }
                }

                return new Moneypenny(sum, currency);
            }

            EMPTY_COLLECTION:
            return Moneypenny.Zero(Currency.None);
        }

        public static Moneypenny Sum(this IEnumerable<Moneypenny?> pennies)
        {
            Require.NotNull(pennies, nameof(pennies));

            using (var iter = pennies.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    Moneypenny? item = iter.Current;
                    if (!item.HasValue) { continue; }

                    var pny = item.Value;
                    var currency = pny.Currency;
                    long sum = pny.Amount;

                    while (iter.MoveNext())
                    {
                        item = iter.Current;

                        if (item.HasValue)
                        {
                            pny = item.Value;

                            MoneyHelpers.ThrowIfCurrencyMismatch(pny, currency);

                            checked { sum += pny.Amount; }
                        }
                    }

                    return new Moneypenny(sum, currency);
                }
            }

            return Moneypenny.Zero(Currency.None);
        }
    }
}
