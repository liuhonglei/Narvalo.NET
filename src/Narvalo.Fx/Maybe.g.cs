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

    public partial struct Maybe<T>
    {

        public void Forever(Action<T> action)
        {
            Require.NotNull(action, nameof(action));

            ForeverImpl(action);
        }

        partial void ForeverImpl(Action<T> action);

        public void While(Func<bool> istrue, Action<T> action)
        {
            Require.NotNull(istrue, nameof(istrue));
            Require.NotNull(action, nameof(action));

            Bind(val =>
            {
                while (istrue()) { action(val); }

                return Maybe.Unit;
            });
        }

        public void Until(Func<bool> istrue, Action<T> action)
        {
            Require.NotNull(istrue, nameof(istrue));
            Require.NotNull(action, nameof(action));

            Bind(val =>
            {
                while (!istrue()) { action(val); }

                return Maybe.Unit;
            });
        }
    }

    // Provides a set of static methods for Maybe<T>.
    public static partial class Maybe
    {
        /// <summary>
        /// The unique object of type <c>Maybe&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Maybe<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>Maybe&lt;Unit&gt;</c>.
        /// </summary>
        public static Maybe<global::Narvalo.Fx.Unit> Unit => s_Unit;

        /// <summary>
        /// Gets the zero for <see cref="Maybe{T}.Bind"/>.
        /// </summary>
        public static Maybe<global::Narvalo.Fx.Unit> None => Maybe<global::Narvalo.Fx.Unit>.None;

        /// <summary>
        /// Obtains an instance of the <see cref="Maybe{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Maybe{T}"/>.</param>
        /// <returns>An instance of the <see cref="Maybe{T}"/> class for the specified value.</returns>
        public static Maybe<T> Of<T>(T value)
            /* T4: type constraint */
            => Maybe<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Maybe<T> Flatten<T>(Maybe<Maybe<T>> square)
            /* T4: type constraint */
            => Maybe<T>.μ(square);

        public static Maybe<Unit> Guard(bool predicate) => predicate ? Unit : None;

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="Select{T, TResult}" />
        public static Func<Maybe<T>, Maybe<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            /* T4: type constraint */
            => arg =>
            {
                /* T4: NotNull(arg) */
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, TResult}" />
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, TResult}" />
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, TResult}" />
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<T4>, Maybe<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult}" />
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<T4>, Maybe<T5>, Maybe<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    } // End of Maybe - T4: EmitMonadCore().

    // Provides extension methods for Maybe<T>.
    public static partial class Maybe
    {
        /// <seealso cref="Apply{TSource, TResult}" />
        public static Maybe<TResult> Gather<TSource, TResult>(
            this Maybe<TSource> @this,
            Maybe<Func<TSource, TResult>> applicative)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(applicative) */
            return applicative.Bind(func => @this.Select(func));
        }

        /// <seealso cref="Gather{TSource, TResult}" />
        public static Maybe<TResult> Apply<TSource, TResult>(
            this Maybe<Func<TSource, TResult>> @this,
            Maybe<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Gather(@this);
        }

        public static Maybe<IEnumerable<TSource>> Repeat<TSource>(
            this Maybe<TSource> @this,
            int count)
        {
            /* T4: NotNull(@this) */
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static Maybe<TResult> ReplaceBy<TSource, TResult>(
            this Maybe<TSource> @this,
            TResult value)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Select(_ => value);
        }

        public static Maybe<TResult> Then<TSource, TResult>(
            this Maybe<TSource> @this,
            Maybe<TResult> other)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Bind(_ => other);
        }

        public static Maybe<TSource> Ignore<TSource, TOther>(
            this Maybe<TSource> @this,
            Maybe<TOther> other)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static Maybe<global::Narvalo.Fx.Unit> Skip<TSource>(this Maybe<TSource> @this)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Then(Unit);
        }

        public static Maybe<TResult> If<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate,
            Maybe<TResult> thenResult)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : Maybe<TResult>.None);
        }

        public static Maybe<TResult> Coalesce<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate,
            Maybe<TResult> thenResult,
            Maybe<TResult> elseResult)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static Maybe<TResult> Using<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, Maybe<TResult>> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static Maybe<TResult> Using<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static Maybe<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this Maybe<TSource> @this,
            Maybe<TOther> other)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Zip(other, Tuple.Create);
        }

        /// <seealso cref="Lift{TFirst, TSecond, TResult}" />
        public static Maybe<TResult> Zip<TFirst, TSecond, TResult>(
            this Maybe<TFirst> @this,
            Maybe<TSecond> second,
            Func<TFirst, TSecond, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            Require.NotNull(zipper, nameof(zipper));

            Func<TFirst, Func<TSecond, TResult>> selector
                = arg1 => arg2 => zipper(arg1, arg2);

            return second.Gather(
                @this.Select(selector));
        }

        /// <seealso cref="Lift{T1, T2, T3, TResult}" />
        public static Maybe<TResult> Zip<T1, T2, T3, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Maybe<T3> third,
            Func<T1, T2, T3, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, TResult>>> selector
                = arg1 => arg2 => arg3 => zipper(arg1, arg2, arg3);

            return third.Gather(
                second.Gather(
                    @this.Select(selector)));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, TResult}" />
        public static Maybe<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Maybe<T1> @this,
             Maybe<T2> second,
             Maybe<T3> third,
             Maybe<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> selector
                = arg1 => arg2 => arg3 => arg4 => zipper(arg1, arg2, arg3, arg4);

            return fourth.Gather(
                third.Gather(
                    second.Gather(
                        @this.Select(selector))));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult}" />
        public static Maybe<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Maybe<T3> third,
            Maybe<T4> fourth,
            Maybe<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            /* T4: NotNull(fifth) */
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

        public static Maybe<TResult> Select<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Maybe.Of(selector(val)));
        }

        public static Maybe<TSource> Where<TSource>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? Maybe.Of(val) : Maybe<TSource>.None);
        }

        /// <remarks>
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static Maybe<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, Maybe<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        public static Maybe<TResult> Join<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
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

        public static Maybe<TResult> Join<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
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

        public static Maybe<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector)
            /* T4: type constraint */
            => GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static Maybe<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
            => GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);

        private static Maybe<TResult> JoinImpl<TSource, TInner, TKey, TResult>(
            Maybe<TSource> outer,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            /* T4: NotNull(outer) */
            /* T4: NotNull(inner) */
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var keyLookup = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return outer.SelectMany(val => keyLookup(val).Then(inner), resultSelector);
        }

        private static Maybe<TResult> GroupJoinImpl<TSource, TInner, TKey, TResult>(
            Maybe<TSource> outer,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            /* T4: NotNull(outer) */
            /* T4: NotNull(inner) */
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var keyLookup = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return outer.Select(val => resultSelector(val, keyLookup(val).Then(inner)));
        }

        private static Func<TSource, Maybe<TKey>> GetKeyLookup<TSource, TInner, TKey>(
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Demand.NotNull(outerKeySelector);
            Demand.NotNull(innerKeySelector);
            Demand.NotNull(comparer);

            return arg => inner.Select(innerKeySelector)
                .Where(key => comparer.Equals(key, outerKeySelector(arg)));
        }

        #endregion
    } // End of Maybe - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kleisli
    {
        public static Maybe<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, Maybe<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static Maybe<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, Maybe<TResult>> @this,
            Maybe<TSource> value)
            /* T4: type constraint */
        {
            /* T4: NotNull(value) */
            return value.Bind(@this);
        }

        public static Func<TSource, Maybe<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Maybe<TMiddle>> @this,
            Func<TMiddle, Maybe<TResult>> second)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Maybe<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Maybe<TResult>> @this,
            Func<TSource, Maybe<TMiddle>> second)
            /* T4: type constraint */
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    } // End of Kleisli - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<Maybe<T>>.
    public static partial class Maybe
    {
        public static Maybe<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
            => @this.CollectImpl();

        public static Maybe<TSource> Sum<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
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

    // Provides default implementations for the extension methods for IEnumerable<Maybe<T>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return Maybe.Of(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource>(IEnumerable<Maybe<TSource>> source)
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

                            return Maybe.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TSource> SumImpl<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
            /* T4: type constraint */
        {
            Demand.NotNull(@this);

            return @this.Aggregate(Maybe<TSource>.None, (m, n) => m.OrElse(n));
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
        public static Maybe<IEnumerable<TResult>> SelectWith<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> selector)
            => @this.SelectWithImpl(selector);

        public static Maybe<IEnumerable<TSource>> WhereBy<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicate)
            => @this.WhereByImpl(predicate);

        public static Maybe<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Maybe<TResult>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator);

        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator,
            Func<Maybe<TAccumulate>, bool> predicate)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator, predicate);

        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulator)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator);

        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulator,
            Func<Maybe<TSource>, bool> predicate)
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
        internal static Maybe<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            return Maybe.Of(WhereByIterator(@this, predicate));
        }

        private static IEnumerable<TSource> WhereByIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, Maybe<bool>> predicate)
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

                        return Maybe.Unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Maybe<TResult>> resultSelector)
        {
            Demand.NotNull(resultSelector);
            Demand.NotNull(@this);
            Demand.NotNull(second);

            return @this.Zip(second, resultSelector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            Maybe<TAccumulate> retval = Maybe.Of(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator,
            Func<Maybe<TAccumulate>, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            Maybe<TAccumulate> retval = Maybe.Of(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulator)
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

                Maybe<TSource> retval = Maybe.Of(iter.Current);

                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulator,
            Func<Maybe<TSource>, bool> predicate)
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

                Maybe<TSource> retval = Maybe.Of(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    } // End of EnumerableExtensions - T4: EmitEnumerableInternalExtensions().
}
