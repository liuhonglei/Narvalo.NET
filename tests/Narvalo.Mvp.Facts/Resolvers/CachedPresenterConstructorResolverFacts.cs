﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Resolvers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection.Emit;

    using NSubstitute;
    using Xunit;

    public static class CachedPresenterConstructorResolverFacts
    {
        #region Ctor()

        [Fact]
        public static void Ctor_ThrowsArgumentNullException_ForNullInnerResolver()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CachedPresenterConstructorResolver(inner: null));
        }

        #endregion

        #region Resolve()

        [Fact]
        public static void Resolve_CachesInnerResolverCalls()
        {
            // Arrange
            var inner = Substitute.For<IPresenterConstructorResolver>();
            inner.Resolve(typeof(String), typeof(Char[]))
                .Returns(new DynamicMethod(String.Empty, typeof(String), new Type[0]));

            var resolver = new CachedPresenterConstructorResolver(inner);

            // Act
            resolver.Resolve(typeof(String), typeof(Char[]));
            resolver.Resolve(typeof(String), typeof(Char[]));

            // Assert
            inner.Received(1).Resolve(typeof(String), typeof(Char[]));
            Assert.True(true);
        }

        [Fact]
        public static void Resolve_ReturnsSameResult_ForSameInput()
        {
            // Arrange
            var inner = Substitute.For<IPresenterConstructorResolver>();
            inner.Resolve(typeof(String), typeof(Char[]))
                .Returns(new DynamicMethod(String.Empty, typeof(String), new Type[0]));

            var resolver = new CachedPresenterConstructorResolver(inner);

            // Act
            var ctor1 = resolver.Resolve(typeof(String), typeof(Char[]));
            var ctor2 = resolver.Resolve(typeof(String), typeof(Char[]));

            // Assert
            Assert.Equal(ctor1, ctor2);
        }

        [Fact]
        public static void Resolve_ReturnsDifferentResults_ForDifferentInputs()
        {
            // Arrange
            var inner = Substitute.For<IPresenterConstructorResolver>();
            inner.Resolve(typeof(String), typeof(Char*))
                .Returns(new DynamicMethod(String.Empty, typeof(String), new Type[0]));
            inner.Resolve(typeof(String), typeof(Char[]))
                .Returns(new DynamicMethod(String.Empty, typeof(String), new Type[0]));

            var resolver = new CachedPresenterConstructorResolver(inner);

            // Act
            var ctor1 = resolver.Resolve(typeof(String), typeof(Char*));
            var ctor2 = resolver.Resolve(typeof(String), typeof(Char[]));

            // Assert
            Assert.NotEqual(ctor1, ctor2);
        }

        #endregion
    }
}
