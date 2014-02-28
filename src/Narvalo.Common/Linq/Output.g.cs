﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Linq {
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo.Fx;

	// Query Expression Pattern for Output<T>.
	public static partial class OutputExtensions
    {
        public static Output<TResult> Select<TSource, TResult>(
            this Output<TSource> @this, 
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);

            return @this.Map(selector);
        }

        // Kind of generalisation of Zip (liftM2).
        public static Output<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Output<TSource> @this,
            Func<TSource, Output<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(_ => valueSelectorM.Invoke(_).Map(middle => resultSelector.Invoke(_, middle)));
        }
	}

	// Linq extensions for Output<T>.
	public static partial class OutputExtensions
    {
	}

	// Prelude extensions for IEnumerable<Output<T>>.
	public static partial class EnumerableOutputExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] sequence
        public static Output<IEnumerable<TSource>> Collect<TSource>(this IEnumerable<Output<TSource>> @this)
        {
            Require.Object(@this);

            var seed = Output.Success(Enumerable.Empty<TSource>());
            Func<Output<IEnumerable<TSource>>, Output<TSource>, Output<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => Output.Success(list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }
		
        #endregion
	}

	// Prelude extensions for IEnumerable<T>.
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] mapM
        public static Output<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<TResult>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");

            return (from _ in @this select funM.Invoke(_)).Collect();
        }
		
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] filterM
        public static Output<IEnumerable<TSource>> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<bool>> predicateM)
        {
            Require.Object(@this);
            Require.NotNull(predicateM, "predicateM");

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this) {
                predicateM.Invoke(item)
                    .Bind(_ =>
                    {
                        if (_ == true) {
                            list.Add(item);
                        }

                        return Output.Unit;
                    });
            }

            return Output.Success(list.AsEnumerable());
        }

        // [Haskell] mapAndUnzipM
        public static Output<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>> MapAndUnzip<TSource, TFirst, TSecond>(
           this IEnumerable<TSource> @this,
           Func<TSource, Output<Tuple<TFirst, TSecond>>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");

            return from _ in
                       (from _ in @this select funM.Invoke(_)).Collect()
                   let item1 = from item in _ select item.Item1
                   let item2 = from item in _ select item.Item2
                   select new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(item1, item2);
        }

        // [Haskell] zipWithM
        public static Output<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Output<TResult>> resultSelectorM)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, Output<TResult>> resultSelector = (v1, v2) => resultSelectorM.Invoke(v1, v2);

			// WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call to Zip 
			// instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        // [Haskell] foldM
        public static Output<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Output<TAccumulate> result = Output.Success(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        #endregion
    }

	// Non-standard extensions for IEnumerable<T>.
	public static partial class EnumerableExtensions
    {
        #region Aggregate Operators

        public static Output<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);

            return @this.Reverse().Fold(seed, accumulatorM);
        }

        public static Output<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Output<TSource> result = Output.Success(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        public static Output<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Require.Object(@this);

            return @this.Reverse().Reduce(accumulatorM);
        }

        #endregion
	}
}
