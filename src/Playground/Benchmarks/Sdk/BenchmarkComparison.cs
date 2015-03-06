﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Playground.Benchmarks.Sdk
{
    using System.Collections.Generic;

    using Narvalo;
    using Narvalo.Benchmarking;

    public sealed class BenchmarkComparison
    {
        private readonly IEnumerable<Benchmark> _items;
        private readonly int _iterations;
        private readonly string _name;

        public BenchmarkComparison(
            string name,
            IEnumerable<Benchmark> items,
            int iterations)
        {
            Require.NotNullOrEmpty(name, "name");
            Require.NotNull(items, "items");

            _name = name;
            _items = items;
            _iterations = iterations;
        }

        public IEnumerable<Benchmark> Items { get { return _items; } }

        public int Iterations { get { return _iterations; } }

        public string Name { get { return _name; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
