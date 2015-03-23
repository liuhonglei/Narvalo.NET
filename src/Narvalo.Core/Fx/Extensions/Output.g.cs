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

// See http://msdn.microsoft.com/en-us/library/ms244717.aspx for an explanation 
// of the effect of the SuppressMessage attribute at module scope.
// This suppresses the corresponding warnings for the code inside the generated file.
// We either favour T4 readibility over StyleCop rules or disable rules that do not make sense 
// for files generated by a Text Template.
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess",
    Justification = "[GeneratedCode] Elements are correctly ordered in the T4 source file.")]
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace",
    Justification = "[GeneratedCode] Directives are correctly ordered in the T4 source file.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
    Justification = "[GeneratedCode] A T4 template may contain multiple classes.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1403:FileMayOnlyContainASingleNamespace",
    Justification = "[GeneratedCode] A T4 template may contain multiple namespaces.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1505:OpeningCurlyBracketsMustNotBeFollowedByBlankLine",
    Justification = "[GeneratedCode] Newline rules are disabled for T4 templates.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1507:CodeMustNotContainMultipleBlankLinesInARow",
    Justification = "[GeneratedCode] Newline rules are disabled for T4 templates.")]

namespace Narvalo.Fx.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx;
    using Narvalo.Fx.Extensions.Internal;

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> that depend on the <see cref="Output{T}"/> class..
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class EnumerableOutputExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Output<TSource>> @this)
        {
            // No need to check for null-reference, "CollectCore" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }

        #endregion
    } // End of the class EnumerableOutputExtensions.

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    public static partial class EnumerableOutputExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<TResult>> funM)
        {
            // No need to check for null-reference, "MapCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            return @this.MapCore(funM);
        }

        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// <para>Named <c>filterM</c> in Haskell parlance.</para>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<bool>> predicateM)
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
        public static Output<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<Tuple<TFirst, TSecond>>> funM)
        {
            // No need to check for null-reference, "MapAndUnzipCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Output<TResult>> resultSelectorM)
        {
            // No need to check for null-reference, "ZipCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(second != null);
            Contract.Requires(resultSelectorM != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Output<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion

        #region Aggregate Operators
        
        public static Output<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "FoldBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }
        
        public static Output<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceCore(accumulatorM);
        }
        
        public static Output<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "ReduceBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Output<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM,
            Func<Output<TAccumulate>, bool> predicate)
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Output<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM,
            Func<Output<TSource>, bool> predicate)
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    } // End of the class EnumerableOutputExtensions.
}

namespace Narvalo.Fx.Extensions.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using Narvalo.Fx;

    /// <summary>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/> that depend on the <see cref="Output{T}"/> class.
    /// </summary>
    internal static partial class EnumerableOutputExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Output<TSource>> @this)
        {
            // No need to check for null-reference, "Enumerable.Aggregate" is an extension method.
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TSource>>>() != null);

            var seed = Output.Success(Enumerable.Empty<TSource>());
            Func<Output<IEnumerable<TSource>>, Output<TSource>, Output<IEnumerable<TSource>>> fun
                = (m, n) => m.Bind(list => CollectCore_(n, list));

            return @this.Aggregate(seed, fun).AssumeNotNull_();
        }
        
        // NB: We do not inline this method to avoid the creation of an unused private field (CA1823 warning).
        private static Output<IEnumerable<TSource>> CollectCore_<TSource>(
            Output<TSource> m, 
            IEnumerable<TSource> list)
        {
            Contract.Requires(m != null);

            return m.Bind(item => Output.Success(list.Concat(Enumerable.Repeat(item, 1))));
        }

        /// <summary>
        /// Instructs code analysis tools to assume that the specified value is not null,
        /// even if it cannot be statically proven not to be <see langword="null"/>.
        /// Inlining the method should remove any performance concern.
        /// </summary>
        [DebuggerHidden]
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private static T AssumeNotNull_<T>(this T @this) where T : class
        {
            Contract.Ensures(Contract.Result<T>() == @this);
            Contract.Ensures(Contract.Result<T>() != null);
            Contract.Assume(@this != null, "'this' is null.");

            return @this;
        }
    } // End of the class EnumerableOutputExtensions.

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    internal static partial class EnumerableOutputExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<TResult>> funM)
        {
            // No need to check for null-reference, "Enumerable.Select" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            return @this.Select(funM).AssumeNotNull_().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<bool>> predicateM)
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
                    m.Apply(
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
        internal static Output<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<Tuple<TFirst, TSecond>>> funM)
        {
            // No need to check for null-reference, "Enumerable.Select" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(funM != null);

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
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Output<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, "resultSelectorM");

            // No need to check for null-reference, "Enumerable.Zip" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(second != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            Func<TFirst, TSecond, Output<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ.
            return @this.Zip(second, resultSelector: resultSelector).AssumeNotNull_().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Output<TAccumulate> result = Output.Success(seed);

            foreach (TSource item in @this)
            {
                if (result == null) 
                {
                    return null;
                }

                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull_().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Output<TSource> result = Output.Success(iter.Current);

                while (iter.MoveNext())
                {
                    if (result == null) 
                    {
                        return null;
                    }

                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull_().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM,
            Func<Output<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            Output<TAccumulate> result = Output.Success(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate.Invoke(result) && iter.MoveNext())
                {
                    if (result == null)
                    {
                        return null;
                    }

                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM,
            Func<Output<TSource>, bool> predicate)
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

                Output<TSource> result = Output.Success(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext())
                {
                    if (result == null)
                    {
                        return null;
                    }

                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    } // End of the class EnumerableOutputExtensions.
}
