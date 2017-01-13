﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using Narvalo.Finance.Properties;
    using Narvalo.Finance.Utilities;

    /// <summary>
    /// Represents a currency such as Euro or US Dollar.
    /// </summary>
    /// <remarks>
    /// <para>Recognized currencies are defined in ISO 4217.</para>
    /// <para>Only decimal currencies are supported.</para>
    /// <para>There's never more than one <see cref="Currency"/> instance for any given currency.
    /// You can not directly construct a currency. You must instead use one of the
    /// static factories, eg <see cref="Currency.Of(string)"/>.</para>
    /// <para>This class does not offer extended information about the currency.</para>
    /// </remarks>
    public partial struct Currency : IEquatable<Currency>
    {
        private const int MAX_DECIMAL_PLACES = 28;

        // Be very careful, if you set this constant to something other than MAX_DECIMAL_PLACES:
        // you MUST adapt the code for DecimalPlaces, Epsilon and Factor. Most implementations
        // that I have came across, use -1; here we use MAX_DECIMAL_PLACES just to simplify (a
        // little bit) the code.
        public const int UnknownMinorUnits = MAX_DECIMAL_PLACES;

        private static Dictionary<string, short?> s_UserCodes = new Dictionary<string, short?>();

        // This list is automatically generated using data obtained from the SNV website.
        private static Dictionary<string, short?> s_Codes;

        // This set is automatically generated using data obtained from the SNV website.
        private static HashSet<string> s_WithdrawnCodes;

        private readonly string _code;

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class for the specified code.
        /// </summary>
        /// <param name="code">A string that contains the three-letter identifier defined in ISO 4217.</param>
        /// <param name="minorUnits">The value of a unit expressed in minor units. If there are no
        /// minor units, use null instead.</param>
        internal Currency(string code, short? minorUnits)
        {
            Sentinel.Demand.CurrencyCode(code);
            Demand.True(!minorUnits.HasValue || minorUnits >= 0);

            _code = code;
            MinorUnits = minorUnits;
        }

        internal static Dictionary<string, short?> UserCodes => s_UserCodes;

        // The list is automatically generated using data obtained from the SNV website.
        private static decimal[] Epsilons => s_Epsilons;

        // The list is automatically generated using data obtained from the SNV website.
        private static uint[] PowersOfTen => s_PowersOfTen;

        /// <summary>
        /// Gets the alphabetic code of the currency.
        /// </summary>
        /// <value>The alphabetic code of the currency.</value>
        public string Code { get { Warrant.NotNull<string>(); return _code; } }

        /// <summary>
        /// Gets the number of minor units.
        /// <para>Returns 28 if this number is unknown (which is the case for all legacy
        /// currencies).</para>
        /// </summary>
        /// <value>The number of minor units; null if none defined.</value>
        public short? MinorUnits { get; }

        /// <summary>
        /// Gets the number of decimal digits after the decimal separator.
        /// </summary>
        /// <remarks>
        /// <para>If the currency has no minor units (null), which only happens for meta-currencies
        /// (but not for all of them), we return 0.</para>
        /// <para>If the currency has no known minor units, which is the case for all legacy
        /// currencies, we use 28 (the maximum scale for a decimal) as a replacement, ie an amount
        /// in this currency is free to take any value in the decimal range.</para>
        /// </remarks>
        // To simplify things, for legacy currencies, we directly set MinorUnits to MAX_DECIMAL_PLACES,
        // but if, in the future, we change that we should also replace the code below by:
        // > public int DecimalPlaces => MinorUnits.HasValue
        // >     ? (MinorUnits.Value == UNKNOWN_MINOR_UNITS ? MAX_DECIMAL_PLACES : MinorUnits.Value)
        // >     : 0;
        public int DecimalPlaces => MinorUnits ?? 0;

        /// <summary>
        /// Gets a value indicating whether the instance specifies a fixed number of decimal places.
        /// </summary>
        /// <remarks>This is only necessary because of legacy currencies.</remarks>
        public bool HasFixedDecimalPlaces => DecimalPlaces != MAX_DECIMAL_PLACES;

        /// <summary>
        /// Gets a value indicating whether the currency is a meta-currency.
        /// </summary>
        /// <remarks>
        /// <para>Meta-currencies include supranational currencies (but notice that EUR
        /// is not part of them...), precious metals, the test currency, the "no"
        /// currency and currencies used in international finance.</para>
        /// <para>Meta-currencies are not attached to a specific country.
        /// Their numeric codes are in the range 900-999 and their codes are in the
        /// range XA(A)-XZ(Z). They fall in the ranges of user-assigned codes
        /// as defined by the ISO 3166 standard, ie they will never clash with
        /// those of a real country.</para>
        /// </remarks>
        /// <value>true if the currency is a meta-currency; otherwise false.</value>
        public bool IsMeta => CurrencyMetadata.IsMetaCurrency(Code);

        /// <summary>
        /// Gets the smallest positive (non zero) unit.
        /// <para>Returns 1m if the currency has no minor currency unit.</para>
        /// </summary>
        // If the currency has no fixed decimal places, DecimalPlaces is equal to MAX_DECIMAL_PLACES
        // and DecimalPlaces % MAX_DECIMAL_PLACES = 1 which correctly gives 1m for Epsilon.
        public decimal Epsilon => Epsilons[DecimalPlaces % MAX_DECIMAL_PLACES];

        /// <remarks>Returns 1 if the currency has no minor currency unit.</remarks>
        // If the currency has no fixed decimal places, DecimalPlaces is equal to MAX_DECIMAL_PLACES
        // and DecimalPlaces % MAX_DECIMAL_PLACES = 1 which correctly gives 1 for Factor.
        private uint Factor => PowersOfTen[DecimalPlaces % MAX_DECIMAL_PLACES];

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "[Intentionally] When (if?) we add currencies not using a decimal system, this value will no longer look like a constant.")]
        public decimal One => 1m;

        /// <summary>
        /// Gets a value indicating whether the currency admits a minor currency unit.
        /// </summary>
        /// <remarks>We consider that legacy currencies do not admit a minor unit.
        /// This is actually false, but we do not have enough informations at our disposal to give
        /// a proper answer. It is not only because ISO 4217 does not give us the data, but also
        /// because a currency could have changed over time (devaluation, decimalisation...)
        /// while keeping the same main unit (which most certainly didn't even exist at the time).</remarks>
        public bool HasMinorCurrency
            => MinorUnits.HasValue
            && MinorUnits.Value != 0
            && MinorUnits.Value != UnknownMinorUnits;

        /// <summary>
        /// Gets the minor currency unit.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the currency has no minor
        /// currency unit.</exception>
        public FractionalCurrency MinorCurrency
        {
            get
            {
                if (!HasMinorCurrency)
                {
                    throw new InvalidOperationException("XXX");
                }

                return new FractionalCurrency(this, Epsilon, MinorCurrencyCode);
            }
        }

        // If the currency admits a minor currency unit, we obtain its code by "lowercasing"
        // the last character of its code: "EUR" -> "EUr". This convention is not officially
        // sanctioned, but seems rather common.
        private string MinorCurrencyCode
        {
            get
            {
                Demand.True(HasMinorCurrency);
                return Code[0] + Code[1] + (Code[3] | 0x20).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Obtains an instance of the <see cref="Currency" /> class for the specified alphabetic code.
        /// </summary>
        /// <param name="code">The three letters ISO-4217 code of the currency.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="code"/> is null.</exception>
        /// <exception cref="CurrencyNotFoundException">Thrown if no currency exists for the
        /// specified code.</exception>
        /// <returns>The currency for the specified code.</returns>
        /// <seealso cref="CurrencyFactory.TryCreate(string)"/>
        public static Currency Of(string code)
        {
            Require.NotNull(code, nameof(code));
            Sentinel.Expect.CurrencyCode(code);

            short? minorUnits;
            if (!Codes.TryGetValue(code, out minorUnits))
            {
                throw new CurrencyNotFoundException(Format.Current(Strings.Currency_UnknownCode, code));
            }

            return new Currency(code, minorUnits);
        }

        /// <seealso cref="CurrencyFactory.TryCreate(string, CurrencyTypes)"/>
        public static Currency Of(string code, CurrencyTypes types)
        {
            Sentinel.Expect.CurrencyCode(code);

            var cy = CurrencyFactory.TryCreate(code, types);
            if (!cy.HasValue)
            {
                throw new CurrencyNotFoundException(Format.Current(Strings.Currency_UnknownCode, code));
            }

            return cy.Value;
        }

        /// <summary>
        /// Obtains an instance of the <see cref="Currency" /> class associated with the specified region.
        /// </summary>
        /// <param name="regionInfo">A region info.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="regionInfo"/> is null.</exception>
        /// <exception cref="CurrencyNotFoundException">Thrown if no currency exists for the
        /// specified region.</exception>
        /// <returns>The currency for the specified region info.</returns>
        public static Currency ForRegion(RegionInfo regionInfo)
        {
            Require.NotNull(regionInfo, nameof(regionInfo));

            //var code = regionInfo.ISOCurrencySymbol;
            //Contract.Assume(code != null);
            //Contract.Assume(code.Length != 0);   // Should not be necessary, but CCCheck insists.
            //Contract.Assume(Ascii.IsUpperLetter(code));
            //Contract.Assume(code.Length == 3);

            return Of(regionInfo.ISOCurrencySymbol);
        }

        public static Currency ForCurrentRegion() => ForRegion(RegionInfo.CurrentRegion);

        /// <summary>
        /// Obtains an instance of the <see cref="Currency" /> class associated
        /// with the specified culture.
        /// </summary>
        /// <param name="cultureInfo">A culture info.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cultureInfo"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="cultureInfo"/> is neutral.</exception>
        /// <exception cref="CurrencyNotFoundException">Thrown if no currency exists for the specified culture.</exception>
        /// <returns>The currency for the specified culture info.</returns>
        public static Currency ForCulture(CultureInfo cultureInfo)
        {
            Require.NotNull(cultureInfo, nameof(cultureInfo));

            if (cultureInfo.IsNeutralCulture)
            {
                throw new ArgumentException(Strings.Argument_NeutralCultureNotSupported, nameof(cultureInfo));
            }

            return ForRegion(new RegionInfo(cultureInfo.Name));
        }

        /// <summary>
        /// Obtains an instance of the <see cref="Currency" /> class for the culture
        /// used by the current thread.
        /// </summary>
        /// <exception cref="CurrencyNotFoundException">Thrown if no currency exists for the current culture.</exception>
        /// <returns>The currency for the culture used by the current thread.</returns>
        public static Currency ForCurrentCulture() => ForCulture(CultureInfo.CurrentCulture);

        /// <summary>
        /// Register a currency not part of ISO 4217.
        /// <para>It can also be useful when the library is not up-to-date with the ISO 4217 list
        /// of active currencies.</para>
        /// <para>This method is NOT thread-safe but ensures that nothing is changed if anything
        /// goes wrong.</para>
        /// </summary>
        /// <remarks>
        /// <para>All currencies registered via this method have the <see cref="CurrencyTypes.UserDefined"/>
        /// type. In particular, they inherit the <see cref="CurrencyTypes.Circulating"/> type; as a
        /// consequence, you can not register a withdrawn currency.</para>
        /// <para>If you have more than one currency to register, you should use
        /// <see cref="RegisterCurrencies(Dictionary{string, short?})"/> instead.</para>
        /// </remarks>
        /// <param name="code">The three letters code.</param>
        /// <param name="minorUnits">The number of minor units; null if the currency does not have
        /// a minor currency unit and <see cref="UnknownMinorUnits"/> if the status is unknown.</param>
        /// <returns>true if the operation succeeded; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if a candidate currency does not meet
        /// the requirements: a <paramref name="code"/> must be of length 3 and made of ASCII
        /// uppercase letters, and <paramref name="minorUnits"/>, if not null, must be greater than
        /// or equal to zero and lower than or equal to 28.</exception>
        public static bool RegisterCurrency(string code, short? minorUnits)
        {
            // FIXME: Thread-safety.
            // - In competing threads, we may add the same code twice (this one is not that bad).
            // - If another code is added after we created tmpCopy and before we write it back,
            //   this code will be lost (this one is really problematic).

            // REVIEW: Should we relax the constraints on the code value for user-defined currencies?
            // JavaMoney does it, but I am not very convinced that there are enough good reasons
            // for the complications it will imply. Nevertheless, if we decided to do this, there
            // will a problem with MinorCurrencyCode and we would have to review all guards wherever
            // we accept a code as input.
            Sentinel.Require.CurrencyCode(code, nameof(code));
            Require.True(
                !minorUnits.HasValue || (minorUnits >= 0 && minorUnits <= MAX_DECIMAL_PLACES),
                nameof(minorUnits));

            if (s_UserCodes.ContainsKey(code)
                || Codes.ContainsKey(code)
                || WithdrawnCodes.Contains(code)) { return false; }

            // We work on a temporary copy of s_UserCodes. This is not very efficient but ensures
            // that s_UserCodes does not end up in a broken state if anything bad happens.
            // Also note that, with competing threads, we may end up creating 'tmpCopy' more
            // than once. Anyway, we do not expect this method to be called very often, if ever.
            var tmpCopy = s_UserCodes.ToDictionary(_ => _.Key, _ => _.Value);
            tmpCopy[code] = minorUnits;

            // We use a volatile write to make sure that instructions don't get re-ordered.
            Volatile.Write(ref s_UserCodes, tmpCopy);

            return true;
        }

        /// <summary>
        /// Register a bunch of currencies, at once.
        /// <para>For explanations on when and how to use this method, please see
        /// <see cref="RegisterCurrency(string, short?)"/>.</para>
        /// <para>This method is NOT thread-safe but ensures that nothing is changed if anything
        /// goes wrong.</para>
        /// </summary>
        /// <param name="currencies">The <see cref="Dictionary{TKey, TValue}"/> that contains
        /// the codes and minor units for the new currencies.</param>
        /// <returns>true if the operation succeeded; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if a candidate currency does not meet
        /// the requirements.</exception>
        public static bool RegisterCurrencies(Dictionary<string, short?> currencies)
        {
            // See RegisterCurrency() for explanations.
            // FIXME: Thread-safety.
            Require.NotNull(currencies, nameof(currencies));

            // Before any actual work, we check if the input looks fine.
            foreach (var pair in currencies)
            {
                string code = pair.Key;
                if (code == null || code.Length != 3 || !Ascii.IsUpperLetter(code))
                {
                    throw new ArgumentException("XXX", nameof(currencies));
                }

                short? minorUnits = pair.Value;
                if (minorUnits.HasValue && (minorUnits < 0 || minorUnits > MAX_DECIMAL_PLACES))
                {
                    throw new ArgumentException("XXX", nameof(currencies));
                }

                if (s_UserCodes.ContainsKey(code)
                    || Codes.ContainsKey(code)
                    || WithdrawnCodes.Contains(code))
                {
                    return false;
                }
            }

            var tmpCopy = s_UserCodes.ToDictionary(_ => _.Key, _ => _.Value);
            foreach (var pair in currencies)
            {
                tmpCopy[pair.Key] = pair.Value;
            }

            Volatile.Write(ref s_UserCodes, tmpCopy);

            return true;
        }

        public bool IsNativeTo(CultureInfo cultureInfo)
        {
            Require.NotNull(cultureInfo, nameof(cultureInfo));

            if (cultureInfo.IsNeutralCulture) { return false; }

            var ri = new RegionInfo(cultureInfo.Name);

            return ri.ISOCurrencySymbol == Code;
        }

        /// <summary>
        /// Converts an amount from minor units to major units.
        /// </summary>
        /// <param name="minor">The amount in minor units to convert.</param>
        internal decimal ConvertToMajor(decimal minor) => Epsilon * minor;

        /// <summary>
        /// Converts an amount from major units to minor units.
        /// </summary>
        /// <param name="major">The amount in major units to convert.</param>
        internal decimal ConvertToMinor(decimal major) => Factor * major;

        /// <summary>
        /// Returns a string containing the code of the currency.
        /// </summary>
        /// <returns>A string containing the code of the currency.</returns>
        public override string ToString()
        {
            Warrant.NotNull<string>();

            return Code;
        }
    }

    // Interface IEquatable<Currency>.
    public partial struct Currency
    {
        public static bool operator ==(Currency left, Currency right) => left.Equals(right);

        public static bool operator !=(Currency left, Currency right) => !left.Equals(right);

        /// <inheritdoc cref="IEquatable{T}.Equals" />
        public bool Equals(Currency other) => Code == other.Code;

        /// <inheritdoc cref="Object.Equals(Object)" />
        public override bool Equals(object obj)
        {
            if (!(obj is Currency)) { return false; }

            return Equals((Currency)obj);
        }

        /// <inheritdoc cref="Object.GetHashCode" />
        // TODO: Since there are so few currencies, we could cache the hash code?
        public override int GetHashCode() => Code.GetHashCode();
    }

    // Aliases for some of the most commonly used currencies.
    public partial struct Currency
    {
        /// <summary>
        /// Gets the currency unit for the pseudo-currency for transactions where no currency is involved.
        /// </summary>
        public static Currency None => Of("XXX");

        /// <summary>
        /// Gets the currency unit for the currency specifically reserved for testing purposes.
        /// </summary>
        public static Currency Test => Of("XTS");

        /// <summary>
        /// Gets the currency unit for the "Euro".
        /// </summary>
        public static Currency Euro => Of("EUR");

        /// <summary>
        /// Gets the currency unit for the "(British) "Pound Sterling".
        /// </summary>
        public static Currency PoundSterling => Of("GBP");

        /// <summary>
        /// Gets the currency unit for the "Swiss Franc".
        /// </summary>
        public static Currency SwissFranc => Of("CHF");

        /// <summary>
        /// Gets the currency unit for the "United States Dollar".
        /// </summary>
        public static Currency UnitedStatesDollar => Of("USD");

        /// <summary>
        /// Gets the currency unit for the "Japanese Yen".
        /// </summary>
        public static Currency Yen => Of("JPY");

        /// <summary>
        /// Gets the currency unit for the pseudo-currency for gold.
        /// </summary>
        /// <remarks>The code for a precious metal is formed after its chemical symbol: AU.</remarks>
        public static Currency Gold => Of("XAU");

        /// <summary>
        /// Gets the currency unit class for the pseudo-currency for palladium.
        /// </summary>
        /// <remarks>The code for a precious metal is formed after its chemical symbol: PD.</remarks>
        public static Currency Palladium => Of("XPD");

        /// <summary>
        /// Gets the currency unit for the pseudo-currency for platinum.
        /// </summary>
        /// <remarks>The code for a precious metal is formed after its chemical symbol: PT.</remarks>
        public static Currency Platinum => Of("XPT");

        /// <summary>
        /// Gets the currency unit for the pseudo-currency for silver.
        /// </summary>
        /// <remarks>The code for a precious metal is formed after its chemical symbol: AG.</remarks>
        public static Currency Silver => Of("XAG");
    }
}

#if CONTRACTS_FULL

namespace Narvalo.Finance
{
    using System.Diagnostics.Contracts;

    public partial struct Currency
    {
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(_code != null);
            Contract.Invariant(_code.Length == 3);
        }
    }
}

#endif
