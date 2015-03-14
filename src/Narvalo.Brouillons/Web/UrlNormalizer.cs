﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class UrlNormalizer
    {
        const char NormalizationChar_ = '-';

        static readonly Regex MultipleDashRegex_ = new Regex(@"\-{2,}", RegexOptions.Compiled);

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase",
            Justification = "It is safer to only use lowercase characters in URIs.")]
        public static string NormalizePart(string value)
        {
            Require.NotNullOrEmpty(value, "value");

            // TODO: À refaire et remplacer tous les caractères spéciaux d'un traite.
            // FIXME: Supprimer les caractères de contrôle.
            string result = new StringBuilder(
                value.Trim())
                // Caractères réservés
                .Replace('$', NormalizationChar_)
                .Replace('&', NormalizationChar_)
                .Replace('+', NormalizationChar_)
                .Replace(',', NormalizationChar_)
                .Replace('/', NormalizationChar_)
                .Replace(':', NormalizationChar_)
                .Replace('=', NormalizationChar_)
                .Replace('?', NormalizationChar_)
                .Replace('@', NormalizationChar_)
                .Replace(';', NormalizationChar_)

                // Caractères spéciaux
                .Replace(' ', NormalizationChar_)
                .Replace('\'', NormalizationChar_)
                .Replace('<', NormalizationChar_)
                .Replace('>', NormalizationChar_)
                .Replace('#', NormalizationChar_)
                .Replace('%', NormalizationChar_)

                .Replace('{', NormalizationChar_)
                .Replace('}', NormalizationChar_)
                .Replace('|', NormalizationChar_)
                .Replace('\\', NormalizationChar_)
                .Replace('^', NormalizationChar_)
                .Replace('~', NormalizationChar_)
                .Replace('[', NormalizationChar_)
                .Replace(']', NormalizationChar_)
                .Replace('`', NormalizationChar_)

                // Autres caractères
                .Replace('*', NormalizationChar_)
                .Replace('.', NormalizationChar_)
                .Replace('!', NormalizationChar_)
                .Replace('"', NormalizationChar_)
                .Replace('\'', NormalizationChar_)

                .ToString();

            //result = MultipleDashRegex_.Replace(StringManip.RemoveDiacritics(result), NormalizationChar_.ToString());

            return result.ToLowerInvariant();
        }
    }
}