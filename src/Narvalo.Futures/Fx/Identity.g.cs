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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Provides a set of static methods for Identity<T>.
    /// </summary>
    // NB: Sometimes we prefer extension methods over static methods to be able to override them locally.
    public static partial class Identity
    {
        /// <summary>
        /// The unique object of type <c>Identity&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Identity<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Identity&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Identity&lt;Unit&gt;</c>.</value>
        public static Identity<global::Narvalo.Fx.Unit> Unit
        {
            get
            {

                return s_Unit;
            }
        }


        /// <summary>
        /// Obtains an instance of the <see cref="Identity{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="Identity{T}"/> object.</param>
        /// <returns>An instance of the <see cref="Identity{T}"/> class for the specified value.</returns>
        // Named "return" in Haskell parlance.
        public static Identity<T> Of<T>(T value)
            /* T4: C# indent */
        {

            return Identity<T>.η(value);
        }

        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        // Named "join" in Haskell parlance.
        public static Identity<T> Flatten<T>(Identity<Identity<T>> square)
            /* T4: C# indent */
        {

            return Identity<T>.μ(square);
        }

        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        // Named "when" in Haskell parlance. Haskell uses a different signature.
        public static void When<TSource>(
            this Identity<TSource> @this,
            Func<TSource, bool> predicate,
            Action<TSource> action)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            @this.Bind(_ => { if (predicate.Invoke(_)) { action.Invoke(_); } return Identity.Unit; });
        }

        // Named "unless" in Haskell parlance. Haskell uses a different signature.
        public static void Unless<TSource>(
            this Identity<TSource> @this,
            Func<TSource, bool> predicate,
            Action<TSource> action)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            @this.Bind(_ => { if (!predicate.Invoke(_)) { action.Invoke(_); } return Identity.Unit; });
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values.
        /// </summary>
        // Named "liftM" in Haskell parlance.
        public static Func<Identity<T>, Identity<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Identity<T>, Identity<TResult>>>();

            return m =>
            {
                /* T4: C# indent */
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM2" in Haskell parlance.
        public static Func<Identity<T1>, Identity<T2>, Identity<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Identity<T1>, Identity<T2>, Identity<TResult>>>();

            return (m1, m2) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM3" in Haskell parlance.
        public static Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<TResult>>>();

            return (m1, m2, m3) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM4" in Haskell parlance.
        public static Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<TResult>>>();

            return (m1, m2, m3, m4) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Identity{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM5" in Haskell parlance.
        public static Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<T5>, Identity<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Identity<T1>, Identity<T2>, Identity<T3>, Identity<T4>, Identity<T5>, Identity<TResult>>>();

            return (m1, m2, m3, m4, m5) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    } // End of Identity - T4: EmitMonadCore().

    // Provides the core monadic extension methods for Identity<T>.
    public static partial class Identity
    {
        #region Basic Monad functions (Prelude)

        // Named "fmap", "liftA" or "<$>" in Haskell parlance.
        public static Identity<TResult> Select<TSource, TResult>(
            this Identity<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(selector, nameof(selector));

            return @this.Bind(_ => Identity.Of(selector.Invoke(_)));
        }

        // Named ">>" in Haskell parlance.
        public static Identity<TResult> Then<TSource, TResult>(
            this Identity<TSource> @this,
            Identity<TResult> other)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.Bind(_ => other);
        }

        // Named "forever" in Haskell parlance.
        public static Identity<TResult> Forever<TSource, TResult>(
            this Identity<TSource> @this,
            Func<Identity<TResult>> fun
            )
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.Then(@this.Forever(fun));
        }

        // Named "void" in Haskell parlance.
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this", Justification = "[Intentionally] This method always returns the same result.")]
        public static Identity<global::Narvalo.Fx.Unit> Forget<TSource>(this Identity<TSource> @this)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return Identity.Unit;
        }

        #endregion

        #region Generalisations of list functions (Prelude)


        // Named "replicateM" in Haskell parlance.
        public static Identity<IEnumerable<TSource>> Repeat<TSource>(
            this Identity<TSource> @this,
            int count)
        {
            /* T4: C# indent */
            Require.Range(count >= 1, nameof(count));

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }


        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        // Named "liftA2" in Haskell parlance.
        public static Identity<TResult> Zip<TFirst, TSecond, TResult>(
            this Identity<TFirst> @this,
            Identity<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        // Named "liftA3" in Haskell parlance.
        public static Identity<TResult> Zip<T1, T2, T3, TResult>(
            this Identity<T1> @this,
            Identity<T2> second,
            Identity<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            Func<T1, Identity<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        // Named "liftA4" in Haskell parlance.
        public static Identity<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Identity<T1> @this,
             Identity<T2> second,
             Identity<T3> third,
             Identity<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            Func<T1, Identity<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth,
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        // Named "liftA5" in Haskell parlance.
        public static Identity<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Identity<T1> @this,
            Identity<T2> second,
            Identity<T3> third,
            Identity<T4> fourth,
            Identity<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

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
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" /> (liftM2).
        /// </remarks>
        public static Identity<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Identity<TSource> @this,
            Func<TSource, Identity<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(valueSelectorM, nameof(valueSelectorM));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }


        #endregion

        #region LINQ extensions


        #endregion
    } // End of Identity - T4: EmitMonadExtensions().

    // Provides more extension methods for Identity<T>.
    public static partial class Identity
    {
        #region Applicative

        // Named "<$" in Haskell parlance.
        public static Identity<TSource> Replace<TSource>(
            this Identity<TSource> @this,
            TSource value)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.Select(_ => value);
        }

        #endregion

        public static Identity<TResult> Coalesce<TSource, TResult>(
            this Identity<TSource> @this,
            Func<TSource, bool> predicate,
            Identity<TResult> then,
            Identity<TResult> otherwise)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(predicate, nameof(predicate));

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

        public static void Do<TSource>(
            this Identity<TSource> @this,
            Action<TSource> action)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(action, nameof(action));

            @this.Bind(_ => { action.Invoke(_); return Identity.Unit; });
        }
    } // End of Identity - T4: EmitMonadExtraExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Func
    {
        #region Basic Monad functions (Prelude)


        // Named "=<<" in Haskell parlance. Same as Bind (>>=) with its arguments flipped.
        public static Identity<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Identity<TResult>> @this,
            Identity<TSource> value)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            /* T4: C# indent */

            return value.Bind(@this);
        }

        // Named ">=>" in Haskell parlance.
        public static Func<TSource, Identity<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Identity<TMiddle>> @this,
            Func<TMiddle, Identity<TResult>> funM)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Expect.NotNull(funM);
            Warrant.NotNull<Func<TSource, Identity<TResult>>>();

            return _ => @this.Invoke(_).Bind(funM);
        }

        // Named "<=<" in Haskell parlance.
        public static Func<TSource, Identity<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Identity<TResult>> @this,
            Func<TSource, Identity<TMiddle>> funM)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Require.NotNull(funM, nameof(funM));
            Warrant.NotNull<Func<TSource, Identity<TResult>>>();

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of Func - T4: EmitKleisliExtensions().
}


namespace Narvalo.Fx
{
    // Implements core Comonad methods.
    public static partial class Identity
    {
        /// <remarks>
        /// Named <c>extract</c> in Haskell parlance.
        /// </remarks>
        public static T Extract<T>(Identity<T> monad)
            /* T4: C# indent */
        {

            return Identity<T>.ε(monad);
        }

        /// <remarks>
        /// Named <c>duplicate</c> in Haskell parlance.
        /// </remarks>
        public static Identity<Identity<T>> Duplicate<T>(Identity<T> monad)
            /* T4: C# indent */
        {

            return Identity<T>.δ(monad);
        }
    } // End of Identity - T4: EmitComonadCore().
}

