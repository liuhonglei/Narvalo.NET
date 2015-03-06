﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Benchmarking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using Narvalo;
    using NodaTime;

    public sealed class BenchmarkRunner
    {
        private readonly IBenchmarkTimer _timer;

        private Duration _testDuration = Duration.FromSeconds(10);
        private Duration _warmUpDuration = Duration.FromSeconds(1);

        public BenchmarkRunner(IBenchmarkTimer timer)
        {
            Require.NotNull(timer, "timer");
            Contract.Assume(_testDuration.Ticks > 0L, "At construction time, '_testDuration' should have been strictly positive.");
            Contract.Assume(_warmUpDuration.Ticks > 0L, "At construction time, '_warmUpDuration' should have been strictly positive.");

            _timer = timer;
        }

        public Duration TestDuration
        {
            get
            {
                Contract.Ensures(Contract.Result<Duration>().Ticks > 0L);
                return _testDuration;
            }

            set
            {
                Require.Condition(value.Ticks > 0L, "value");
                _testDuration = value;
            }
        }

        public Duration WarmUpDuration
        {
            get
            {
                Contract.Ensures(Contract.Result<Duration>().Ticks > 0L);
                return _warmUpDuration;
            }

            set
            {
                Require.Condition(value.Ticks > 0L, "value");
                _warmUpDuration = value;
            }
        }

        // Constant time benchmarking.
        public BenchmarkMetric Run(Benchmark benchmark)
        {
            Require.NotNull(benchmark, "benchmark");

            int iterations = WarmUp_(benchmark.Action);
            Duration duration = Time_(benchmark.Action, iterations);

            return new BenchmarkMetric(benchmark.CategoryName, benchmark.Name, duration, iterations);
        }

        // Benchmark for a pre-defined number of iterations.
        public BenchmarkMetric Run(Benchmark benchmark, int iterations)
        {
            Require.NotNull(benchmark, "benchmark");
            Contract.Requires(iterations > 0);

            // Warmup.
            benchmark.Action();

            Duration duration = Time_(benchmark.Action, iterations);

            return new BenchmarkMetric(benchmark.CategoryName, benchmark.Name, duration, iterations, fixedTime: false);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.GC.Collect",
            Justification = "The call to GC methods is done on purpose to ensure timing happens in a clean room.")]
        private Duration Time_(Action action, int iterations)
        {
            Contract.Requires(action != null);
            Contract.Ensures(Contract.Result<Duration>().Ticks > 0L);

            // Make sure we start with a clean room.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            _timer.Reset();

            for (int i = 0; i < iterations; i++)
            {
                action();
            }

            return _timer.ElapsedTime;
        }

        private int WarmUp_(Action action)
        {
            Contract.Requires(action != null);
            Contract.Ensures(Contract.Result<int>() > 0);

            double testTicks = (double)TestDuration.Ticks;
            double maxIterations = (double)(Int32.MaxValue - 1);
            int iterations = 100;
            while (iterations < Int32.MaxValue / 2)
            {
                Duration duration = Time_(action, iterations);

                if (duration >= WarmUpDuration)
                {
                    double scale = testTicks / duration.Ticks;
                    double scaledIterations = scale * iterations;
                    iterations = (int)Math.Min(scaledIterations, maxIterations);
                    Contract.Assume(iterations > 0, "Both 'scaledIterations' and 'maxIterations' should have been strictly positive.");
                    break;
                }

                iterations *= 2;
            }

            return iterations;
        }

#if CONTRACTS_FULL

        [ContractInvariantMethod]
        private void ObjectInvariants()
        {
            Contract.Invariant(_timer != null);
            Contract.Invariant(_testDuration.Ticks > 0L);
            Contract.Invariant(_warmUpDuration.Ticks > 0L);
        }

#endif
    }
}
