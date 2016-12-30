﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System;

    using Narvalo.Finance.Properties;
    using Narvalo.Finance.Utilities;

    public sealed class IbanValidator
    {
        private readonly bool _verifyIntegrity;
        private readonly bool _verifyISOCountryCode;
        private readonly bool _verifyBban;

        public IbanValidator(IbanValidationLevels levels)
        {
            _verifyIntegrity = levels.Contains(IbanValidationLevels.Integrity);
            _verifyISOCountryCode = levels.Contains(IbanValidationLevels.ISOCountryCode);
            _verifyBban = levels.Contains(IbanValidationLevels.Bban);
        }

        public static bool Validate(IbanParts parts, IbanValidationLevels levels)
            => new IbanValidator(levels).Validate(parts);

        public static BooleanResult TryValidate(IbanParts parts, IbanValidationLevels levels)
        {
            Warrant.NotNull<BooleanResult>();
            return new IbanValidator(levels).TryValidate(parts);
        }

        // Keep this internal. We prefer to expose the simpler TryValidate().
        internal static Outcome<IbanParts> TryValidateIntern(IbanParts parts, IbanValidationLevels levels)
        {
            Warrant.NotNull<Outcome<IbanParts>>();

            var result = new IbanValidator(levels).TryValidate(parts);

            return result.IsTrue
                ? Outcome.Success(parts)
                : Outcome<IbanParts>.Failure(result.ErrorMessage);
        }

        public bool Validate(IbanParts parts)
            => (!_verifyIntegrity || VerifyIntegrity(parts))
                  && (!_verifyISOCountryCode || VerifyISOCountryCode(parts))
                  && (!_verifyBban || VerifyBban(parts));

        public BooleanResult TryValidate(IbanParts parts)
        {
            Warrant.NotNull<BooleanResult>();

            if (_verifyIntegrity && !VerifyIntegrity(parts))
            {
                return BooleanResult.False(Strings.IbanValidator_IntegrityCheckFailure);
            }
            if (_verifyISOCountryCode && !VerifyISOCountryCode(parts))
            {
                return BooleanResult.False(Strings.IbanValidator_UnknownISOCountryCode);
            }
            if (_verifyBban && !VerifyBban(parts))
            {
                return BooleanResult.False(Strings.IbanValidator_BbanVerificationFailure);
            }

            return BooleanResult.True;
        }

        public static bool VerifyISOCountryCode(IbanParts parts)
            => CountryISOCodes.TwoLetterCodeExists(parts.CountryCode);

        public static bool VerifyBban(IbanParts parts)
        {
            throw new NotImplementedException();
        }

        public static bool VerifyIntegrity(IbanParts parts)
            // NB: On full .NET we have Environment.Is64BitProcess.
            // If IntPtr.Size is equal to 8, we are running in a 64-bit process and
            // we check the integrity using Int64 arithmetic; otherwise (32-bit or 16-bit process)
            // we use Int32 arithmetic (NB: IntPtr.Size = 4 in a 32-bit process). I believe,
            // but I have not verified, that ComputeInt64Checksum() is faster in a 64-bit process.
            => ISO7064.CheckIntegrity(parts.LiteralValue, IntPtr.Size == 8);
    }
}
