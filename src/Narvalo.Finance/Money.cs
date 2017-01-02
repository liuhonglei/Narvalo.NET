﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using Narvalo.Finance.Globalization;
    using Narvalo.Finance.Properties;

    // Per default, the CLR will use LayoutKind.Sequential for structs. Here, we do not care
    // about interop with unmanaged code, so why not let the CLR decide what's best for it?
    //[StructLayout(LayoutKind.Auto)]
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial struct Money : IEquatable<Money>, IComparable<Money>, IComparable, IFormattable
    {
        public const MidpointRounding DefaultRounding = MidpointRounding.ToEven;

        [CLSCompliant(false)]
        public Money(uint amount) : this(amount, Currency.None, true) { }

        [CLSCompliant(false)]
        public Money(ulong amount) : this(amount, Currency.None, true) { }

        public Money(int amount) : this(amount, Currency.None, true) { }

        public Money(long amount) : this(amount, Currency.None, true) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class without any currency attached
        /// and an amount for which no rounding is done.
        /// </summary>
        /// <param name="amount">A decimal representing the amount of money.</param>
        public Money(decimal amount) : this(amount, Currency.None, false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class for a specific currency
        /// and an amount for which no rounding is done.
        /// </summary>
        /// <param name="amount">A decimal representing the amount of money.</param>
        /// <param name="currency">The specific currency.</param>
        public Money(decimal amount, Currency currency) : this(amount, currency, false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class for a specific currency
        /// and an amount for which the number of decimal places is determined by the currency.
        /// </summary>
        /// <param name="amount">A decimal representing the amount of money.</param>
        /// <param name="currency">The specific currency.</param>
        /// <param name="rounding">The rounding mode.</param>
        public Money(decimal amount, Currency currency, MidpointRounding rounding)
        {
            Amount = currency.DecimalPlaces == 0
                ? Math.Truncate(amount)
                : Math.Round(amount, currency.DecimalPlaces, rounding);
            Currency = currency;
            Rounded = true;
        }

        private Money(decimal amount, Currency currency, bool rounded)
        {
            Amount = amount;
            Currency = currency;
            Rounded = rounded;
        }

        public decimal Amount { get; }

        public Currency Currency { get; }

        public bool Rounded { get; }

        public static Money Zero(Currency currency) => new Money(0L, currency);

        public Money Round() => Round(MidpointRounding.ToEven);

        public Money Round(MidpointRounding rounding)
        {
            if (Rounded) { return this; }

            return new Money(Amount, Currency, rounding);
        }

        [ExcludeFromCodeCoverage(Justification = "Debugger-only code.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[Intentionally] Debugger-only code.")]
        private string DebuggerDisplay => Format.Current("{0:F2} ({1})", Amount, Currency.Code);

        // Check that the currencies match.
        private void ThrowIfCurrencyMismatch(Money other, string parameterName)
            => Enforce.True(Currency != other.Currency, parameterName, Strings.Argument_CurrencyMismatch);
    }

    // Implements the IFormattable interface.
    public partial struct Money
    {
        /// <inheritdoc cref="Object.ToString" />
        public override string ToString()
        {
            Warrant.NotNull<string>();
            return MoneyFormatter.Format(this, null, NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format)
        {
            Warrant.NotNull<string>();
            return MoneyFormatter.Format(this, format, NumberFormatInfo.CurrentInfo);
        }

        public string ToString(IFormatProvider formatProvider)
        {
            Warrant.NotNull<string>();
            return MoneyFormatter.Format(this, null, NumberFormatInfo.GetInstance(formatProvider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            Warrant.NotNull<string>();

            if (formatProvider != null)
            {
                var fmt = formatProvider.GetFormat(GetType()) as ICustomFormatter;
                if (fmt != null)
                {
                    return fmt.Format(format, this, formatProvider);
                }
            }

            return MoneyFormatter.Format(this, format, NumberFormatInfo.GetInstance(formatProvider));
        }
    }

    // Implements the IEquatable<Money> interface.
    public partial struct Money
    {
        public static bool operator ==(Money left, Money right) => left.Equals(right);

        public static bool operator !=(Money left, Money right) => !left.Equals(right);

        public bool Equals(Money other)
            => Amount == other.Amount && Currency == other.Currency && Rounded == other.Rounded;

        public override bool Equals(object obj)
        {
            if (!(obj is Money)) { return false; }

            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = 31 * hash + Amount.GetHashCode();
                hash = 31 * hash + Currency.GetHashCode();
                hash = 31 * hash + Rounded.GetHashCode();
                return hash;
            }
        }
    }

    // Implements the IComparable and IComparable<Money> interfaces.
    public partial struct Money
    {
        public static bool operator <(Money left, Money right) => left.CompareTo(right) < 0;

        public static bool operator <=(Money left, Money right) => left.CompareTo(right) <= 0;

        public static bool operator >(Money left, Money right) => left.CompareTo(right) > 0;

        public static bool operator >=(Money left, Money right) => left.CompareTo(right) >= 0;

        public int CompareTo(Money other)
        {
            ThrowIfCurrencyMismatch(other, nameof(other));

            return Amount.CompareTo(other.Amount);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj == null) { return 1; }

            if (!(obj is Money))
            {
                throw new ArgumentException(Strings.Argument_InvalidMoneyType, nameof(obj));
            }

            return CompareTo((Money)obj);
        }
    }

    // Conversions.
    public partial struct Money
    {
        [CLSCompliant(false)]
        public static sbyte ToSByte(Money value) => Decimal.ToSByte(value.Amount);

        [CLSCompliant(false)]
        public static ushort ToUInt16(Money value) => Decimal.ToUInt16(value.Amount);

        [CLSCompliant(false)]
        public static uint ToUInt32(Money value) => Decimal.ToUInt32(value.Amount);

        [CLSCompliant(false)]
        public static ulong ToUInt64(Money value) => Decimal.ToUInt64(value.Amount);

        public static byte ToByte(Money value) => Decimal.ToByte(value.Amount);

        public static short ToInt16(Money value) => Decimal.ToInt16(value.Amount);

        public static int ToInt32(Money value) => Decimal.ToInt32(value.Amount);

        public static long ToInt64(Money value) => Decimal.ToInt64(value.Amount);

        public static decimal ToDecimal(Money value) => value.Amount;

        #region Integral type or decimal -> Money.

        [CLSCompliant(false)]
        public static implicit operator Money(sbyte value) => new Money(value);

        [CLSCompliant(false)]
        public static implicit operator Money(ushort value) => new Money(value);

        [CLSCompliant(false)]
        public static implicit operator Money(uint value) => new Money(value);

        [CLSCompliant(false)]
        public static implicit operator Money(ulong value) => new Money(value);

        public static implicit operator Money(byte value) => new Money(value);

        public static implicit operator Money(short value) => new Money(value);

        public static implicit operator Money(int value) => new Money(value);

        public static implicit operator Money(long value) => new Money(value);

        public static implicit operator Money(decimal value) => new Money(value);

        #endregion

        #region Money -> integral type or decimal.

        [CLSCompliant(false)]
        public static explicit operator sbyte(Money value) => ToSByte(value);

        [CLSCompliant(false)]
        public static explicit operator ushort(Money value) => ToUInt16(value);

        [CLSCompliant(false)]
        public static explicit operator uint(Money value) => ToUInt32(value);

        [CLSCompliant(false)]
        public static explicit operator ulong(Money value) => ToUInt64(value);

        public static explicit operator byte(Money value) => ToByte(value);

        public static explicit operator short(Money value) => ToInt16(value);

        public static explicit operator int(Money value) => ToInt32(value);

        public static explicit operator long(Money value) => ToInt64(value);

        // NB: This one is implicit (no loss of precision).
        public static implicit operator decimal(Money value) => ToDecimal(value);

        #endregion
    }

    // Overrides the op_Addition operator.
    public partial struct Money
    {
        [CLSCompliant(false)]
        public static Money operator +(Money left, uint right) => left.Add(right);
        [CLSCompliant(false)]
        public static Money operator +(uint left, Money right) => right.Add(left);
        [CLSCompliant(false)]
        public static Money operator +(Money left, ulong right) => left.Add(right);
        [CLSCompliant(false)]
        public static Money operator +(ulong left, Money right) => right.Add(left);
        public static Money operator +(Money left, int right) => left.Add(right);
        public static Money operator +(int left, Money right) => right.Add(left);
        public static Money operator +(Money left, long right) => left.Add(right);
        public static Money operator +(long left, Money right) => right.Add(left);
        public static Money operator +(Money left, decimal right) => left.Add(right);
        public static Money operator +(decimal left, Money right) => right.Add(left);
        public static Money operator +(Money left, Money right) => left.Add(right);

        [CLSCompliant(false)]
        public Money Add(uint amount)
        {
            if (amount == 0) { return this; }
            return new Money(Amount + amount, Currency, Rounded);
        }

        [CLSCompliant(false)]
        public Money Add(ulong amount)
        {
            if (amount == 0UL) { return this; }
            return new Money(Amount + amount, Currency, Rounded);
        }

        public Money Add(int amount)
        {
            if (amount == 0) { return this; }
            return new Money(Amount + amount, Currency, Rounded);
        }

        public Money Add(long amount)
        {
            if (amount == 0L) { return this; }
            return new Money(Amount + amount, Currency, Rounded);
        }

        public Money Add(decimal amount)
        {
            if (amount == 0M) { return this; }
            return new Money(Amount + amount, Currency, false);
        }

        public Money Add(Money other)
        {
            ThrowIfCurrencyMismatch(other, nameof(other));

            if (Amount == 0M) { return other; }
            if (other.Amount == 0M) { return this; }
            return new Money(Amount + other.Amount, Currency, Rounded && other.Rounded);
        }

        public Money Plus(decimal amount) => Plus(amount, MidpointRounding.ToEven);

        public Money Plus(decimal amount, MidpointRounding rounding)
        {
            if (amount == 0M) { return this; }
            return new Money(Amount + amount, Currency, rounding);
        }

        public Money Plus(Money other) => Plus(other, MidpointRounding.ToEven);

        public Money Plus(Money other, MidpointRounding rounding)
        {
            ThrowIfCurrencyMismatch(other, nameof(other));

            return Rounded && other.Rounded
                ? new Money(Amount + other.Amount, Currency, true)
                : new Money(Amount + other.Amount, Currency, rounding);
        }
    }

    // Overrides the op_Subtraction operator.
    public partial struct Money
    {
        [CLSCompliant(false)]
        public static Money operator -(Money left, uint right) => left.Subtract(right);
        [CLSCompliant(false)]
        public static Money operator -(uint left, Money right) => right.SubtractLeft(left);
        [CLSCompliant(false)]
        public static Money operator -(Money left, ulong right) => left.Subtract(right);
        [CLSCompliant(false)]
        public static Money operator -(ulong left, Money right) => right.SubtractLeft(left);
        public static Money operator -(Money left, long right) => left.Subtract(right);
        public static Money operator -(long left, Money right) => right.SubtractLeft(left);
        public static Money operator -(Money left, int right) => left.Subtract(right);
        public static Money operator -(int left, Money right) => right.SubtractLeft(left);
        public static Money operator -(Money left, decimal right) => left.Subtract(right);
        public static Money operator -(decimal left, Money right) => right.SubtractLeft(left);
        public static Money operator -(Money left, Money right) => left.Subtract(right);

        [CLSCompliant(false)]
        public Money Subtract(uint amount)
        {
            if (amount == 0) { return this; }
            return new Money(Amount - amount, Currency, Rounded);
        }

        [CLSCompliant(false)]
        public Money Subtract(ulong amount)
        {
            if (amount == 0UL) { return this; }
            return new Money(Amount - amount, Currency, Rounded);
        }

        public Money Subtract(int amount) => Add(-amount);

        public Money Subtract(long amount) => Add(-amount);

        public Money Subtract(decimal amount) => Add(-amount);

        public Money Subtract(Money other)
        {
            ThrowIfCurrencyMismatch(other, nameof(other));

            if (Amount == 0M) { return other.Negate(); }
            if (other.Amount == 0M) { return this; }
            return new Money(other.Amount - Amount, Currency, Rounded && other.Rounded);
        }

        public Money Minus(decimal amount) => Plus(-amount, MidpointRounding.ToEven);

        public Money Minus(decimal amount, MidpointRounding rounding) => Plus(-amount, rounding);

        public Money Minus(Money other) => Minus(other, MidpointRounding.ToEven);

        public Money Minus(Money other, MidpointRounding rounding)
        {
            ThrowIfCurrencyMismatch(other, nameof(other));

            return Rounded && other.Rounded
                ? new Money(Amount - other.Amount, Currency, true)
                : new Money(Amount - other.Amount, Currency, rounding);
        }

        private Money SubtractLeft(uint amount) => new Money(amount - Amount, Currency, Rounded);

        private Money SubtractLeft(ulong amount) => new Money(amount - Amount, Currency, Rounded);

        private Money SubtractLeft(int amount) => new Money(amount - Amount, Currency, Rounded);

        private Money SubtractLeft(long amount) => new Money(amount - Amount, Currency, Rounded);

        private Money SubtractLeft(decimal amount)
        {
            if (amount == 0M) { return Negate(); }
            return new Money(amount - Amount, Currency, false);
        }
    }

    // Overrides the op_Multiply operator.
    public partial struct Money
    {
        [CLSCompliant(false)]
        public static Money operator *(ulong multiplier, Money money) => money.Multiply(multiplier);
        [CLSCompliant(false)]
        public static Money operator *(Money money, ulong multiplier) => money.Multiply(multiplier);
        public static Money operator *(long multiplier, Money money) => money.Multiply(multiplier);
        public static Money operator *(Money money, long multiplier) => money.Multiply(multiplier);
        public static Money operator *(int multiplier, Money money) => money.Multiply(multiplier);
        public static Money operator *(Money money, int multiplier) => money.Multiply(multiplier);
        public static Money operator *(decimal multiplier, Money money) => money.Multiply(multiplier);
        public static Money operator *(Money money, decimal multiplier) => money.Multiply(multiplier);

        [CLSCompliant(false)]
        public Money Multiply(uint multiplier) => new Money(multiplier * Amount, Currency, Rounded);

        [CLSCompliant(false)]
        public Money Multiply(ulong multiplier) => new Money(multiplier * Amount, Currency, Rounded);

        public Money Multiply(int multiplier) => new Money(multiplier * Amount, Currency, Rounded);

        public Money Multiply(long multiplier) => new Money(multiplier * Amount, Currency, Rounded);

        public Money Multiply(decimal multiplier) => new Money(multiplier * Amount, Currency, false);
    }

    // Overrides the op_Division operator.
    public partial struct Money
    {
        public static Money operator /(Money money, decimal divisor)
        {
            Expect.True(divisor != 0m);

            return money.Divide(divisor);
        }

        public Money Divide(decimal divisor)
        {
            if (divisor == 0m)
            {
                throw new DivideByZeroException();
            }

            return new Money(Amount / divisor, Currency, false);
        }
    }

    // Overrides the op_Modulus operator.
    public partial struct Money
    {
        public static Money operator %(Money money, decimal divisor)
        {
            Expect.True(divisor != 0m);

            return money.Remainder(divisor);
        }

        public Money Remainder(decimal divisor)
        {
            if (divisor == 0m)
            {
                throw new DivideByZeroException();
            }

            return new Money(Amount % divisor, Currency, false);
        }
    }

    // Overrides the op_UnaryNegation operator.
    public partial struct Money
    {
        public static Money operator -(Money money) => money.Negate();

        public Money Negate() => new Money(-Amount, Currency, Rounded);
    }
}
