﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx.Advanced;

    /// <summary>
    /// Provides a set of static and extension methods for <see cref="Maybe{T}"/>.
    /// </summary>
    public static partial class Maybe
    {
        public static Maybe<T> Of<T>(T? value) where T : struct
        {
            Contract.Ensures(Contract.Result<Maybe<T>>() != null);

            return value.HasValue ? Maybe<T>.η(value.Value) : Maybe<T>.None;
        }
    }

    /// <content>
    /// Provides extension methods for <see cref="Maybe{T}"/> where <c>T</c> is a struct.
    /// </content>
    public static partial class Maybe
    {
        public static T? ToNullable<T>(this Maybe<T?> @this) where T : struct
        {
            Require.Object(@this);

            return @this.ValueOrDefault();
        }

        public static T? ToNullable<T>(this Maybe<T> @this) where T : struct
        {
            Require.Object(@this);

            return @this.IsSome ? (T?)@this.Value : null;
        }

        public static T UnpackOrDefault<T>(this Maybe<T?> @this) where T : struct
        {
            Acknowledge.Object(@this);

            return UnpackOrElse(@this, default(T));
        }

        public static T UnpackOrElse<T>(this Maybe<T?> @this, T defaultValue) where T : struct
        {
            Acknowledge.Object(@this);

            return UnpackOrElse(@this, () => defaultValue);
        }

        public static T UnpackOrElse<T>(this Maybe<T?> @this, Func<T> defaultValueFactory) where T : struct
        {
            Require.Object(@this);
            Require.NotNull(defaultValueFactory, "defaultValueFactory");

            return @this.ValueOrDefault() ?? defaultValueFactory.Invoke();
        }

        public static T UnpackOrThrow<T>(this Maybe<T?> @this, Exception exception) where T : struct
        {
            Acknowledge.Object(@this);

            return UnpackOrThrow(@this, () => exception);
        }

        public static T UnpackOrThrow<T>(this Maybe<T?> @this, Func<Exception> exceptionFactory) where T : struct
        {
            Require.Object(@this);

            T? m = @this.ValueOrDefault();

            m.OnNull(() => { throw exceptionFactory.Invoke(); });

            Contract.Assume(m.HasValue, "'m' is null; we should have throw an exception.");

            return m.Value;
        }
    }
}