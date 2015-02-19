﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CurrencyNotFoundException : CurrencyException
    {
        public CurrencyNotFoundException() { }

        public CurrencyNotFoundException(string message)
            : base(message) { }

        public CurrencyNotFoundException(string message, Exception innerException) :
            base(message, innerException) { }

        protected CurrencyNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
