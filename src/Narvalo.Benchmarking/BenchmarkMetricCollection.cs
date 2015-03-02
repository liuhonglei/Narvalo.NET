﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Benchmarking
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;

    using Narvalo;

    public sealed class BenchmarkMetricCollection : ReadOnlyCollection<BenchmarkMetric>
    {
        private readonly string _name;

        public BenchmarkMetricCollection(
            string name,
            IList<BenchmarkMetric> metrics)
            : base(metrics)
        {
            Require.NotNullOrEmpty(name, "name");

            _name = name;
        }

        public string Name { get { return _name; } }

        public override string ToString()
        {
            return ToString(BenchmarkMetric.DefaultFormatter);
        }

        public string ToString(IBenchmarkMetricFormatter formatter)
        {
            Require.NotNull(formatter, "formatter");

            return formatter.Format(CultureInfo.CurrentCulture, this);
        }
    }
}
