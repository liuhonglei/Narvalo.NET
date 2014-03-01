﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Edu.Monads {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    // Monad methods.
    public static partial class MonadZero
    {
        static readonly MonadZero<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);
        static readonly MonadZero<Unit> Zero_ = MonadZero<Unit>.Zero;

        public static MonadZero<Unit> Unit { get { return Unit_; } }

        // [Haskell] mzero
        public static MonadZero<Unit> Zero { get { return Zero_; } }

        // [Haskell] return
        public static MonadZero<T> Return<T>(T value)
        {
            return MonadZero<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        // [Haskell] join
        public static MonadZero<T> Flatten<T>(MonadZero<MonadZero<T>> square)
        {
            return MonadZero<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators

        public static Func<MonadZero<T>, MonadZero<TResult>> Lift<T, TResult>(Func<T, TResult> fun)
        {
            return m => m.Select(fun);
        }

        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            return (m1, m2) => m1.Zip(m2, fun);
        }

        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<T3>, MonadZero<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            return (m1, m2, m3) => m1.Zip(m2, m3, fun);
        }

        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<T3>, MonadZero<T4>, MonadZero<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            return (m1, m2, m3, m4) => m1.Zip(m2, m3, m4, fun);
        }

        public static Func<MonadZero<T1>, MonadZero<T2>, MonadZero<T3>, MonadZero<T4>, MonadZero<T5>, MonadZero<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
        {
            return (m1, m2, m3, m4, m5) => m1.Zip(m2, m3, m4, m5, fun);
        }

        #endregion
    }
    // Extensions for MonadZero<T>.
    public static partial class MonadZeroExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] fmap
        public static MonadZero<TResult> Select<TSource, TResult>(this MonadZero<TSource> @this, Func<TSource, TResult> selector)
        {
            return @this.Bind(_ => MonadZero.Return(selector.Invoke(_)));
        }

        // [Haskell] >>
        public static MonadZero<TResult> Then<TSource, TResult>(this MonadZero<TSource> @this, MonadZero<TResult> other)
        
        {
            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] mfilter
        public static MonadZero<TSource> Where<TSource>(this MonadZero<TSource> @this, Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? @this : MonadZero<TSource>.Zero);
        }
        // [Haskell] replicateM
        public static MonadZero<IEnumerable<TSource>> Repeat<TSource>(this MonadZero<TSource> @this, int count)
        {
            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        // [Haskell] guard
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static MonadZero<Unit> Guard<TSource>(this MonadZero<TSource> @this, bool predicate)
        {
            return predicate ? MonadZero.Unit : MonadZero.Zero;
        }

        // [Haskell] when
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static MonadZero<Unit> When<TSource>(this MonadZero<TSource> @this, bool predicate, Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return MonadZero.Unit;
        }

        // [Haskell] unless
        public static MonadZero<Unit> Unless<TSource>(this MonadZero<TSource> @this, bool predicate, Action action)
        {
            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        // [Haskell] liftM2
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

        // [Haskell] liftM3
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

        // [Haskell] liftM4
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
                = t1 => second.Zip(third, fourth, (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        // [Haskell] liftM5
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
                = t1 => second.Zip(third, fourth, fifth, (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        // Kind of generalisation of Zip (liftM2).
        public static MonadZero<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, MonadZero<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(_ => valueSelectorM.Invoke(_).Select(middle => resultSelector.Invoke(_, middle)));
        }

        public static MonadZero<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
        {
            return @this.Join(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        public static MonadZero<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadZero<TInner>, TResult> resultSelector)
        {
            return @this.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
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
            return GroupJoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }
        
        static MonadZero<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.Object(@this);
            Require.NotNull(inner, "inner");
            Require.NotNull(outerKeySelector, "valueSelector");
            Require.NotNull(innerKeySelector, "innerKeySelector");
            Require.NotNull(resultSelector, "resultSelector");
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in @this
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        static MonadZero<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
            this MonadZero<TSource> @this,
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadZero<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.Object(@this);
            Require.NotNull(inner, "inner");
            Require.NotNull(outerKeySelector, "valueSelector");
            Require.NotNull(innerKeySelector, "innerKeySelector");
            Require.NotNull(resultSelector, "resultSelector");

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in @this
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        static Func<TSource, MonadZero<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            MonadZero<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
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
            return @this.Coalesce(predicate, other, MonadZero<TResult>.Zero);
        }

        public static MonadZero<TResult> Otherwise<TSource, TResult>(
            this MonadZero<TSource> @this,
            Func<TSource, bool> predicate,
            MonadZero<TResult> other)
        {
            return @this.Coalesce(predicate, MonadZero<TResult>.Zero, other);
        }

        public static MonadZero<TSource> Run<TSource>(this MonadZero<TSource> @this, Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static MonadZero<TSource> OnZero<TSource>(this MonadZero<TSource> @this, Action action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            // REVIEW
            return @this.Then(MonadZero.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }
    // Extensions for Func<T, MonadZero<TResult>>.
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] =<<
        public static MonadZero<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadZero<TResult>> @this,
            MonadZero<TSource> monad)
        {
            return monad.Bind(@this);
        }

        // [Haskell] >=>
        public static Func<TSource, MonadZero<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadZero<TMiddle>> @this,
            Func<TMiddle, MonadZero<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        // [Haskell] <=<
        public static Func<TSource, MonadZero<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadZero<TResult>> @this,
            Func<TSource, MonadZero<TMiddle>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}

namespace Narvalo.Edu.Monads {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Monads;
    // Extensions for IEnumerable<MonadZero<T>>.
    public static partial class EnumerableMonadZeroExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] sequence
        public static MonadZero<IEnumerable<TSource>> Collect<TSource>(this IEnumerable<MonadZero<TSource>> @this)
        {
            Require.Object(@this);

            var seed = MonadZero.Return(Enumerable.Empty<TSource>());
            Func<MonadZero<IEnumerable<TSource>>, MonadZero<TSource>, MonadZero<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => MonadZero.Return(list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }
        
        #endregion

    }
}

namespace Narvalo.Edu.Monads.MonadZeroEx {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Monads;
    // Extensions for IEnumerable<T>.
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] mapM
        public static MonadZero<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<TResult>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");

            return (from _ in @this select funM.Invoke(_)).Collect();
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] filterM
        public static MonadZero<IEnumerable<TSource>> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadZero<bool>> predicateM)
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

                        return MonadZero.Unit;
                    });
            }

            return MonadZero.Return(list.AsEnumerable());
        }

        // [Haskell] mapAndUnzipM
        public static MonadZero<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>> MapAndUnzip<TSource, TFirst, TSecond>(
           this IEnumerable<TSource> @this,
           Func<TSource, MonadZero<Tuple<TFirst, TSecond>>> funM)
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
        public static MonadZero<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadZero<TResult>> resultSelectorM)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, MonadZero<TResult>> resultSelector = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call to Zip 
            // instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        // [Haskell] foldM
        public static MonadZero<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            MonadZero<TAccumulate> result = MonadZero.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        #endregion
        
        #region Aggregate Operators

        public static MonadZero<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadZero<TAccumulate>> accumulatorM)
        {
             Require.Object(@this);

            return @this.Reverse().Fold(seed, accumulatorM);
        }

        public static MonadZero<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

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

        public static MonadZero<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadZero<TSource>> accumulatorM)
        {
            Require.Object(@this);

            return @this.Reverse().Reduce(accumulatorM);
        }

        #endregion
    }
    // Possibly conflicting extensions for IEnumerable<T>.
    public static partial class UnsafeEnumerableExtensions
    {
        #region Element Operators

        public static MonadZero<TSource> FirstOrZero<TSource>(this IEnumerable<TSource> @this)
        {
            return FirstOrZero(@this, _ => true);
        }

        public static MonadZero<TSource> FirstOrZero<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            var seq = from t in @this where predicate.Invoke(t) select MonadZero.Return(t);
            using (var iter = seq.GetEnumerator()) {
                return iter.MoveNext() ? iter.Current : MonadZero<TSource>.Zero;
            }
        }

        public static MonadZero<TSource> LastOrZero<TSource>(this IEnumerable<TSource> @this)
        {
            return LastOrZero(@this, _ => true);
        }

        public static MonadZero<TSource> LastOrZero<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            var seq = from t in @this where predicate.Invoke(t) select MonadZero.Return(t);
            using (var iter = seq.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    return MonadZero<TSource>.Zero;
                }

                var value = iter.Current;
                while (iter.MoveNext()) {
                    value = iter.Current;
                }

                return value;
            }
        }

        public static MonadZero<TSource> SingleOrZero<TSource>(this IEnumerable<TSource> @this)
        {
            return SingleOrZero(@this, _ => true);
        }

        public static MonadZero<TSource> SingleOrZero<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            var seq = from t in @this where predicate.Invoke(t) select MonadZero.Return(t);
            using (var iter = seq.GetEnumerator()) {
                var result = iter.MoveNext() ? iter.Current : MonadZero<TSource>.Zero;

                // On retourne MonadZero.Zero si il y a encore un élément.
                return iter.MoveNext() ? MonadZero<TSource>.Zero : result;
            }
        }

        #endregion
    }
}
