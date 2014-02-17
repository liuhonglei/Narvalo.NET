﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Edu.Fx
{
    using System;

    public static partial class MonadExtensions
    {
        public static Monad<TResult> Coalesce<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Monad<TResult> then,
            Monad<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

#if !MONAD_DISABLE_ZERO
        public static Monad<TResult> Then<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Monad<TResult> other)
        {
            return Coalesce(@this, predicate, other, Monad<TResult>.Zero);
        }

        public static Monad<TResult> Otherwise<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Monad<TResult> other)
        {
            return Coalesce(@this, predicate, Monad<TResult>.Zero, other);
        }
#endif

        public static Monad<Unit> Run<TSource>(this Monad<TSource> @this, Kunc<TSource, Unit> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(action);
        }

        //public static Monad<Unit> OnZero<TSource>(this Monad<TSource> @this, Kunc<Unit, Unit> action)
        //{
        //    Require.Object(@this);
        //    Require.NotNull(action, "action");

        //    throw new NotImplementedException();
        //}
    }
}
