﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using Xunit;

    public static class CurrencyNotFoundExceptionFacts
    {
        #region Ctor

        [Fact]
        public static void Ctor_DefaultCtor()
        {
            var ex = new CurrencyNotFoundException();

            Assert.NotNull(ex.Message);
        }

        [Fact]
        public static void Ctor_MessageCtor()
        {
            var message = "My message";
            var ex = new CurrencyNotFoundException(message);

            Assert.Equal(message, ex.Message);
        }

        [Fact]
        public static void Ctor_MessageInnerExceptionCtor()
        {
            var message = "My message";
            var innerException = new My.SimpleException();
            var ex = new CurrencyNotFoundException(message, innerException);

            Assert.Equal(message, ex.Message);
            Assert.Same(innerException, ex.InnerException);
        }

        #endregion
    }
}
