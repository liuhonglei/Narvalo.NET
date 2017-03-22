﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 15.0
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;

    using FsCheck.Xunit;
    using Xunit;

    public static partial class OutcomeFacts
    {
        #region Repeat()

        [Fact]
        public static void Repeat_ThrowsArgumentOutOfRangeException_ForNegativeCount()
        {
            var source = Outcome.Of(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => Outcome.Repeat(source, -1));
        }

        #endregion

        #region Zip()

        [Fact]
        public static void Zip2_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Outcome.Of(1);
            var second = Outcome.Of(2);
            Func<int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, zipper));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.Zip(first, second, zipper));
        }

        [Fact]
        public static void Zip3_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Outcome.Of(1);
            var second = Outcome.Of(2);
            var third = Outcome.Of(3);
            Func<int, int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, third, zipper));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.Zip(first, second, third, zipper));
        }

        [Fact]
        public static void Zip4_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Outcome.Of(1);
            var second = Outcome.Of(2);
            var third = Outcome.Of(3);
            var fourth = Outcome.Of(4);
            Func<int, int, int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, third, fourth, zipper));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.Zip(first, second, third, fourth, zipper));
        }

        [Fact]
        public static void Zip5_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Outcome.Of(1);
            var second = Outcome.Of(2);
            var third = Outcome.Of(3);
            var fourth = Outcome.Of(4);
            var fifth = Outcome.Of(4);
            Func<int, int, int, int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, third, fourth, fifth, zipper));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.Zip(first, second, third, fourth, fifth, zipper));
        }

        #endregion

        #region Select()

        [Fact]
        public static void Select_ThrowsArgumentNullException_ForNullSelector()
        {
            var source = Outcome.Of(1);
            Func<int, int> selector = null;

            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.Select(source, selector));
        }

        #endregion

        #region SelectMany()

        [Fact]
        public static void SelectMany_ThrowsArgumentNullException_ForNullValueSelector()
        {
            var source = Outcome.Of(1);
            Func<int, Outcome<int>> valueSelector = null;
            Func<int, int, int> resultSelector = (i, j) => i + j;

            Assert.Throws<ArgumentNullException>(() => source.SelectMany(valueSelector, resultSelector));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.SelectMany(source, valueSelector, resultSelector));
        }

        [Fact]
        public static void SelectMany_ThrowsArgumentNullException_ForNullResultSelector()
        {
            var source = Outcome.Of(1);
            var middle = Outcome.Of(2);
            Func<int, Outcome<int>> valueSelector = _ => middle;
            Func<int, int, int> resultSelector = null;

            Assert.Throws<ArgumentNullException>(() => source.SelectMany(valueSelector, resultSelector));
            Assert.Throws<ArgumentNullException>(() => OutcomeExtensions.SelectMany(source, valueSelector, resultSelector));
        }

        #endregion

        #region Functor Rules

        [Fact(DisplayName = "Outcome<T> - The identity map is a fixed point for Select.")]
        public static void Satisfies_FirstFunctorLaw()
        {
            // Arrange
            var me = Outcome.Of(1);

            // Act
            var left = me.Select(Stubs<int>.Identity);
            var right = Stubs<Outcome<int>>.Identity(me);

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact(DisplayName = "Outcome<T> - Select preserves the composition operator.")]
        public static void Satisfies_FunctorSecondRule()
        {
            // Arrange
            var me = Outcome.Of(1);
            Func<int, long> g = val => (long)2 * val;
            Func<long, long> f = val => 3 * val;

            // Act
            var left = me.Select(_ => f(g(_)));
            var right = me.Select(g).Select(f);

            // Assert
            Assert.True(left.Equals(right));
        }

        #endregion

        #region Monad Rules

        [Property(DisplayName = "Outcome<T> - Of is a left identity for Bind (first monad rule).")]
        public static bool Of_IsLeftIdentityForBind(int arg0, float arg1)
        {
            Func<int, Outcome<float>> binder = val => Outcome.Of(arg1 * val);

            var left = Outcome.Of(arg0).Bind(binder);
            var right = binder(arg0);

            return left.Equals(right);
        }

        [Property(DisplayName = "Outcome<T> - Of is a left identity for Compose (first monad rule).")]
        public static bool Of_IsLeftIdentityForCompose(int arg0, float arg1)
        {
            Func<int, Outcome<int>> of = val => Outcome.Of(val);
            Func<int, Outcome<float>> fun = val => Outcome.Of(arg1 * val);

            var left = of.Compose(fun).Invoke(arg0);
            var right = fun(arg0);

            return left.Equals(right);
        }

        [Property(DisplayName = "Outcome<T> - Of is a right identity for Bind (second monad rule).")]
        public static bool Of_IsRightIdentityForBind(int arg0)
        {
            var me = Outcome.Of(arg0);

            var left = me.Bind(Outcome.Of);
            var right = me;

            return left.Equals(right);
        }

        [Property(DisplayName = "Outcome<T> - Of is a right identity for Compose (second monad rule).")]
        public static bool Of_IsRightIdentityForCompose(int arg0, float arg1)
        {
            Func<float, Outcome<float>> of = val => Outcome.Of(val);
            Func<int, Outcome<float>> fun = val => Outcome.Of(arg1 * val);

            var left = fun.Compose(of).Invoke(arg0);
            var right = fun(arg0);

            return left.Equals(right);
        }

        [Property(DisplayName = "Outcome<T> - Bind is associative (third monad law).")]
        public static bool Bind_IsAssociative(short arg0, int arg1, long arg2)
        {
            var me = Outcome.Of(arg0);

            Func<short, Outcome<int>> f = val => Outcome.Of(arg1);
            Func<int, Outcome<long>> g = val => Outcome.Of(arg2);

            var left = me.Bind(f).Bind(g);
            var right = me.Bind(val => f(val).Bind(g));

            return left.Equals(right);
        }

        #endregion
    }
}

