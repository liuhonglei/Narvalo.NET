﻿namespace Narvalo
{
    using System;
    using System.Globalization;
    using System.Text;

    public static class StringManipIncubated
    {
        [Alien(AlienSource.Informal,
            Link = "http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net")]
        public static string RemoveDiacritics(string value)
        {
            Require.NotNull(value, "value");

            if (value.Length == 0) {
                return String.Empty;
            }

            var formD = value.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            for (int i = 0; i < formD.Length; i++) {
                Char c = formD[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
