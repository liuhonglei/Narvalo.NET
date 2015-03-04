﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Benchmarking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Narvalo;
    using Narvalo.Benchmarking.Internal;

    public sealed class BenchmarkFinder
    {
        private const BindingFlags DEFAULT_BINDINGS
           = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        private readonly BindingFlags _bindings;

        public BenchmarkFinder() : this(DEFAULT_BINDINGS) { }

        public BenchmarkFinder(BindingFlags bindings)
        {
            _bindings = bindings;
        }

        public IEnumerable<Benchmark> FindBenchmarks(Assembly assembly)
        {
            Require.NotNull(assembly, "assembly");

            return from type in assembly.GetExportedTypes()
                   from benchmark in FindBenchmarks(type)
                   select benchmark;
        }

        public IEnumerable<Benchmark> FindBenchmarks(Type type)
        {
            Require.NotNull(type, "type");

            MethodInfo[] methods = type.GetMethods(_bindings);

            foreach (var method in methods)
            {
                var attr = Attribute.GetCustomAttribute(method, typeof(BenchmarkAttribute), inherit: false);

                if (attr == null)
                {
                    continue;
                }

                var benchAttr = attr as BenchmarkAttribute;

                yield return new Benchmark(
                    benchAttr.DisplayName ?? method.Name,
                    ActionFactory.Create(method),
                    benchAttr.Iterations);
            }
        }

        //public IEnumerable<Benchmark> FindBenchmarks(Type type)
        //{
        //    Require.NotNull(type, "type");

        //    return type.GetMethods(_bindings).MapAny(MaySelectBenchmark_);
        //}

        //private static Maybe<Benchmark> MaySelectBenchmark_(MethodInfo method)
        //{
        //    return from attr in method.MayGetBenchmarkAttribute()
        //           select new Benchmark(
        //               attr.DisplayName ?? method.Name,
        //               ActionFactory.Create(method),
        //               attr.Iterations);
        //}
    }
}
