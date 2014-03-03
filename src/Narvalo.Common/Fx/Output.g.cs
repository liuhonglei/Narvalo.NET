﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Creation Time: 03/03/2014 13:34:51
// Runtime Version: 4.0.30319.34011
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Fx {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    // Monad methods.
    public static partial class Output
    {
        static readonly Output<Unit> Unit_ = Success(Narvalo.Fx.Unit.Single);

        public static Output<Unit> Unit { get { return Unit_; } }


        // [Haskell] return
        public static Output<T> Success<T>(T value)
        {
            return Output<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        // [Haskell] join
        public static Output<T> Flatten<T>(Output<Output<T>> square)
        {
            return Output<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators

        public static Func<Output<T>, Output<TResult>> Lift<T, TResult>(Func<T, TResult> fun)
        {
            return m =>
            {
	            Require.NotNull(m, "m");
                return m.Select(fun);
            };
        }

        public static Func<Output<T1>, Output<T2>, Output<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            return (m1, m2) => 
            {
	            Require.NotNull(m1, "m1");
                return m1.Zip(m2, fun);
            };
        }

        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            return (m1, m2, m3) =>
            {
	            Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, fun);
            };
        }

        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            return (m1, m2, m3, m4) =>
            {
	            Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<T5>, Output<TResult>>
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

    // Extensions for Output<T>.
    public static partial class Output
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] fmap
        public static Output<TResult> Select<TSource, TResult>(this Output<TSource> @this, Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => Output.Success(selector.Invoke(_)));
        }

        // [Haskell] >>
        public static Output<TResult> Then<TSource, TResult>(this Output<TSource> @this, Output<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)


        // [Haskell] replicateM
        public static Output<IEnumerable<TSource>> Repeat<TSource>(this Output<TSource> @this, int count)
        {
            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        // [Haskell] when
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static Output<Unit> When<TSource>(this Output<TSource> @this, bool predicate, Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return Output.Unit;
        }

        // [Haskell] unless
        public static Output<Unit> Unless<TSource>(this Output<TSource> @this, bool predicate, Action action)
        {
            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        // [Haskell] liftM2
        public static Output<TResult> Zip<TFirst, TSecond, TResult>(
            this Output<TFirst> @this,
            Output<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        // [Haskell] liftM3
        public static Output<TResult> Zip<T1, T2, T3, TResult>(
            this Output<T1> @this,
            Output<T2> second,
            Output<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Output<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        // [Haskell] liftM4
        public static Output<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Output<T1> @this,
             Output<T2> second,
             Output<T3> third,
             Output<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Output<TResult>> g
                = t1 => second.Zip(third, fourth, (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        // [Haskell] liftM5
        public static Output<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Output<T1> @this,
            Output<T2> second,
            Output<T3> third,
            Output<T4> fourth,
            Output<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Output<TResult>> g
                = t1 => second.Zip(third, fourth, fifth, (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        // Kind of generalisation of Zip (liftM2).
        public static Output<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Output<TSource> @this,
            Func<TSource, Output<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(_ => valueSelectorM.Invoke(_).Select(middle => resultSelector.Invoke(_, middle)));
        }


        #endregion
        
        #region Linq extensions


        #endregion

        #region Non-standard extensions
        
        public static Output<TResult> Coalesce<TSource, TResult>(
            this Output<TSource> @this,
            Func<TSource, bool> predicate,
            Output<TResult> then,
            Output<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static Output<TSource> Run<TSource>(this Output<TSource> @this, Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }


        #endregion
    }

    // Extensions for Func<T, Output<TResult>>.
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] =<<
        public static Output<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Output<TResult>> @this,
            Output<TSource> value)
        {
            return value.Bind(@this);
        }

        // [Haskell] >=>
        public static Func<TSource, Output<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Output<TMiddle>> @this,
            Func<TMiddle, Output<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        // [Haskell] <=<
        public static Func<TSource, Output<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Output<TResult>> @this,
            Func<TSource, Output<TMiddle>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}
