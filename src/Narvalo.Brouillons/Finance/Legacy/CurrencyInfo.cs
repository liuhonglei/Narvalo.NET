// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance.Legacy
{
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using Narvalo.Internal;

    /// <summary>
    /// Provides information about a localized currency.
    /// </summary>
    /// <remarks>
    /// <para>You can define your own set of currencies by creating a <see cref="ICurrencyInfoProvider"/>.</para>
    /// <para>Different currencies may have the same <see cref="CurrencyInfo.Code"/>
    /// and <see cref="CurrencyInfo.NumericCode"/> but be associated to different 
    /// regions/countries. There is no 1-1 correspondance between currencies
    /// and currency infos.</para>
    /// </remarks>
    public sealed class CurrencyInfo
    {
        private readonly string _code;
        private readonly short _numericCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyInfo" /> class 
        /// for the specified alphabetic and numeric codes.
        /// </summary>
        /// <param name="code">A string that contains a three-letter code defined in ISO 4217.</param>
        /// <param name="numericCode">A numeric identifier defined in ISO 4217.</param>
        public CurrencyInfo(string code, short numericCode)
        {
            //Require.NotNullOrWhiteSpace(code, "code");
            //ContractFor.CurrencyCode(code);
            Contract.Requires(
                numericCode >= 0 && numericCode < 1000,
                "The numeric code MUST be strictly greater than 0 and less than 1000.");

            _code = code;
            _numericCode = numericCode;
        }

        /// <summary>
        /// Gets the alphabetic code of the currency.
        /// </summary>
        /// <remarks>
        /// A currency is uniquely identified by a three letter code, based on ISO 4217.
        /// Valid currency codes are three upper-case ASCII letters.
        /// If the currency is not a meta-currency, the first two letters usually match 
        /// an alpha-2 country code as found in the ISO 3166 (Ecuador, Haiti, El Savador...
        /// are counter-examples).
        /// The third letter is usually the initial of the currency name.
        /// For instance: USD = US (United States) + D (Dollar).
        /// </remarks>
        /// <value>The alphabetic code of the currency.</value>
        public string Code
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                return _code;
            }
        }

        /// <summary>
        /// Gets the currency unit of the currency.
        /// </summary>
        /// <value>The currency unit of the currency.</value>
        public Currency Currency
        {
            get
            {
                Contract.Ensures(Contract.Result<Currency>() != null);

                return Currency.Of(Code);
            }
        }

        /// <summary>
        /// Gets or sets the full name of the currency in English.
        /// </summary>
        /// <remarks>
        /// This name is not guaranteed to match the value of RegionInfo.CurrencyEnglishName.
        /// </remarks>
        /// <value>The full name of the currency in English.</value>
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the full name of the country/region in English.
        /// </summary>
        /// <remarks>
        /// <para>This name is not guaranteed to match the value of 
        /// <see cref="RegionInfo.EnglishName"/>.</para>
        /// <para>Most meta-currencies do not belong to a region but they still
        /// get a pseudo region name. Besides that, most of these currencies use
        /// a region name that starts with "ZZ" to make it clear.</para>
        /// </remarks>
        /// <value>The full name of the country/region in English.</value>
        public string EnglishRegionName { get; set; }

        /// <summary>
        /// Gets a value indicating whether the currency has a numeric code.
        /// </summary>
        /// <value><see langword="true"/> if the currency has a numeric code; otherwise <see langword="false"/>.</value>
        public bool HasNumericCode { get { return NumericCode == 0; } }

        /// <summary>
        /// Gets or sets a value indicating whether the currency represents a fund.
        /// </summary>
        /// <value><see langword="true"/> if the currency represents a fund; otherwise <see langword="false"/>.
        /// The default is <see langword="false"/>.</value>
        public bool IsFund { get; set; }

        /// <summary>
        /// Gets or sets the number of minor units.
        /// </summary>
        /// <value>The number of minor units; <see langword="null"/> if none defined.
        /// The default is <see langword="null"/>.</value>
        public short? MinorUnits { get; set; }

        /// <summary>
        /// Gets the numeric code of the currency.
        /// </summary>
        /// <remarks>
        /// <para>The numeric code is an alternative to the alphabetic code.</para>
        /// <para>It usually matches the numeric code of the country as defined by the ISO 3166,
        /// but this is not always true. Obviously, supranational currencies, like the EUR, are 
        /// currencies where we can not infer the country from this code.
        /// I think, but I have not verified, that for codes strictly lower than 900 we do actually
        /// get an ISO 3166 country code. Funny enough, Afghanistan or Angola are among those
        /// actual countries for which the currency has a numeric code that has nothing to do 
        /// with their country code.
        /// For instance: 840 = United States.</para>
        /// </remarks>
        /// <seealso cref="HasNumericCode"/>
        /// <value>The numeric code of the currency; zero if the currency has no numeric code.</value>
        public short NumericCode { get { return _numericCode; } }

        /// <summary>
        /// Gets or sets a value indicating whether the currency is no longer in use.
        /// </summary>
        /// <value><see langword="true"/> if the currency is no longer in use; otherwise <see langword="false"/>.
        /// The default is <see langword="false"/>.</value>
        public bool Superseded { get; set; }

        /// <summary>
        /// Obtains the list of currently active currencies.
        /// </summary>
        /// <example>
        /// Obtains the list of currency/country using the euro:
        /// <code>
        /// CurrencyInfo.GetCurrencies().Where(_ => _.Code == "EUR");
        /// </code>
        /// </example>
        public static CurrencyInfoCollection GetCurrencies()
        {
            return GetCurrencies(CurrencyTypes.CurrentCurrencies);
        }

        /// <summary>
        /// Obtains the list of supported currencies filtered by the specified
        /// <see cref="CurrencyTypes"/> parameter.
        /// </summary>
        /// <param name="types">A bitwise combination of the enumeration values 
        /// that filter the currencies to retrieve.</param>
        /// <returns>An enumeration that contains the currencies specified by 
        /// the <paramref name="types"/> parameter.</returns>
        public static CurrencyInfoCollection GetCurrencies(CurrencyTypes types)
        {
            return CurrencyInfoProvider.Current.GetCurrencies(types);
        }

        public override string ToString()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return Format.CurrentCulture("{0} ({1})", EnglishName, EnglishRegionName);
        }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(_code != null);
            Contract.Invariant(_code.Length == 3);
            Contract.Invariant(_numericCode >= 0 && _numericCode < 1000);
        }

#endif
    }
}