﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 15.0
// </auto-generated>
//------------------------------------------------------------------------------

using unit = global::Narvalo.Applicative.Unit;

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Narvalo.Internal;

    // Provides a set of static methods for Outcome<T>.
    // T4: EmitHelpers().
    public partial struct Outcome
    {
        /// <summary>
        /// The unique object of type <c>Outcome&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Outcome<unit> s_Unit = Of(unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>Outcome&lt;Unit&gt;</c>.
        /// </summary>
        public static Outcome<unit> Unit => s_Unit;

        /// <summary>
        /// Obtains an instance of the <see cref="Outcome{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Outcome{T}"/>.</param>
        /// <returns>An instance of the <see cref="Outcome{T}"/> class for the specified value.</returns>
        public static Outcome<T> Of<T>(T value) => Outcome<T>.η(value);

        public static Outcome<IEnumerable<TSource>> Repeat<TSource>(
            Outcome<TSource> source,
            int count)
        {
            /* T4: NotNull(source) */
            Require.Range(count >= 0, nameof(count));
            return source.Select(val => Enumerable.Repeat(val, count));
        }

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values.
        /// </summary>
        /// <seealso cref="OutcomeExtensions.Select{T, TResult}" />
        public static Func<Outcome<T>, Outcome<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            => arg =>
            {
                /* T4: NotNull(arg) */
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values.
        /// </summary>
        /// <seealso cref="OutcomeExtensions.Zip{T1, T2, TResult}"/>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values.
        /// </summary>
        /// <seealso cref="OutcomeExtensions.Zip{T1, T2, T3, TResult}"/>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values.
        /// </summary>
        /// <seealso cref="OutcomeExtensions.Zip{T1, T2, T3, T4, TResult}"/>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<T4>, Outcome<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values.
        /// </summary>
        /// <seealso cref="OutcomeExtensions.Zip{T1, T2, T3, T4, T5, TResult}"/>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<T4>, Outcome<T5>, Outcome<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for Outcome<T>.
    // T4: EmitExtensions().
    public static partial class OutcomeExtensions
    {
        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Outcome<T> Flatten<T>(this Outcome<Outcome<T>> @this)
            => Outcome<T>.μ(@this);

        /// <seealso cref="Ap.Apply{TSource, TResult}(Outcome{Func{TSource, TResult}}, Outcome{TSource})" />
        public static Outcome<TResult> Gather<TSource, TResult>(
            this Outcome<TSource> @this,
            Outcome<Func<TSource, TResult>> applicative)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(applicative) */
            return applicative.Bind(func => @this.Select(func));
        }

        public static Outcome<TResult> ReplaceBy<TSource, TResult>(
            this Outcome<TSource> @this,
            TResult value)
        {
            /* T4: NotNull(@this) */
            return @this.Select(_ => value);
        }

        public static Outcome<TResult> ContinueWith<TSource, TResult>(
            this Outcome<TSource> @this,
            Outcome<TResult> other)
        {
            /* T4: NotNull(@this) */
            return @this.Bind(_ => other);
        }

        public static Outcome<TSource> PassBy<TSource, TOther>(
            this Outcome<TSource> @this,
            Outcome<TOther> other)
        {
            /* T4: NotNull(@this) */
            return @this.Zip(other, (arg, _) => arg);
        }

        public static Outcome<unit> Skip<TSource>(this Outcome<TSource> @this)
        {
            /* T4: NotNull(@this) */
            return @this.ContinueWith(Outcome.Unit);
        }

        #region Zip()

        /// <seealso cref="Outcome.Lift{T1, T2, TResult}"/>
        public static Outcome<TResult> Zip<T1, T2, TResult>(
            this Outcome<T1> @this,
            Outcome<T2> second,
            Func<T1, T2, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        /// <seealso cref="Outcome.Lift{T1, T2, T3, TResult}"/>
        public static Outcome<TResult> Zip<T1, T2, T3, TResult>(
            this Outcome<T1> @this,
            Outcome<T2> second,
            Outcome<T3> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            Require.NotNull(zipper, nameof(zipper));

            // This is the same as:
            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >        arg2 => third.Select(
            // >            arg3 => zipper(arg1, arg2, arg3))));
            // but faster if Zip is locally shadowed.
            return @this.Bind(
                arg1 => second.Zip(
                    third, (arg2, arg3) => zipper(arg1, arg2, arg3)));
        }

        /// <seealso cref="Outcome.Lift{T1, T2, T3, T4, TResult}"/>
        public static Outcome<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Outcome<T1> @this,
             Outcome<T2> second,
             Outcome<T3> third,
             Outcome<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            Require.NotNull(zipper, nameof(zipper));

            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >         arg2 => third.Bind(
            // >             arg3 => fourth.Select(
            // >                 arg4 => zipper(arg1, arg2, arg3, arg4)))));
            return @this.Bind(
                arg1 => second.Zip(
                    third,
                    fourth,
                    (arg2, arg3, arg4) => zipper(arg1, arg2, arg3, arg4)));
        }

        /// <seealso cref="Outcome.Lift{T1, T2, T3, T4, T5, TResult}"/>
        public static Outcome<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Outcome<T1> @this,
            Outcome<T2> second,
            Outcome<T3> third,
            Outcome<T4> fourth,
            Outcome<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            /* T4: NotNull(fifth) */
            Require.NotNull(zipper, nameof(zipper));

            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >         arg2 => third.Bind(
            // >             arg3 => fourth.Bind(
            // >                 arg4 => fifth.Select(
            // >                     arg5 => zipper(arg1, arg2, arg3, arg4, arg5))))));
            return @this.Bind(
                arg1 => second.Zip(
                    third,
                    fourth,
                    fifth,
                    (arg2, arg3, arg4, arg5) => zipper(arg1, arg2, arg3, arg4, arg5)));
        }

        #endregion

        #region Resource management

        // Bind() with automatic resource management.
        public static Outcome<TResult> Using<TSource, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, Outcome<TResult>> binder)
            where TSource : IDisposable
        {
            /* T4: NotNull(@this) */
            Require.NotNull(binder, nameof(binder));
            return @this.Bind(val => { using (val) { return binder(val); } });
        }

        // Select() with automatic resource management.
        public static Outcome<TResult> Using<TSource, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #endregion

        #region Query Expression Pattern

        public static Outcome<TResult> Select<TSource, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, TResult> selector)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Outcome<TResult>.η(selector(val)));
        }

        // Generalizes both Bind() and Zip<T1, T2, TResult>().
        public static Outcome<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, Outcome<TMiddle>> selector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => selector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        #endregion
    }

    // Provides extension methods for Outcome<Func<TSource, TResult>>.
    // T4: EmitApplicative().
    public static partial class Ap
    {
        /// <seealso cref="OutcomeExtensions.Gather{TSource, TResult}" />
        public static Outcome<TResult> Apply<TSource, TResult>(
            this Outcome<Func<TSource, TResult>> @this,
            Outcome<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Gather(@this);
        }
    }

    // Provides extension methods for functions in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static Outcome<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, Outcome<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.Select(@this).Collect();

        public static Outcome<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, Outcome<TResult>> @this,
            Outcome<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Bind(@this);
        }

        public static Func<TSource, Outcome<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Outcome<TMiddle>> @this,
            Func<TMiddle, Outcome<TResult>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Outcome<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Outcome<TResult>> @this,
            Func<TSource, Outcome<TMiddle>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<Outcome<T>>.
    // T4: EmitEnumerableExtensions().
    public static partial class OutcomeExtensions
    {
        public static IEnumerable<TSource> CollectAny<TSource>(
            this IEnumerable<Outcome<TSource>> source)
        {
            Require.NotNull(source, nameof(source));
            return source.CollectAnyImpl();
        }

        // Hidden because this operator is not composable.
        // Do not disable, we use it in Kleisli.InvokeWith().
        internal static Outcome<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Outcome<TSource>> source)
        {
            Require.NotNull(source, nameof(source));
            return source.CollectImpl();
        }
    }
}

namespace Narvalo.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.Applicative;

    // Provides default implementations for the extension methods for IEnumerable<Outcome<T>>.
    // You will certainly want to shadow them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> CollectAnyImpl<TSource>(
            this IEnumerable<Outcome<TSource>> source)
        {
            Debug.Assert(source != null);

            var item = default(TSource);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool append = false;
                    var current = iter.Current;

                    current.Bind(val =>
                    {
                        append = true;
                        item = val;

                        return Outcome.Unit;
                    });

                    if (append) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Outcome<TSource>> source)
        {
            Debug.Assert(source != null);
            return Outcome<IEnumerable<TSource>>.η(CollectAnyImpl(source));
        }
    }
}

namespace Narvalo.Linq.Applicative
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Applicative;
    using Narvalo.Internal;

    // Provides extension methods for IEnumerable<T>.
    // T4: EmitLinqCore().
    public static partial class Kperators
    {
        public static IEnumerable<TResult> SelectAny<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Outcome<TResult>> selector)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(selector, nameof(selector));
            return source.SelectAnyImpl(selector);
        }

        public static IEnumerable<TSource> WhereAny<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Outcome<bool>> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(predicate, nameof(predicate));
            return source.WhereAnyImpl(predicate);
        }

        public static Outcome<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            return source.FoldImpl(seed, accumulator);
        }

        public static Outcome<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulator,
            Func<Outcome<TAccumulate>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));
            return source.FoldImpl(seed, accumulator, predicate);
        }

        public static Outcome<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Outcome<TSource>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            return source.ReduceImpl(accumulator);
        }

        public static Outcome<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Outcome<TSource>> accumulator,
            Func<Outcome<TSource>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));
            return source.ReduceImpl(accumulator, predicate);
        }
    }
}

namespace Narvalo.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.Applicative;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to shadow them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TResult> SelectAnyImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Outcome<TResult>> selector)
        {
            Debug.Assert(source != null);
            Debug.Assert(selector != null);

            var result = default(TResult);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool append = false;

                    var item = selector(iter.Current);

                    item.Bind(val =>
                    {
                        append = true;
                        result = val;

                        return Outcome.Unit;
                    });

                    if (append) { yield return result; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> WhereAnyImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Outcome<bool>> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(predicate != null);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource current = iter.Current;

                    var item = predicate(current);

                    item.Bind(val =>
                    {
                        pass = val;

                        return Outcome.Unit;
                    });

                    if (pass) { yield return current; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulator)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);

            Outcome<TAccumulate> retval = Outcome<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulator,
            Func<Outcome<TAccumulate>, bool> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);
            Debug.Assert(predicate != null);

            Outcome<TAccumulate> retval = Outcome<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
            {
                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Outcome<TSource>> accumulator)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Outcome<TSource> retval = Outcome<TSource>.η(iter.Current);

                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Outcome<TSource>> accumulator,
            Func<Outcome<TSource>, bool> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);
            Debug.Assert(predicate != null);

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Outcome<TSource> retval = Outcome<TSource>.η(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    }
}
