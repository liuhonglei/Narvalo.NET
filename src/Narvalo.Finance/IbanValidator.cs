﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System;

    using Narvalo.Finance.Internal;
    using Narvalo.Finance.Properties;

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
            => new IbanValidator(levels).TryValidate(parts);

        // Keep this internal. We prefer to expose the simpler TryValidate().
        internal static Result<IbanParts> TryValidateIntern(IbanParts parts, IbanValidationLevels levels)
        {
            var result = new IbanValidator(levels).TryValidate(parts);

            return result.IsTrue
                ? Result.Of(parts)
                : Result<IbanParts>.FromError(result.Error);
        }

        public bool Validate(IbanParts parts)
            => (!_verifyIntegrity || VerifyIntegrity(parts))
                  && (!_verifyISOCountryCode || VerifyISOCountryCode(parts))
                  && (!_verifyBban || VerifyBban(parts));

        public BooleanResult TryValidate(IbanParts parts)
        {
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

        public static bool VerifyIntegrity(IbanParts parts) => IbanCheckDigits.Verify(parts.LiteralValue);
    }
}
