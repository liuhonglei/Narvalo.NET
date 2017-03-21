﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;

    using Xunit;

    public static class HashCodeHelpersFacts
    {
        [Fact]
        public static void Combine2_DoesNotThrow_ForMinValueOverflow()
            => HashCodeHelpers.Combine(Int32.MinValue, 1);

        [Fact]
        public static void Combine2_DoesNotThrow_ForMaxValueOverflow()
            => HashCodeHelpers.Combine(Int32.MaxValue, 1);
        [Fact]
        public static void Combine3_DoesNotThrow_ForMinValueOverflow()
            => HashCodeHelpers.Combine(Int32.MinValue, 1, 1);

        [Fact]
        public static void Combine3_DoesNotThrow_ForMaxValueOverflow()
            => HashCodeHelpers.Combine(Int32.MaxValue, 1, 1);
    }
}