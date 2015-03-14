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

namespace Narvalo.Collections 
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx;
    using Narvalo.Collections.Internal;

    /// <summary>
    /// Provides extension methods for <c>IEnumerable&lt;Maybe&lt;T&gt;&gt;</c>.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class EnumerableMaybeExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            // No need to check for null-reference, "CollectCore" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>msum</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TSource> Sum<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            // No need to check for null-reference, "SumCore" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            return @this.SumCore();
        }

        #endregion
    } // End of the class EnumerableMaybeExtensions.

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> funM)
        {
            // No need to check for null-reference, "MapCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TResult>>>() != null);

            return @this.MapCore(funM);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>filterM</c> in Haskell parlance.
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicateM)
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
        public static Maybe<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<Tuple<TFirst, TSecond>>> funM)
        {
            // No need to check for null-reference, "MapAndUnzipCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Maybe<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>>() != null);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Maybe<TResult>> resultSelectorM)
        {
            // No need to check for null-reference, "ZipCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(second != null);
            Contract.Requires(resultSelectorM != null);
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TResult>>>() != null);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Ensures(Contract.Result<Maybe<TAccumulate>>() != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static Maybe<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "FoldBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Ensures(Contract.Result<Maybe<TAccumulate>>() != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static Maybe<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "ReduceBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM,
            Func<Maybe<TAccumulate>, bool> predicate)
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);
            Contract.Ensures(Contract.Result<Maybe<TAccumulate>>() != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM,
            Func<Maybe<TSource>, bool> predicate)
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    } // End of the class EnumerableExtensions.
}

namespace Narvalo.Collections.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using Narvalo.Fx;

    /// <summary>
    /// Provides extension methods for <c>IEnumerable&lt;Maybe&lt;T&gt;&gt;</c>
    /// and <see cref="IEnumerable{T}"/>.
    /// </summary>
    internal static partial class EnumerableMaybeExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            // No need to check for null-reference, "Enumerable.Aggregate" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TSource>>>() != null);

            var seed = Maybe.Create(Enumerable.Empty<TSource>());
            Func<Maybe<IEnumerable<TSource>>, Maybe<TSource>, Maybe<IEnumerable<TSource>>> fun
                = (m, n) => m.Bind(
                    list => 
                    {
                        return n.Bind(item => Maybe.Create(
                            list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun).AssumeNotNull_();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TSource> SumCore<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            // No need to check for null-reference, "Enumerable.Aggregate" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            return @this.Aggregate(Maybe<TSource>.None, (m, n) => m.OrElse(n)).AssumeNotNull_();
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
    } // End of the class EnumerableMaybeExtensions.

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    internal static partial class EnumerableMaybeExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> funM)
        {
            // No need to check for null-reference, "Enumerable.Select" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TResult>>>() != null);

            return @this.Select(funM).AssumeNotNull_().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicateM)
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
                    m.Run(
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
            Justification = "This method has been localy overriden.")]
        internal static Maybe<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<Tuple<TFirst, TSecond>>> funM)
        {
            // No need to check for null-reference, "Enumerable.Select" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Maybe<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>>() != null);

            var m = @this.Select(funM).AssumeNotNull_().Collect();

            return m.Select(
                tuples => 
                {
                    IEnumerable<TFirst> list1 = tuples.Select(_ => _.Item1);
                    IEnumerable<TSecond> list2 = tuples.Select(_ => _.Item2);

                    return new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(list1, list2);
                });
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Maybe<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, "resultSelectorM");
            Contract.Requires(@this != null); // No need to check for null-reference, "Enumerable.Zip" is an extension method. 
            Contract.Requires(second != null);
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TResult>>>() != null);

            Func<TFirst, TSecond, Maybe<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ.
            return @this.Zip(second, resultSelector: resultSelector).AssumeNotNull_().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Contract.Ensures(Contract.Result<Maybe<TAccumulate>>() != null);

            Maybe<TAccumulate> result = Maybe.Create(seed);

            foreach (TSource item in @this) 
            {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Ensures(Contract.Result<Maybe<TAccumulate>>() != null);

            return @this.Reverse().AssumeNotNull_().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            using (var iter = @this.GetEnumerator()) 
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Maybe<TSource> result = Maybe.Create(iter.Current);

                while (iter.MoveNext()) 
                {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            return @this.Reverse().AssumeNotNull_().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM,
            Func<Maybe<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");
            Contract.Ensures(Contract.Result<Maybe<TAccumulate>>() != null);

            Maybe<TAccumulate> result = Maybe.Create(seed);

            using (var iter = @this.GetEnumerator()) 
            {
                while (predicate.Invoke(result) && iter.MoveNext())
                {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static Maybe<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM,
            Func<Maybe<TSource>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            using (var iter = @this.GetEnumerator()) 
            {
                if (!iter.MoveNext()) 
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Maybe<TSource> result = Maybe.Create(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    } // End of the class EnumerableMaybeExtensions.
}
