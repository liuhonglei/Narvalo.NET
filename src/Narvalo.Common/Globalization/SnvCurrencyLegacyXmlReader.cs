﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Globalization
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;

    using Narvalo.Xml;

    public sealed class SnvCurrencyLegacyXmlReader : SnvCurrencyXmlReaderBase
    {
        private DateTime? _publicationDate;

        public SnvCurrencyLegacyXmlReader(string source) : base(source) { }

        public DateTime PublicationDate
        {
            get
            {
                if (!_publicationDate.HasValue)
                {
                    throw new CurrencyException("XXX");
                }

                return _publicationDate.Value;
            }
        }

        public IEnumerable<CurrencyInfo> Read()
        {
            XElement root = ReadContent();

            _publicationDate = root
                .AttributeOrThrow("Pblshd", ExceptionThunk("XXX"))
                .Select(ProcessPublicationDate);

            List<XElement> currencyElements = root
                .ElementOrThrow("HstrcCcyTbl", ExceptionThunk("XXX"))
                .Elements("HstrcCcyNtry")
                .ToList();

            if (currencyElements.Count == 0)
            {
                throw new CurrencyException("XXX");
            }

            foreach (var currencyElement in currencyElements)
            {
                // English Name
                // NB: Keep the "englishNameElement" around, we will need it later on.
                XElement englishNameElement = currencyElement
                    .ElementOrThrow("CcyNm", ExceptionThunk("XXX"));
                string englishName = englishNameElement.Select(ProcessCurrencyName);

                // Alphabetic Code
                string code = currencyElement
                    .ElementOrThrow("Ccy", ExceptionThunk("XXX"))
                    .Select(ProcessAlphabeticCode);

                // Numeric Code
                short numericCode = currencyElement
                    .ElementOrNone("CcyNbr")
                    .Select(_ => _.Select(ProcessNumericCode))
                    .ValueOrElse(0);
                if (numericCode == 0)
                {
                    Debug.WriteLine("Found a currency without a numeric code: " + englishName);
                }

                // Fund?
                bool isFund = englishNameElement
                    .AttributeOrNone("IsFund")
                    .Select(_ => _.Select(ProcessIsFund))
                    .ValueOrElse(false);

                // Country English Name
                string englishRegionName = currencyElement
                    .ElementOrThrow("CtryNm", ExceptionThunk("XXX"))
                    .Select(ProcessRegionName);

                yield return new CurrencyInfo(code, numericCode) {
                    EnglishName = englishName,
                    EnglishRegionName = englishRegionName,
                    IsFund = isFund,
                    Superseded = true,
                };
            }
        }
    }
}
