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

using global::Narvalo;
using global::Narvalo.Fx;

namespace Edufun.Haskell.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Edufun.Haskell.Templates.Internal;
    using Edufun.Haskell.Templates.Linq;

    // Provides a set of static methods for Monad<T>.
    // T4: EmitHelpers().
    public static partial class Monad
    {
        /// <summary>
        /// The unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Monad<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        public static Monad<global::Narvalo.Fx.Unit> Unit => s_Unit;

        /// <summary>
        /// Obtains an instance of the <see cref="Monad{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Monad{T}"/>.</param>
        /// <returns>An instance of the <see cref="Monad{T}"/> class for the specified value.</returns>
        public static Monad<T> Of<T>(T value)
            => Monad<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Monad<T> Flatten<T>(Monad<Monad<T>> square)
            => Monad<T>.μ(square);

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        /// <seealso cref="Select{T, TResult}" />
        public static Func<Monad<T>, Monad<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, TResult}" />
        public static Func<Monad<T1>, Monad<T2>, Monad<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, TResult}" />
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, TResult}" />
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult}" />
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<T5>, Monad<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for Monad<T>.
    // T4: EmitExtensions().
    public static partial class Monad
    {
        /// <seealso cref="Apply{TSource, TResult}" />
        public static Monad<TResult> Gather<TSource, TResult>(
            this Monad<TSource> @this,
            Monad<Func<TSource, TResult>> applicative)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        /// <seealso cref="Gather{TSource, TResult}" />
        public static Monad<TResult> Apply<TSource, TResult>(
            this Monad<Func<TSource, TResult>> @this,
            Monad<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }

        public static Monad<IEnumerable<TSource>> Repeat<TSource>(
            this Monad<TSource> @this,
            int count)
        {
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static Monad<TResult> ReplaceBy<TSource, TResult>(
            this Monad<TSource> @this,
            TResult value)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static Monad<TResult> Then<TSource, TResult>(
            this Monad<TSource> @this,
            Monad<TResult> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static Monad<TSource> Ignore<TSource, TOther>(
            this Monad<TSource> @this,
            Monad<TOther> other)
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static Monad<global::Narvalo.Fx.Unit> Skip<TSource>(this Monad<TSource> @this)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Then(Unit);
        }

        public static Monad<TResult> Coalesce<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Monad<TResult> thenResult,
            Monad<TResult> elseResult)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static Monad<TResult> Using<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, Monad<TResult>> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static Monad<TResult> Using<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static Monad<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this Monad<TSource> @this,
            Monad<TOther> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        /// <seealso cref="Lift{TFirst, TSecond, TResult}" />
        public static Monad<TResult> Zip<TFirst, TSecond, TResult>(
            this Monad<TFirst> @this,
            Monad<TSecond> second,
            Func<TFirst, TSecond, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        /// <seealso cref="Lift{T1, T2, T3, TResult}" />
        public static Monad<TResult> Zip<T1, T2, T3, TResult>(
            this Monad<T1> @this,
            Monad<T2> second,
            Monad<T3> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Bind(
                    arg2 => third.Select(
                        arg3 => zipper(arg1, arg2, arg3))));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, TResult}" />
        public static Monad<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Monad<T1> @this,
             Monad<T2> second,
             Monad<T3> third,
             Monad<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Bind(
                    arg2 => third.Bind(
                        arg3 => fourth.Select(
                            arg4 => zipper(arg1, arg2, arg3, arg4)))));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult}" />
        public static Monad<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Monad<T1> @this,
            Monad<T2> second,
            Monad<T3> third,
            Monad<T4> fourth,
            Monad<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(fifth, nameof(fifth));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Bind(
                    arg2 => third.Bind(
                        arg3 => fourth.Bind(
                            arg4 => fifth.Select(
                                arg5 => zipper(arg1, arg2, arg3, arg4, arg5))))));
        }

        #endregion

        #region LINQ dialect

        public static Monad<TResult> Select<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Monad.Of(selector(val)));
        }

        /// <remarks>
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static Monad<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Monad<TSource> @this,
            Func<TSource, Monad<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        #endregion
    }

    // Provides extension methods for Func<T> in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static Monad<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static Monad<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            Monad<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, Monad<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Monad<TMiddle>> @this,
            Func<TMiddle, Monad<TResult>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Monad<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Monad<TResult>> @this,
            Func<TSource, Monad<TMiddle>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<Monad<T>>.
    // T4: EmitEnumerableExtensions().
    public static partial class Monad
    {
        public static Monad<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Monad<TSource>> @this)
            => @this.CollectImpl();

    }
}

namespace Edufun.Haskell.Templates.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<Monad<T>>.
    // You will certainly want to override them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return Monad.Of(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource>(IEnumerable<Monad<TSource>> source)
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

                            return Monad.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }
    }
}

namespace Edufun.Haskell.Templates.Linq
{
    using System;
    using System.Collections.Generic;

    using Edufun.Haskell.Templates;
    using Edufun.Haskell.Templates.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid any confusion.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    // T4: EmitLinqCore().
    public static partial class Qperators
    {
        public static Monad<IEnumerable<TResult>> SelectWith<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> selector)
            => @this.SelectWithImpl(selector);

        public static Monad<IEnumerable<TSource>> WhereBy<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicate)
            => @this.WhereByImpl(predicate);

        public static Monad<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulator)
            => @this.FoldImpl(seed, accumulator);

        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulator,
            Func<Monad<TAccumulate>, bool> predicate)
            => @this.FoldImpl(seed, accumulator, predicate);

        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulator)
            => @this.ReduceImpl(accumulator);

        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulator,
            Func<Monad<TSource>, bool> predicate)
            => @this.ReduceImpl(accumulator, predicate);
    }
}

namespace Edufun.Haskell.Templates.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            return Monad.Of(WhereByIterator(@this, predicate));
        }

        private static IEnumerable<TSource> WhereByIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, Monad<bool>> predicate)
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

                        return Monad.Unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelector)
        {
            Demand.NotNull(resultSelector);
            Demand.NotNull(@this);
            Demand.NotNull(second);

            return @this.Zip(second, resultSelector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulator)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            Monad<TAccumulate> retval = Monad.Of(seed);

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
        internal static Monad<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulator,
            Func<Monad<TAccumulate>, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            Monad<TAccumulate> retval = Monad.Of(seed);

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
        internal static Monad<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulator)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> retval = Monad.Of(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulator,
            Func<Monad<TSource>, bool> predicate)
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

                Monad<TSource> retval = Monad.Of(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    }
}
