﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Platforms
{
    using System;
    using System.ComponentModel;

    using Narvalo.Mvp.Properties;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class LazyValueHolder<TValue> where TValue : class
    {
        private readonly Lazy<TValue> _lazyValue;

        private Func<TValue> _valueFactory;

        public LazyValueHolder(Func<TValue> valueFactory)
        {
            Require.NotNull(valueFactory, nameof(valueFactory));

            _valueFactory = valueFactory;

            // WARNING: Do not change the following line for:
            // _lazyValue = new Lazy<TValue>(_valueFactory);
            // it will fail to capture the variable "_valueFactory".
            _lazyValue = new Lazy<TValue>(() => _valueFactory.Invoke());
        }

        public TValue Value
        {
            get
            {
                var value = _lazyValue.Value;

                if (value == null)
                {
                    throw new InvalidOperationException(Strings.LazyValueHolder_ValueFactoryReturnsNull);
                }

                return value;
            }
        }

        public bool CanReset { get { return !_lazyValue.IsValueCreated; } }

        public void Reset(TValue value)
        {
            Require.NotNull(value, nameof(value));

            Reset(() => value);
        }

        public void Reset(Func<TValue> valueFactory)
        {
            Require.NotNull(valueFactory, nameof(valueFactory));

            if (!CanReset)
            {
                throw new InvalidOperationException(Strings.LazyValueHolder_CannotReset);
            }

            // REVIEW: We break thread-safety here, but does it matter for our use case?
            _valueFactory = valueFactory;
        }
    }
}
