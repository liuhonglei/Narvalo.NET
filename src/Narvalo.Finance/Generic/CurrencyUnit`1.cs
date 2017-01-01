﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance.Generic
{
    using System.Globalization;

    public class CurrencyUnit<TCurrency> where TCurrency : CurrencyUnit<TCurrency>
    {
        internal CurrencyUnit(short? minorUnits) { MinorUnits = minorUnits; }

        protected static string Name
        {
            get { Warrant.NotNull<string>(); return typeof(TCurrency).Name; }
        }

        public string Code { get { Warrant.NotNull<string>(); return Name; } }

        public short DecimalPlaces => MinorUnits ?? 0;

        public  bool IsMeta => Currency.IsMetaCurrency(Code);

        public short? MinorUnits { get; }

        public Currency ToCurrency() => new Currency(Code, MinorUnits);

        public override string ToString()
        {
            Warrant.NotNull<string>();

            return Code;
        }

        public bool IsNativeTo(CultureInfo cultureInfo)
        {
            Require.NotNull(cultureInfo, nameof(cultureInfo));

            if (cultureInfo.IsNeutralCulture) { return false; }

            var ri = new RegionInfo(cultureInfo.Name);

            return ri.ISOCurrencySymbol == Code;
        }
    }
}
