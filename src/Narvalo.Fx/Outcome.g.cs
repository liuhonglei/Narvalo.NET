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
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using Narvalo.Fx.Internal;

    /// <content>
    /// Provides a set of static methods for <see cref="Outcome{T}" />.
    /// </content>
    /// <remarks>
    /// Sometimes we prefer to use extension methods over static methods to be able to override them locally.
    /// </remarks>
    public static partial class Outcome
    {
        /// <summary>
        /// The unique object of type <c>Outcome&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Outcome<global::Narvalo.Fx.Unit> s_Unit = Success(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Outcome&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Outcome&lt;Unit&gt;</c>.</value>
        public static Outcome<global::Narvalo.Fx.Unit> Unit
        {
            get
            {
                Contract.Ensures(Contract.Result<Outcome<global::Narvalo.Fx.Unit>>() != null);

                return s_Unit;
            }
        }


        /// <summary>
        /// Obtains an instance of the <see cref="Outcome{T}"/> class for the specified value.
        /// </summary>
        /// <remarks>
        /// Named <c>return</c> in Haskell parlance.
        /// </remarks>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="Outcome{T}"/> object.</param>
        /// <returns>An instance of the <see cref="Outcome{T}"/> class for the specified value.</returns>
        public static Outcome<T> Success<T>(T value)
            /* T4: C# indent */
        {
            Contract.Ensures(Contract.Result<Outcome<T>>() != null);

            return Outcome<T>.η(value);
        }

        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        /// <remarks>
        /// Named <c>join</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<T> Flatten<T>(Outcome<Outcome<T>> square)
            /* T4: C# indent */
        {
            Contract.Requires(square != null);

            return Outcome<T>.μ(square);
        }

        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM</c> in Haskell parlance.
        /// </remarks>
        public static Func<Outcome<T>, Outcome<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
            /* T4: C# indent */
        {
            Contract.Ensures(Contract.Result<Func<Outcome<T>, Outcome<TResult>>>() != null);

            return m =>
            {
                Require.NotNull(m, "m");
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM2</c> in Haskell parlance.
        /// </remarks>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
            /* T4: C# indent */
        {
            Contract.Ensures(Contract.Result<Func<Outcome<T1>, Outcome<T2>, Outcome<TResult>>>() != null);

            return (m1, m2) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM3</c> in Haskell parlance.
        /// </remarks>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
            /* T4: C# indent */
        {
            Contract.Ensures(Contract.Result<Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<TResult>>>() != null);

            return (m1, m2, m3) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM4</c> in Haskell parlance.
        /// </remarks>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<T4>, Outcome<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
            /* T4: C# indent */
        {
            Contract.Ensures(Contract.Result<Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<T4>, Outcome<TResult>>>() != null);

            return (m1, m2, m3, m4) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Outcome{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM5</c> in Haskell parlance.
        /// </remarks>
        public static Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<T4>, Outcome<T5>, Outcome<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
            /* T4: C# indent */
        {
            Contract.Ensures(Contract.Result<Func<Outcome<T1>, Outcome<T2>, Outcome<T3>, Outcome<T4>, Outcome<T5>, Outcome<TResult>>>() != null);

            return (m1, m2, m3, m4, m5) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    } // End of Outcome.

    /// <content>
    /// Provides the core monadic extension methods for <see cref="Outcome{T}" />.
    /// </content>
    public static partial class Outcome
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>fmap</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<TResult> Select<TSource, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => Outcome.Success(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<TResult> Then<TSource, TResult>(
            this Outcome<TSource> @this,
            Outcome<TResult> other)
            /* T4: C# indent */
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }

        /// <remarks>
        /// Named <c>forever</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<TResult> Forever<TSource, TResult>(
            this Outcome<TSource> @this,
            Func<Outcome<TResult>> fun
            )
            /* T4: C# indent */
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Outcome<TResult>>() != null);

            // http://stackoverflow.com/questions/24042977/how-does-forever-monad-work

            return @this.Then(@this.Forever(fun));
        }

        /// <remarks>
        /// Named <c>void</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<global::Narvalo.Fx.Unit> Forget<TSource>(this Outcome<TSource> @this)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Outcome<global::Narvalo.Fx.Unit>>() != null);

            return Outcome.Unit;
        }

        #endregion

        #region Generalisations of list functions (Prelude)


        /// <remarks>
        /// Named <c>replicateM</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<IEnumerable<TSource>> Repeat<TSource>(
            this Outcome<TSource> @this,
            int count)
        {
            Require.Object(@this);
            Require.GreaterThanOrEqualTo(count, 1, "count");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }


        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static Outcome<TResult> Zip<TFirst, TSecond, TResult>(
            this Outcome<TFirst> @this,
            Outcome<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Outcome<TResult> Zip<T1, T2, T3, TResult>(
            this Outcome<T1> @this,
            Outcome<T2> second,
            Outcome<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Outcome<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static Outcome<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Outcome<T1> @this,
             Outcome<T2> second,
             Outcome<T3> third,
             Outcome<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Outcome<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth,
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static Outcome<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Outcome<T1> @this,
            Outcome<T2> second,
            Outcome<T3> third,
            Outcome<T4> fourth,
            Outcome<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Outcome<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth,
                    fifth,
                    (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        /// <remarks>
        /// Kind of generalisation of Zip (liftM2).
        /// </remarks>
        public static Outcome<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, Outcome<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }


        #endregion

        #region LINQ extensions


        #endregion
    } // End of Outcome.

    /// <content>
    /// Provides non-standard extension methods for <see cref="Outcome{T}" />.
    /// </content>
    public static partial class Outcome
    {
        public static Outcome<TResult> Coalesce<TSource, TResult>(
            this Outcome<TSource> @this,
            Func<TSource, bool> predicate,
            Outcome<TResult> then,
            Outcome<TResult> otherwise)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static Outcome<TSource> When<TSource>(
            this Outcome<TSource> @this,
            bool predicate,
            Action action)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(action, "action");
            Contract.Ensures(Contract.Result<Outcome<TSource>>() != null);

            if (predicate) { action.Invoke(); }

            return @this;
        }

        public static Outcome<TSource> Unless<TSource>(
            this Outcome<TSource> @this,
            bool predicate,
            Action action)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(action != null);
            Contract.Ensures(Contract.Result<Outcome<TSource>>() != null);

            return @this.When(!predicate, action);
        }

        public static Outcome<TSource> Invoke<TSource>(
            this Outcome<TSource> @this,
            Action<TSource> action)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(action, "action");
            Contract.Ensures(Contract.Result<Outcome<TSource>>() != null);

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

    } // End of Outcome.

    /// <content>
    /// Provides extension methods for <see cref="Func{T}"/> in the Kleisli category.
    /// </content>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance. Same as <c>forM</c> with its arguments flipped.
        /// </remarks>
        public static Outcome<IEnumerable<TResult>> Map<TSource, TResult>(
            this Func<TSource, Outcome<TResult>> @this,
            IEnumerable<TSource> seq)
        {
            Acknowledge.Object(@this);
            Contract.Requires(seq != null);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TResult>>>() != null);

            return seq.ForEachCore(@this);
        }


        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Outcome<TResult>> @this,
            Outcome<TSource> value)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Require.NotNull(value, "value");

            return value.Bind(@this);
        }

        /// <remarks>
        /// Named <c>&gt;=&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Outcome<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Outcome<TMiddle>> @this,
            Func<TMiddle, Outcome<TResult>> funM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Func<TSource, Outcome<TResult>>>() != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /// <remarks>
        /// Named <c>&lt;=&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Outcome<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Outcome<TResult>> @this,
            Func<TSource, Outcome<TMiddle>> funM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Require.NotNull(funM, "funM");
            Contract.Ensures(Contract.Result<Func<TSource, Outcome<TResult>>>() != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of FuncExtensions.
}

namespace Narvalo.Fx
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx.Internal;

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> where <c>T</c> is a <see cref="Outcome{S}"/>.
    /// </content>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Outcome<TSource>> @this)
        {
            Acknowledge.Object(@this);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }


        #endregion

    } // End of EnumerableExtensions.
}

namespace Narvalo.Fx.Advanced
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx;
    using Narvalo.Fx.Internal;

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>forM</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<IEnumerable<TResult>> ForEach<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<TResult>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TResult>>>() != null);

            return @this.ForEachCore(funM);
        }


        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// <para>Named <c>filterM</c> in Haskell parlance.</para>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<bool>> predicateM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(predicateM != null);
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            return @this.FilterCore(predicateM);
        }


        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<Tuple<TFirst, TSecond>>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Outcome<TResult>> resultSelectorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(second != null);
            Contract.Requires(resultSelectorM != null);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TResult>>>() != null);

            return @this.ZipCore(second, resultSelectorM);
        }


        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Outcome<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion

        #region Aggregate Operators

        public static Outcome<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static Outcome<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Outcome<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceCore(accumulatorM);
        }

        public static Outcome<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Outcome<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Outcome<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulatorM,
            Func<Outcome<TAccumulate>, bool> predicate)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Outcome<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Outcome<TSource>> accumulatorM,
            Func<Outcome<TSource>, bool> predicate)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    } // End of EnumerableExtensions.
}

namespace Narvalo.Fx.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using global::Narvalo.Fx; // Required for EmptyIfNull().
    using Narvalo.Fx.Advanced;

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/> where <c>T</c> is a <see cref="Maybe{S}"/>.
    /// </content>
    internal static partial class EnumerableExtensions
    {


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Outcome<TSource>> @this)
        {
            Acknowledge.Object(@this);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TSource>>>() != null);

            var seed = Outcome.Success(Enumerable.Empty<TSource>());
            Func<Outcome<IEnumerable<TSource>>, Outcome<TSource>, Outcome<IEnumerable<TSource>>> fun
                = (m, n) => m.Bind(list => CollectCore(n, list));

            var retval = @this.Aggregate(seed, fun);
            Contract.Assume(retval != null);

            return retval;
        }

        // NB: We do not inline this method to avoid the creation of an unused private field (CA1823 warning).
        private static Outcome<IEnumerable<TSource>> CollectCore<TSource>(
            Outcome<TSource> m,
            IEnumerable<TSource> list)
        {
            Contract.Requires(m != null);

            return m.Bind(item => Outcome.Success(list.Concat(Enumerable.Repeat(item, 1))));
        }

    } // End of EnumerableExtensions.

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    internal static partial class EnumerableExtensions
    {


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<IEnumerable<TResult>> ForEachCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<TResult>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TResult>>>() != null);

            return @this.Select(funM).EmptyIfNull().Collect();
        }


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<bool>> predicateM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(predicateM, "predicateM");
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this)
            {
                var m = predicateM.Invoke(item);

                if (m != null)
                {
                    m.Invoke(
                        _ =>
                        {
                            if (_ == true)
                            {
                                list.Add(item);
                            }
                        });
                }
            }

            return list;
        }


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<Tuple<TFirst, TSecond>>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);

            var m = @this.Select(funM).EmptyIfNull().Collect();

            return m.Select(
                tuples =>
                {
                    IEnumerable<TFirst> list1 = tuples.Select(_ => _.Item1);
                    IEnumerable<TSecond> list2 = tuples.Select(_ => _.Item2);

                    return new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(list1, list2);
                });
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Outcome<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Acknowledge.Object(@this);
            Contract.Requires(second != null);
            Contract.Ensures(Contract.Result<Outcome<IEnumerable<TResult>>>() != null);

            Func<TFirst, TSecond, Outcome<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ.
            return @this.Zip(second, resultSelector: resultSelector).EmptyIfNull().Collect();
        }


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Outcome<TAccumulate> retval = Outcome.Success(seed);

            foreach (TSource item in @this)
            {
                if (retval == null)
                {
                    return null;
                }

                retval = retval.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().EmptyIfNull().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Outcome<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Outcome<TSource> retval = Outcome.Success(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null)
                    {
                        return null;
                    }

                    retval = retval.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Outcome<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().EmptyIfNull().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Outcome<TAccumulate>> accumulatorM,
            Func<Outcome<TAccumulate>, bool> predicate)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            Outcome<TAccumulate> retval = Outcome.Success(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    if (retval == null)
                    {
                        return null;
                    }

                    retval = retval.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Outcome<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Outcome<TSource>> accumulatorM,
            Func<Outcome<TSource>, bool> predicate)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Outcome<TSource> retval = Outcome.Success(iter.Current);

                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    if (retval == null)
                    {
                        return null;
                    }

                    retval = retval.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return retval;
            }
        }
    } // End of EnumerableExtensions.
}
