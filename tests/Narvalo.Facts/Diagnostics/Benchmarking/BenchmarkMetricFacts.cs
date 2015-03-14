﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Diagnostics.Benchmarking
{
    using System;

    using Xunit;

    public static class BenchmarkMetricFacts
    {
        private static readonly TimeSpan s_Epsilon = TimeSpan.FromTicks(1L);

        [Fact]
        public static void ToString_ForNullFormat()
        {
            // Arrange
            var metric = new BenchmarkMetric("Category", "Name", s_Epsilon, 1);

            // Act & Assert
            Assert.Equal(metric.ToString(), metric.ToString(null, null));
        }

        [Fact]
        public static void ToString_ForDefaultFormat()
        {
            // Arrange
            var metric = new BenchmarkMetric("Category", "Name", s_Epsilon, 1);

            // Act & Assert
            Assert.Equal(metric.ToString(), metric.ToString("G", null));
        }
    }
}