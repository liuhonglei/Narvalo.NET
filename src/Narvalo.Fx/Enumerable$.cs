﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using static System.Diagnostics.Contracts.Contract;

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        // Useful when using built-in LINQ operators. Even if it is not publicly visible,
        // I think that all LINQ operators never return a null but rather an empty sequence if needed.
        public static IEnumerable<TSource> EmptyIfNull<TSource>(this IEnumerable<TSource> @this)
        {
            Ensures(Result<IEnumerable<TSource>>() != null);

            if (@this == null)
            {
                return Sequence<TSource>.Empty;
            }

            return @this;
        }

        public static bool IsEmpty<TSource>(this IEnumerable<TSource> @this)
        {
            Expect.NotNull(@this);

            return !@this.Any();
        }

        #region Element Operators

        public static Maybe<TSource> FirstOrNone<TSource>(this IEnumerable<TSource> @this)
        {
            Expect.NotNull(@this);

            return FirstOrNone(@this, Stubs<TSource>.AlwaysTrue);
        }

        public static Maybe<TSource> FirstOrNone<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            IEnumerable<Maybe<TSource>> seq
                = from t in @this where predicate.Invoke(t) select Maybe.Of(t);

            using (var iter = seq.EmptyIfNull().GetEnumerator())
            {
                var current = iter.Current;

                return iter.MoveNext() ? current : Maybe<TSource>.None;
            }
        }

        public static Maybe<TSource> LastOrNone<TSource>(this IEnumerable<TSource> @this)
        {
            Expect.NotNull(@this);

            return LastOrNone(@this, Stubs<TSource>.AlwaysTrue);
        }

        public static Maybe<TSource> LastOrNone<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            return @this.Reverse().EmptyIfNull().FirstOrNone();
        }

        public static Maybe<TSource> SingleOrNone<TSource>(this IEnumerable<TSource> @this)
        {
            Expect.NotNull(@this);

            return SingleOrNone(@this, Stubs<TSource>.AlwaysTrue);
        }

        public static Maybe<TSource> SingleOrNone<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            IEnumerable<Maybe<TSource>> seq
                = from t in @this where predicate.Invoke(t) select Maybe.Of(t);

            using (var iter = seq.EmptyIfNull().GetEnumerator())
            {
                var current = iter.Current;

                var result = iter.MoveNext() ? current : Maybe<TSource>.None;

                // Return Maybe.None if there is one more element.
                return iter.MoveNext() ? Maybe<TSource>.None : result;
            }
        }

        #endregion

        #region Concatenation Operators

        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> @this, TSource element)
        {
            Expect.NotNull(@this);
            Ensures(Result<IEnumerable<TSource>>() != null);

            return @this.Concat(Sequence.Pure(element)).EmptyIfNull();
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> @this, TSource element)
        {
            Expect.NotNull(@this);
            Ensures(Result<IEnumerable<TSource>>() != null);

            return Sequence.Pure(element).Concat(@this).EmptyIfNull();
        }

        #endregion

        #region Conversion Operators

        public static ICollection<TSource> ToCollection<TSource>(this IEnumerable<TSource> @this)
        {
            Require.NotNull(@this, nameof(@this));
            Ensures(Result<ICollection<TSource>>() != null);

            var retval = new Collection<TSource>();

            foreach (TSource item in @this)
            {
                retval.Add(item);
            }

            return retval;
        }

        #endregion

        #region Aggregate Operators

        public static TAccumulate AggregateBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> accumulator)
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulator);

            return @this.Reverse().Aggregate(seed, accumulator);
        }

        public static TSource AggregateBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, TSource> accumulator)
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulator);

            return @this.Reverse().Aggregate(accumulator);
        }

        #endregion

        #region Catamorphisms

        public static TAccumulate Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> accumulator,
            Func<TAccumulate, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            TAccumulate retval = seed;

            using (var iter = @this.GetEnumerator())
            {
                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    retval = accumulator.Invoke(retval, iter.Current);
                }
            }

            return retval;
        }

        public static TSource Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, TSource> accumulator,
            Func<TSource, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                TSource retval = iter.Current;

                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    retval = accumulator.Invoke(retval, iter.Current);
                }

                return retval;
            }
        }

        #endregion

        #region Overrides for auto-generated (extension) methods on IEnumerable<Maybe<T>>

        // Custom version of CollectCore.
        internal static Maybe<IEnumerable<TSource>> CollectCore<TSource>(this IEnumerable<Maybe<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            var list = new List<TSource>();

            foreach (var m in @this)
            {
                if (!m.IsSome)
                {
                    return Maybe<IEnumerable<TSource>>.None;
                }

                list.Add(m.Value);
            }

            return Maybe.Of(list.AsEnumerable());
        }

        #endregion

        #region Overrides for auto-generated (extension) methods on IEnumerable<Outcome<T>>

        // Custom version of CollectCore.
        internal static Outcome<IEnumerable<TSource>> CollectCore<TSource>(this IEnumerable<Outcome<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));
            Ensures(Result<Outcome<IEnumerable<TSource>>>() != null);

            var list = new List<TSource>();

            foreach (var m in @this)
            {
                // REVIEW: Is this the correct behaviour when m is null?
                if (m == null)
                {
                    continue;
                }

                if (!m.IsSuccess)
                {
                    return Outcome.Failure<IEnumerable<TSource>>(m.ToExceptionDispatchInfo());
                }

                list.Add(m.ToValue());
            }

            return Outcome.Success(list.AsEnumerable());
        }

        #endregion
    }
}
