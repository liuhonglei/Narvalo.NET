﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// Provides overrides for a bunch of auto-generated (extension) methods (see Output.g.cs).
    /// </summary>
    public static partial class EnumerableOutputExtensions
    {
        // Custom version of CollectCore.
        internal static Output<IEnumerable<TSource>> CollectCore<TSource>(this IEnumerable<Output<TSource>> @this)
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TSource>>>() != null);

            var list = new List<TSource>();

            foreach (var m in @this)
            {
                // REVIEW: Is this the correct behaviour when m is null?
                if (m == null)
                {
                    continue;
                }

                if (!m.IsSuccess)
                {
                    return Output.Failure<IEnumerable<TSource>>(m.ToExceptionDispatchInfo());
                }

                list.Add(m.ToValue());
            }

            return Output.Success(list.AsEnumerable());
        }
    }
}