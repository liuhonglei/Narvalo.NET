﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx.Monads
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#if !MONAD_DISABLE_ZERO && !MONAD_DISABLE_PLUS
    /*!
     * Monoid Laws
     * -----------
     */
    public static partial class Rules
    {
        /// <summary>
        /// First Monoid Law: Zero is a left identity for Plus.
        /// </summary>
        public static bool SatisfiesFirstMonoidLaw<X>(Monad<X> m)
        {
            // mplus mzero m = m
            return Monad<X>.Zero.Plus(m) == m;
        }

        /// <summary>
        /// Second Monoid Law: Zero is a right identity for Plus.
        /// </summary>
        public static bool SatisfiesSecondMonoidLaw<X>(Monad<X> m)
        {
            // mplus m mzero = m
            return m.Plus(Monad<X>.Zero) == m;
        }

        /// <summary>
        /// Third Monoid Law: Plus is associative.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1119:StatementMustNotUseUnnecessaryParenthesis",
            Justification = "[Educational] Unnecessary parenthesis are kept to emphasis the order of operations.")]
        public static bool SatisfiesThirdMonoidLaw<X>(Monad<X> a, Monad<X> b, Monad<X> c)
        {
            // mplus a (mplus b c) = mplus (mplus a b) c
            return a.Plus(b.Plus(c)) == (a.Plus(b)).Plus(c);
        }
    }
#endif

    /*!
     * Monad Laws
     * ----------
     */
    public static partial class Rules
    {
        /// <summary>
        /// First Monad Law: Unit is a left identity for Bind.
        /// </summary>
        public static bool SatisfiesFirstMonadLaw<X, Y>(Kunc<X, Y> f, X value)
        {
            // return x >>= f = f x
            return Monad.Return(value).Bind(f) == f(value);
        }

        /// <summary>
        /// Second Monad Law: Unit is a right identity for Bind.
        /// </summary>
        public static bool SatisfiesSecondMonadLaw<X>(Monad<X> m)
        {
            // m >>= return = m
            return m.Bind(Monad.Return) == m;
        }

        /// <summary>
        /// Third Monad Law: Bind is associative.
        /// </summary>
        public static bool SatisfiesThirdMonadLaw<X, Y, Z>(Monad<X> m, Kunc<X, Y> f, Kunc<Y, Z> g)
        {
            // (m >>= f) >>= g = m >>= (\x -> f x >>= g)
            return m.Bind(f).Bind(g) == m.Bind(_ => f(_).Bind(g));
        }

        /*!
         * ### Same rules but in the Kleisli Category
         */

        /// <summary>
        /// First Monad Law.
        /// </summary>
        public static bool SatisfiesFirstMonadLawKleisliVersion<X, Y>(Kunc<X, Y> g, X value)
        {
            Kunc<X, X> id = _ => Monad.Return(_);

            // return >=> g ≡ g
            return id.Compose(g).Invoke(value) == g(value);
        }

        /// <summary>
        /// Second Monad Law.
        /// </summary>
        public static bool SatisfiesSecondMonadLawKleisliVersion<X, Y>(Kunc<X, Y> f, X value)
        {
            // f >=> return ≡ f
            return f.Compose(Monad.Return).Invoke(value) == f(value);
        }

        /// <summary>
        /// Third Monad Law.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1119:StatementMustNotUseUnnecessaryParenthesis",
            Justification = "[Educational] Unnecessary parenthesis are kept to emphasis the order of operations.")]
        public static bool SatisfiesThirdMonadLawKleisliVersion<X, Y, Z, T>(
           Kunc<X, Y> f,
           Kunc<Y, Z> g,
           Kunc<Z, T> h,
           X value)
        {
            // (f >=> g) >=> h ≡ f >=> (g >=> h)
            return (f.Compose(g)).Compose(h).Invoke(value) == f.Compose(g.Compose(h)).Invoke(value);
        }

        /*!
         * ### Other rules automatically satisfied
         */

        /// <summary>
        /// First rule satisfied by Map, implied by the definition of Map and the second monad law:
        ///     fmap id x = x >>= (return . id) = x >>= return = x
        /// </summary>
        public static bool SatisfiesFirstFunctorRule<X>(Monad<X> m)
        {
            Func<Monad<X>, Monad<X>> idM = _ => _;

            // fmap id  ==  id
            return m.Map(_ => _) == idM.Invoke(m);
        }

        /// <summary>
        /// Second rule satisfied by Map.
        /// </summary>
        public static bool SatisfiesSecondFunctorRule<X, Y, Z>(Monad<X> m, Func<Y, Z> f, Func<X, Y> g)
        {
            // REVIEW: Is this obvious?
            // fmap (f . g) == fmap f . fmap g
            return m.Map(_ => f(g(_))) == m.Map(g).Map(f);
        }

        /// <summary>
        /// Then is associative, implied by the definition of Then and the third monad law.
        /// </summary>
        public static bool ThenIsAssociative<X, Y, Z>(Monad<X> a, Monad<Y> b, Monad<Z> c)
        {
            // (m >> n) >> o = m >> (n >> o)
            return a.Then(b).Then(c) == a.Then(b.Then(c));
        }
    }

    public static partial class Rules
    {
#if !MONAD_DISABLE_ZERO
        /// <summary>
        /// MonadZero: Zero is a left zero for Bind.
        /// </summary>
        public static bool SatisfiesMonadZeroRule<X, Y>(Kunc<X, Y> f)
        {
            // mzero >>= f = mzero
            return Monad<X>.Zero.Bind(f) == Monad<Y>.Zero;
        }

        /// <summary>
        /// MonadMore: Zero is a right zero for Bind or equivalently Zero is a right zero for Then.
        /// </summary>
        public static bool SatisfiesMonadMoreRule<X>(Monad<X> m)
        {
            // m >>= (\x -> mzero) = mzero
            return m.Bind(_ => Monad<X>.Zero) == Monad<X>.Zero;
        }

        /// <summary>
        /// MonadMore: Zero is a right zero for Then, implied by the definition of then and the MonadMore rule.
        /// </summary>
        public static bool SatisfiesMonadMoreRuleVariant<X>(Monad<X> m)
        {
            // v >> mzero = mzero
            return m.Then(Monad<X>.Zero) == Monad<X>.Zero;
        }
#endif

#if !MONAD_DISABLE_ZERO && !MONAD_DISABLE_PLUS
        /// <summary>
        /// MonadPlus: Bind is right distributive over Plus.
        /// </summary>
        public static bool SatisfiesMonadPlusRule<X>(Monad<X> a, Monad<X> b, Kunc<X, X> f)
        {
            // mplus a b >>= f = mplus (a >>= f) (b >>= f)
            return a.Plus(b).Bind(f) == a.Bind(f).Plus(b.Bind(f));
        }

        /// <summary>
        /// MonadOr: Unit is a left zero for Plus.
        /// </summary>
        public static bool SatisfiesMonadOrRule<X>(X a, Monad<X> b)
        {
            // morelse (return a) b ≡ return a
            return Monad.Return(a).Plus(b) == Monad.Return(a);
        }

        /////// <summary>
        /////// Unit is a right zero for Plus.
        /////// </summary>
        ////public static bool Unused_UnitIsRightZeroForPlus<X>(Monad<X> a, X b)
        ////{
        ////    // morelse a (return b) ≡ return b
        ////    return a.Plus(Monad.Return(b)) == Monad.Return(b);
        ////}
#endif
    }
}