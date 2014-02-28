﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public partial class Maybe<T>
    {
        #region MonadOr

        public Maybe<T> OrElse(Maybe<T> other)
        {
            return IsNone ? other : this;
        }

        #endregion

        #region Monad

        public Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> selector)
        {
            Require.NotNull(selector, "selector");

            return IsSome ? selector.Invoke(Value) : Maybe<TResult>.None;
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
            Justification = "Standard naming convention from mathematics.")]
        internal static Maybe<T> η(T value)
        {
            return value != null ? new Maybe<T>(value) : Maybe<T>.None;
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
            Justification = "Standard naming convention from mathematics.")]
        internal static Maybe<T> μ(Maybe<Maybe<T>> square)
        {
            Require.NotNull(square, "square");

            return square.IsSome ? square.Value : Maybe<T>.None;
        }

        #endregion

        #region Native methods (MaybeExtensions)

        public Maybe<TResult> Map<TResult>(Func<T, TResult> selector)
        {
            Require.NotNull(selector, "selector");

            return IsSome ? Maybe<TResult>.η(selector.Invoke(Value)) : Maybe<TResult>.None;
        }

        public Maybe<TResult> Then<TResult>(Maybe<TResult> other)
        {
            return IsSome ? other : Maybe<TResult>.None;
        }

        public Maybe<TResult> Zip<TSecond, TResult>(
            Maybe<TSecond> second,
            Func<T, TSecond, TResult> resultSelector)
        {
            Require.NotNull(second, "second");

            return IsSome && second.IsSome
                ? Maybe.Create(resultSelector.Invoke(Value, second.Value))
                : Maybe<TResult>.None;
        }

        #endregion
    }
}
