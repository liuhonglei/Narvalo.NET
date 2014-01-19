﻿namespace Narvalo.Benchmark.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Narvalo;
    using Narvalo.Linq;
    using Narvalo.Fx;

    class BenchComparativeFinder
    {
        const BindingFlags DefaultBindings
           = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        readonly BindingFlags _bindings;

        public BenchComparativeFinder() : this(DefaultBindings) { }

        public BenchComparativeFinder(BindingFlags bindings)
        {
            _bindings = bindings;
        }

        public IEnumerable<BenchComparative> FindComparatives(Type type)
        {
            Require.NotNull(type, "type");

            return Maybe.SelectAny(
                type.GetMethods(_bindings), 
                BenchComparativeFactory.MayCreate);
        }

        // FIXME: Theory.
        public IEnumerable<BenchComparative> FindComparatives<T>(Type type, T value)
        {
            Require.NotNull(type, "type");

            return Maybe.SelectAny(
                type.GetMethods(_bindings), 
                m => BenchComparativeFactory.MayCreate(m, value));
        }
    }
}
