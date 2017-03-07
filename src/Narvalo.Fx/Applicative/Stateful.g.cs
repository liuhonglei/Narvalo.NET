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

using _Unit_ = global::Narvalo.Applicative.Unit;

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Narvalo.Internal;

    // Provides a set of static methods for Stateful<T, TState>.
    // T4: EmitHelpers().
    public static partial class Stateful
    {
        public static Stateful<IEnumerable<TSource>, TState> Repeat<TSource, TState>(
            Stateful<TSource, TState> source,
            int count)
        {
            Require.NotNull(source, nameof(source));
            Require.Range(count >= 0, nameof(count));
            return source.Select(val => Enumerable.Repeat(val, count));
        }

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Stateful{T, TState}" /> values.
        /// </summary>
        /// <seealso cref="Stateful.Select{T, TResult, TState}" />
        public static Func<Stateful<T, TState>, Stateful<TResult, TState>> Lift<T, TResult, TState>(
            Func<T, TResult> func)
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Stateful{T, TState}" /> values.
        /// </summary>
        /// <seealso cref="Stateful.Zip{T1, T2, TResult, TState}"/>
        public static Func<Stateful<T1, TState>, Stateful<T2, TState>, Stateful<TResult, TState>>
            Lift<T1, T2, TResult, TState>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Stateful{T, TState}" /> values.
        /// </summary>
        /// <seealso cref="Stateful.Zip{T1, T2, T3, TResult, TState}"/>
        public static Func<Stateful<T1, TState>, Stateful<T2, TState>, Stateful<T3, TState>, Stateful<TResult, TState>>
            Lift<T1, T2, T3, TResult, TState>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Stateful{T, TState}" /> values.
        /// </summary>
        /// <seealso cref="Stateful.Zip{T1, T2, T3, T4, TResult, TState}"/>
        public static Func<Stateful<T1, TState>, Stateful<T2, TState>, Stateful<T3, TState>, Stateful<T4, TState>, Stateful<TResult, TState>>
            Lift<T1, T2, T3, T4, TResult, TState>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Stateful{T, TState}" /> values.
        /// </summary>
        /// <seealso cref="Stateful.Zip{T1, T2, T3, T4, T5, TResult, TState}"/>
        public static Func<Stateful<T1, TState>, Stateful<T2, TState>, Stateful<T3, TState>, Stateful<T4, TState>, Stateful<T5, TState>, Stateful<TResult, TState>>
            Lift<T1, T2, T3, T4, T5, TResult, TState>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for Stateful<T, TState>.
    // T4: EmitExtensions().
    public static partial class Stateful
    {
        /// <seealso cref="Ap.Apply{TSource, TResult, TState}(Stateful{Func{TSource, TResult}, TState}, Stateful{TSource, TState})" />
        public static Stateful<TResult, TState> Gather<TSource, TResult, TState>(
            this Stateful<TSource, TState> @this,
            Stateful<Func<TSource, TResult>, TState> applicative)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        public static Stateful<TResult, TState> ReplaceBy<TSource, TResult, TState>(
            this Stateful<TSource, TState> @this,
            TResult value)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static Stateful<TResult, TState> ContinueWith<TSource, TResult, TState>(
            this Stateful<TSource, TState> @this,
            Stateful<TResult, TState> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static Stateful<TSource, TState> PassThrough<TSource, TOther, TState>(
            this Stateful<TSource, TState> @this,
            Stateful<TOther, TState> other)
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> zipper = (arg, _) => arg;

            return @this.Zip(other, zipper);
        }

        public static Stateful<_Unit_, TState> Skip<TSource, TState>(this Stateful<TSource, TState> @this)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ReplaceBy(_Unit_.Default);
        }

        #region Zip()

        /// <seealso cref="Stateful.Lift{T1, T2, TResult, TState}"/>
        public static Stateful<TResult, TState> Zip<T1, T2, TResult, TState>(
            this Stateful<T1, TState> @this,
            Stateful<T2, TState> second,
            Func<T1, T2, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        /// <seealso cref="Stateful.Lift{T1, T2, T3, TResult, TState}"/>
        public static Stateful<TResult, TState> Zip<T1, T2, T3, TResult, TState>(
            this Stateful<T1, TState> @this,
            Stateful<T2, TState> second,
            Stateful<T3, TState> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
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

        /// <seealso cref="Stateful.Lift{T1, T2, T3, T4, TResult, TState}"/>
        public static Stateful<TResult, TState> Zip<T1, T2, T3, T4, TResult, TState>(
             this Stateful<T1, TState> @this,
             Stateful<T2, TState> second,
             Stateful<T3, TState> third,
             Stateful<T4, TState> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
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

        /// <seealso cref="Stateful.Lift{T1, T2, T3, T4, T5, TResult, TState}"/>
        public static Stateful<TResult, TState> Zip<T1, T2, T3, T4, T5, TResult, TState>(
            this Stateful<T1, TState> @this,
            Stateful<T2, TState> second,
            Stateful<T3, TState> third,
            Stateful<T4, TState> fourth,
            Stateful<T5, TState> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(fifth, nameof(fifth));
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
        public static Stateful<TResult, TState> Using<TSource, TResult, TState>(
            this Stateful<TSource, TState> @this,
            Func<TSource, Stateful<TResult, TState>> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        // Select() with automatic resource management.
        public static Stateful<TResult, TState> Using<TSource, TResult, TState>(
            this Stateful<TSource, TState> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #endregion

        #region Query Expression Pattern

        public static Stateful<TResult, TState> Select<TSource, TResult, TState>(
            this Stateful<TSource, TState> @this,
            Func<TSource, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Stateful.Of<TResult, TState>(selector(val)));
        }

        // Generalizes both Bind() and Zip<T1, T2, TResult>().
        public static Stateful<TResult, TState> SelectMany<TSource, TMiddle, TResult, TState>(
            this Stateful<TSource, TState> @this,
            Func<TSource, Stateful<TMiddle, TState>> valueSelector,
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

    // Provides extension methods for Stateful<Func<TSource, TResult>, TState>.
    // T4: EmitApplicative().
    public static partial class Ap
    {
        /// <seealso cref="Stateful.Gather{TSource, TResult, TState}" />
        public static Stateful<TResult, TState> Apply<TSource, TResult, TState>(
            this Stateful<Func<TSource, TResult>, TState> @this,
            Stateful<TSource, TState> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }
    }

    // Provides extension methods for functions in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static Stateful<IEnumerable<TResult>, TState> InvokeWith<TSource, TResult, TState>(
            this Func<TSource, Stateful<TResult, TState>> @this,
            IEnumerable<TSource> seq)
            => seq.Select(@this).Collect();

        public static Stateful<TResult, TState> InvokeWith<TSource, TResult, TState>(
            this Func<TSource, Stateful<TResult, TState>> @this,
            Stateful<TSource, TState> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, Stateful<TResult, TState>> Compose<TSource, TMiddle, TResult, TState>(
            this Func<TSource, Stateful<TMiddle, TState>> @this,
            Func<TMiddle, Stateful<TResult, TState>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Stateful<TResult, TState>> ComposeBack<TSource, TMiddle, TResult, TState>(
            this Func<TMiddle, Stateful<TResult, TState>> @this,
            Func<TSource, Stateful<TMiddle, TState>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<Stateful<T, TState>>.
    // T4: EmitEnumerableExtensions().
    public static partial class Stateful
    {
        public static Stateful<IEnumerable<TSource>, TState> Collect<TSource, TState>(
            this IEnumerable<Stateful<TSource, TState>> @this)
            => @this.CollectImpl();
    }
}

namespace Narvalo.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.Applicative;

    // Provides default implementations for the extension methods for IEnumerable<Stateful<T, TState>>.
    // You will certainly want to override them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Stateful<IEnumerable<TSource>, TState> CollectImpl<TSource, TState>(
            this IEnumerable<Stateful<TSource, TState>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return Stateful.Of<IEnumerable<TSource>, TState>(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource, TState>(IEnumerable<Stateful<TSource, TState>> source)
        {
            Demand.NotNull(source);

            var unit = Stateful.Of<Unit, TState>(Unit.Default);
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

                            return unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }
    }
}
