﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.34209
// </auto-generated>
//------------------------------------------------------------------------------

using global::System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
    Justification = "This is disabled for files generated by a Text Template.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1403:FileMayOnlyContainASingleNamespace",
    Justification = "This is disabled for files generated by a Text Template.")]
    
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1505:OpeningCurlyBracketsMustNotBeFollowedByBlankLine",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1507:CodeMustNotContainMultipleBlankLinesInARow",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]

[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace",
    Justification = "Actual namespaces are not known in advance.")]

namespace Narvalo.Edu.Monads.Samples {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    /// <summary>
    /// Provides a set of static methods and extension methods for <see cref="MonadZero{T}" />.
    /// </summary>
    public static partial class MonadZero
    {
        static readonly MonadZero<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);
        static readonly MonadZero<Unit> Zero_ = MonadZero<Unit>.Zero;

        /// <summary>
        /// Returns the unique object of type <c>MonadZero&lt;Unit&gt;</c>.
        /// </summary>
        public static MonadZero<Unit> Unit { get { return Unit_; } }

        /*!
         * Named `mzero` in Haskell parlance.
         */

        /// <summary>
        /// Returns the zero of type <c>MonadZero&lt;Unit&gt;.Zero</c>.
        /// </summary>
        public static MonadZero<Unit> Zero { get { return Zero_; } }

        /*!
         * Named `return` in Haskell parlance.
         */

        /// <summary>
        /// Returns a new instance of <see cref="MonadZero{T}" />.
        /// </summary>
        public static MonadZero<T> Return<T>(T value)
        {
            return MonadZero<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /*!
         * Named `join` in Haskell parlance.
         */

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static MonadZero<T> Flatten<T>(MonadZero<MonadZero<T>> square)
        {
            Contract.Requires(square != null);

            return MonadZero<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /*!
         * Named `liftM` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadZero{T}" /> values.
        /// </summary>
        public static Func<MonadZero<T>, MonadZero<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
        {
            return m =>
            {
                Require.NotNull(m, "m");
                return m.Select(fun);
            };
        }

        /*!
         * Named `liftM2` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadZero{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            return (m1, m2) => 
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, fun);
            };
        }

        /*!
         * Named `liftM3` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadZero{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<T3>, MonadZero<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            return (m1, m2, m3) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, fun);
            };
        }

        /*!
         * Named `liftM4` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadZero{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<T3>, MonadZero<T4>, MonadZero<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            return (m1, m2, m3, m4) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /*!
         * Named `liftM5` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadZero{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<T3>, MonadZero<T4>, MonadZero<T5>, MonadZero<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
        {
            return (m1, m2, m3, m4, m5) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    }

    /*!
     * Extensions methods for MonadZero<T>.
     */
    public static partial class MonadZero
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `fmap` in Haskell parlance.
         */
        public static MonadZero<TResult> Select<TSource, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => MonadZero.Return(selector.Invoke(_)));
        }

        /*!
         * Named `>>` in Haskell parlance.
         */
        public static MonadZero<TResult> Then<TSource, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /*!
         * Named `mfilter` in Haskell parlance.
         */
        public static MonadZero<TSource> Where<TSource>(
            this MonadZero<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(
                _ => predicate.Invoke(_) ? @this : MonadZero<TSource>.Zero);
        }

        /*!
         * Named `replicateM` in Haskell parlance.
         */
        public static MonadZero<IEnumerable<TSource>> Repeat<TSource>(
            this MonadZero<TSource> @this,
            int count)
        {
            Require.Object(@this);
            Require.GreaterThanOrEqualTo(count, 1, "count");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        /*!
         * Named `guard` in Haskell parlance.
         */
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static MonadZero<Unit> Guard<TSource>(
            this MonadZero<TSource> @this,
            bool predicate)
        {
            return predicate ? MonadZero.Unit : MonadZero.Zero;
        }

        /*!
         * Named `when` in Haskell parlance.
         */
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static MonadZero<Unit> When<TSource>(
            this MonadZero<TSource> @this, 
            bool predicate, 
            Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return MonadZero.Unit;
        }

        /*!
         * Named `unless` in Haskell parlance.
         */
        public static MonadZero<Unit> Unless<TSource>(
            this MonadZero<TSource> @this,
            bool predicate,
            Action action)
        {
            Require.Object(@this);
            Contract.Requires(action != null);

            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static MonadZero<TResult> Zip<TFirst, TSecond, TResult>(
            this MonadZero<TFirst> @this,
            MonadZero<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static MonadZero<TResult> Zip<T1, T2, T3, TResult>(
            this MonadZero<T1> @this,
            MonadZero<T2> second,
            MonadZero<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadZero<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static MonadZero<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadZero<T1> @this,
             MonadZero<T2> second,
             MonadZero<T3> third,
             MonadZero<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadZero<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static MonadZero<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadZero<T1> @this,
            MonadZero<T2> second,
            MonadZero<T3> third,
            MonadZero<T4> fourth,
            MonadZero<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadZero<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    fifth,
                    (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        /*!
         * Kind of generalisation of Zip (liftM2).
         */
        public static MonadZero<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, MonadZero<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }

        public static MonadZero<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
        {
            Require.Object(@this);
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(resultSelector != null);

            return @this.Join(
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);
        }

        public static MonadZero<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadZero<TInner>, TResult> resultSelector)
        {
            Require.Object(@this);
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(resultSelector != null);

            return @this.GroupJoin(
                inner, 
                outerKeySelector,
                innerKeySelector, 
                resultSelector, 
                EqualityComparer<TKey>.Default);
        }

        #endregion
        
        #region Linq extensions

        public static MonadZero<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Contract.Requires(@this != null);
            Contract.Requires(resultSelector != null);
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);

            return JoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }

        public static MonadZero<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadZero<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Contract.Requires(@this != null);
            Contract.Requires(resultSelector != null);
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);

            return GroupJoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }
        
        static MonadZero<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
            MonadZero<TSource> seq,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(seq, "seq");
            Require.NotNull(resultSelector, "resultSelector");
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(comparer != null);
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        static MonadZero<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
            MonadZero<TSource> seq,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadZero<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(seq, "seq");
            Require.NotNull(resultSelector, "resultSelector");
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(comparer != null);

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        static Func<TSource, MonadZero<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(inner, "inner");
            Require.NotNull(outerKeySelector, "outerKeySelector");
            DebugCheck.NotNull(comparer);

            return source =>
            {
                TKey outerKey = outerKeySelector.Invoke(source);
            
                return inner.Select(innerKeySelector).Where(_ => comparer.Equals(_, outerKey));
            };
        }

        #endregion

        #region Non-standard extensions
        
        public static MonadZero<TResult> Coalesce<TSource, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, bool> predicate,
            MonadZero<TResult> then,
            MonadZero<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

        public static MonadZero<TResult> Then<TSource, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, bool> predicate,
            MonadZero<TResult> other)
        {
            Require.Object(@this);
            Contract.Requires(predicate != null);

            return @this.Coalesce(predicate, other, MonadZero<TResult>.Zero);
        }

        public static MonadZero<TResult> Otherwise<TSource, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, bool> predicate,
            MonadZero<TResult> other)
        {
            Require.Object(@this);
            Contract.Requires(predicate != null);

            return @this.Coalesce(predicate, MonadZero<TResult>.Zero, other);
        }

        public static MonadZero<TSource> Run<TSource>(
            this MonadZero<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static MonadZero<TSource> OnZero<TSource>(
            this MonadZero<TSource> @this,
            Action action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Then(MonadZero.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }

    /*!
     * Extensions methods for Func<TSource, MonadZero<TResult>>.
     */
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `=<<` in Haskell parlance.
         */
        public static MonadZero<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadZero<TResult>> @this,
            MonadZero<TSource> value)
        {
            Require.NotNull(value, "value");
            Contract.Requires(@this != null);

            return value.Bind(@this);
        }

        /*!
         * Named `>=>` in Haskell parlance.
         */
        public static Func<TSource, MonadZero<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadZero<TMiddle>> @this,
            Func<TMiddle, MonadZero<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /*!
         * Named `<=<` in Haskell parlance.
         */
        public static Func<TSource, MonadZero<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadZero<TResult>> @this,
            Func<TSource, MonadZero<TMiddle>> funM)
        {
            Require.NotNull(funM, "funM");

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}

namespace Narvalo.Edu.Monads.Samples {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Monads.Samples;
    using Narvalo.Edu.Monads.Samples.Internal;

    /*!
     * Extensions for IEnumerable<MonadZero<T>>.
     */
    public static partial class EnumerableMonadZeroExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `sequence` in Haskell parlance.
         */
        public static MonadZero<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<MonadZero<TSource>> @this)
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<MonadZero<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }
        
        #endregion
    }

    // Extensions for IEnumerable<T>.
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance.
        /// </remarks>
        public static MonadZero<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<TResult>> funM)
        {
            Require.Object(@this);

            return @this.MapCore(funM);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>filterM</c> in Haskell parlance.
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<bool>> predicateM)
        {
            Require.Object(@this);
            Contract.Requires(predicateM != null);

            return @this.FilterCore(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static MonadZero<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<Tuple<TFirst, TSecond>>> funM)
        {
            Require.Object(@this);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static MonadZero<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadZero<TResult>> resultSelectorM)
        {
            Require.Object(@this);
            Contract.Requires(resultSelectorM != null);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static MonadZero<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static MonadZero<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM)
        {
             Require.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static MonadZero<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Contract.Requires(accumulatorM != null);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static MonadZero<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static MonadZero<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM,
            Func<MonadZero<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static MonadZero<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM,
            Func<MonadZero<TSource>, bool> predicate)
        {
            Require.Object(@this);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    }
}

namespace Narvalo.Edu.Monads.Samples.Internal {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Monads.Samples;

    /*!
     * Internal extensions for IEnumerable<MonadZero<T>>.
     */
    static partial class EnumerableMonadZeroExtensions
    {
        internal static MonadZero<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<MonadZero<TSource>> @this)
        {
            DebugCheck.NotNull(@this);
            Contract.Ensures(Contract.Result<MonadZero<IEnumerable<TSource>>>() != null);

            var seed = MonadZero.Return(Enumerable.Empty<TSource>());
            Func<MonadZero<IEnumerable<TSource>>, MonadZero<TSource>, MonadZero<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => MonadZero.Return(
                            list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun).AssumeNotNull();
        }
    }

    // Internal extensions for IEnumerable<T>.
    static partial class EnumerableExtensions
    {
        internal static MonadZero<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<TResult>> funM)
        {
            DebugCheck.NotNull(@this);

            return @this.Select(funM).AssumeNotNull().Collect();
        }

        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<bool>> predicateM)
        {
            Require.NotNull(predicateM, "predicateM");
            DebugCheck.NotNull(@this);

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this) {
                predicateM.Invoke(item)
                    .Run(_ =>
                    {
                        if (_ == true) {
                            list.Add(item);
                        }
                    });
            }

            return list;
        }

        internal static MonadZero<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<Tuple<TFirst, TSecond>>> funM)
        {
            DebugCheck.NotNull(@this);

            return from tuple in @this.Select(funM).AssumeNotNull().Collect()
                   let item1 = tuple.Select(_ => _.Item1)
                   let item2 = tuple.Select(_ => _.Item2)
                   select new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(item1, item2);
        }

        internal static MonadZero<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadZero<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, "resultSelectorM");
            DebugCheck.NotNull(@this);

            Func<TFirst, TSecond, MonadZero<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call
            // instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).AssumeNotNull().Collect();
        }

        internal static MonadZero<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM)
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            DebugCheck.NotNull(@this);

            MonadZero<TAccumulate> result = MonadZero.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        internal static MonadZero<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull().Fold(seed, accumulatorM);
        }

        internal static MonadZero<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM)
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            DebugCheck.NotNull(@this);

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadZero<TSource> result = MonadZero.Return(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        internal static MonadZero<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull().Reduce(accumulatorM);
        }

        internal static MonadZero<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM,
            Func<MonadZero<TAccumulate>, bool> predicate)
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");
            DebugCheck.NotNull(@this);

            MonadZero<TAccumulate> result = MonadZero.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        internal static MonadZero<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM,
            Func<MonadZero<TSource>, bool> predicate)
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");
            DebugCheck.NotNull(@this);

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadZero<TSource> result = MonadZero.Return(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    }
}
