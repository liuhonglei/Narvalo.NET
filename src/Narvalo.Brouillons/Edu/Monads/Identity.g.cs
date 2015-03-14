﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

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
    Justification = "This rule is disabled for files generated by a Text Template.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1403:FileMayOnlyContainASingleNamespace",
    Justification = "This rule is disabled for files generated by a Text Template.")]
    
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1505:OpeningCurlyBracketsMustNotBeFollowedByBlankLine",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1507:CodeMustNotContainMultipleBlankLinesInARow",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]

[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace",
    Justification = "The directives are correctly ordered in the T4 source file.")]

namespace Narvalo.Edu.Monads 
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;

    /// <summary>
    /// Provides a set of static and extension methods for <see cref="Identity{T}" />.
    /// </summary>
    /// <remarks>
    /// Sometimes we prefer to use extension methods over static methods to be able to locally override them.
    /// </remarks>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class Identity
    {
        private static readonly Identity<global::Narvalo.Fx.Unit> s_Unit = Return(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Identity&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Identity&lt;Unit&gt;</c>.</value>
        public static Identity<global::Narvalo.Fx.Unit> Unit { get { return s_Unit; } }


        /// <summary>
        /// Obtains an instance of the <see cref="Identity{T}"/> class for the specified value.
        /// </summary>
        /// <remarks>
        /// Named <c>return</c> in Haskell parlance.
        /// </remarks>
        /// <typeparam name="T">The underlying type of the <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="Identity{T}"/> object.</param>
        /// <returns>An instance of the <see cref="Identity{T}"/> class for the specified value.</returns>
        public static Identity<T> Return<T>(T value)
        {

            return Identity<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        /// <remarks>
        /// Named <c>join</c> in Haskell parlance.
        /// </remarks>
        public static Identity<T> Flatten<T>(Identity<Identity<T>> square)
        {
            Contract.Requires(square != null);

            return Identity<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM</c> in Haskell parlance.
        /// </remarks>
        public static Func<Identity<T>, Identity<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Identity<T>, Identity<TResult>>>() != null);

            return m => 
            {
                Require.NotNull(m, "m"); // Null-reference check: "Select" could have been overriden by a normal method.
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM2</c> in Haskell parlance.
        /// </remarks>
        public static Func<Identity<T1>, Identity<T2>, Identity<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Identity<T1>, Identity<T2>, Identity<TResult>>>() != null);

            return (m1, m2) => 
            {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM3</c> in Haskell parlance.
        /// </remarks>
        public static Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<TResult>>>() != null);

            return (m1, m2, m3) => 
            {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM4</c> in Haskell parlance.
        /// </remarks>
        public static Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<TResult>>>() != null);
            
            return (m1, m2, m3, m4) => 
            {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM5</c> in Haskell parlance.
        /// </remarks>
        public static Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<T5>, Identity<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<T5>, Identity<TResult>>>() != null);
       
            return (m1, m2, m3, m4, m5) => 
            {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    } // End of the class Identity.

    /// <content>
    /// Provides core Monad extension methods.
    /// </content>
    public static partial class Identity
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>fmap</c> in Haskell parlance.
        /// </remarks>
        public static Identity<TResult> Select<TSource, TResult>(
            this Identity<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => Identity.Return(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Identity<TResult> Then<TSource, TResult>(
            this Identity<TSource> @this,
            Identity<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>replicateM</c> in Haskell parlance.
        /// </remarks>
        public static Identity<IEnumerable<TSource>> Repeat<TSource>(
            this Identity<TSource> @this,
            int count)
        {
            Require.Object(@this); // Null-reference check: "Select" could have been overriden by a normal method.
            Require.GreaterThanOrEqualTo(count, 1, "count");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        /// <remarks>
        /// Named <c>when</c> in Haskell parlance.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static Identity<global::Narvalo.Fx.Unit> When<TSource>(
            this Identity<TSource> @this, 
            bool predicate, 
            Action action)
        {
            Require.NotNull(action, "action");
            Contract.Ensures(Contract.Result<Identity<global::Narvalo.Fx.Unit>>() != null);

            if (predicate) {
                action.Invoke();
            }

            return Identity.Unit;
        }

        /// <remarks>
        /// Named <c>unless</c> in Haskell parlance.
        /// </remarks>
        public static Identity<global::Narvalo.Fx.Unit> Unless<TSource>(
            this Identity<TSource> @this,
            bool predicate,
            Action action)
        {
            Require.Object(@this);
            Contract.Requires(action != null);
            Contract.Ensures(Contract.Result<Identity<global::Narvalo.Fx.Unit>>() != null);

            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static Identity<TResult> Zip<TFirst, TSecond, TResult>(
            this Identity<TFirst> @this,
            Identity<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Select" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Identity<TResult> Zip<T1, T2, T3, TResult>(
            this Identity<T1> @this,
            Identity<T2> second,
            Identity<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Zip" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Identity<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static Identity<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Identity<T1> @this,
             Identity<T2> second,
             Identity<T3> third,
             Identity<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Zip" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Identity<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static Identity<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Identity<T1> @this,
            Identity<T2> second,
            Identity<T3> third,
            Identity<T4> fourth,
            Identity<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Zip" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Identity<TResult>> g
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
        public static Identity<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Identity<TSource> @this,
            Func<TSource, Identity<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
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

        #region Non-standard extensions
        
        public static Identity<TResult> Coalesce<TSource, TResult>(
            this Identity<TSource> @this,
            Func<TSource, bool> predicate,
            Identity<TResult> then,
            Identity<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static Identity<TSource> Run<TSource>(
            this Identity<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }


        #endregion
    } // End of the class Identity.

    /// <summary>
    /// Provides extension methods for <c>Func&lt;TSource, Identity&lt;TResult&gt;&gt;</c>.
    /// </summary>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Identity<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Identity<TResult>> @this,
            Identity<TSource> value)
        {
            Require.NotNull(value, "value");
            Contract.Requires(@this != null);

            return value.Bind(@this);
        }

        /// <remarks>
        /// Named <c>&gt;=&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Identity<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Identity<TMiddle>> @this,
            Func<TMiddle, Identity<TResult>> funM)
        {
            Require.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Func<TSource, Identity<TResult>>>() != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /// <remarks>
        /// Named <c>&lt;=&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Identity<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Identity<TResult>> @this,
            Func<TSource, Identity<TMiddle>> funM)
        {
            Require.NotNull(funM, "funM");
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Func<TSource, Identity<TResult>>>() != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of the class FuncExtensions.
}

namespace Narvalo.Edu.Monads 
{
    using System.Diagnostics.Contracts;

    // Implements core Comonad methods.
    public static partial class Identity
    {
        /// <remarks>
        /// Named <c>extract</c> in Haskell parlance.
        /// </remarks>
        public static T Extract<T>(Identity<T> monad)
        {
            Contract.Requires(monad != null);

            return Identity<T>.ε(monad);
        }

        /// <remarks>
        /// Named <c>duplicate</c> in Haskell parlance.
        /// </remarks>
        public static Identity<Identity<T>> Duplicate<T>(Identity<T> monad)
        {
            return Identity<T>.δ(monad);
        }
    } // End of the class Identity.
}

namespace Narvalo.Edu.Monads 
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Edu.Monads;
    using Narvalo.Edu.Monads.Internal;

    /// <summary>
    /// Provides extension methods for <c>IEnumerable&lt;Identity&lt;T&gt;&gt;</c>.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class EnumerableIdentityExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Identity<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Identity<TSource>> @this)
        {
            // No need to check for null-reference, "CollectCore" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Identity<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }
        
        #endregion
    } // End of the class EnumerableIdentityExtensions.

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance.
        /// </remarks>
        public static Identity<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<TResult>> funM)
        {
            // No need to check for null-reference, "MapCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Identity<IEnumerable<TResult>>>() != null);

            return @this.MapCore(funM);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>filterM</c> in Haskell parlance.
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<bool>> predicateM)
        {
            // No need to check for null-reference, "FilterCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(predicateM != null);
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            return @this.FilterCore(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static Identity<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<Tuple<TFirst, TSecond>>> funM)
        {
            // No need to check for null-reference, "MapAndUnzipCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Identity<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Identity<TResult>> resultSelectorM)
        {
            // No need to check for null-reference, "ZipCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(second != null);
            Contract.Requires(resultSelectorM != null);
            Contract.Ensures(Contract.Result<Identity<IEnumerable<TResult>>>() != null);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Identity<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static Identity<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "FoldBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static Identity<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static Identity<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "ReduceBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static Identity<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM,
            Func<Identity<TAccumulate>, bool> predicate)
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static Identity<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM,
            Func<Identity<TSource>, bool> predicate)
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    } // End of the class EnumerableExtensions.
}

namespace Narvalo.Edu.Monads.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using Narvalo.Edu.Monads;

    /// <summary>
    /// Provides extension methods for <c>IEnumerable&lt;Identity&lt;T&gt;&gt;</c>
    /// and <see cref="IEnumerable{T}"/>.
    /// </summary>
    internal static partial class EnumerableIdentityExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Identity<TSource>> @this)
        {
            // No need to check for null-reference, "Enumerable.Aggregate" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Identity<IEnumerable<TSource>>>() != null);

            var seed = Identity.Return(Enumerable.Empty<TSource>());
            Func<Identity<IEnumerable<TSource>>, Identity<TSource>, Identity<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list => {
                        return n.Bind(item => Identity.Return(
                            list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun).AssumeNotNull_();
        }

        /// <summary>
        /// Instructs code analysis tools to assume that the specified value is not null,
        /// even if it cannot be statically proven to always be not null.
        /// When Code Contracts is disabled, this method is meant to be erased by the JIT compiler.
        /// </summary>
        [DebuggerHidden]
#if !CONTRACTS_FULL
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        private static T AssumeNotNull_<T>(this T @this) where T : class
        {
            Contract.Ensures(Contract.Result<T>() == @this);
            Contract.Ensures(Contract.Result<T>() != null);
            Contract.Assume(@this != null);

            return @this;
        }
    } // End of the class EnumerableIdentityExtensions.

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    internal static partial class EnumerableIdentityExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<TResult>> funM)
        {
            // No need to check for null-reference, "Enumerable.Select" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Identity<IEnumerable<TResult>>>() != null);

            return @this.Select(funM).AssumeNotNull_().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<bool>> predicateM)
        {
            Require.Object(@this);
            Require.NotNull(predicateM, "predicateM");
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this) {
                var m = predicateM.Invoke(item);

                if (m != null) {
                    m.Run(_ => {
                        if (_ == true) {
                            list.Add(item);
                        }
                    });
                }
            }

            return list;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<Tuple<TFirst, TSecond>>> funM)
        {
            // No need to check for null-reference, "Enumerable.Select" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);

            var m = @this.Select(funM).AssumeNotNull_().Collect();

            return m.Select(tuples => {
                IEnumerable<TFirst> list1 = tuples.Select(_ => _.Item1);
                IEnumerable<TSecond> list2 = tuples.Select(_ => _.Item2);

                return new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(list1, list2);
            });
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Identity<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, "resultSelectorM");
            Contract.Requires(@this != null); // No need to check for null-reference, "Enumerable.Zip" is an extension method. 
            Contract.Requires(second != null);
            Contract.Ensures(Contract.Result<Identity<IEnumerable<TResult>>>() != null);

            Func<TFirst, TSecond, Identity<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ.
            return @this.Zip(second, resultSelector: resultSelector).AssumeNotNull_().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Identity<TAccumulate> result = Identity.Return(seed);

            foreach (TSource item in @this) {
                if (result == null) {
                    return null;
                }

                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull_().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Identity<TSource> result = Identity.Return(iter.Current);

                while (iter.MoveNext()) {
                    if (result == null) {
                        return null;
                    }

                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull_().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM,
            Func<Identity<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            Identity<TAccumulate> result = Identity.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                if (result == null) {
                    return null;
                }

                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Identity<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM,
            Func<Identity<TSource>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Identity<TSource> result = Identity.Return(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    if (result == null) {
                        return null;
                    }

                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    } // End of the class EnumerableIdentityExtensions.
}
