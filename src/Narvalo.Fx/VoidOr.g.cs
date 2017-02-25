﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 14.0
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Narvalo.Fx.Internal;
    using Narvalo.Fx.Linq;

    // Provides a set of static methods for VoidOr<T>.
    public static partial class VoidOr
    {
        /// <summary>
        /// The unique object of type <c>VoidOr&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly VoidOr<global::Narvalo.Fx.Unit> s_Unit = FromError(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>VoidOr&lt;Unit&gt;</c>.
        /// </summary>
        public static VoidOr<global::Narvalo.Fx.Unit> Unit => s_Unit;

        /// <summary>
        /// Gets the zero for <see cref="VoidOr{T}.Bind"/>.
        /// </summary>
        public static VoidOr<global::Narvalo.Fx.Unit> Void => VoidOr<global::Narvalo.Fx.Unit>.Void;

        /// <summary>
        /// Obtains an instance of the <see cref="VoidOr{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="VoidOr{T}"/>.</param>
        /// <returns>An instance of the <see cref="VoidOr{T}"/> class for the specified value.</returns>
        public static VoidOr<T> FromError<T>(T value)
            /* T4: type constraint */
            => VoidOr<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static VoidOr<T> Flatten<T>(VoidOr<VoidOr<T>> square)
            /* T4: type constraint */
            => VoidOr<T>.μ(square);

        public static VoidOr<Unit> Guard(bool predicate) => predicate ? Unit : Void;

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="VoidOr{T}" /> values.
        /// </summary>
        /// <seealso cref="Select{T, TResult}" />
        public static Func<VoidOr<T>, VoidOr<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            /* T4: type constraint */
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="VoidOr{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, TResult}" />
        public static Func<VoidOr<T1>, VoidOr<T2>, VoidOr<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="VoidOr{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, TResult}" />
        public static Func<VoidOr<T1>, VoidOr<T2>, VoidOr<T3>, VoidOr<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="VoidOr{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, TResult}" />
        public static Func<VoidOr<T1>, VoidOr<T2>, VoidOr<T3>, VoidOr<T4>, VoidOr<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="VoidOr{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult}" />
        public static Func<VoidOr<T1>, VoidOr<T2>, VoidOr<T3>, VoidOr<T4>, VoidOr<T5>, VoidOr<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    } // End of VoidOr - T4: EmitMonadCore().

    // Provides extension methods for VoidOr<T>.
    public static partial class VoidOr
    {
        /// <seealso cref="Apply{TSource, TResult}" />
        public static VoidOr<TResult> Gather<TSource, TResult>(
            this VoidOr<TSource> @this,
            VoidOr<Func<TSource, TResult>> applicative)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        /// <seealso cref="Gather{TSource, TResult}" />
        public static VoidOr<TResult> Apply<TSource, TResult>(
            this VoidOr<Func<TSource, TResult>> @this,
            VoidOr<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }

        public static VoidOr<IEnumerable<TSource>> Repeat<TSource>(
            this VoidOr<TSource> @this,
            int count)
        {
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static VoidOr<TResult> ReplaceBy<TSource, TResult>(
            this VoidOr<TSource> @this,
            TResult value)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static VoidOr<TResult> Then<TSource, TResult>(
            this VoidOr<TSource> @this,
            VoidOr<TResult> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static VoidOr<TSource> Ignore<TSource, TOther>(
            this VoidOr<TSource> @this,
            VoidOr<TOther> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static VoidOr<global::Narvalo.Fx.Unit> Skip<TSource>(this VoidOr<TSource> @this)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Then(Unit);
        }

        public static VoidOr<TResult> If<TSource, TResult>(
            this VoidOr<TSource> @this,
            Func<TSource, bool> predicate,
            VoidOr<TResult> thenResult)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : VoidOr<TResult>.Void);
        }

        public static VoidOr<TResult> Coalesce<TSource, TResult>(
            this VoidOr<TSource> @this,
            Func<TSource, bool> predicate,
            VoidOr<TResult> thenResult,
            VoidOr<TResult> elseResult)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static VoidOr<TResult> Using<TSource, TResult>(
            this VoidOr<TSource> @this,
            Func<TSource, VoidOr<TResult>> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static VoidOr<TResult> Using<TSource, TResult>(
            this VoidOr<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static VoidOr<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this VoidOr<TSource> @this,
            VoidOr<TOther> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        /// <seealso cref="Lift{TFirst, TSecond, TResult}" />
        public static VoidOr<TResult> Zip<TFirst, TSecond, TResult>(
            this VoidOr<TFirst> @this,
            VoidOr<TSecond> second,
            Func<TFirst, TSecond, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            Func<TFirst, Func<TSecond, TResult>> selector
                = arg1 => arg2 => zipper(arg1, arg2);

            return second.Gather(
                @this.Select(selector));
        }

        /// <seealso cref="Lift{T1, T2, T3, TResult}" />
        public static VoidOr<TResult> Zip<T1, T2, T3, TResult>(
            this VoidOr<T1> @this,
            VoidOr<T2> second,
            VoidOr<T3> third,
            Func<T1, T2, T3, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, TResult>>> selector
                = arg1 => arg2 => arg3 => zipper(arg1, arg2, arg3);

            return third.Gather(
                second.Gather(
                    @this.Select(selector)));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, TResult}" />
        public static VoidOr<TResult> Zip<T1, T2, T3, T4, TResult>(
             this VoidOr<T1> @this,
             VoidOr<T2> second,
             VoidOr<T3> third,
             VoidOr<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> selector
                = arg1 => arg2 => arg3 => arg4 => zipper(arg1, arg2, arg3, arg4);

            return fourth.Gather(
                third.Gather(
                    second.Gather(
                        @this.Select(selector))));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult}" />
        public static VoidOr<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this VoidOr<T1> @this,
            VoidOr<T2> second,
            VoidOr<T3> third,
            VoidOr<T4> fourth,
            VoidOr<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(fifth, nameof(fifth));
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> selector
                = arg1 => arg2 => arg3 => arg4 => arg5 => zipper(arg1, arg2, arg3, arg4, arg5);

            return fifth.Gather(
                fourth.Gather(
                    third.Gather(
                        second.Gather(
                            @this.Select(selector)))));
        }

        #endregion

        #region LINQ dialect

        public static VoidOr<TResult> Select<TSource, TResult>(
            this VoidOr<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => VoidOr.FromError(selector(val)));
        }

        public static VoidOr<TSource> Where<TSource>(
            this VoidOr<TSource> @this,
            Func<TSource, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? VoidOr.FromError(val) : VoidOr<TSource>.Void);
        }

        /// <remarks>
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static VoidOr<TResult> SelectMany<TSource, TMiddle, TResult>(
            this VoidOr<TSource> @this,
            Func<TSource, VoidOr<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        public static VoidOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this VoidOr<TSource> @this,
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
            /* T4: type constraint */
            => JoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static VoidOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this VoidOr<TSource> @this,
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
            => JoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);

        public static VoidOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this VoidOr<TSource> @this,
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, VoidOr<TInner>, TResult> resultSelector)
            /* T4: type constraint */
            => GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static VoidOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this VoidOr<TSource> @this,
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, VoidOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
            => GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);

        private static VoidOr<TResult> JoinImpl<TSource, TInner, TKey, TResult>(
            VoidOr<TSource> outer,
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Require.NotNull(outer, nameof(outer));
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var keyLookup = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return outer.SelectMany(val => keyLookup(val).Then(inner), resultSelector);
        }

        private static VoidOr<TResult> GroupJoinImpl<TSource, TInner, TKey, TResult>(
            VoidOr<TSource> outer,
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, VoidOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Require.NotNull(outer, nameof(outer));
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var keyLookup = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return outer.Select(val => resultSelector(val, keyLookup(val).Then(inner)));
        }

        private static Func<TSource, VoidOr<TKey>> GetKeyLookup<TSource, TInner, TKey>(
            VoidOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Demand.NotNull("inner");
            Demand.NotNull(outerKeySelector);
            Demand.NotNull(innerKeySelector);
            Demand.NotNull(comparer);

            return arg =>
            {
                TKey outerKey = outerKeySelector(arg);

                return inner.Select(innerKeySelector)
                    .Where(key => comparer.Equals(key, outerKey));
            };
        }

        #endregion
    } // End of VoidOr - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kleisli
    {
        public static VoidOr<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, VoidOr<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static VoidOr<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, VoidOr<TResult>> @this,
            VoidOr<TSource> value)
            /* T4: type constraint */
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, VoidOr<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, VoidOr<TMiddle>> @this,
            Func<TMiddle, VoidOr<TResult>> second)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, VoidOr<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, VoidOr<TResult>> @this,
            Func<TSource, VoidOr<TMiddle>> second)
            /* T4: type constraint */
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    } // End of Kleisli - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<VoidOr<T>>.
    public static partial class VoidOr
    {
        public static VoidOr<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<VoidOr<TSource>> @this)
            => @this.CollectImpl();

        public static VoidOr<TSource> Sum<TSource>(
            this IEnumerable<VoidOr<TSource>> @this)
            /* T4: type constraint */
            => @this.SumImpl();
    } // End of Sequence - T4: EmitMonadEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<VoidOr<T>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<VoidOr<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return VoidOr.FromError(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource>(IEnumerable<VoidOr<TSource>> source)
        {
            Demand.NotNull(source);

            var item = default(TSource);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var append = false;

                    iter.Current.Bind(
                        val =>
                        {
                            append = true;
                            item = val;

                            return VoidOr.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<TSource> SumImpl<TSource>(
            this IEnumerable<VoidOr<TSource>> @this)
            /* T4: type constraint */
        {
            Demand.NotNull(@this);

            return @this.Aggregate(VoidOr<TSource>.Void, (m, n) => m.OrElse(n));
        }
    } // End of EnumerableExtensions - T4: EmitMonadEnumerableInternalExtensions().
}

namespace Narvalo.Fx.Linq
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Fx;
    using Narvalo.Fx.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid any confusion.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    public static partial class Qperators
    {
        public static VoidOr<IEnumerable<TResult>> SelectWith<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, VoidOr<TResult>> selector)
            => @this.SelectWithImpl(selector);

        public static VoidOr<IEnumerable<TSource>> WhereBy<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, VoidOr<bool>> predicate)
            => @this.WhereByImpl(predicate);

        public static VoidOr<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, VoidOr<TResult>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static VoidOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, VoidOr<TAccumulate>> accumulator)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator);

        public static VoidOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, VoidOr<TAccumulate>> accumulator,
            Func<VoidOr<TAccumulate>, bool> predicate)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator, predicate);

        public static VoidOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, VoidOr<TSource>> accumulator)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator);

        public static VoidOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, VoidOr<TSource>> accumulator,
            Func<VoidOr<TSource>, bool> predicate)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator, predicate);
    } // End of Iterable - T4: EmitEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, VoidOr<TResult>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, VoidOr<bool>> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            return VoidOr.FromError(WhereByIterator(@this, predicate));
        }

        private static IEnumerable<TSource> WhereByIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, VoidOr<bool>> predicate)
        {
            Demand.NotNull(source);
            Demand.NotNull(predicate);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource item = iter.Current;

                    predicate(item).Bind(val =>
                    {
                        pass = val;

                        return VoidOr.Unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, VoidOr<TResult>> resultSelector)
        {
            Demand.NotNull(resultSelector);
            Demand.NotNull(@this);
            Demand.NotNull(second);

            return @this.Zip(second, resultSelector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, VoidOr<TAccumulate>> accumulator)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            VoidOr<TAccumulate> retval = VoidOr.FromError(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, VoidOr<TAccumulate>> accumulator,
            Func<VoidOr<TAccumulate>, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            VoidOr<TAccumulate> retval = VoidOr.FromError(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate(retval) && iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, VoidOr<TSource>> accumulator)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                VoidOr<TSource> retval = VoidOr.FromError(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static VoidOr<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, VoidOr<TSource>> accumulator,
            Func<VoidOr<TSource>, bool> predicate)
            /* T4: type constraint */
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

                VoidOr<TSource> retval = VoidOr.FromError(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    } // End of EnumerableExtensions - T4: EmitEnumerableInternalExtensions().
}
