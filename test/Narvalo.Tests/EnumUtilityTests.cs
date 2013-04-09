﻿namespace Narvalo
{
    using System;
    using Xunit;

    public static class EnumUtilityTests
    {
        #region > Stubs <

        struct StructStub_ { }

        enum EnumStub_
        {
            None = 0,
            ActualValue = 1,
            AliasValue = ActualValue,
        }

        enum EnumWithoutDefaultStub_
        {
            ActualValue1 = 1,
            ActualValue2 = 2,
        }

        [Flags]
        enum EnumFlagStub_
        {
            None = 0,
            ActualValue1 = 1 << 0,
            ActualValue2 = 1 << 1,
            ActualValue3 = 1 << 2,
            CompositeValue1 = ActualValue1 | ActualValue2,
            CompositeValue2 = ActualValue1 | ActualValue2 | ActualValue3
        }

        #endregion

        #region + Parse<T> +

        public static class Parse
        {
            #region > Validation du paramètre générique <

            [Fact]
            public static void ThrowsArgumentException_WithInt32()
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(() => EnumUtility.Parse<int>("Whatever"));
            }

            [Fact]
            public static void ThrowsArgumentException_WithStruct()
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(() => EnumUtility.Parse<StructStub_>("Whatever"));
            }

            #endregion

            #region > Analyse d'une valeur valide <

            [Fact]
            public static void ReturnsCorrectMember_ForActualValue()
            {
                // Act
                EnumStub_ result = EnumUtility.Parse<EnumStub_>("ActualValue");
                // Assert
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ReturnsCorrectMember_ForActualValue_WhenIgnoreCase()
            {
                // Act
                EnumStub_ result = EnumUtility.Parse<EnumStub_>("actualvalue", true /* ignoreCase */);
                // Assert
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ThrowsArgumentException_ForActualValueAndBadCase()
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(
                    () => EnumUtility.Parse<EnumStub_>("actualvalue", false /* ignoreCase */));
            }

            #endregion

            #region > Analyse d'une valeur invalide <

            [Fact]
            public static void ThrowsArgumentException_ForInvalidValue()
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(
                    () => EnumUtility.Parse<EnumStub_>("InvalidValue"));
            }

            [Fact]
            public static void ThrowsArgumentException_ForInvalidValue_WhenIgnoreCase()
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(
                    () => EnumUtility.Parse<EnumStub_>("invalidvalue", true /* ignoreCase */));
            }

            [Fact]
            public static void ThrowsArgumentException_ForInvalidValueAndBadCase()
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(
                    () => EnumUtility.Parse<EnumStub_>("invalidvalue", false /* ignoreCase */));
            }

            #endregion
        }

        #endregion

#if NET_35

        #region + TryParse<T> +

        public static class TryParse
        {
            #region > Validation du paramètre générique <

            [Fact]
            public static void ThrowsArgumentException_WithInt32()
            {
                // Arrange
                int result;
                // Act & Assert
                Assert.Throws<ArgumentException>(
                    () => EnumUtility.TryParse<int>("Whatever", out result));
            }

            [Fact]
            public static void ThrowsArgumentException_WithStruct()
            {
                // Arrange
                StructStub_ result;
                // Act & Assert
                Assert.Throws<ArgumentException>(
                    () => EnumUtility.TryParse<StructStub_>("Whatever", out result));
            }

            #endregion

            #region > Analyse d'une valeur valide <

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValue()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>("ActualValue", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValueAndWhitespaces()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>(" ActualValue  ", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValueAndIgnoreCase()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>(
                    "actualvalue", true /* ignoreCase */, out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValueAndIgnoreCaseAndWhitespaces()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>(
                    "  actualvalue   ", true /* ignoreCase */, out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForActualValueAndBadCase()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>(
                    "actualvalue", false /* ignoreCase */, out result);
                // Assert
                Assert.False(succeed);
                Assert.NotEqual(EnumStub_.ActualValue, result);
                Assert.Equal(default(EnumStub_), result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForAliasValue()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>("AliasValue", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumStub_.AliasValue, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValue_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumFlagStub_>("ActualValue1", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumFlagStub_.ActualValue1, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualCompositeValue_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumFlagStub_>("CompositeValue1", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumFlagStub_.CompositeValue1, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForUserDefinedCompositeValue_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumFlagStub_>("ActualValue1, ActualValue2", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumFlagStub_.CompositeValue1, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForUserDefinedCompositeValueAndWhitespaces_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumFlagStub_>(
                    "  ActualValue1,  ActualValue2,ActualValue3  ", out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumFlagStub_.CompositeValue2, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForUserDefinedCompositeValueAndWhitespacesAndIgnoreCase_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumFlagStub_>(
                    "  actualvalue1,  ActualValue2,actualVAlue3  ", true /* ignoreCase */, out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumFlagStub_.CompositeValue2, result);
            }

            #endregion

            #region > Analyse d'une valeur invalide <

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForInvalidValue()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>("InvalidValue", out result);
                // Assert
                Assert.False(succeed);
                Assert.Equal(default(EnumStub_), result);
            }

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForInvalidValueAndIgnoreCase()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>("invalidvalue", true /* ignoreCase */, out result);
                // Assert
                Assert.False(succeed);
                Assert.Equal(default(EnumStub_), result);
            }

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForInvalidValueAndBadCase()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumStub_>("invalidvalue", false /* ignoreCase */, out result);
                // Assert
                Assert.False(succeed);
                Assert.Equal(default(EnumStub_), result);
            }

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForInvalidValue_WithEnumWithoutDefault()
            {
                // Arrange
                EnumWithoutDefaultStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumWithoutDefaultStub_>("InvalidValue", out result);
                // Assert
                Assert.False(succeed);
                Assert.Equal(default(EnumWithoutDefaultStub_), result);
            }

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForInvalidUserDefinedCompositeValueAndWhitespaces_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryParse<EnumFlagStub_>("  InvalidValue,  ActualValue2,ActualValue3  ", out result);
                // Assert
                Assert.False(succeed);
                Assert.Equal(default(EnumFlagStub_), result);
            }

            #endregion
        }

        #endregion

#endif

        #region + TryConvert<T> +

        public static class TryConvert
        {
            #region > Validation du paramètre générique <

            [Fact]
            public static void ThrowsArgumentException_WithInt32()
            {
                // Arrange
                int result;
                // Act & Assert
                Assert.Throws<ArgumentException>(() => EnumUtility.TryConvert<int>(1, out result));
            }

            [Fact]
            public static void ThrowsArgumentException_WithStruct()
            {
                // Arrange
                StructStub_ result;
                // Act & Assert
                Assert.Throws<ArgumentException>(() => EnumUtility.TryConvert<StructStub_>(1, out result));
            }

            #endregion

            #region > Conversion d'une valeur valide <

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValue()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryConvert<EnumStub_>(1, out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumStub_.ActualValue, result);
            }

            [Fact]
            public static void ReturnsTrueAndPicksCorrectMember_ForActualValue_WithFlagEnum()
            {
                // Arrange
                EnumFlagStub_ result;
                // Act
                var succeed = EnumUtility.TryConvert<EnumFlagStub_>(1 << 0, out result);
                // Assert
                Assert.True(succeed);
                Assert.Equal(EnumFlagStub_.ActualValue1, result);
            }

            #endregion

            #region > Conversion d'une valeur invalide <

            [Fact]
            public static void ReturnsFalseAndPicksDefaultMember_ForInvalidValue()
            {
                // Arrange
                EnumStub_ result;
                // Act
                var succeed = EnumUtility.TryConvert<EnumStub_>(2, out result);
                // Assert
                Assert.False(succeed);
                Assert.Equal(default(EnumStub_), result);
            }

            #endregion
        }

        #endregion
    }
}
