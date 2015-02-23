﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Benchmarking
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Narvalo;
    using Narvalo.Benchmarking.Internal;

    public class BenchmarkProcessor
    {
        private readonly BenchmarkFinder _finder;
        private readonly BenchmarkRunner _runner;

        private BenchmarkProcessor(BenchmarkFinder finder, BenchmarkRunner runner)
        {
            Require.NotNull(finder, "finder");
            Require.NotNull(runner, "runner");

            _finder = finder;
            _runner = runner;
        }

        #region Raccourcis de construction.

        public static BenchmarkProcessor Create()
        {
            return new BenchmarkProcessor(
                new BenchmarkFinder(),
                BenchmarkRunner.Create());
        }

        public static BenchmarkProcessor Create(BindingFlags bindings)
        {
            return new BenchmarkProcessor(
                new BenchmarkFinder(bindings),
                BenchmarkRunner.Create());
        }

        public static BenchmarkProcessor Create(IBenchmarkTimer timer)
        {
            return new BenchmarkProcessor(
                new BenchmarkFinder(),
                BenchmarkRunner.Create(timer));
        }

        public static BenchmarkProcessor Create(
            BindingFlags bindings,
            IBenchmarkTimer timer)
        {
            return new BenchmarkProcessor(
                new BenchmarkFinder(bindings),
                BenchmarkRunner.Create(timer));
        }

        #endregion

        public IEnumerable<BenchmarkMetric> Process(Assembly assembly)
        {
            var benchmarks = _finder.FindBenchmarks(assembly);

            foreach (var benchmark in benchmarks) {
                yield return _runner.Run(benchmark);
            }
        }

        public IEnumerable<BenchmarkMetric> Process(Type type)
        {
            var benchmarks = _finder.FindBenchmarks(type);

            foreach (var benchmark in benchmarks) {
                yield return _runner.Run(benchmark);
            }
        }
    }
}
