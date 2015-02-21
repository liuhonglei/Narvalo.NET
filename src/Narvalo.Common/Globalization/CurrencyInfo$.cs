﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Globalization
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    public static class CurrencyInfoExtensions
    {
        static Lazy<List<RegionInfo>> Regions_ = new Lazy<List<RegionInfo>>(GetRegions_);

        /// <summary>
        /// Obtains the region info of the currency.
        /// </summary>
        /// <remarks>
        /// <para>
        /// .NET does not cover the full range of countries used by ISO 4217. 
        /// </para>
        /// <para>
        /// The <see cref="Currency.Code"/> property is not guaranteed to match the value of 
        /// <see cref="RegionInfo.ISOCurrencySymbol"/>. Indeed, the region info
        /// only uses the most recent currency.
        /// Moreover, a country might use more than one currency but .NET will only 
        /// allow for one currency. For instance, El Salvador use both USD and SVC 
        /// but .NET only knows about USD.
        /// </para>
        /// </remarks>
        /// <returns>The region info of the currency; <c>null</c> if none found.</returns>
        public static RegionInfo FindRegion(this CurrencyInfo @this)
        {
            Require.Object(@this);

            // Data from the ISO 4217 offer several hints from which we can infer the country/region:
            // - If the numeric code is strictly less than 900, it SHOULD match 
            //   the numeric country code defined by ISO 3166.
            // - The first two letters from the alphabetic code SHOULD match
            //   the country alpha-2 code defined by ISO 3166.
            // - The english name of the region. Let's hope that .NET and ISO 4217
            //   both use the same name.
            // Using the numeric code is not good. For instance, we would miss most of the European 
            // countries which use the EUR supranational currency whose code (978) does not relate 
            // to the actual country. For exactly the same reason we can not use the alphabetic code.
            var region = Regions_.Value
                .Where(_ => _.EnglishName.ToUpperInvariant() == @this.EnglishRegionName.ToUpperInvariant())
                .SingleOrDefault();

            if (@this.NumericCode < 900) {
                if (region == null) {
                    // This should not come as a surprise, .NET does not cover the full range 
                    // of countries defined by ISO 3166.
                    Debug.WriteLine("No region found for: " + @this.EnglishRegionName);
                }
            }

            return region;
        }

        static List<RegionInfo> GetRegions_()
        {
            return (from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                    let ri = new RegionInfo(ci.LCID)
                    select ri).Distinct().ToList();
        }
    }
}