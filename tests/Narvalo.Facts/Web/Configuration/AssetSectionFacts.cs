﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Configuration
{
    using System;

    using Narvalo.TestCommon;
    using Xunit;

    public static partial class AssetSectionFacts
    {
        #region DefaultProvider

        [Fact]
        public static void DefaultProvider_DefaultValueIsNotNull()
        {
            // Arrange
            var section = new AssetSection();

            // Assert
            Assert.True(section.DefaultProvider != null);
        }

        [Fact]
        public static void DefaultProvider_ThrowsArgumentNullException_ForNullInput()
        {
            // Arrange
            var section = new AssetSection();

            // Assert
            Assert.Throws<ArgumentNullException>(() => section.DefaultProvider = null);
        }

        [Fact]
        public static void DefaultProvider_ThrowsArgumentException_ForEmptyInput()
        {
            // Arrange
            var section = new AssetSection();

            // Assert
            Assert.Throws<ArgumentException>(() => section.DefaultProvider = String.Empty);
        }

        [Fact]
        public static void DefaultProvider_ThrowsArgumentException_ForWhiteSpaceInput()
        {
            // Arrange
            var section = new AssetSection();

            // Assert
            Assert.Throws<ArgumentException>(() => section.DefaultProvider = Constants.WhiteSpaceOnlyString);
        }

        #endregion

        #region Providers

        [Fact]
        public static void Providers_DefaultValueIsNotNull()
        {
            // Arrange
            var section = new AssetSection();

            // Assert
            Assert.True(section.Providers != null);
        }

        [Fact]
        public static void Providers_ThrowsArgumentNullException_ForNullInput()
        {
            // Arrange
            var section = new AssetSection();

            // Assert
            Assert.Throws<ArgumentNullException>(() => section.Providers = null);
        }

        #endregion
    }
}