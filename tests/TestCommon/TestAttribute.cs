﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo {
    using Xunit;

    internal class TestAttribute : FactAttribute {
        public TestAttribute(string category, string message) : base() {
            DisplayName = category + " - " + message;
        }
    }
}
